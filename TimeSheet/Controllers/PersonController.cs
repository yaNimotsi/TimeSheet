using Microsoft.AspNetCore.Mvc;
using PersonModel;

namespace TimeSheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private static PersonLogic personLogic;



        [HttpGet("/{id}")]
        // GET: PersonController
        public IActionResult GetPersonById([FromRoute] int id)
        {
            
            return null;
        }

        [HttpGet("/{nameToSearch}")]
        // GET: PersonController
        public IActionResult GetPersonByName([FromRoute] string nameToSearch)
        {
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
