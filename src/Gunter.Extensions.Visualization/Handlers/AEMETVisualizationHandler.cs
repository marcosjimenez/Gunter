using CoreHtmlToImage;
using Gunter.Core.Contracts;
using Gunter.Extensions.InfoSources.Specialized;
using Gunter.Extensions.InfoSources.Specialized.Models;
using System.Text;

namespace Gunter.Extensions.Visualization.Handlers
{
	public class AEMETVisualizationHandler : VisualizationHandlerBase<AEMETInfoSource>, IGunterVisualizationHandler
    {
        private AEMETInfoSource objectToDraw;

		public new string Name { get; set; } = "Visor de AEMET (Agencia Estatal de Meteorología)";

        protected string HTML_Template = @"
<!DOCTYPE html>
<html>
<body>

<div>
	<table cellspacing=""1"">
	 <thead>
	 	<tr>
			<th title=""@@DIA1"" colspan=""12"">@@DIA1</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<th colspan=""12"" title=""El tiempo en @@LOCALIDAD"" ><b>El tiempo en @@LOCALIDAD</b></th>
		</tr>
		<tr>
			<th colspan=""12"">@@FECHAACTUALIZACION</th>
		</tr>
		<tr>				
			<th>
				<div>
					<img src=""https://www.aemet.es/imagenes/png/estado_cielo/11_g.png"" title=""@@ESTADO_CIELO"">
				</div>
				<div title=""Temperatura a las&nbsp; @@HORA_TEMPERATURA1&nbsp;h:&nbsp; @@TEMPERATURA1°C"">@@TEMPERATURA1°(@@HORA_TEMPERATURA1:00)</div>
				<div title=""Temperatura a las&nbsp; @@HORA_TEMPERATURA2&nbsp;h:&nbsp; @@TEMPERATURA2°C"">@@TEMPERATURA2°(@@HORA_TEMPERATURA2:00)</div>
				<div title=""Temperatura a las&nbsp; @@HORA_TEMPERATURA3&nbsp;h:&nbsp; @@TEMPERATURA3°C"">@@TEMPERATURA3°(@@HORA_TEMPERATURA3:00)</div>
				<div title=""Temperatura a las&nbsp; @@HORA_TEMPERATURA4&nbsp;h:&nbsp; @@TEMPERATURA4°C"">@@TEMPERATURA4°(@@HORA_TEMPERATURA4:00)</div>
			</th> 						
		</tr>
		<tr>
			<td colspan=""8"">
				<b>Probabilidad de precipitación</b>
			</td>
			<td colspan=""4"">
				@@PROB_PRECIPITACION1%
			</td>
		</tr>
		<tr>
			<td colspan=""8"">
				<b>Temperatura mínima y máxima (°C)</b>
			</td>
			<td colspan=""4"">
				<span>@@MINIMA_TEMPº</span> / <span>@@MAXIMA_TEMPº</span>
			</td>
		</tr>
	 </tbody>
	</table>
</div>

</body>
</html>
";
		public AEMETVisualizationHandler()
		{

		}

        public AEMETVisualizationHandler(string id)
		{
			Id = id;
		}

		public AEMETVisualizationHandler(AEMETInfoSource infoSource)
        {
            objectToDraw = infoSource;
        }

		public string GetHTML()
		{
			var data = objectToDraw?.LastItem;
			if (data is null)
				return String.Empty;
            var prediccion = GetPrediction(data);

			var html = HTML_Template
			.ReplaceVariable("LOCALIDAD", $"{data.nombre} ({data.provincia})")
			.ReplaceVariable("FECHAACTUALIZACION", data.elaborado.ToLongDateString())
			.ReplaceVariable("DIA1", prediccion.fecha.ToShortDateString())
			.ReplaceVariable("PROB_PRECIPITACION1", prediccion.prob_precipitacion[0].Value ?? "0")
            .ReplaceVariable("MINIMA_TEMP", prediccion.temperatura.minima.ToString())
            .ReplaceVariable("MAXIMA_TEMP", prediccion.temperatura.maxima.ToString());

			var counter = 1;
			foreach (var item in prediccion.temperatura.dato.OrderBy(x => x.hora))
			{
				html = html
					.ReplaceVariable($"HORA_TEMPERATURA{counter}", item.hora.ToString())
					.ReplaceVariable( $"TEMPERATURA{counter}", item.Value.ToString());
				counter++;
            }

			return html;
		}

        public byte[] GetImage()
        {
            var converter = new HtmlConverter();
			var bytes = converter.FromHtmlString(GetHTML());

            return bytes; 
        }

		private rootDia GetPrediction(AEMETResponseModel model)
			=> model.prediccion
			.Where(x => x.fecha == DateTime.Now.Date).Single();


    }

	static class StringManipulation
	{
        public static string ReplaceVariable(this string mainString, string variable, string value)
            => mainString.Replace($"@@{variable}", value);
    }
}
