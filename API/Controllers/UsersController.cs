using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController:ControllerBase
{

private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();

        return users;

    }

    [HttpGet("{Id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int Id)
    {
        var user = await  _context.Users.FindAsync(Id);
        if (user == null) return NotFound();

        return user;

    }


}