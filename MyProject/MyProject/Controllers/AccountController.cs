using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyProject.Extensions;
using MyProject.ViewComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MyProject.Controllers
{

    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return ViewComponent("Login");
        }

        public IActionResult Register()
        {
            return ViewComponent("Register");
        }
        [HttpPost]
        public IActionResult GetLoginData(Login L) 
        {
            //str = str.Trim('\"');
            //NameValueCollection parameters = HttpUtility.ParseQueryString(str);
            //Login L = new Login();
            //L.EmailOrUsername = parameters["EmailOrUsername"];
            //L.Password = parameters["Password"];
            //L.HashPassword = parameters["HashPassword"];
            var a = ViewComponent("Login", L);
            if (ViewData["LoginError"]==null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my super secret code"));
                var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                //Сначала нужно проверять пароль на валидность, т.к. он не представляет как такового пользователя, то есть не работает
                //напрямую с секретными данными. Только потом выдавать токен
                List<Login> logins = HttpContext.Session.Get<List<Login>>("reglist");
                Login login;
                login = logins == null ? null : logins.FirstOrDefault(p => p.EmailOrUsername.Equals(L.EmailOrUsername) /*&& p.Password.Equals(L.Password)*/);
                if(login==null)
                {
                    TempData["LoginEr"] = "The user doesn`t exist";
                    return a;
                }
                if (login != null && !BCrypt.Net.BCrypt.Verify(L.Password, login.HashPassword))
                {
                    if(HttpContext.Request.Cookies.ContainsKey("loginerrors"))
                    {
                        string? n = HttpContext.Request.Cookies["loginerrors"];
                        int num = Convert.ToInt32(n) + 1;
                        if (num>3)
                        {
                            TempData["LoginEr"] = "Too many attempts! Wait for 3 minutes and try again";
                            HttpContext.Response.Cookies.Append("loginerrors", $"0");
                        }
                        else
                        {
                            HttpContext.Response.Cookies.Append("loginerrors", $"{num}");
                            TempData["LoginEr"] = "Incorrect password. Try again";
                        }
                          
                    }
                    else
                    {
                        HttpContext.Response.Cookies.Append("loginerrors", "1");
                        TempData["LoginEr"] = "Incorrect password. Try again";
                    }
                    return a;
                }
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, login.EmailOrUsername) };
                var jwt = new JwtSecurityToken(
                        issuer: "Photovibe",
                        audience: "Photovibe",
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(20)),
                        signingCredentials: credentials);
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                HttpContext.Session.Set("token", encodedJwt);

                TempData["Login"] = "green";
                var emailBytes = Encoding.UTF8.GetBytes(L.EmailOrUsername);
                TempData["Email"] = emailBytes;
                var emailBytes1 = TempData["Email"] as byte[];
                var email = Encoding.UTF8.GetString(emailBytes1);
                TempData["Email"] = email;
                HttpContext.Session.Set("Email", email);
                return RedirectToAction("Index", "MainPage");
            }
            return a;
        }
        
        [HttpGet]

        public string GetToken()
        {
            if (HttpContext.Session.Get("token") != null)
            {
                var token = HttpContext.Session.Get("token");
                string json = JsonConvert.SerializeObject(token, Formatting.Indented);
                return json;
            }
            else
                return "Nah bro";
        }
        [HttpPost]
        public IActionResult GetRegisterData(Register R)
        {
            var a= ViewComponent("Register", R);
            if( ModelState.IsValid)
            {
                Login L = new Login();
                L.EmailOrUsername = R.Email;
                //L.Password = R.Password;
                L.HashPassword = BCrypt.Net.BCrypt.HashPassword(R.Password);
                List<Login> list = new List<Login>();
                list.Add(L);
                List<Login> s = HttpContext.Session.Get<List<Login>>("reglist");
                if (s == null)
                {
                    HttpContext.Session.Set<List<Login>>("reglist", list);
                }
                else
                {
                    s.Add(L);
                    HttpContext.Session.Set<List<Login>>("reglist", s);
                }
                return RedirectToAction("Login", "Account");
            }
            return a;
        }
    }
    public class Login
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
        public string HashPassword { get; set; }
        public bool Remember { get; set; }
    }
   
}
