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
    [Route("replies")]
    public class RepliesController : ControllerBase
    {
        private List<Replies> replies = new List<Replies>()
        {
            new Replies() { Id = 1, Content = "This is great! I love biology now!", Member_id = 3, Topic_id = 1 },
            new Replies() { Id = 2, Content = "This is great! I love Physics now!", Member_id = 3, Topic_id = 2 },
            new Replies() { Id = 3, Content = "My father forced me to read this. Now I'm a bishop", Member_id = 3, Topic_id = 3 },
        };
        private readonly ILogger<RepliesController> _logger;

        public RepliesController(ILogger<RepliesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(replies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(replies.First(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult NewData(Replies newuser)
        {
            replies.Add(newuser);
            return Ok(replies);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletedData(int id)
        {
            var y = replies.First(x => x.Id == id);
            replies.Remove(y);
            return Ok(new { status = "Success", message = $"The reply {id} has been deleted", data = replies });
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateData(int id, Replies data)
        {
            var y = replies.First(x => x.Id == id);
            y.Id = y.Id;
            y.Content = data.Content == null ? y.Content : data.Content;
            y.Member_id = y.Member_id;
            y.Topic_id = y.Topic_id;
            replies.Remove(y);
            replies.Add(y);
            return Ok(new { status = "Success", message = $"The reply {id} has been modified", data = replies });
        }
    }
}
