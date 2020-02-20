using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using web_test_api.models;
using WebApiIntroAssignment.Services;

namespace web_test_api.Controllers
{
    [ApiController]
    [Route("members")]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IDatabase _database;
        public MemberController(IDatabase database)
        {
            _database = database;
        }

        [HttpPost]
        public void PostMember(Members data)
        {
            _database.Post(data);
        }

        [HttpGet]
        public IActionResult GetMember()
        {
            var result = _database.GetMembers();
            return Ok (result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetMemberById(int id)
        {
            var result = _database.GetSpecificMember(id);
            return Ok (result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            _database.DeleteMember(id);
            return Ok();

        }
    }
}
