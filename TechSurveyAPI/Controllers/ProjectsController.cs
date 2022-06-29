using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using TechSurveyAPI.DTOs;
using Repository.Models;
using Repository.Repositories;

namespace TechSurveyAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/companies/{companyId}/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;
        private ILoggerManager _logger;

        public ProjectsController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repositoryWrapper = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("/api/[controller]")]
        public async Task<IActionResult> Project()
        {
            try
            {
                _logger.LogInfo($"In Get Project");
                var projects = await _repositoryWrapper.Project.GetAllProjectsAsync();
                var projectsResult = _mapper.Map<IEnumerable<ProjectDTO>>(projects);
                return Ok(projectsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the Get Project service method {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "GetProjectForCompany")]
        public async Task<IActionResult> GetProjectForCompany(int companyId, int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                Project projectExtracted = await _repositoryWrapper.Project.GetProjectByIdAsync(id);

                if (projectExtracted == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ProjectDTO>(projectExtracted));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectsForCompanyAsync(int companyId)
        {
            try
            {
                if (companyId == 0)
                {
                    return BadRequest();
                }

                var projects = await _repositoryWrapper.Project.GetAllProjectsForCompanyAsync(companyId);

                if (projects == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<ProjectDTO>>(projects));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Project(int companyId, [FromBody] ProjectAddDTO projectAddDTO)
        {
            try
            {
                if (projectAddDTO == null)
                {
                    return BadRequest();
                }


                var _mappedProject = _mapper.Map<Project>(projectAddDTO);

                _repositoryWrapper.Project.CreateProject(_mappedProject);
                await _repositoryWrapper.SaveAsync();

                var _projectDTO = _mapper.Map<ProjectDTO>(_mappedProject);

                return CreatedAtRoute("GetProjectForCompany", new { companyId = companyId, id = _projectDTO.ProjectId}, _projectDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Project(int companyId, [FromBody] ProjectUpdateDTO projectUpdateDTO)
        {
            try
            {
                if (projectUpdateDTO == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                Project projectExtracted = await _repositoryWrapper.Project.GetProjectByIdAsync(projectUpdateDTO.ProjectId);

                if (projectExtracted == null)
                {
                    return NotFound();
                }

                var _mappedProject = _mapper.Map<Project>(projectUpdateDTO);
                _mappedProject.CompanyId = companyId;

                _repositoryWrapper.Project.UpdateProject(_mappedProject);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        
        [Route("~/api/[controller]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Project(int id)
        {
            try
            {
                Project projectExtracted = await _repositoryWrapper.Project.GetProjectByIdAsync(id);

                if (projectExtracted == null)
                {
                    return NotFound();
                }

                _repositoryWrapper.Project.DeleteProject(projectExtracted);
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
