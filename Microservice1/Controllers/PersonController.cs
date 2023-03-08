using awapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public PersonController(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> OnGet()
    {

        var result = await _dbContext.People.ToListAsync();

        return Ok(result);
    }
}