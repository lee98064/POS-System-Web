using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;
using POSSystemApi.Models;
namespace POSSystemApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class AuthController : Controller
{

    private readonly POSSystemApiContext _context;

    public AuthController(POSSystemApiContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login(string account, string password)
    {
        var user = _context.User.SingleOrDefault(x => x.account == account);
        if (user == null || !BC.Verify(password, user.password))
        {
            return Json(new AuthData(){status = false, token = "LOGIN_FAILED"});
        }
        else
        {
            JwtAuthUtil jwtAuthUtil = new JwtAuthUtil();
            string jwtToken = jwtAuthUtil.GenerateToken(user);
            return Json(new AuthData(){status = true, token = jwtToken});
        }
    }

    [HttpPost("register")]
    public IActionResult Register(string email, string name, string account, string password, string password_vaild){

        AuthData data = new AuthData();
        if (!(password == password_vaild)){
            data.status = false;
            data.token = "Password vaild error!";
            return Json(data);
        }

        User user = new User();
        user.email = email;
        user.name = name;
        user.account = account;
        user.password = BCrypt.Net.BCrypt.HashPassword(password);
        _context.User.Add(user);
        _context.SaveChanges();

        JwtAuthUtil jwtAuthUtil = new JwtAuthUtil();
        string jwtToken = jwtAuthUtil.GenerateToken(user);

        return Json(new AuthData(){status = true, token = jwtToken});

    }

    [HttpGet("isLogin")]
    public IActionResult isLogin(){
        return Json(new AuthData(){status = true, token = "asdsadsad"});

    }
}

class AuthData{

    public bool status {get; set;}
    public string token {get; set;}

}