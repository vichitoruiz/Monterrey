using SSEL.MONTERREY.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Infrastructure.Repositories;

public interface IUnitOfWork : IDisposable
{
    SSELContext Context { get; }
    Task<int> SaveAsync();
}
