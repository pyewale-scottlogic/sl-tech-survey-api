using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using TechSurveyAPI.DTOs;
using Repository.Models;
using Repository.Repositories;

namespace TechSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectOwnersController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;
        private ILoggerManager _logger;

        public ProjectOwnersController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repositoryWrapper = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ProjectOwner()
        {
            try
            {
                _logger.LogInfo($"In Get ProjectOwner");
                var projectOwners = await _repositoryWrapper.ProjectOwner.GetAllProjectOwnersAsync();
                var projectOwnersResult = _mapper.Map<IEnumerable<ProjectOwnerDTO>>(projectOwners);
                return Ok(projectOwnersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the Get ProjectOwner service method {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ProjectOwnerById")]
        public async Task<IActionResult> ProjectOwner(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                ProjectOwner projectOwnerExtracted = await _repositoryWrapper.ProjectOwner.GetProjectOwnerByProjectSurveyIdAsync(id);

                if (projectOwnerExtracted == null)
                {
                    return NotFound();
                }

                //ApiResult result = new ApiResult { Data = _mapper.Map<ProjectOwnerDTO>(projectOwnerExtracted), ErrorMessage = "" };
                //return Ok(result);

                return Ok(_mapper.Map<ProjectOwnerDTO>(projectOwnerExtracted));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProjectOwner([FromBody] ProjectOwnerAddDTO projectOwnerAddDTO)
        {
            try
            {
                if (projectOwnerAddDTO == null)
                {
                    return BadRequest();
                }


                var _mappedProjectOwner = _mapper.Map<ProjectOwner>(projectOwnerAddDTO);

                _repositoryWrapper.ProjectOwner.CreateProjectOwner(_mappedProjectOwner);
                await _repositoryWrapper.SaveAsync();

                var _projectOwnerDTO = _mapper.Map<ProjectOwnerDTO>(_mappedProjectOwner);

                //ApiResult result = new ApiResult { Data = _projectOwnerDTO, ErrorMessage = "" };
                //return CreatedAtRoute("ProjectOwnerById", new { id = _projectOwnerDTO.ProjectOwnerId }, result);

                return CreatedAtRoute("ProjectOwnerById", new { id = _projectOwnerDTO.ProjectSurveyId }, _projectOwnerDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> ProjectOwner([FromBody] ProjectOwnerUpdateDTO projectOwnerUpdateDTO)
        {
            try
            {
                if (projectOwnerUpdateDTO == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                ProjectOwner projectOwnerExtracted = await _repositoryWrapper.ProjectOwner.GetProjectOwnerByProjectSurveyIdAsync(projectOwnerUpdateDTO.ProjectSurveyId);

                if (projectOwnerExtracted == null)
                {
                    return NotFound();
                }

                var _mappedProjectOwner = _mapper.Map<ProjectOwner>(projectOwnerUpdateDTO);

                _repositoryWrapper.ProjectOwner.UpdateProjectOwner(_mappedProjectOwner);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectOwner(int id)
        {
            try
            {
                ProjectOwner projectOwnerExtracted = await _repositoryWrapper.ProjectOwner.GetProjectOwnerByProjectSurveyIdAsync(id);

                if (projectOwnerExtracted == null)
                {
                    return NotFound();
                }

                _repositoryWrapper.ProjectOwner.DeleteProjectOwner(projectOwnerExtracted);
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
