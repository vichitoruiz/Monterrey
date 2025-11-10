using SSEL.MONTERREY.Infrastructure.Data;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public SSELContext Context { get; }

    public UnitOfWork(SSELContext context) => Context = context;

    public Task<int> SaveAsync() => Context.SaveChangesAsync();

    public void Dispose() => Context.Dispose();
}
