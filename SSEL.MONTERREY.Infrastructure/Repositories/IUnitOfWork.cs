using SSEL.MONTERREY.Infrastructure.Data;
using System.Threading.Tasks;
using System;

namespace SSEL.MONTERREY.Infrastructure.Repositories;

public interface IUnitOfWork : IDisposable
{
    SSELContext Context { get; }
    Task<int> SaveAsync();
}
