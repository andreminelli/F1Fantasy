using F1Fantasy.Simulation.Domain;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace F1Fantasy.Simulation.Infrastructure.Json;

public sealed class DriverIdJsonConverter : JsonConverter<DriverId>
{
    public override DriverId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DriverId.Parse(reader.GetString()!, CultureInfo.CurrentCulture);

    public override void Write(Utf8JsonWriter writer, DriverId value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.Value);
}