using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManager.API.ViewModel;

namespace ContactManager.API.Infrastructure.Queries
{
    public interface IContactQueries
    {
        Task<IEnumerable<ContactViewModel>> GetContactsAsync();
    }
}