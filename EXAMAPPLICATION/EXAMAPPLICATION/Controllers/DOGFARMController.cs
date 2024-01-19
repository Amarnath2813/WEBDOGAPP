using EXAMAPPLICATION.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace EXAMAPPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DOGFARMController : ControllerBase
    {
        private readonly IDOGREPOSITRY _repository;

        public DOGFARMController(IDOGREPOSITRY repository)
        {
            _repository = repository;

        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<DOG>?>> GetDOGs()
        {
            if (await _repository.GetAllDOG() == null)
            {
                return NotFound();
            }

            return await _repository.GetAllDOG();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DOG>> GetById_ActionResultOfT(int id)
        {
            var DOG = await _repository.GetDOG(id);
            return DOG == null ? NotFound() : DOG;
        }

        // PUT: api/DOGs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDOG(int id, DOG DOG)
        {
            if (id != DOG.Id)
            {
                return BadRequest();
            }


            try
            {
                await _repository.Update(id, DOG);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.GetDOG(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DOGs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DOG>> PostDOG(DOG DOG)
        {

            await _repository.Add(DOG);


            return CreatedAtAction("PostDOG", new { id = DOG.Id }, DOG);
        }



        // DELETE: api/DOGs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDOG(int id)
        {
            if (_repository.GetAllDOG() == null)
            {
                return NotFound();
            }
            var DOG = await _repository.Delete(id);
            if (DOG == null)
            {
                return NotFound();
            }

            //await _repository.Delete(DOG.Id);


            return NoContent();
        }



    }

}

