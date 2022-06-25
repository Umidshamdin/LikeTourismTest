﻿using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Reservation;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;
        public ReservationController(IReservationService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetAll/{id}")]
        public async Task<IActionResult> GetAll([FromRoute] int id)
        {
            return Ok(await _service.GetAllAsync(id));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] ReservationCreateDto slider)
        {
            await _service.InsertAsync(slider);
            return Ok();
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }
    }
}
