using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using BCrypt.Net;
using MyProject.Controllers;
using MyProject.Extensions;
namespace MyProject.ViewComponents
{
    [ViewComponent(Name = "Register")]
    public class RegisterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Register R)
        {
            return View("Register");
        }
    }
    public class Register
    {
        [Required(ErrorMessage ="Please enter first name...")]
        [Display (Name ="FirstName")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name...")]
        [Display(Name = "LastName")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please select industry...")]
        [Display(Name = "Industry")]
        public string? Industry { get; set; }
        [Required(ErrorMessage = "Please enter email...")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter password...")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        
        [RegularExpression_CP(@"[A-Z]+", ErrorMessage = "A password should contains at least one capital letter")]
        [RegularExpression_Length(@".{8,}", ErrorMessage = "A password should contains at least 8 digits")]
        public string? Password { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "Please approve you have read the License Agreement...")]
        [Display(Name = "License")]
        public bool License { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "Please approve you have read the Privacy Policy...")]
        [Display(Name = "Privacy")]
        public bool Privacy { get; set; }
    }
    public class RegularExpression_CP: ValidationAttribute
    {
        private readonly string stringpattern;
        public RegularExpression_CP(string pattern)
        {
            stringpattern = pattern;
        }
        public override bool IsValid(object? value)
        {
            var str = value as string;
            var regex = new Regex(stringpattern);
            return regex.IsMatch(str);
        }
    }
    public class RegularExpression_Length : RegularExpression_CP
    {
        public RegularExpression_Length(string pattern):base(pattern) { }
        
    }
}
