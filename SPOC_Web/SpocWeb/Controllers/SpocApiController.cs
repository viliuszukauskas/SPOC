using SpocWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpocWeb.Generate;
using SpocWeb.Parser;

namespace SpocWeb.Controllers
{
    public class SpocApiController : ApiController
    {
        // GET: api/SpocApi
        public string Get()
        {
            return "test";
        }

        // POST: api/SpocApi
        public SpocModel Post(SpocModel spocModel)
        {
            List<PageObjectsModel> objectsModel = new List<PageObjectsModel>();

            Generator gen = new Generator();

            PageObjectsParser parser = new PageObjectsParser();

            objectsModel = parser.CollectElementInPage(spocModel.srcCode);
            spocModel.generatedCode = gen.GeneratePageObjectFile(objectsModel);

            return spocModel;
        }

        // PUT: api/SpocApi/5
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
