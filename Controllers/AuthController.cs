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
            return Json(new AuthData(){status = true, token = jwtToken});
        }
        else
        {
            return Json(new AuthData(){status = false, token = "Account Or Password Error"});
        }
    }

    [HttpPost("register")]
    public IActionResult Register(string name,string account,string password, string password_vaild){

        AuthData data = new AuthData();

        if (!(password == password_vaild)){
            data.status = false;
            data.token = "Password vaild error!";
            return Json(data);
        }



        return Json(data);


    }
}

class AuthData{

    public bool status {get; set;}
    public string token {get; set;}

}