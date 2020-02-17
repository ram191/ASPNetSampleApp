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
    [Route("members")]
    public class MemberController : ControllerBase
    {
        private List<Members> members = new List<Members>()
        {
            new Members() { Id = 1, Username = "admin", Password = "admin", Email = "admin@magazine.com", Full_name = "John Pantau", Popularity = 9 },
            new Members() { Id = 2, Username = "newuser22", Password = "rahasia", Email = "userbaru22@magazine.com", Full_name = "Steve Occupation", Popularity = 6 },
            new Members() { Id = 3, Username = "stalker4", Password = "pA33s4o2", Email = "stalker41@emailmin.com", Full_name = "Paul McCartney", Popularity = 10 },
        };
        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(members);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(members.First(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult NewData(Members newuser)
        {
            members.Add(newuser);
            return Ok(members);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletedData(int id)
        {
            var y = members.First(x => x.Id == id);
            members.Remove(y);
            return Ok(new { status = "Success", message = $"The member {id} has been deleted", data = members });
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateData(int id, Members data)
        {
            var y = members.First(x => x.Id == id);
            y.Id = y.Id;
            y.Username = data.Username == null ? y.Username : data.Username;
            y.Password = data.Password == null ? y.Password : data.Password;
            y.Email = data.Email == null ? y.Email : data.Email;
            y.Full_name = data.Full_name == null ? y.Full_name : data.Full_name;
            y.Popularity = data.Popularity == 0 ? y.Popularity : data.Popularity;
            members.Remove(y);
            members.Add(y);
            return Ok(new { status = "Success", message = $"The member {id} has been modified", data = members });
        }
    }
}
