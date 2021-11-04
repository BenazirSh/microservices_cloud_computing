using DSCC.MicroservicesAPI._7924.DTO;
using DSCC.MicroservicesAPI._7924.Model;
using DSCC.MicroservicesAPI._7924.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace DSCC.MicroservicesAPI._7924.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly IRepo<Plant> _plantRepo;



        public PlantController(IRepo<Plant> plantRepo)
        {
            _plantRepo = plantRepo;


        }
        // GET: api/Plant
        [HttpGet]
        public async Task<ActionResult<List<Plant>>> GetPlants()
        {
            var plants = await _plantRepo.GetAll();
            return Ok(plants.Select(b => new PlantDTO
            {
                Id = b.Id,
                PlantName = b.PlantName
            }));



        }

        // GET: api/Plant/5
        [HttpGet("{id}")]
        [ResponseType(typeof(PlantDTO))]
        public async Task<ActionResult<PlantDTO>> GetPlant(int id)
        {


            var plant = await _plantRepo.GetById(id);


            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }



        // PUT: api/Plant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlant([FromRoute] int id, [FromBody] Plant plant)
        {
            if (id != plant.Id)
            {
                return BadRequest();
            }


            try
            {
                await _plantRepo.UpdateAsync(plant);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
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

        // POST: api/Plant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _plantRepo.CreateAsync(plant);

            return CreatedAtAction("GetPlant", new { id = plant.Id }, plant);
        }

        // DELETE: api/Plant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var plant = await _plantRepo.GetById(id);
            if (plant == null)
            {
                return NotFound();
            }
            try
            {
                await _plantRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Client is binded to this plant");
            }


            return NoContent();
        }

        private bool PlantExists(int id)
        {
            return _plantRepo.Exists(id);
        }
    }
}
