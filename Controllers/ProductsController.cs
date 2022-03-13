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

    [HttpGet("show")]
    public IActionResult Show(int id){
        var product = _context.Product.SingleOrDefault(x => x.Id == id);
        
        if(product != null){
            return Json(product);
        }else{
            return NotFound();
        }
    }

    [HttpPost("store")]
    public IActionResult Store(Product request){
        _context.Product.Add(request);
        _context.SaveChanges();
        return Json(Ok());
    }
}
