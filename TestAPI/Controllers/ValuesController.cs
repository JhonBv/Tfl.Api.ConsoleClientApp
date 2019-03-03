using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPI.Mocks;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/resp")]

    public class ValuesController : ApiController
    {

        [Route("daGood")]
        // GET api/values/5
        public string GetGood(string id)
        {
            TflModel model = MockModel.GoodMock();
            return JsonConvert.SerializeObject(model);
        }

        [Route("daBad")]
        /// <summary>
        /// Returns a bad response (404)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetBad(string id)
        {
            TflbadResponseModel model = MockModel.BadMock();
            return JsonConvert.SerializeObject(model);
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
