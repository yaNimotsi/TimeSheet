using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TimeSheet.BusinessLogic;
using TimeSheet.DB.Entity;

namespace TimeSheet.API.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : Controller
    {
        private readonly UserLogic _userLogic;
        private readonly CancellationTokenSource _token;

        public UserController(UserLogic userLogic)
        {
            _userLogic = userLogic;
            _token = new CancellationTokenSource();
            _token.CancelAfter(5000);
        }

        [HttpGet("byId/{id}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<User>>> GetUserById([FromRoute] int id)
        {
            var result = await _userLogic.GetUserByIdAsync(_token, id);
            
            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("byName/{nameToSearch}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<User>>> GetUserByName([FromRoute] string nameToSearch)
        {
            var result = await _userLogic.GetUserByNameAsync(_token, nameToSearch);
            
            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("skip/{skipCount}/taken/{takeCount}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<User>>> GetUserByRange([FromRoute] int skipCount, [FromRoute] int takeCount)
        {
            var result = await _userLogic.GetUserByRangeAsync(_token, skipCount, takeCount);

            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User entity)
        {
            if (await _userLogic.AddNewUserAsync(_token, entity) != null)
            {
                return Ok(entity);
            }
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateUserById([FromRoute] int id, [FromBody] User entity)
        {
            entity.Id = id;

            var response = await _userLogic.UpdateUserAsync(_token, entity);

            return response == null ? NoContent() : Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById([FromRoute] int id)
        {
            var response = await _userLogic.DeleteUserAsync(_token, id);
            
            return response ? Ok(true) : NoContent();
        }
    }
}
