using Microsoft.AspNetCore.Mvc;

namespace YummyProject.WebUI.ViewComponents.DefaultMenuViewComponent
{
    public class _DefaultMenuViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
