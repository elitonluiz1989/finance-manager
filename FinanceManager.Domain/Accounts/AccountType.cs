using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.Accounts;

public enum AccountType
{
    [Display(ResourceType = typeof(AccountsResources), Name = nameof(AccountsResources.Personal))]
    Personal,
    [Display(ResourceType = typeof(AccountsResources), Name = nameof(AccountsResources.Savings))]
    Savings,
    [Display(ResourceType = typeof(AccountsResources), Name = nameof(AccountsResources.Custody))]
    Custody
}