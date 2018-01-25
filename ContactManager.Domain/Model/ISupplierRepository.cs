using System;
using System.Threading.Tasks;
using ContactManager.Domain.SeedOfWork;

namespace ContactManager.Domain.Model
{
    public interface ISupplierRepository : IRepository
    {
        Supplier Add( Supplier supplier);
        Supplier Update(Supplier supplier);
        Task<Supplier> FindAsync(Int64 id);
        void Delete(Supplier  supplier);

    }
}