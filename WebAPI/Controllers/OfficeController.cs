using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly DapperOfficeRepo dapperOfficeRepo;

        public OfficeController()
        {
            dapperOfficeRepo = new DapperOfficeRepo();
        }

        //The list of all tasks or the list of everyone in our system.
        //Everyone Details and All list
        [HttpGet("AllList")]
        public IEnumerable<OfficeManagement> Get()
        {
            return dapperOfficeRepo.Get();
        }

        //Given a person’s name let that person know his tasks for a day.
        //Assistant task 
        [HttpGet("Assistants Name Get his Task for today")]
        public IEnumerable<OfficeManagement> Get(string Name)
        {
            var hero = dapperOfficeRepo.GetByName(Name);
            if (hero == null)
                return null;

            return hero;
        }

        //Given a person’s name let that person know his requested task for a day
        //Individual Employee details
        [HttpGet("Employee Name Get his requested task")]
        public OfficeManagement GetByEmployeeName(string Name)
        {
            var hero = dapperOfficeRepo.GetByEmployeeName(Name);
            if (hero == null)
                return null;

            return hero;
        }

        // Given a person’s name, show us the list of tasks completed by that person.
        //Enter Assistent name WHERE IsTaskComplete == yes
        //Bonous Task
        [HttpGet("Get Assistant CompletedTask")]
        public IEnumerable<OfficeManagement> GetAssistantCompletedTask(string Name)
        {
            var hero = dapperOfficeRepo.GetAssistantCompletedTask(Name);
            if (hero == null)
                return null;

            return hero;
        }
    }
}
