using Microsoft.Extensions.Options;
using WebApplication6.Model;
using Okta.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebApplication6.Services
{
    public class TokenService : ITokenService
    {

        public IConfiguration _config;
        public TokenService(IConfiguration config) {
            _config = _config;
        }


        public async Task<OktaResponse> GetToken()
        {
            var token = new OktaResponse();
            var client= new HttpClient();
            var client_id = "0oaa40nakqbxzOgfg5d7";
            var client_secret = "K893XGdummDdxAQg21DHSJCjifRbhjn7BIRoqndD";
            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));
            var postMessage=new Dictionary<string, string>();
            postMessage.Add("grant_type", "client_credentials");
            postMessage.Add("username", "abhimukherj000ee007@gmail.com");
            //postMessage.Add("password", password);
            postMessage.Add("scope", "access_token");
            var request = new HttpRequestMessage(HttpMethod.Post, "https://dev-79347492.okta.com/oauth2/default/v1/token")
            {
                Content = new FormUrlEncodedContent(postMessage)
            };

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<OktaResponse>(json);
                token.ExpiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);
            }
            else
            {
                throw new ApplicationException("Unable to retrieve access token from Okta");
            }
            return token;
        }
    }
}
