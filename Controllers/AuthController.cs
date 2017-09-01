using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using websites;
using alexwilkinson.Auth;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace alexwilkinson.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly AlexwilkinsonContext _context;

        public AuthController(AlexwilkinsonContext context)
        {          
            _context = context;

        }

        // POST: api/Auth
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]string value)
        {
            return null;

        }


    }
}
