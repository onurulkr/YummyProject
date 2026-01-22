using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyProject.WebUI.Dtos.ChefDtos;
using YummyProject.WebUI.Dtos.MessageDtos;

namespace YummyProject.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarMessageListAdminLayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarMessageListAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7053/api/Messages/MessageListByIsReadFalse/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDta = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageByIsReadFalse>>(jsonDta);
                return View(values);
            }
            return View();
        }
    }
}
