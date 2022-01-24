using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeManagementController : ControllerBase
    {
        private readonly IOfficeRepository _context;

        public OfficeManagementController(IOfficeRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _context.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hero = await _context.GetById(id);
            if (hero == null)
                return BadRequest("This Id not Exists");

            return Ok(hero);
        }


        [HttpPost]
        public async Task<IActionResult> Create(OfficeManagement office)
        {
            return Ok(await _context.Create(office));
        }


        [HttpPut]
        public async Task<IActionResult> Update(OfficeManagement request)
        {
            var hero = await _context.Update(request);
            if (hero == null)
                return BadRequest("Id not Exists");


            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            {
                var bookToDelete = await _context.GetById(id);
                if (bookToDelete == null)
                {
                    return BadRequest("NO found");
                }

                await _context.Delete(bookToDelete.Id);
                return Ok("Deleted");
            }
        }
    }
}
