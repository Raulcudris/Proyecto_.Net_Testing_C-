using DemoUnitTesting.Data.Entities;
using DemoUnitTesting.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoUnitTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _todoService.GetAllAsync();
            if (result.Count == 0)
            {
               return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(Todo newTodo)
        {
            await _todoService.SaveAsync(newTodo);
            return Ok();
        }

    }
}
