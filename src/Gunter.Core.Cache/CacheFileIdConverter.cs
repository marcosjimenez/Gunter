using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gunter.Core.Infrastructure.Cache
{
    internal class CacheFileIdConverter
    {
    }

    //internal sealed class CacheFileIdConverter : JsonConverter<string>
    //{
    //    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        Debug.Assert(reader.TokenType == JsonTokenType.String);
    //        return reader.GetString();
    //    }

    //    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    //        => writer.WriteStringValue(value);

    //    public override string ReadFromPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        Debug.Assert(reader.TokenType == JsonTokenType.PropertyName);
    //        return reader.GetString();
    //    }

    //    protected override void WriteToPropertyName(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    //        => writer.WritePropertyName(value);
    //}

}
