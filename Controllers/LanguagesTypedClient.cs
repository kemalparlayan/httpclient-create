using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace httpclient_create.Controllers.NamedClient
{
    [ApiController]
    [Route("[controller]")]
    public class LanguagesTypedClient : ControllerBase
    {
        private readonly LanguageClient _languageClient;

        public LanguagesTypedClient(LanguageClient languageClient)
        {
            _languageClient = languageClient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               string result =_languageClient.GetLanguages();

                return Ok(result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}