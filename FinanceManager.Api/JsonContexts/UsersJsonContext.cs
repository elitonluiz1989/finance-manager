using System.Text.Json.Serialization;
using FinanceManager.Domain.Users;

namespace FinanceManager.Api.JsonContexts;

[JsonSerializable(typeof(User))]
internal partial class UsersJsonContext : JsonSerializerContext { }