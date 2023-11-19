using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CarWashing.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var zuluUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Luis"),
                new Claim("LastName", "Florez"),
                new Claim(ClaimTypes.Name, "pinaef87@hotmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(zuluUser)));
        }
    }
}
