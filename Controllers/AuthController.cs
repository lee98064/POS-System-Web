using Microsoft.AspNetCore.Mvc;

namespace POSSystemApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class AuthController : Controller
{
    [HttpPost("login")]
    public IActionResult Login(string account, string password)
    {
        if(account == "admin" && password == "12345")
        {
            JwtAuthUtil jwtAuthUtil = new JwtAuthUtil();
            string jwtToken = jwtAuthUtil.GenerateToken();
            return Json(new LoginData(){status = true, token = jwtToken});
        }
        else
        {
            return Json(new LoginData(){status = false, token = "Account Or Password Error"});
        }
    }
}

class LoginData{

    public bool status {get; set;}
    public string token {get; set;}

}