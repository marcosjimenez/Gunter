using CoreHtmlToImage;
using Gunter.Core.Contracts;
using Gunter.Core.Visualizations;
using Gunter.Extensions.InfoSources.Specialized;

namespace Gunter.Extensions.Visualizations.Specialized
{
	public class OpenWeatherVisualizationHandler : VisualizationHandlerBase<OpenWeatherInfoSource>, IGunterVisualizationHandler
	{
		public new string Name { get; set; } = "Visor de OpenWeather";

		private OpenWeatherInfoSource objectToDraw;

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

		public OpenWeatherVisualizationHandler(string id)
		{
			Id = id;
		}

		public OpenWeatherVisualizationHandler(OpenWeatherInfoSource infoSource)
		{
			objectToDraw = infoSource;
		}

		public string GetHTML()
		{
			if (objectToDraw?.LastItem is null)
				return string.Empty;

			var prediccion = objectToDraw.LastItem;
			if (prediccion is null)
				return String.Empty;

			var html = HTML_Template
			.ReplaceVariable("LOCALIDAD", objectToDraw.GetMandatoryParam("city")?.ToString() ?? string.Empty)
			.ReplaceVariable("FECHAACTUALIZACION", string.Empty)
			.ReplaceVariable("DIA1", DateTime.Now.ToLongDateString())
			.ReplaceVariable("PROB_PRECIPITACION1", prediccion.RainProbability.ToString() ?? "0")
			.ReplaceVariable("MINIMA_TEMP", prediccion.MinTemp.ToString())
			.ReplaceVariable("MAXIMA_TEMP", prediccion.MaxTemp.ToString())
			.ReplaceVariable($"HORA_TEMPERATURA1", DateTime.Now.TimeOfDay.Hours.ToString("00"))
			.ReplaceVariable($"TEMPERATURA1", prediccion.Temperature.ToString());

			return html;
		}

		public byte[] GetImage()
		{
			var converter = new HtmlConverter();
			var bytes = converter.FromHtmlString(GetHTML());

			return bytes;
		}
	}
}
