using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyProject.Controllers;
using MyProject.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using MyProject.Extensions;
namespace MyProject.ViewComponents
{
    [ViewComponent(Name = "Login")]
    public class LoginViewComponent: ViewComponent
    {
        private List<Login> people;
        public async Task<IViewComponentResult> InvokeAsync(Login L)
        {
           if(L == null)
                return View("Login");
           else
            {
                people = new List<Login>
                 {
                    new Login{EmailOrUsername = "tom@gmail.com", Password = "12345"},
                    new Login{ EmailOrUsername = "bob@gmail.com", Password = "55555" },
                };
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");
                var EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var usernameRegex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
                Match isValidated = hasNumber.Match(L.Password);
                
                if (isValidated.Success)
                {
                    isValidated = hasUpperChar.Match(L.Password);
                    if (isValidated.Success)
                    {
                        isValidated = hasMinimum8Chars.Match(L.Password);
                        if (isValidated.Success)
                        {
                            if (L.EmailOrUsername.Contains('@'))
                            {
                                isValidated = EmailRegex.Match(L.EmailOrUsername);
                                if (isValidated.Success)
                                {
                                    ViewData["LoginError"] = "Good";
                                    return View("Login");
                                }
                                else
                                {
                                    ViewData["LoginError"] = "Wrong email format!";
                                    return View("Login");
                                }
                            }
                            else
                            {
                                isValidated = usernameRegex.Match(L.EmailOrUsername);
                                if (isValidated.Success)
                                {
                                    ViewData["LoginError"] = "Good";
                                    return View("Login");
                                }
                                else
                                {
                                    ViewData["LoginError"] = "Write correct email or username!";
                                    return View("Login");
                                }
                            }
                        }
                        else
                        {
                            ViewData["LoginError"] = "A password should contains at least 8 symbols";
                            return View("Login");
                        }
                    }
                    else
                    {
                        ViewData["LoginError"] = "A password should contains at least one capital letter";
                        return View("Login");
                    }
                }
                else
                {
                    ViewData["LoginError"] = "A password should contains at least one number";
                    return View("Login");
                }
                
            }
        }

    }
}
