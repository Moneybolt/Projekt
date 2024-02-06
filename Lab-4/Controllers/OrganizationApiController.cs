using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_App_Reservation.Controllers;

[Route("api/organization")]
[ApiController]
public class OrganizationApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrganizationApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetOrganizationsByName(string? q)
    {
        return Ok(
            q == null ? _context.Organization
            .Select(o => new { o.Title, o.Id })
            .ToList() :
            _context.Organization.Where(o => o.Title.ToUpper().StartsWith(q.ToUpper()))
            .Select(o => new { o.Title, o.Id })
            .ToList()
        );
    }
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var organization = _context.Organization.Find(id);
        if (organization == null)
        {
            return NotFound();

        }
        else
        {
            return Ok(organization);
        }
    }
}