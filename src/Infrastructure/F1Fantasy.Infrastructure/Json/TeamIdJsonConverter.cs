using F1Fantasy.Domain.Simulation;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace F1Fantasy.Infrastructure.Json;

public class TeamIdJsonConverter : JsonConverter<TeamId>
{
    public override TeamId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => TeamId.Parse(reader.GetString()!, CultureInfo.CurrentCulture);

    public override void Write(Utf8JsonWriter writer, TeamId value, JsonSerializerOptions options)
        =>writer.WriteStringValue(value.Value);
}