using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Domain.SeedOfWork
{
    public interface IUnitOfWork : IDisposable
    {        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}