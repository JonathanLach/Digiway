using DigiwayWebapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayWebapi.Controllers
{
    [Route("token")]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]TokenRequest tr)
        {
            if (IsValidUserAndPasswordCombination(tr.Username, tr.Password))
            {
                Token newToken = new Token()
                {
                    TokenValue = GenerateToken(tr.Username)
                };
                return new ObjectResult(newToken);
            
            }
            return BadRequest();
        }

        private bool IsValidUserAndPasswordCombination(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }

        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
            new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("H38DLSIEKD8EKDOS")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
