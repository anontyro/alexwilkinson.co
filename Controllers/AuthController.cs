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

namespace alexwilkinson.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly AlexwilkinsonContext _context;
        private readonly JwtFactory _jwtFactory;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthController(AlexwilkinsonContext context, IOptions<JwtIssuerOptions> jwtOptions)
        {

            _context = context;
            _jwtOptions = jwtOptions.Value;
            _jwtFactory = new JwtFactory(jwtOptions);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

        }

        // POST: api/Auth
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]string value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = new
            {
                title = "Auth output",
                auth_token =  _jwtFactory.GenerateEncodedToken("test"),
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);



        }
        
    }
}
