using InsuranceAdvisor.Domain.Interfaces;
using InsuranceAdvisor.WebApi.Mappers;
using InsuranceAdvisor.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceAdvisor.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class InsuranceAdvisorController : ControllerBase
    {
        private readonly ILogger<InsuranceAdvisorController> _logger;
        private readonly IInsuranceAdvisorService _insuranceAdvisorService;

        public InsuranceAdvisorController(ILogger<InsuranceAdvisorController> logger, IInsuranceAdvisorService insuranceAdvisorService)
        {
            _logger = logger;
            _insuranceAdvisorService = insuranceAdvisorService;
        }

        [HttpPost("advise")]
        public IActionResult RequestInsuranceAdvice([FromBody] ClientProfileDto clientProfileDto)
        {
            var clientProfile = clientProfileDto.ToDomain();

            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Messages);
            
            var insuranceAdvice = _insuranceAdvisorService.GenerateInsuranceAdvice(clientProfile);
            
            var insuranceAdviceDto = insuranceAdvice.ToDto();
            return Ok(insuranceAdviceDto);
        }
    }
}