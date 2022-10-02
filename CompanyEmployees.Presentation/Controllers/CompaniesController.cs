using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CompaniesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        var companies = _serviceManager.CompanyService.GetAllCompanies(false);

        return Ok(companies);
    }
}