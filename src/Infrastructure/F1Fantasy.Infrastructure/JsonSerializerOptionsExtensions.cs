using F1Fantasy.Infrastructure.Json;
using System.Text.Json;

namespace F1Fantasy.Simulation.Infrastructure;

public static class JsonSerializerOptionsExtensions
{
    public static void AddCustomConverters(this JsonSerializerOptions options)
    {
        options.Converters.Add(new TeamIdJsonConverter());
    }
}
