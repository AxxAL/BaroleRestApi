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
        [HttpGet("{id}")]
        public ActionResult<BarotraumaRole> Get(string id)
        {
            Guid guid = Guid.Parse(id);
            BarotraumaRole? result = BarotraumaRoleService.Get(guid);
            if (result == null) return NotFound();
            return result;
        }

        [HttpGet("all")]
        public ActionResult<List<BarotraumaRole>> GetAll()
        {
            List<BarotraumaRole>? result = BarotraumaRoleService.GetAll();

            if (result == null || result.Count < 1)
            {
                return NoContent();
            }

            return result;
        }

        [HttpPost]
        public IActionResult Create(BarotraumaRole barotraumaRole)
        {
            BarotraumaRole? result = BarotraumaRoleService.Add(barotraumaRole);
            
            if (result == null)
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, BarotraumaRole barotraumaRole)
        {
            Guid guid = Guid.Parse(id);
            
            if (guid != barotraumaRole.Id)
            {
                return BadRequest();
            }

            BarotraumaRole? result = BarotraumaRoleService.Put(guid, barotraumaRole);

            if (result == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Guid guid = Guid.Parse(id);
            BarotraumaRole? result = BarotraumaRoleService.Remove(guid);
            
            if (result == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}