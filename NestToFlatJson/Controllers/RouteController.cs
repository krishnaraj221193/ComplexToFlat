using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NestToFlatProject.Controllers
{
    public class RouteController : ApiController
    {
        NestToFlat _nestToFlat;
        public RouteController()
        {
            _nestToFlat = new NestToFlat();
        }
        public IHttpActionResult Post([FromBody]object complexObj)
        {
            JArray jArray = _nestToFlat.getFlatObject(complexObj);
            return Ok(jArray);
        }
    }
}
