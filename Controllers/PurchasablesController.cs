using System;
using System.Collections.Generic;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Vacay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchasablesController : ControllerBase
    {

        private readonly VacationService _vService;
        private readonly FlightService _fService;

        public PurchasablesController(VacationService vService, FlightService fService)
        {
            _vService = vService;
            _fService = fService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IVactionPurchasable>> GetAllVacations()
        {
            try
            {
                return Ok(_vService.getAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


    }
}