using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebApplication6.Model;
using WebApplication6.Services;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public OktaResponse reponse = new OktaResponse();

        public WeatherForecastController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpGet("GetAuthorization")]
        public async Task<string> GetAuth()
        {
            reponse = await _tokenService.GetToken();
            return reponse.AccessToken;
        }

        [Authorize]
        [HttpGet("GetTestMethod")]
        public async Task<string> GetTestResponse()
        {
            return "This is test response";
        }          


        // GET: api/whoami
        [HttpGet]
        [Route("whoami")]
        [HttpGet("GetAuthorized")]
        public Dictionary<string, string> GetAuthorized()
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;
            return principal.Claims
               .GroupBy(claim => claim.Type)
               .ToDictionary(claim => claim.Key, claim => claim.First().Value);

        }


    }
    }