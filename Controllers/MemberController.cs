using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using web_test_api.models;
using WebApiIntroAssignment.Services;
using web_test_api.Interfaces;


namespace web_test_api.Controllers
{
    [ApiController]
    [Route("members")]
    public class MemberController : ControllerBase
    {
        private readonly IDatabase _database;

        public MemberController(IDatabase database)
        {
            _database = database;
        }

        //Http Methods
        [HttpPost]
        public void PostMember(Members data)
        {
            _database.Create(data);
        }

        [HttpGet]
        public IActionResult GetMember()
        {
            var result = _database.Read();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberById(int id)
        {
            var result = _database.ReadById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            _database.Delete(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchMember(int id, [FromBody]JsonPatchDocument<Members> data)
        {
            _database.Update(id, data);
            return Ok();
        }
    }
}
