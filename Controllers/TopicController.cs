using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_test_api.models;

namespace web_test_api.Controllers
{
    [ApiController]
    [Route("topics")]
    public class TopicController : ControllerBase
    {
        private List<Topics> topics = new List<Topics>()
        {
            new Topics() { Id = 1, Content = "Biology", Title = "Dissecting a Cockroach", Member_id = 1 },
            new Topics() { Id = 2, Content = "Physics", Title = "Quantum Physics on a Margarine", Member_id = 2 },
            new Topics() { Id = 3, Content = "Math", Title = "Matrix", Member_id = 2 },
        };
        private readonly ILogger<TopicController> _logger;

        public TopicController(ILogger<TopicController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(topics);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(topics.First(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult NewData(Topics newuser)
        {
            topics.Add(newuser);
            return CreatedAtAction(nameof(GetById), newuser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletedData(int id)
        {
            var y = topics.First(x => x.Id == id);
            topics.Remove(y);
            return Ok(new { status = "Success", message = $"The topic {id} has been deleted", data = topics });
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateData(int id, [FromBody] JsonPatchDocument<Topics> topicPatch)
        {
            Topics topicdata = topics.First(x => x.Id == id);
            topicPatch.ApplyTo(topicdata);
            return Ok(topicdata);
        }
    }
}
