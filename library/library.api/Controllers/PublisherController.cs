using library.domain.Entities;
using library.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(publishers);
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
            return Ok(publisher);
        }

        // POST: api/Publisher
        [HttpPost]
        public IActionResult Post([FromBody] Publisher publisher)
        {
            _publisherRepository.Save(publisher);
            return Ok();
        }

        // PUT: api/Publisher/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Publisher publisher)
        {
            var existingPublisher = _publisherRepository.GetById(id);
            if (existingPublisher == null)
            {
                return NotFound();
            }
            publisher.pub_id = id;
            _publisherRepository.Update(publisher);
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
