using CRUD.Data;
using CRUD.Dto_s;
using CRUD.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }
    // only get
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_context.Users.ToList());
    }
    // only create 
    [HttpPost]
    public IActionResult AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok();
    }
    //only update
    [HttpPut]
    public IActionResult EditUser(int Id,UserDto user)
    {
        var getUsers = _context.Users.FirstOrDefault(x => x.Id == Id);
        getUsers.Email = user.Email;
        getUsers.Name = user.Name;
        getUsers.Password = user.Password;

        _context.Users.Update(getUsers);
        _context.SaveChanges();
        return Ok();    
    }

    [HttpDelete]
    public IActionResult DeleteUser(int Id)
    {
        var getUsers = _context.Users.FirstOrDefault(x => x.Id == Id);

        _context.Users.Remove(getUsers);
        _context.SaveChanges();
        return Ok();
    }
    // CRUD

}