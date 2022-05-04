using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechSurveyAPI.DTOs;
using Repository.Models;
using Repository.Repositories;
using LoggerService;

namespace TechSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;
        private ILoggerManager _logger;

        public TechnologiesController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repositoryWrapper = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Technology()
        {
            try
            {
                var Technologies = await _repositoryWrapper.Technology.GetAllTechnologiesAsync();
                var TechnologiesResult = _mapper.Map<IEnumerable<TechnologyDTO>>(Technologies);
                return Ok(TechnologiesResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "TechnologyById")]
        public async Task<IActionResult> Technology(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                Technology technologyExtracted = await _repositoryWrapper.Technology.GetTechnologyByIdAsync(id);

                if (technologyExtracted == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<TechnologyDTO>(technologyExtracted));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Technology([FromBody] TechnologyAddDTO technologyAddDTO)
        {
            try
            {
                if (technologyAddDTO == null)
                {
                    return BadRequest();
                }


                var _mappedTechnology = _mapper.Map<Technology>(technologyAddDTO);

                _repositoryWrapper.Technology.CreateTechnology(_mappedTechnology);
                await _repositoryWrapper.SaveAsync();

                var _technologyDTO = _mapper.Map<TechnologyDTO>(_mappedTechnology);

                return CreatedAtRoute("TechnologyById", new { id = _technologyDTO.TechnologyId }, _technologyDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Technology([FromBody] TechnologyUpdateDTO technologyUpdateDTO)
        {
            try
            {
                if (technologyUpdateDTO == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                Technology technologyExtracted = await _repositoryWrapper.Technology.GetTechnologyByIdAsync(technologyUpdateDTO.TechnologyId);

                if (technologyExtracted == null)
                {
                    return NotFound();
                }

                var _mappedTechnology = _mapper.Map<Technology>(technologyUpdateDTO);

                _repositoryWrapper.Technology.UpdateTechnology(_mappedTechnology);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnology(int id)
        {
            try
            {
                Technology technologyExtracted = await _repositoryWrapper.Technology.GetTechnologyByIdAsync(id);

                if (technologyExtracted == null)
                {
                    return NotFound();
                }

                _repositoryWrapper.Technology.DeleteTechnology(technologyExtracted);
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
