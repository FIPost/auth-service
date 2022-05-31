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

namespace Services
{
    public interface IIdentityServer4Service
    {
        Task<TokenResponse> GetToken(string apiScope);
    }
}
