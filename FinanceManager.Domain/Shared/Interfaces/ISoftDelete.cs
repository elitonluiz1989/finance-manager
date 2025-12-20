using FinanceManager.Domain.Users;

namespace FinanceManager.Domain.Shared.Interfaces;

public interface ISoftDelete
{
    DateTime? DeletedAt { get; set; }
    UserId? DeletedBy { get; set; }

    public void SetDeletedAt(UserId deletedBy)
    {
        DeletedAt = DateTime.UtcNow;
        DeletedBy = deletedBy;
    }
}