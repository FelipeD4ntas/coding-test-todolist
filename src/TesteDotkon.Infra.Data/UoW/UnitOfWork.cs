using TesteDotkon.Core.Domain.Services;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.IoC.interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using TesteDotkon.Infra.Data.Context;

namespace TesteDotkon.Infra.Data.UoW;

public class UnitOfWork(TesteDotkonContext context) : Notifiable, IUnitOfWork, IInjectScoped
{
    public async Task<CommitResult> CommitAsync()
    {
        try
        {
            await context.SaveChangesAsync();
            return new CommitResult(true, this);
        }
        catch (Exception ex)
        {
            AddNotification("Database", ex.InnerException == null ? ex.Message : $"{ex.Message} - {ex.InnerException.Message}");
            return new CommitResult(false, this);
        }
    }

    public CommitResult Commit()
    {
        try
        {
            context.SaveChanges();
            return new CommitResult(true, this);
        }
        catch (Exception ex)
        {
            AddNotification("Database", ex.InnerException == null ? ex.Message : $"{ex.Message} - {ex.InnerException.Message}");
            return new CommitResult(false, this);
        }
    }
}