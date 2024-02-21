using Demo.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

//using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Demo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
        {
            var _userInfor = await AutenticarUsuario(usuarioLogin.Usuario, usuarioLogin.Password);

            if (_userInfor == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new { Token = GenerarTokenJWT(_userInfor) });
            }
        }
        private async Task<UsuarioInfo> AutenticarUsuario(string usurio, string password)
        {
            // AQUI LA LOGICA DE AUTENTICACION
            if(usurio == "31832200" && password == "123456")
            {
                //Suponemos que el usurio existe en la BD.
                //Retornar un objeto de tipo UsuarioInfo con toda la informacion necesaria para el token.
                var info = new UsuarioInfo()
                {
                    Id = Guid.NewGuid(),
                    Nombres = "Juan",
                    Apellidos = "Perez",
                    Email = "juan@dominio.com",
                    Rol = "superusuario"
                };

                return info;
            }
            else
            {
                return null;
            }
            
        }


        public string GenerarTokenJWT(UsuarioInfo usuarioInfo)
        {
            // CREAMOS EL HEADER
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"]));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);

            //CREAR LOS CLAIMS
            var _claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("nombre", usuarioInfo.Nombres),
                new Claim("apellidos", usuarioInfo.Apellidos),
                new Claim("llave", "El valor que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                new Claim(ClaimTypes.Role, usuarioInfo.Rol)
            };

            // CREAMOS EL PAYLOAD (CARGA UTIL)
            var _payload = new JwtPayload(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: _claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(1)
                );

            // GENERAR TOKEN
            var _token = new JwtSecurityToken(_header, _payload);

            return new JwtSecurityTokenHandler().WriteToken(_token);
        }
    }
}
