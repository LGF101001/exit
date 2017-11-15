using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PPT.Hex.Models;

namespace PPT.Hex.Controllers
{
    [Route("values/[action]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var builder = new AppBuilder();
            var obj = new MachineKeyDataProtectionProvider().ToOwinFunction();

            builder.Properties["security.DataProtectionProvider"] = obj;

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public TagCheckResult Post([FromBody]AuditFeedback value)
        {
            TagCheckResult ragRs = value.ExecTagCheck();

            //Order info = new Order();
            //TagCheckResult ragRs = info.ExecTagCheck();

            return ragRs;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody]string value)
        {
         
            return id;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
  
}
