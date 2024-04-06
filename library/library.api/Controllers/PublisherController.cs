using library.domain.Entities;
using library.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using library.api.Dtos.Publisher;
using library.api.Models;
using library.Infrastructure.Dtos;

namespace library.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController(IPublisherRepository publisherRepository) : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository = publisherRepository;

        // GET: api/Publisher
        [HttpGet]
        public IActionResult Get()
        {
            var publishers = _publisherRepository.GetAll();

            var publisherGetModels = publishers.Select(p => new Models.PublisherGetModel
            {
                PublisherId = p.pub_id,
                Name = p.pub_name,
                city = p.city,
                state = p.state,
                country = p.country,
                CreationDate = p.CreationDate
            });

            return Ok(publisherGetModels);
        }

        // GET: api/Publisher/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = _publisherRepository.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            var publisherGetModel = new PublisherGetModel
            {
                PublisherId = publisher.pub_id,
                Name = publisher.pub_name,
                city = publisher.city,
                state = publisher.state,
                country = publisher.country,
                CreationDate = publisher.CreationDate
            };

            return Ok(publisherGetModel);
        }

        // POST: api/Publisher
        [HttpPost]
        public IActionResult Post([FromBody] PublisherDtoBase publisherDto)
        {
            var publisher = new Publisher
            {
                pub_name = publisherDto.Name,
                city = publisherDto.City,
                state = publisherDto.State,
                country = publisherDto.Country
            };

            _publisherRepository.Save(publisher);
            return Ok();
        }

        // PUT: api/Publisher/5
        [HttpPut("{id}")]
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

        // DELETE: api/Publisher/5
        [HttpDelete("{id}")]
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
