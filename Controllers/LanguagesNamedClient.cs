using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace httpclient_create.Controllers.NamedClient
{
    [ApiController]
    [Route("[controller]")]
    public class LanguagesNamedClient : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LanguagesNamedClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("rapidapi");

                HttpResponseMessage responseMessage = client.GetAsync("language/translate/v2/languages?target=tr").Result;

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