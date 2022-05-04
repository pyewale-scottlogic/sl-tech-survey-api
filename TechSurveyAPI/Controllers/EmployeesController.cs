using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSurveyAPI.DTOs;
using Repository.Models;
using Repository.Repositories;

namespace TechSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;

        public EmployeesController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repositoryWrapper = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Employee()
        {
            try
            {
                var Employees = await _repositoryWrapper.Employee.GetAllEmployeesAsync();
                var EmployeesResult = _mapper.Map<IEnumerable<EmployeeDTO>>(Employees);
                return Ok(EmployeesResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> Employee(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                Employee employeeExtracted = await _repositoryWrapper.Employee.GetEmployeeByIdAsync(id);

                if (employeeExtracted == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<EmployeeDTO>(employeeExtracted));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Employee([FromBody] EmployeeAddDTO employeeAddDTO)
        {
            try
            {
                if (employeeAddDTO == null)
                {
                    return BadRequest();
                }


                var _mappedEmployee = _mapper.Map<Employee>(employeeAddDTO);

                _repositoryWrapper.Employee.CreateEmployee(_mappedEmployee);
                await _repositoryWrapper.SaveAsync();

                var _employeeDTO = _mapper.Map<EmployeeDTO>(_mappedEmployee);

                return CreatedAtRoute("EmployeeById", new { id = _employeeDTO.EmployeeId }, _employeeDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Employee([FromBody] EmployeeUpdateDTO employeeUpdateDTO)
        {
            try
            {
                if (employeeUpdateDTO == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                Employee employeeExtracted = await _repositoryWrapper.Employee.GetEmployeeByIdAsync(employeeUpdateDTO.EmployeeId);

                if (employeeExtracted == null)
                {
                    return NotFound();
                }

                var _mappedEmployee = _mapper.Map<Employee>(employeeUpdateDTO);

                _repositoryWrapper.Employee.UpdateEmployee(_mappedEmployee);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                Employee employeeExtracted = await _repositoryWrapper.Employee.GetEmployeeByIdAsync(id);

                if (employeeExtracted == null)
                {
                    return NotFound();
                }

                _repositoryWrapper.Employee.DeleteEmployee(employeeExtracted);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
