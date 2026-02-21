using System.Text.Json.Serialization;
using FinanceManager.Domain.Users;

namespace FinanceManager.Application.Shared.Requests;

public abstract record CreateCommand<TResponse> : ICommand<TResponse>
{
    [JsonIgnore]
    public UserId CreatedBy { get; set; }
}