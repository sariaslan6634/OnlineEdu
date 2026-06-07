using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DTO.DTOS.LoginDtos;
using OnlineEdu.DTO.DTOS.UserDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineEdu.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var result = await _client.PostAsJsonAsync("users/login", userLoginDto);
            if (!result.IsSuccessStatusCode)
            {
                ModelState.AddModelError("","Kullanıcı adı veya şifre hatalı.");
                return View(userLoginDto);
            }
            var handle = new JwtSecurityTokenHandler();
            var response = await result.Content.ReadFromJsonAsync<LoginResponseDto>();
            var token = handle.ReadJwtToken(response.Token);

            var claims = token.Claims.ToList();
            if (response.Token != null)
            {
                claims.Add(new Claim("Token", response.Token));
                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    ExpiresUtc = response.ExpireDate,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return View(userLoginDto);


        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
