using library.domain.Entities;
using library.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using library.api.Dtos.Publisher;
using library.api.Models;
using library.Infrastructure.Dtos;
using System;
using System.Linq;

namespace library.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet("GetPublishers")]
        public IActionResult Get()
        {
            var result = _publisherRepository.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetPublisherById/{id}")]
        public IActionResult Get(int id)
        {
            var result = _publisherRepository.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("AddPublisher")]
        public IActionResult Post([FromBody] PublisherDtoBase publisherDto)
        {
            var publisher = new Publisher
            {
                pub_name = publisherDto.Name,
                city = publisherDto.City,
                state = publisherDto.State,
                country = publisherDto.Country,
                CreationDate = DateTime.UtcNow
            };

            _publisherRepository.Save(publisher);

            return Ok();
        }

        [HttpPut("UpdatePublisher/{id}")]
        public IActionResult Put(int id, [FromBody] PublisherUpdateDto publisherDto)
        {
            var existingPublisher = _publisherRepository.GetById(id);

            if (existingPublisher == null)
            {
                return NotFound();
            }

            existingPublisher.pub_name = publisherDto.Name;
            existingPublisher.city = publisherDto.City;
            existingPublisher.state = publisherDto.State;
            existingPublisher.country = publisherDto.Country;

            _publisherRepository.Update(existingPublisher);

            return Ok();
        }

        [HttpDelete("DeletePublisher/{id}")]
        public IActionResult Delete(int id)
        {
            var existingPublisher = _publisherRepository.GetById(id);

            if (existingPublisher == null)
            {
                return NotFound();
            }

            _publisherRepository.Remove(existingPublisher);

            return Ok();
        }
    }
}
