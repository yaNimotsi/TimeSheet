
using Microsoft.AspNetCore.Mvc;

using TimeSheet.BusinessLogic;
using TimeSheet.DB;

namespace TimeSheet.API.Controllers
{
    [ApiController]
    [Route("/person")]
    public class PersonController : ControllerBase
    {
        private readonly PersonLogic _personLogic;
        public PersonController(PersonLogic logic)
        {
            _personLogic = logic;
        }

        [HttpGet("byId/{id}")]
        // GET: PersonController
        public IActionResult GetPersonById([FromRoute] int id)
        {
            var response = _personLogic.GetPerson(id);
            return response == null ? NoContent() : Ok(response);
        }

        [HttpGet("byName/{nameToSearch}")]
        // GET: PersonController
        public IActionResult GetPersonByName([FromRoute] string nameToSearch)
        {
            var response = _personLogic.GetPerson(nameToSearch);
            return response == null ? NoContent() : Ok(response);
        }

        [HttpGet("skip/{skipCount}/taken/{takeCount}")]
        // GET: PersonController
        public IActionResult GetPersonByRange([FromRoute] int skipCount, [FromRoute] int takeCount)
        {
            var response = _personLogic.GetPerson(skipCount, takeCount);
            return response == null ? NoContent() : Ok(response);
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            var response = _personLogic.AddNewPerson(person);
            return response == null ? NoContent() : Ok(response);
        }

        [HttpPut("update/")]
        public IActionResult UpdatePersonById([FromBody] Person updatePerson)
        {
            var response = _personLogic.UpdatePerson(updatePerson);
            return response == null ? NoContent() : Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePersonById([FromRoute] int id)
        {
            var response = _personLogic.DeletePerson(id);
            return response == false ? BadRequest(false) : Ok(true);
        }
    }
}
