using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories;
using TechSurveyAPI.DTOs;

namespace TechSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectSurveyController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;
        private ILoggerManager _logger;

        public ProjectSurveyController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repositoryWrapper = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "ProjectSurveyById")]
        public async Task<IActionResult> ProjectSurvey(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                ProjectSurvey projectSurveyExtracted = await _repositoryWrapper.ProjectSurvey.GetProjectSurveyAndRelatedDataByIdAsync(id);

                if (projectSurveyExtracted == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ProjectSurveyDTO>(projectSurveyExtracted));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [Route("projects/{projectId}")]
        [HttpGet("{projectId}", Name = "ProjectSurveyForProjectId")]
        public async Task<IActionResult> ProjectSurveyForProjectId(int projectId)
        {
            try
            {
                if (projectId == 0)
                {
                    return BadRequest();
                }
                var projectSurveyExtracted = await _repositoryWrapper.ProjectSurvey.GetProjectSurveyAndRelatedDataByForProjectIdAsync(projectId);

                if (projectSurveyExtracted == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map <IEnumerable<ProjectSurveyDTO>>(projectSurveyExtracted));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProjectSurvey([FromBody] ProjectSurveyAddDTO projectSurveyAddDTO)
        {
            try
            {
                if (projectSurveyAddDTO == null)
                {
                    return BadRequest();
                }


                var _mappedProjectSurvey= _mapper.Map<ProjectSurvey>(projectSurveyAddDTO);

                _repositoryWrapper.ProjectSurvey.CreateProjectSurvey(_mappedProjectSurvey);

                await _repositoryWrapper.SaveAsync();

                var _projectSurveyDTO = _mapper.Map<ProjectSurveyDTO>(_mappedProjectSurvey);

                return CreatedAtRoute("ProjectSurveyById", new { id = _projectSurveyDTO.ProjectSurveyId }, _projectSurveyDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> ProjectSurvey([FromBody]ProjectSurveyUpdateDTO projectSurveyUpdateDTO)
        {
            try
            {
                if (projectSurveyUpdateDTO == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                ProjectSurvey projectSurveyExtracted = await _repositoryWrapper.ProjectSurvey.GetProjectSurveyAndRelatedDataByIdAsync(projectSurveyUpdateDTO.ProjectSurveyId);

                if (projectSurveyExtracted == null)
                {
                    return NotFound();
                }

                //Phase2 : We need to figure out how to use only one SaveAsync.
                //Somehow cascade delete is not working on child entities hence I have separately deleted related data
                //Or we can update object in context with latest data and use saveAsync only once
                projectSurveyExtracted.Technologies.Clear();
                projectSurveyExtracted.Platforms.Clear();
                await _repositoryWrapper.SaveAsync();

                var _mappedProjectSurvey = _mapper.Map<ProjectSurvey>(projectSurveyUpdateDTO);

                _repositoryWrapper.ProjectSurvey.UpdateProjectSurvey(_mappedProjectSurvey);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectSurvey(int id)
        {
            try
            {
                ProjectSurvey projectSurveyExtracted = await _repositoryWrapper.ProjectSurvey.GetProjectSurveyByIdAsync(id);

                if (projectSurveyExtracted == null)
                {
                    return NotFound();
                }

                _repositoryWrapper.ProjectSurvey.DeleteProjectSurvey(projectSurveyExtracted);
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
