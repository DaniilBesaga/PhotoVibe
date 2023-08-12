using Microsoft.AspNetCore.Mvc;
using MyProject.Controllers;

namespace MyProject.ViewComponents
{
    public class AddToLightBoxViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("AddToLightBox");
        }
    }
}
