using HashidsNet;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public ActionResult<string> GetShort(string url)
        {
            var hashids = new Hashids(url); 
            var id = hashids.Encode(1, 2, 3);

            return id;
        }
    }
}
