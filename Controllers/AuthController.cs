using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;
using POSSystemApi.Models;
using POSSystemApi.RequestData;
using POSSystemApi.ResponseData;
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
    public IActionResult Login(LoginData request)
    {
        var user = _context.User.SingleOrDefault(x => x.account == request.account);
        if (user == null || !BC.Verify(request.password, user.password))
        {
            return Json(new AuthData(){status = false, token = "LOGIN_FAILED"});
        }
        else
        {
            string jwtToken = JwtAuthUtil.GenerateToken(user);
            return Json(new AuthData(){status = true, token = jwtToken});
        }
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterData request){

        AuthData data = new AuthData();
        if (!(request.password == request.password_vaild)){
            data.status = false;
            data.token = "Password vaild error!";
            return Json(data);
        }

        User user = new User();
        user.email = request.email;
        user.name = request.name;
        user.account = request.account;
        user.password = BCrypt.Net.BCrypt.HashPassword(request.password);
        _context.User.Add(user);
        _context.SaveChanges();

        string jwtToken = JwtAuthUtil.GenerateToken(user);

        return Json(new AuthData(){status = true, token = jwtToken});

    }

    [HttpGet("isLogin")]
    public IActionResult isLogin(string token){

        if(JwtAuthUtil.VerifyToken(token)){
            return Json(new AuthData(){status = true});
        }else{
            return Json(new AuthData(){status = false});
        }

    }
}
