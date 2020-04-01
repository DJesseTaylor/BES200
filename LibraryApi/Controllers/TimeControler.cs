using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class TimeControler : Controller
    {
        [HttpGet("/time")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 10)]
        public ActionResult GetTime()
        {
            var response = new { time = DateTime.Now };
            return Ok(response);
        }
    }
}
