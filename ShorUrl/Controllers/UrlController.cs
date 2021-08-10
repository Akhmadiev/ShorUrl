using HashidsNet;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ShorUrl.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShorUrl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly UrlService _urlService;

        public UrlController(UrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public async Task<ActionResult<object>> Get(string url)
        {
            var urlRec = await _urlService.GetUrl(url);
            
            return urlRec;
        }

        [HttpPut]
        public async Task<ActionResult<string>> Save(string url)
        {
            var urlRec = await _urlService.SaveUrl(url);

            return urlRec.ShortUrl;
        }
    }
}
