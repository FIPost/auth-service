using IdentityModel.Client;
using IdentityModel.OidcClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Net.Http.Server;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Services;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace authservice.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {

        public AuthController()
        {

        }

        [Route("/login")]
        [Authorize]
        public async Task<string> getLogin()
        {

            return "";
        }

        [HttpGet]
        [Route("token")]
        public async Task<String> getToken()
        {
            var values = new Dictionary<string, string>
                {
                    { "grant_type", "authorization_code" },
                    { "client_id", "ipost.local"},
                    { "client_secret", "8LZS5cRJbjU6TqhLxG1Z" },
                    { "code" , "openid" },
                    { "redirect_uri", "https://ipost.local:8080/loggedIn"}
                };

            HttpClient tokenClient = new HttpClient();
            var content = new FormUrlEncodedContent(values);
            var response = tokenClient.PostAsync("https://connect.test.surfconext.nl/oidc/token", content).Result;
            return response.ToString();
        }
        
    }
}
