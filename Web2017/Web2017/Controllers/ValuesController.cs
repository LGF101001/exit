using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web2017.Models;

namespace Web2017.Controllers
{
    //[Route("Values/[action]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<TagCheckResult> Get()
        {
            string input = "梁罡福";
            char[] values = input.ToCharArray();
            string temp = string.Format(input, "LGF");

            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form.
                string hexOutput = String.Format("{0:X}", value);

                temp += hexOutput + " -";
            }

            User u = new User()
            {
                Mobile = null,// "13097930800",
                Age = 300,
                UserMsg = "22"
            };

            TagCheckResult result = u.ExecTagCheck();

            return new TagCheckResult[] { result };

            // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post(string value)
        {

            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public IActionResult LayerData(int page, int limit)
        {
            IList<LayerDemo> dmList = new List<LayerDemo>();

            for (int i = 0; i < limit; i++)
            {
                LayerDemo ly = new LayerDemo();
                ly.id = i + 1;
                ly.username = "user-" + page + "-" + (i + 1);
                ly.sign = "签名-" + page;
                dmList.Add(ly);
            }

            return Json(new { code = 0, msg = "", count = 800, data = dmList });
        }

    }

    public class LayerDemo
    {
        public int id { get; set; }
        public string username { get; set; }
        public string sex { get; set; } = "男";
        public string city { get; set; } = "广东省/深圳市/罗湖区";
        public string sign { get; set; }
        public int experience { get; set; } = 255;
        public int logins { get; set; } = 24;
        public int wealth { get; set; } = 82830700;
        public string classify { get; set; } = "作家";
        public int score { get; set; } = 57;
    }

    public abstract class AbsPerson
    {

        protected abstract void Test();

        protected abstract int GetName();

        public void Run()
        {
            this.Test();
            this.GetName();
        }
    }
}
