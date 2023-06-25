using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Services;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthorizationController(ITokenService tokenService)
        {
            _tokenService= tokenService;
        }
        [HttpGet(Name = "GetAuthorization")]
        public string GetAuthorized1()
        {
            var token = _tokenService.GetToken();
            return token.ToString();
        }
    }
}
