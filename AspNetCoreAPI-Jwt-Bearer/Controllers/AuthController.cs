using AspNetCoreAPI_Jwt_Bearer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAPI_Jwt_Bearer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            //Frontend'de bulunan projeden gelen kullanıcı bilgilerini kontrol ettikten sonra token üretir ve gönderir.
            return Created("", _authService.GenerateToken());
        }

    }
}
