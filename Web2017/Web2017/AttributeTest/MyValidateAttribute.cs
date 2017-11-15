using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2017.AttributeTest
{
    [System.AttributeUsage(AttributeTargets.Property)]
    public class MyValidateAttribute : System.Attribute
    {
        public MyValidateAttribute(ValidateType validateType)
        {
            this._validatetype = validateType;
        }
        private ValidateType _validatetype;

        public ValidateType ValidateType
        {
            get { return this._validatetype; }
            set { this._validatetype = value; }
        }
    }
    public enum ValidateType
    {
        Email,
        Password,
        Number,
        Id
    }
}
