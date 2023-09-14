using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace httpclient_create.Controllers
{
    public class LanguageClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public LanguageClient(HttpClient httpClient,IConfiguration configuration)
        {
            _configuration=configuration;
            _httpClient = httpClient;
            
            _httpClient.BaseAddress=new Uri(_configuration.GetSection("LanguageServiceSettings").GetSection("BaseAdress").Value);
             _httpClient.BaseAddress=new Uri(_configuration.GetSection("LanguageServiceSettings:BaseAdress").Value);
         _httpClient.BaseAddress=new Uri(_configuration.GetSection("LanguageServiceSettings").GetValue<string>(""));
            
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "35f1d1aeeemsh3ad9c6de0f0b1aep176963jsn21587b71b364");
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "google-translate1.p.rapidapi.com");
        }

        public string GetLanguages(){
             HttpResponseMessage responseMessage = _httpClient.GetAsync("language/translate/v2/languages?target=tr").Result;

                string result = responseMessage.Content.ReadAsStringAsync().Result;
                return result;

        }
    }
}