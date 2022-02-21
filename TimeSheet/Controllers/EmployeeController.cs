using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TimeSheet.BusinessLogic;
using TimeSheet.DB.Entity;

namespace TimeSheet.API.Controllers
{
    [ApiController]
    [Route("/employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeLogic _employeeLogic;
        private readonly CancellationTokenSource _token;

        public EmployeeController(EmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
            _token = new CancellationTokenSource();
            _token.CancelAfter(5000);
        }

        [HttpGet("byId/{id}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployeeById([FromRoute] int id)
        {
            var result = await _employeeLogic.GetEmployeeByIDAsync(_token, id);

            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("byName/{nameToSearch}")]
        // GET: EmployeeController
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployeeByName([FromRoute] string nameToSearch)
        {
            var result = await _employeeLogic.GetEmployeeByNameAsync(_token, nameToSearch);

            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("skip/{skipCount}/taken/{takeCount}")]
        // GET: EmployeeController
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployeeByRange([FromRoute] int skipCount, [FromRoute] int takeCount)
        {
            var result = await _employeeLogic.GetEmployeeByRangeAsync(_token, skipCount, takeCount);

            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] Employee entity)
        {
            if (await _employeeLogic.AddNewEmployeeAsync(_token, entity) != null)
            {
                return Ok(entity);
            }
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateEmployeeById([FromRoute] int id, [FromBody] Employee entity)
        {
            entity.Id = id;
            var response = await _employeeLogic.UpdateEmployeeAsync(_token, entity);

            return response == null ? NoContent() : Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteEmployeeById([FromRoute] int id)
        {
            var response = await _employeeLogic.DeleteEmployeeAsync(_token, id);

            return response ? Ok(true) : NoContent();
        }
    }
}
