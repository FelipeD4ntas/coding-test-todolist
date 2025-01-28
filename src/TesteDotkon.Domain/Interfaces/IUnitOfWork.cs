using TesteDotkon.Core.Domain.Services;

namespace TesteDotkon.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<CommitResult> CommitAsync();
    CommitResult Commit();
}
