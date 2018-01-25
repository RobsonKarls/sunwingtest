using System;
using System.Net;
using System.Threading.Tasks;
using ContactManager.API.Infrastructure.Factory;
using ContactManager.API.Infrastructure.Repositories;
using ContactManager.API.ViewModel;
using ContactManager.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class SuppliersController : Controller
    {
        private readonly ISupplierRepository _supplierRespository;
        
        public SuppliersController(ISupplierRepository supplierRespository)
        {
            _supplierRespository = supplierRespository ?? throw new ArgumentNullException(nameof(supplierRespository));
        }
        
        //POST api/v1/[controller]/
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] ContactViewModel model)
        {
            Supplier supplier = ContactFactory.CreatePerson(model) as Supplier;

            supplier = _supplierRespository.Add(supplier);

            await _supplierRespository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new {id = supplier.Id}, null);
        }
        
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Costumer),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var supplier = await _supplierRespository.FindAsync(id);
            
            if (supplier != null)
            {
                return Ok(supplier);
            }

            return NotFound();
        }
        
        //PUT api/v1/[controller]/
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateProduct([FromBody]Supplier supplierToUpdate)
        {
            var supplier = await _supplierRespository.FindAsync(supplierToUpdate.Id);

            if (supplier == null)
            {
                return NotFound(new { Message = $"Item with id {supplier.Id} not found." });
            }

            supplier = _supplierRespository.Update(supplier);
            
            await _supplierRespository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new { id = supplier.Id }, null);
        }
        
        //DELETE api/v1/[controller]/id
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _supplierRespository.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _supplierRespository.Delete(supplier);

            await _supplierRespository.UnitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}