using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyProject.WebUI.Dtos.ProductDtos;
using YummyProject.WebUI.Dtos.TestimonialDtos;

namespace YummyProject.WebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _TestimonialDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7053/api/Testimonials/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDta = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonDta);
                return View(values);
            }
            return View();
        }
    }
}

