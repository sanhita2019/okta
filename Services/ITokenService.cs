using WebApplication6.Model;
namespace WebApplication6.Services
{
    public interface ITokenService
    {
       Task<OktaResponse> GetToken();
    }
}
