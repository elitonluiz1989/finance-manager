using System.Text.Json;
using System.Text.Json.Serialization;
using FinanceManager.Domain.Accounts;

namespace FinanceManager.Application.Accounts.Shared;

public class AccountIdJsonConverter : JsonConverter<AccountId>
{
    public override AccountId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        (AccountId)reader.GetGuid();

    public override void Write(Utf8JsonWriter writer, AccountId value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString());
}