using System.Text.Json;
using System.Text.Json.Serialization;
using FinanceManager.Domain.Users;

namespace FinanceManager.Infrastructure.Converters.Users;

public class UserIdJsonConverter : JsonConverter<UserId>
{
    public override UserId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        (UserId)reader.GetGuid();

    public override void Write(Utf8JsonWriter writer, UserId value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString());
}