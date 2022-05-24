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
    public class SurveysController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;
        private ILoggerManager _logger;

        public SurveysController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repositoryWrapper = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Survey()
        {
            try
            {
                _logger.LogInfo($"In Get Survey");
                var surveys = await _repositoryWrapper.Survey.GetAllSurveysAsync();
                var surveysResult = _mapper.Map<IEnumerable<SurveyDTO>>(surveys);
                return Ok(surveysResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the Get Survey service method {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "SurveyById")]
        public async Task<IActionResult> Survey(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                Survey surveyExtracted = await _repositoryWrapper.Survey.GetSurveyByIdAsync(id);

                if (surveyExtracted == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<SurveyDTO>(surveyExtracted));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Survey([FromBody] SurveyAddDTO surveyAddDTO)
        {
            try
            {
                if (surveyAddDTO == null)
                {
                    return BadRequest();
                }


                var _mappedSurvey = _mapper.Map<Survey>(surveyAddDTO);

                _repositoryWrapper.Survey.CreateSurvey(_mappedSurvey);
                await _repositoryWrapper.SaveAsync();

                var _surveyDTO = _mapper.Map<SurveyDTO>(_mappedSurvey);

                return CreatedAtRoute("SurveyById", new { id = _surveyDTO.SurveyId }, _surveyDTO);

                //return CreatedAtRoute("SurveyById", new { id = _surveyDTO.SurveyId }, _surveyDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Survey([FromBody] SurveyUpdateDTO surveyUpdateDTO)
        {
            try
            {
                if (surveyUpdateDTO == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                Survey surveyExtracted = await _repositoryWrapper.Survey.GetSurveyByIdAsync(surveyUpdateDTO.SurveyId);

                if (surveyExtracted == null)
                {
                    return NotFound();
                }

                var _mappedSurvey = _mapper.Map<Survey>(surveyUpdateDTO);

                _repositoryWrapper.Survey.UpdateSurvey(_mappedSurvey);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            try
            {
                Survey surveyExtracted = await _repositoryWrapper.Survey.GetSurveyByIdAsync(id);

                if (surveyExtracted == null)
                {
                    return NotFound();
                }

                _repositoryWrapper.Survey.DeleteSurvey(surveyExtracted);
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
