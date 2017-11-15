using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2017.AttributeTest;

namespace Web2017.Models
{
    public class ActionForm
    {
        private string email = "";
        private string password = "";

        [MyValidate(ValidateType.Email)]
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        [MyValidate(ValidateType.Password)]
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

    }
}
