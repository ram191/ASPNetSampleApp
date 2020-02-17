using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return Ok(topics);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletedData(int id)
        {
            var y = topics.First(x => x.Id == id);
            topics.Remove(y);
            return Ok(new { status = "Success", message = $"The topic {id} has been deleted", data = topics });
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateData(int id, Topics data)
        {
            var y = topics.First(x => x.Id == id);
            y.Id = y.Id;
            y.Content = data.Content == null ? y.Content : data.Content;
            y.Title = data.Title == null ? y.Title : data.Title;
            y.Member_id = y.Member_id;
            topics.Remove(y);
            topics.Add(y);
            return Ok(new { status = "Success", message = $"The topic {id} has been modified", data = topics });
        }
    }
}
