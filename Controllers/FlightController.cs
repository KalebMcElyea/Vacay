using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase

    {
        private readonly FlightService _fService;

        public FlightController(FlightService fService)
        {
            _fService = fService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Flight>> GetAll()
        {
            try
            {
                return Ok(_fService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")] // GETBYID
        public ActionResult<Flight> Get(int id)
        {
            try
            {
                return Ok(_fService.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Flight> Create([FromBody] Flight newFlight)
        {
            try
            {
                return Ok(_fService.Create(newFlight));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] //EDIT
        public ActionResult<Flight> Edit([FromBody] Flight updated, int id)
        {
            try
            {
                updated.Id = id;
                return Ok(_fService.Edit(updated));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")] // DELETE
        public ActionResult<Flight> Delete(int id)
        {
            try
            {
                return Ok(_fService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}