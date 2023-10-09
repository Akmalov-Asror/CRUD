using CRUD.Data;
using CRUD.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
       return Ok(await _context.Products.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm]Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }
}