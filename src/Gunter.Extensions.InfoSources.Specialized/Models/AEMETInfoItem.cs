using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Xml.Serialization;

namespace Gunter.Extensions.InfoSources.Specialized.Models
{
    [Serializable, XmlRoot("root")]
    public class AEMETInfoItem
    {
        [JsonProperty("origen")]
        public Origen Origen { get; set; }

        [JsonProperty("prediccion")]
        public Prediccion Prediccion { get; set; }

        //public static AEMETInfoItem FromJson(string json) => JsonConvert.DeserializeObject<AEMETInfoItem>(json, Converter.Settings);

        public AEMETInfoItem()
        {
            Origen = new();
            Prediccion = new();
        }

    }

    public partial class Origen
    {
        [JsonProperty("productor")]
        public string Productor { get; set; }

        [JsonProperty("web")]
        public string Web { get; set; }

        [JsonProperty("enlace")]
        public string Enlace { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("nota_legal")]
        public string NotaLegal { get; set; }
    }

    public partial class Prediccion
    {
        [JsonProperty("dia")]
        public Dia[] Dia { get; set; }
    }

    public partial class Dia
    {
        [JsonProperty("prob_precipitacion")]
        public ProbPrecipitacionUnion ProbPrecipitacion { get; set; }

        [JsonProperty("cota_nieve_prov")]
        public CotaNieveProvUnion CotaNieveProv { get; set; }

        [JsonProperty("estado_cielo")]
        public EstadoCieloUnion EstadoCielo { get; set; }

        [JsonProperty("viento")]
        public VientoUnion Viento { get; set; }

        [JsonProperty("racha_max")]
        public CotaNieveProvUnion RachaMax { get; set; }

        [JsonProperty("temperatura")]
        public HumedadRelativa Temperatura { get; set; }

        [JsonProperty("sens_termica")]
        public HumedadRelativa SensTermica { get; set; }

        [JsonProperty("humedad_relativa")]
        public HumedadRelativa HumedadRelativa { get; set; }

        [JsonProperty("uv_max", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? UvMax { get; set; }

        [JsonProperty("_fecha")]
        public DateTimeOffset Fecha { get; set; }
    }

    public partial class CotaNieveProvElement
    {
        [JsonProperty("_periodo")]
        public string Periodo { get; set; }
    }

    public partial class EstadoCieloElement
    {
        [JsonProperty("_periodo")]
        public string Periodo { get; set; }

        [JsonProperty("_descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("__text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }

    public partial class PurpleEstadoCielo
    {
        [JsonProperty("_descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("__text")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Text { get; set; }
    }

    public partial class HumedadRelativa
    {
        [JsonProperty("maxima")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Maxima { get; set; }

        [JsonProperty("minima")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Minima { get; set; }

        [JsonProperty("dato", NullValueHandling = NullValueHandling.Ignore)]
        public Dato[] Dato { get; set; }
    }

    public partial class Dato
    {
        [JsonProperty("_hora")]
        public string Hora { get; set; }

        [JsonProperty("__text")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Text { get; set; }
    }

    public partial class ProbPrecipitacionElement
    {
        [JsonProperty("_periodo")]
        public string Periodo { get; set; }

        [JsonProperty("__text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Text { get; set; }
    }

    public partial class VientoElement
    {
        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("velocidad")]
        public string Velocidad { get; set; }

        [JsonProperty("_periodo")]
        public string Periodo { get; set; }
    }

    public partial class PurpleViento
    {
        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("velocidad")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Velocidad { get; set; }
    }

    public partial struct CotaNieveProvUnion
    {
        public CotaNieveProvElement[] CotaNieveProvElementArray;
        public string String;

        public static implicit operator CotaNieveProvUnion(CotaNieveProvElement[] CotaNieveProvElementArray) => new CotaNieveProvUnion { CotaNieveProvElementArray = CotaNieveProvElementArray };
        public static implicit operator CotaNieveProvUnion(string String) => new CotaNieveProvUnion { String = String };
    }

    public partial struct EstadoCieloUnion
    {
        public EstadoCieloElement[] EstadoCieloElementArray;
        public PurpleEstadoCielo PurpleEstadoCielo;

        public static implicit operator EstadoCieloUnion(EstadoCieloElement[] EstadoCieloElementArray) => new EstadoCieloUnion { EstadoCieloElementArray = EstadoCieloElementArray };
        public static implicit operator EstadoCieloUnion(PurpleEstadoCielo PurpleEstadoCielo) => new EstadoCieloUnion { PurpleEstadoCielo = PurpleEstadoCielo };
    }

    public partial struct ProbPrecipitacionUnion
    {
        public long? Integer;
        public ProbPrecipitacionElement[] ProbPrecipitacionElementArray;

        public static implicit operator ProbPrecipitacionUnion(long Integer) => new ProbPrecipitacionUnion { Integer = Integer };
        public static implicit operator ProbPrecipitacionUnion(ProbPrecipitacionElement[] ProbPrecipitacionElementArray) => new ProbPrecipitacionUnion { ProbPrecipitacionElementArray = ProbPrecipitacionElementArray };
    }

    public partial struct VientoUnion
    {
        public PurpleViento PurpleViento;
        public VientoElement[] VientoElementArray;

        public static implicit operator VientoUnion(PurpleViento PurpleViento) => new VientoUnion { PurpleViento = PurpleViento };
        public static implicit operator VientoUnion(VientoElement[] VientoElementArray) => new VientoUnion { VientoElementArray = VientoElementArray };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CotaNieveProvUnionConverter.Singleton,
                EstadoCieloUnionConverter.Singleton,
                ProbPrecipitacionUnionConverter.Singleton,
                VientoUnionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (long.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class CotaNieveProvUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CotaNieveProvUnion) || t == typeof(CotaNieveProvUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new CotaNieveProvUnion { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<CotaNieveProvElement[]>(reader);
                    return new CotaNieveProvUnion { CotaNieveProvElementArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type CotaNieveProvUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (CotaNieveProvUnion)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.CotaNieveProvElementArray != null)
            {
                serializer.Serialize(writer, value.CotaNieveProvElementArray);
                return;
            }
            throw new Exception("Cannot marshal type CotaNieveProvUnion");
        }

        public static readonly CotaNieveProvUnionConverter Singleton = new CotaNieveProvUnionConverter();
    }

    internal class EstadoCieloUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(EstadoCieloUnion) || t == typeof(EstadoCieloUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PurpleEstadoCielo>(reader);
                    return new EstadoCieloUnion { PurpleEstadoCielo = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<EstadoCieloElement[]>(reader);
                    return new EstadoCieloUnion { EstadoCieloElementArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type EstadoCieloUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (EstadoCieloUnion)untypedValue;
            if (value.EstadoCieloElementArray != null)
            {
                serializer.Serialize(writer, value.EstadoCieloElementArray);
                return;
            }
            if (value.PurpleEstadoCielo != null)
            {
                serializer.Serialize(writer, value.PurpleEstadoCielo);
                return;
            }
            throw new Exception("Cannot marshal type EstadoCieloUnion");
        }

        public static readonly EstadoCieloUnionConverter Singleton = new EstadoCieloUnionConverter();
    }

    internal class ProbPrecipitacionUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ProbPrecipitacionUnion) || t == typeof(ProbPrecipitacionUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    long l;
                    if (long.TryParse(stringValue, out l))
                    {
                        return new ProbPrecipitacionUnion { Integer = l };
                    }
                    break;
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<ProbPrecipitacionElement[]>(reader);
                    return new ProbPrecipitacionUnion { ProbPrecipitacionElementArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type ProbPrecipitacionUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ProbPrecipitacionUnion)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            if (value.ProbPrecipitacionElementArray != null)
            {
                serializer.Serialize(writer, value.ProbPrecipitacionElementArray);
                return;
            }
            throw new Exception("Cannot marshal type ProbPrecipitacionUnion");
        }

        public static readonly ProbPrecipitacionUnionConverter Singleton = new ProbPrecipitacionUnionConverter();
    }


    internal class VientoUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(VientoUnion) || t == typeof(VientoUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PurpleViento>(reader);
                    return new VientoUnion { PurpleViento = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<VientoElement[]>(reader);
                    return new VientoUnion { VientoElementArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type VientoUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (VientoUnion)untypedValue;
            if (value.VientoElementArray != null)
            {
                serializer.Serialize(writer, value.VientoElementArray);
                return;
            }
            if (value.PurpleViento != null)
            {
                serializer.Serialize(writer, value.PurpleViento);
                return;
            }
            throw new Exception("Cannot marshal type VientoUnion");
        }

        public static readonly VientoUnionConverter Singleton = new VientoUnionConverter();
    }

}