using BlazorAppDemo.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorAppDemo.Auth
{
    public class ImitateAuthStateProvider : AuthenticationStateProvider
    {
        bool isLogin = false;
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if(isLogin)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,"user"),
                    new Claim(ClaimTypes.Role,"admin")
                };
                var anonymous = new ClaimsIdentity(claims, "testAuthType");
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
            }
            else
            {
                var anonymous = new ClaimsIdentity();   // 匿名使用，不传参数
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
            }
        }
        public void Login(UserInfo request)
        {
            if(request.UserName == "user" && request.Password == "111111")
                isLogin = true;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
