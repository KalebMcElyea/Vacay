using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FerryController : ControllerBase
    {
        private readonly FerryService _Service;

        public FerryController(FerryService Service)
        {
            _Service = Service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ferry>> GetAll()
        {
            try
            {
                return Ok(_Service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}