using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.API.Mapping;
using TimeSheet.BusinessLogic;

using APIEmployeeModel = TimeSheet.API.DAL.Entity.Employee;

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
        public async Task<ActionResult<IReadOnlyList<APIEmployeeModel>>> GetEmployeeById([FromRoute] int id)
        {
            var result = await _employeeLogic.GetEmployeeByIdAsync(_token, id);

            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(EmployeeMapping.MappingToAPIEmployeeModel(result.ToList()));
        }

        [HttpGet("byName/{nameToSearch}")]
        // GET: EmployeeController
        public async Task<ActionResult<IReadOnlyList<APIEmployeeModel>>> GetEmployeeByName([FromRoute] string nameToSearch)
        {
            var result = await _employeeLogic.GetEmployeeByNameAsync(_token, nameToSearch);

            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(EmployeeMapping.MappingToAPIEmployeeModel(result.ToList()));
        }

        [HttpGet("skip/{skipCount}/taken/{takeCount}")]
        // GET: EmployeeController
        public async Task<ActionResult<IReadOnlyList<APIEmployeeModel>>> GetEmployeeByRange([FromRoute] int skipCount, [FromRoute] int takeCount)
        {
            var result = await _employeeLogic.GetEmployeeByRangeAsync(_token, skipCount, takeCount);

            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(EmployeeMapping.MappingToAPIEmployeeModel(result.ToList()));
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] APIEmployeeModel entity)
        {
            var blUserModel = EmployeeMapping.MappingFromBLEmployeeModel(entity);
            if (await _employeeLogic.AddNewEmployeeAsync(_token, blUserModel) != null)
            {
                return Ok(entity);
            }
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateEmployeeById([FromRoute] int id, [FromBody] APIEmployeeModel entity)
        {
            entity.Id = id;
            var blUserModel = EmployeeMapping.MappingFromBLEmployeeModel(entity);
            var response = await _employeeLogic.UpdateEmployeeAsync(_token, blUserModel);

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
