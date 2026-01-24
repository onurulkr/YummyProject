using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyProject.WebUI.Dtos.MessageDtos;
using YummyProject.WebUI.Dtos.NotificationDtos;

namespace YummyProject.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarNotificationAdminLayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarNotificationAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7053/api/Notifications/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDta = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonDta);
                return View(values);
            }
            return View();
        }
    }
}
