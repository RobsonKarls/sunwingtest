using System;
using System.Threading.Tasks;
using ContactManager.Domain.Model;
using ContactManager.Domain.SeedOfWork;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.API.Infrastructure.Repositories
{
    public class CostumerRepository : ICostumerRepository
    {
        private readonly ContactManagerContext _context;
        
        public IUnitOfWork UnitOfWork
        {
            get => _context;
        }

        public CostumerRepository(ContactManagerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public Costumer Add(Costumer costumer)
        {
            if (costumer.IsTransient())
                return _context.Costumers.Add(costumer).Entity;

            return costumer;
        }

        public Costumer Update(Costumer costumer)
        {
            return _context.Costumers.Update(costumer).Entity;
        }

        public async Task<Costumer> FindAsync(Int64 id)
        {
            return await _context.Costumers.SingleOrDefaultAsync(x => x.Id == id);
        }
        
        public void Delete(Costumer costumer)
        {
            _context.Costumers.Remove(costumer);
        }
    }
}