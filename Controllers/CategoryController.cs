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
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private List<Categories> categories = new List<Categories>()
        {
            new Categories() { Id = 1, Name = "Staff", Description = "List of staffs" },
            new Categories() { Id = 2, Name = "Owner", Description = "List of owners" },
            new Categories() { Id = 3, Name = "Manager", Description = "List of managers" },
        };
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(categories.First(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult NewData(Categories newuser)
        {
            categories.Add(newuser);
            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletedData(int id)
        {
            var y = categories.First(x => x.Id == id);
            categories.Remove(y);
            return Ok(new { status = "Success", message = $"The category {id} has been deleted", data = categories });
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateData(int id, Categories data)
        {
            var y = categories.First(x => x.Id == id);
            y.Id = y.Id;
            y.Name = data.Name == null ? y.Name : data.Name;
            y.Description = data.Description == null ? y.Description : data.Description;
            categories.Remove(y);
            categories.Add(y);
            return Ok(new { status = "Success", message = $"The category {id} has been modified", data = categories });
        }
    }
}
