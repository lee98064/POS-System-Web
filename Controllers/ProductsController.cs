using Microsoft.AspNetCore.Mvc;
using POSSystemApi.Models;

namespace POSSystemApi.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class ProductsController : Controller
{

    private readonly POSSystemApiContext _context;
    public ProductsController(POSSystemApiContext context)
    {
        _context = context;
    }
    
    [HttpGet("index")]
    public IActionResult Index()
    {
        return Json(_context.Product.ToList());
    }

    [HttpPost("store")]
    public IActionResult Store(Product request){
        _context.Product.Add(request);
        _context.SaveChanges();
        return Json(Ok());
    }
}
