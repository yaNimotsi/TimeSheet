﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using TimeSheet.BusinessLogic;
using TimeSheet.DB;
using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.API.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : Controller
    {
        private readonly UserLogic _userLogic;
        private readonly IUserRepository _repository;
        private readonly MyDBContext _context;

        public UserController(UserLogic userLogic, IUserRepository repository, MyDBContext context)
        {
            _userLogic = userLogic;
            _repository = repository;
            _context = context;
        }

        [HttpGet("byId/{id}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<User>>> GetUserById([FromRoute] int id)
        {
            var result = await _userLogic.GetUserByIDAsync(_context, _repository, id);
            return Ok(result);
        }

        [HttpGet("byName/{nameToSearch}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<User>>> GetUserByName([FromRoute] string nameToSearch)
        {
            var result = await _userLogic.GetUserByNameAsync(_context, _repository, nameToSearch);
            return Ok(result);
        }

        [HttpGet("skip/{skipCount}/taken/{takeCount}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<User>>> GetUserByRange([FromRoute] int skipCount, [FromRoute] int takeCount)
        {
            var result = await _userLogic.GetUserByRangeAsync(_context, _repository, skipCount, takeCount);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User entity)
        {
            await _userLogic.AddNewUserAsync(_context, _repository, entity);
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateUserById([FromBody] User entity)
        {
            await _userLogic.UpdateUserAsync(_context, _repository, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById([FromRoute] int id)
        {
            await _userLogic.DeleteUserAsync(_context, _repository, id);
            return NoContent();
        }
    }
}
