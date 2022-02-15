using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using TimeSheet.BusinessLogic;
using TimeSheet.DB;
using TimeSheet.DB.Entitys;

namespace TimeSheet.API.Controllers
{
    [ApiController]
    [Route("/person")]
    public class PersonController : ControllerBase
    {
        private readonly PersonLogic _personLogic;
        private readonly Repository _repository;
        public PersonController(PersonLogic logic, Repository repository)
        {
            _personLogic = logic;
            _repository = repository;
        }

        [HttpGet("byId/{id}")]
        // GET: PersonController
        public IActionResult GetPersonById([FromRoute] int id)
        {
            return Ok(_personLogic.GetPerson(_repository, id));
        }

        [HttpGet("byName/{nameToSearch}")]
        // GET: PersonController
        public IActionResult GetPersonByName([FromRoute] string nameToSearch)
        {
            return Ok(_personLogic.GetPerson(_repository, nameToSearch));
        }

        [HttpGet("skip/{skipCount}/taken/{takeCount}")]
        // GET: PersonController
        public IActionResult GetPersonByRange([FromRoute] int skipCount, [FromRoute] int takeCount)
        {
            return Ok(_personLogic.GetPerson(_repository, skipCount, takeCount));
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            return Ok(_personLogic.AddNewPerson(_repository, person));
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePersonById([FromBody] Person updatePerson)
        {
            return Ok(_personLogic.UpdatePerson(_repository, updatePerson));
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePersonById([FromRoute] int id)
        {
            return Ok(_personLogic.DeletePerson(_repository, id));
        }
    }
}
