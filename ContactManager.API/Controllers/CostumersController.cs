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
    public class CostumersController : Controller
    {
        private readonly ICostumerRepository _costumerRepository;

        public CostumersController(ICostumerRepository costumerRepository)
        {
            _costumerRepository = costumerRepository ?? throw new ArgumentNullException(nameof(costumerRepository));
        }
        
        //POST api/v1/[controller]/
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] ContactViewModel model)
        {
            Costumer costumer = ContactFactory.CreatePerson(model) as Costumer;

            costumer = _costumerRepository.Add(costumer);

            await _costumerRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new {id = costumer.Id}, null);
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

            var costumer = await _costumerRepository.FindAsync(id);
            
            if (costumer != null)
            {
                return Ok(costumer);
            }

            return NotFound();
        }
        
        //PUT api/v1/[controller]/
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateProduct([FromBody]Costumer costumerToUpdate)
        {
            var costumer = await _costumerRepository.FindAsync(costumerToUpdate.Id);

            if (costumer == null)
            {
                return NotFound(new { Message = $"Item with id {costumer.Id} not found." });
            }

            costumer = _costumerRepository.Update(costumer);
            
            await _costumerRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new { id = costumer.Id }, null);
        }
        
        //DELETE api/v1/[controller]/id
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var costumer = await _costumerRepository.FindAsync(id);

            if (costumer == null)
            {
                return NotFound();
            }

            _costumerRepository.Delete(costumer);

            await _costumerRepository.UnitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}