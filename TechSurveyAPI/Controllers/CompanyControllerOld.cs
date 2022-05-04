using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechSurveyAPI.DTOs;
using TechSurveyAPI.Models;
using TechSurveyAPI.Repositories;

namespace TechSurveyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyControllerOld : Controller
    {
        ICompanyRepositoryOld _companyRepo;
        public readonly IMapper _mapper;
        public CompanyControllerOld(ICompanyRepositoryOld companyRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> Company([FromQuery]int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Company companyExtracted = await _companyRepo.Get(id);

            if (companyExtracted == null)
            {
                return NotFound();
            }

            return _mapper.Map<CompanyDTO>(companyExtracted);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> Company([FromBody] CompanyAddDTO company)
        {
            if(company == null)
            {
                return BadRequest();
            }
            var _mappedCompany = _mapper.Map<Company>(company);
            await _companyRepo.Add(_mappedCompany);

            return Ok(company);
        }
    }
}
