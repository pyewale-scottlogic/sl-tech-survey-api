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
    public class PlatformsController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;

        public PlatformsController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repositoryWrapper = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Platform()
        {
            try
            {
                var Platforms = await _repositoryWrapper.Platform.GetAllPlatformsAsync();
                var PlatformsResult = _mapper.Map<IEnumerable<PlatformDTO>>(Platforms);
                return Ok(PlatformsResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "PlatformById")]
        public async Task<IActionResult> Platform(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                Platform platformExtracted = await _repositoryWrapper.Platform.GetPlatformByIdAsync(id);

                if (platformExtracted == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<PlatformDTO>(platformExtracted));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Platform([FromBody] PlatformAddDTO platformAddDTO)
        {
            try
            {
                if (platformAddDTO == null)
                {
                    return BadRequest();
                }


                var _mappedPlatform = _mapper.Map<Platform>(platformAddDTO);

                _repositoryWrapper.Platform.CreatePlatform(_mappedPlatform);
                await _repositoryWrapper.SaveAsync();

                var _platformDTO = _mapper.Map<PlatformDTO>(_mappedPlatform);

                return CreatedAtRoute("PlatformById", new { id = _platformDTO.PlatformId }, _platformDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Platform([FromBody] PlatformUpdateDTO platformUpdateDTO)
        {
            try
            {
                if (platformUpdateDTO == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                Platform platformExtracted = await _repositoryWrapper.Platform.GetPlatformByIdAsync(platformUpdateDTO.PlatformId);

                if (platformExtracted == null)
                {
                    return NotFound();
                }

                var _mappedPlatform = _mapper.Map<Platform>(platformUpdateDTO);

                _repositoryWrapper.Platform.UpdatePlatform(_mappedPlatform);
                await _repositoryWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            try
            {
                Platform platformExtracted = await _repositoryWrapper.Platform.GetPlatformByIdAsync(id);

                if (platformExtracted == null)
                {
                    return NotFound();
                }

                _repositoryWrapper.Platform.DeletePlatform(platformExtracted);
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
