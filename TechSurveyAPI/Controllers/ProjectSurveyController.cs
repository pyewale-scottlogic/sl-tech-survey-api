using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace TechSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectSurveyController : ControllerBase
    {
        //private IRepositoryWrapper _repositoryWrapper;
        //private IMapper _mapper;
        //private ILoggerManager _logger;

        //public ProjectSurveyController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        //{
        //    _repositoryWrapper = repository;
        //    _mapper = mapper;
        //    _logger = logger;
        //}

        //[HttpGet]
        //public async Task<IActionResult> Company()
        //{
        //    try
        //    {
        //        var companies = await _repositoryWrapper.Company.GetAllCompanysAsync();
        //        var companiesResult = _mapper.Map<IEnumerable<CompanyDTO>>(companies);
        //        return Ok(companiesResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpGet("{id}", Name = "CompanyById")]
        //public async Task<IActionResult> Company(int id)
        //{
        //    try
        //    {
        //        if (id == 0)
        //        {
        //            return BadRequest();
        //        }
        //        Company companyExtracted = await _repositoryWrapper.Company.GetCompanyByIdAsync(id);

        //        if (companyExtracted == null)
        //        {
        //            return NotFound();
        //        }

        //        //ApiResult result = new ApiResult { Data = _mapper.Map<CompanyDTO>(companyExtracted), ErrorMessage = "" };
        //        //return Ok(result);

        //        return Ok(_mapper.Map<CompanyDTO>(companyExtracted));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> Company([FromBody] CompanyAddDTO companyAddDTO)
        //{
        //    try
        //    {
        //        if (companyAddDTO == null)
        //        {
        //            return BadRequest();
        //        }


        //        var _mappedCompany = _mapper.Map<Company>(companyAddDTO);

        //        _repositoryWrapper.Company.CreateCompany(_mappedCompany);
        //        await _repositoryWrapper.SaveAsync();

        //        var _companyDTO = _mapper.Map<CompanyDTO>(_mappedCompany);

        //        ApiResult result = new ApiResult { Data = _companyDTO, ErrorMessage = "" };
        //        return CreatedAtRoute("CompanyById", new { id = _companyDTO.CompanyId }, result);

        //        //return CreatedAtRoute("CompanyById", new { id = _companyDTO.CompanyId }, _companyDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}


        //[HttpPut]
        //public async Task<IActionResult> Company([FromBody] CompanyUpdateDTO companyUpdateDTO)
        //{
        //    try
        //    {
        //        if (companyUpdateDTO == null || !ModelState.IsValid)
        //        {
        //            return BadRequest();
        //        }

        //        Company companyExtracted = await _repositoryWrapper.Company.GetCompanyByIdAsync(companyUpdateDTO.CompanyId);

        //        if (companyExtracted == null)
        //        {
        //            return NotFound();
        //        }

        //        var _mappedCompany = _mapper.Map<Company>(companyUpdateDTO);

        //        _repositoryWrapper.Company.UpdateCompany(_mappedCompany);
        //        await _repositoryWrapper.SaveAsync();

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCompany(int id)
        //{
        //    try
        //    {
        //        Company companyExtracted = await _repositoryWrapper.Company.GetCompanyByIdAsync(id);

        //        if (companyExtracted == null)
        //        {
        //            return NotFound();
        //        }

        //        _repositoryWrapper.Company.DeleteCompany(companyExtracted);
        //        await _repositoryWrapper.SaveAsync();

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
