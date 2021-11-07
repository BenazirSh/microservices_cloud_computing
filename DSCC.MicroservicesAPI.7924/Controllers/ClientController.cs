﻿using DSCC.MicroservicesAPI._7924.DTO;
using DSCC.MicroservicesAPI._7924.Model;
using DSCC.MicroservicesAPI._7924.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.MicroservicesAPI._7924.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IRepo<Client> _clientRepo;

        public ClientController(IRepo<Client> clientRepo)
        {
            _clientRepo = clientRepo;

        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> GetClients()
        {

            var clients = await _clientRepo.GetAll();
            return Ok(clients.Select(b => new ClientDTO
            {
                Id = (int)b.Id,
                FirstName = b.FirstName,
                LastName = b.LastName,
                PhoneNumber = b.PhoneNumber,
                PlantID = b.PlantID

            }));
        } 

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _clientRepo.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }



            try
            {
                await _clientRepo.UpdateAsync(client);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Client
        //post api
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientRepo.UpdateAsync(client);

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var plant = await _clientRepo.GetById(id);
            if (plant == null)
            {
                return NotFound();
            }

            await _clientRepo.DeleteAsync(id);

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _clientRepo.Exists(id);
        }
    }
}
