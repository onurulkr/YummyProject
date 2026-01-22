using Microsoft.AspNetCore.Mvc;

namespace YummyProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _RightSettingsAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}