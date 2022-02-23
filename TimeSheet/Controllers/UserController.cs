using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.API.Mapping;
using TimeSheet.BusinessLogic;

using APIUserModel = TimeSheet.API.DAL.Entity.User;

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
        public async Task<ActionResult<IReadOnlyList<APIUserModel>>> GetUserById([FromRoute] int id)
        {
            var result = await _userLogic.GetUserByIdAsync(_token, id);
            
            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(UserMapping.MappingToAPIUserModel(result.ToList()));
        }

        [HttpGet("byName/{nameToSearch}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<APIUserModel>>> GetUserByName([FromRoute] string nameToSearch)
        {
            var result = await _userLogic.GetUserByNameAsync(_token, nameToSearch);
            
            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(UserMapping.MappingToAPIUserModel(result.ToList()));
        }

        [HttpGet("skip/{skipCount}/taken/{takeCount}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<APIUserModel>>> GetUserByRange([FromRoute] int skipCount, [FromRoute] int takeCount)
        {
            var result = await _userLogic.GetUserByRangeAsync(_token, skipCount, takeCount);

            if (result is not { Count: > 0 })
            {
                return NoContent();
            }

            return Ok(UserMapping.MappingToAPIUserModel(result.ToList()));
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] APIUserModel entity)
        {
            var blUserModel = UserMapping.MappingFromAPIUserModel(entity);
            if (await _userLogic.AddNewUserAsync(_token, blUserModel) != null)
            {
                return Ok(entity);
            }
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateUserById([FromRoute] int id, [FromBody] APIUserModel entity)
        {
            entity.Id = id;

            var blUserModel = UserMapping.MappingFromAPIUserModel(entity);
            var response = await _userLogic.UpdateUserAsync(_token, blUserModel);

            return response == null ? NoContent() : Ok(UserMapping.MappingToAPIUserModel(response));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById([FromRoute] int id)
        {
            var response = await _userLogic.DeleteUserAsync(_token, id);
            
            return response ? Ok(true) : NoContent();
        }
    }
}
