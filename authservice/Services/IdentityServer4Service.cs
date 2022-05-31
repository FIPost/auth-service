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
using System.Net.Http;

namespace Services
{
    public class IdentityServer4Service : IIdentityServer4Service
    {
        private DiscoveryDocumentResponse _discoveryDocument { get; set; }
        public IdentityServer4Service()
        {
            using (var client = new HttpClient())
            {
                _discoveryDocument = client.GetDiscoveryDocumentAsync("https://connect.test.surfconext.nl/.well-known/openid-configuration").Result;
            }
        }
        public async Task<TokenResponse> GetToken(string apiScope)
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = _discoveryDocument.TokenEndpoint,
                    ClientId = "ipost.local",
                    Scope = apiScope,
                    ClientSecret = "8LZS5cRJbjU6TqhLxG1Z"
                });
                if (tokenResponse.IsError)
                {
                    throw new Exception("Token Error");
                }
                return tokenResponse;
            }
        }
    }
}
