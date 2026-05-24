using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class JWTController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        public JWTController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        [HttpPost]
        public IActionResult Login(JwtDTO request)
        {
            if (request.username != "admin" ||
                request.password != "123")
            {
                return Unauthorized();
            }

            var token = _jwtService.GenerateToken(request.username);

            return Ok(new
            {
                token
            });
        }
        
    }
}
