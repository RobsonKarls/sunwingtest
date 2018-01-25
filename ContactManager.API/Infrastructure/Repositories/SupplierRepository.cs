using System;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Domain.Model;
using ContactManager.Domain.SeedOfWork;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.API.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ContactManagerContext _context;
        
        public IUnitOfWork UnitOfWork
        {
            get => _context;
        }

        public SupplierRepository(ContactManagerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public Supplier Add(Supplier supplier)
        {
            if (supplier.IsTransient())
                return _context.Suppliers.Add(supplier).Entity;

            return supplier;
        }

        public Supplier Update(Supplier supplier)
        {
            return _context.Suppliers.Update(supplier).Entity;
        }

        public async Task<Supplier> FindAsync(Int64 id)
        {
            return await _context.Suppliers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Delete(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
        }
    }
}