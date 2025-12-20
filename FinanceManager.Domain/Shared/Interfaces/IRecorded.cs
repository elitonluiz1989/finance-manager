using FinanceManager.Domain.Users;

namespace FinanceManager.Domain.Shared.Interfaces;

public interface IRecorded
{
    DateTime CreatedAt { get; set; }
    UserId CreatedBy { get; set; }
    DateTime? UpdatedAt { get; set; }
    UserId? UpdatedBy { get; set; }
}