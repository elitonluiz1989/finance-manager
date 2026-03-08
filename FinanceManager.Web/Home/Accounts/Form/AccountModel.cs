using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Accounts.Create;
using FinanceManager.Domain.Accounts;
using FinanceManager.Domain.Users;

namespace FinanceManager.Web.Home.Accounts.Form;

public class AccountModel
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public AccountType? Type { get; set; }
    [Required]
    public UserId? UserId { get; set; }

    public static explicit operator CreateAccountCommand(AccountModel model)
    {
        return new CreateAccountCommand
        {
            Name = model.Name ?? string.Empty,
            Type = model.Type ?? default(AccountType),
            UserId = model.UserId ?? default(UserId),
        };
    } 
}