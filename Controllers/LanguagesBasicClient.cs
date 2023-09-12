using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace httpclient_create.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguagesBasicClient : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LanguagesBasicClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "35f1d1aeeemsh3ad9c6de0f0b1aep176963jsn21587b71b364");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "google-translate1.p.rapidapi.com");

                HttpResponseMessage responseMessage = client.GetAsync("https://google-translate1.p.rapidapi.com/language/translate/v2/languages?target=tr").Result;

                string result = responseMessage.Content.ReadAsStringAsync().Result;

                return Ok(result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}