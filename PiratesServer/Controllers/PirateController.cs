using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PiratesServer.Controllers
{
    public class PirateController : ApiController
    {
        [HttpGet]
        [Route("api/pirate/{numberOfPirates}")]
        public IHttpActionResult Get(int numberOfPirates)
        {
            if (numberOfPirates < 2)
            {
                return this.Ok("We expect 2 or more pirates.");
            }

            // this is a special case, it can be calculated
            // as 2^4 - 1 or n^(n + 2) - n + 1
            // everything else is n^(n + 1) - n + 1
            if (numberOfPirates == 2) 
            {
                return this.Ok(15);
            }

            var doubleOfPirates = (double)numberOfPirates;

            var temp = Math.Pow(doubleOfPirates, doubleOfPirates + 1);

            return this.Ok(temp - doubleOfPirates + 1);
        }
    }
}
