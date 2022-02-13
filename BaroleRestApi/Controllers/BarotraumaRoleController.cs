using System;
using System.Collections.Generic;
using BaroleRestApi.Models;
using BaroleRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaroleRestApi.Controllers
{
    [ApiController]
    [Route("/api/v1/role")]
    public class BarotraumaRoleController : ControllerBase
    {
        private readonly BarotraumaRoleService service;

        public BarotraumaRoleController(BarotraumaRoleService service)
        {
            this.service = service;
        }
        
        
        [HttpGet("{id}")]
        public ActionResult<BarotraumaRole> Get(string id)
        {
            Guid guid = Guid.Parse(id);
            BarotraumaRole? result = service.Get(guid);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }

        [HttpGet("all")]
        public ActionResult<List<BarotraumaRole>> GetAll()
        {
            List<BarotraumaRole>? result = service.GetAll();

            if (result == null || result.Count < 1)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<BarotraumaRole> Create(BarotraumaRole barotraumaRole)
        {
            BarotraumaRole? result = service.Add(barotraumaRole);
            
            if (result == null)
            {
                return BadRequest();
            }
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<BarotraumaRole> Update(string id, BarotraumaRole barotraumaRole)
        {
            Guid guid = Guid.Parse(id);
            
            if (guid != barotraumaRole.Id)
            {
                return BadRequest();
            }

            BarotraumaRole? result = service.Put(guid, barotraumaRole);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<BarotraumaRole> Delete(string id)
        {
            Guid guid = Guid.Parse(id);
            BarotraumaRole? result = service.Remove(guid);
            
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}