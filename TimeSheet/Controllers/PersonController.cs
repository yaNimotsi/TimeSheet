using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonModel;

namespace TimeSheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonLogic _personLogic;

        public PersonController(PersonLogic logic)
        {
            _personLogic = logic;
        }

        [HttpGet("/{id}")]
        // GET: PersonController
        public Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            //var person = new Task(x => _personLogic.GetPerson(id));
            return null;
        }

        [HttpGet("/{nameToSearch}")]
        // GET: PersonController
        public IActionResult GetPersonByName([FromRoute] string nameToSearch)
        {
            _personLogic.GetPerson(nameToSearch);
            return null;
        }

        [HttpGet("skip/{nameToSearch}/taken/{takeCount}")]
        // GET: PersonController
        public IActionResult GetPersonByRange([FromRoute] string skipValue, [FromRoute] string takeCount)
        {
            return null;
        }

        [HttpPost]
        public IActionResult CreatePerson ([FromBody] Person person)
        {
            return null;
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePersonById([FromRoute] string id, [FromBody] Person updatePerson)
        {
            return null;
        }

        [HttpDelete("/{id}")]
        public IActionResult DeletePersonById([FromRoute] string id)
        {
            return null;
        }
    }
}
