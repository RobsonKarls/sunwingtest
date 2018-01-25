using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ContactManager.API.Infrastructure;
using ContactManager.API.Infrastructure.Factory;
using ContactManager.API.Infrastructure.Queries;
using ContactManager.API.Infrastructure.Repositories;
using ContactManager.API.ViewModel;
using ContactManager.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactQueries _queries;

        public ContactsController(IContactQueries queries)
        {
            _queries = queries;
        }
        
        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(PaginatedContactViewModel<ContactViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Items([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var contacts = await _queries.GetContactsAsync();

            var totalItems = contacts.Count();

            var itemsOnPage = contacts
                .OrderBy(c => c.FirstName)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedContactViewModel<ContactViewModel>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }
    }
}