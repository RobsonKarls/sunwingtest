using System;
using System.Threading.Tasks;
using ContactManager.Domain.SeedOfWork;

namespace ContactManager.Domain.Model
{
    public interface ICostumerRepository : IRepository
    {
        Costumer Add( Costumer costumer);
        Costumer Update(Costumer costumer);
        Task<Costumer> FindAsync(Int64 id);
        void Delete(Costumer costumer);
    }
}