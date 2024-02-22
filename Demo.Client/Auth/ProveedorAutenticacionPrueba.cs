using Demo.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Demo.Client.Auth
{
    public class ProveedorAutenticacionPrueba : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimo = new ClaimsIdentity();

            var usuarioAutenticado = new ClaimsIdentity(
                  new List<Claim>
                  {
                    new Claim("Nombre", "Juan"),
                    new Claim("edad", "30"),
                    new Claim(ClaimTypes.Name, "user@policia.gob.pe"),
                     new Claim(ClaimTypes.Role, "admin")
                  },
                  authenticationType: "prueba");



            var x = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("","")

            }, authenticationType:"prueba");


            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuarioAutenticado)));
        }
    }
}
