﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TimeSheet.BusinessLogic;
using TimeSheet.DB;
using TimeSheet.DB.Entity;
using TimeSheet.DB.Interface;

namespace TimeSheet.API.Controllers
{
    [ApiController]
    [Route("/employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeLogic _employeeLogic;
        private readonly IEmployeeRepository _repository;
        private readonly MyDBContext _context;

        public EmployeeController(EmployeeLogic employeeLogic, IEmployeeRepository repository, MyDBContext context)
        {
            _employeeLogic = employeeLogic;
            _repository = repository;
            _context = context;
        }

        [HttpGet("byId/{id}")]
        // GET: PersonController
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployeeById([FromRoute] int id)
        {
            var result = await _employeeLogic.GetEmployeeByIDAsync(_context, _repository, id);
            return Ok(result);
        }

        [HttpGet("byName/{nameToSearch}")]
        // GET: EmployeeController
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployeeByName([FromRoute] string nameToSearch)
        {
            var result = await _employeeLogic.GetEmployeeByNameAsync(_context, _repository, nameToSearch);
            return Ok(result);
        }

        [HttpGet("skip/{skipCount}/taken/{takeCount}")]
        // GET: EmployeeController
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployeeByRange([FromRoute] int skipCount, [FromRoute] int takeCount)
        {
            var result = await _employeeLogic.GetEmployeeByRangeAsync(_context, _repository, skipCount, takeCount);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] Employee entity)
        {
            await _employeeLogic.AddNewEmployeeAsync(_context, _repository, entity);
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateEmployeeById([FromBody] Employee entity)
        {
            await _employeeLogic.UpdateEmployeeAsync(_context, _repository, entity);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteEmployeeById([FromRoute] int id)
        {
            await _employeeLogic.DeleteEmployeeAsync(_context, _repository, id);
            return NoContent();
        }
    }
}
