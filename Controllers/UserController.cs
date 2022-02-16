using Microsoft.AspNetCore.Mvc;

namespace POSSystemApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UserController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        c1 newItem = new c1();
        newItem.Data = "我好帥00";
        return Json(newItem);
        // return Ok(newItem);
    }

    [HttpGet("show/{id}")]
     public IActionResult Show(int id)
    {
        c1 newItem = new c1() { Data = id.ToString() };
        return Ok(newItem);
    }
}

class c1{
    public string Data{get; set;}
}