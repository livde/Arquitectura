using library.domain.Entities;
using library.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using library.api.Dtos.Publisher;
using library.api.Models;
using library.Infrastructure.Dtos;
using System;
using System.Linq;
using library.application.Contracts;
using library.api.Dtos.PubInfo;


namespace library.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PubInfoController : ControllerBase
    {
        private readonly IPubInfoService _pubInfoService;
        private readonly ILogger<PubInfoController> _logger;

        public PubInfoController(IPubInfoService pubInfoService, ILogger<PubInfoController> logger)
        {
            _pubInfoService = pubInfoService;
            _logger = logger;
        }

        [HttpGet("{pubId}")]
        public IActionResult Get(int pubId)
        {
            var result = _pubInfoService.Get(pubId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(PubInfoAddDto pubInfoAddDto)
        {
            var result = _pubInfoService.Save(pubInfoAddDto);
            if (result.Success)
            {
                return CreatedAtAction(nameof(Get), new { pubId = result.Data.PubId }, result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut("{pubId}")]
        public IActionResult Update(int pubId, PubInfoUpdateDto pubInfoUpdateDto)
        {
            pubInfoUpdateDto.PubId = pubId;
            var result = _pubInfoService.Update(pubInfoUpdateDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("{pubId}")]
        public IActionResult Remove(int pubId)
        {
            var result = _pubInfoService.Remove(new PubInfoRemoveDto { PubId = pubId });
            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
