using SpocWeb.Models;
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
            var generator = new Generator();
            var parser = new PageObjectsParser();

            var objectsModel = parser.CollectElementInPage(spocModel.srcCode);
            spocModel.generatedCode = generator.GeneratePageObjectFile(objectsModel);

            return spocModel;
        }

        // PUT: api/SpocApi/5
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
