using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web2017.AttributeTest
{
    public class Validator
    {
        //public static bool Validate(object validateObject, string validateProperty)
        //{
        //    System.Type t = validateObject.GetType();
        //    PropertyInfo pi = t.GetProperty(validateProperty);

        //    string validateValue = pi.GetValue(validateObject, null) as string;

        //    if (pi.IsDefined(typeof(MyValidateAttribute), true))
        //    {
        //        object[] atts = pi.GetCustomAttributes(true);
        //        MyValidateAttribute vatt = atts[0] as MyValidateAttribute;
        //        string strExpr = "";
        //        switch (vatt.ValidateType)
        //        {
        //            case ValidateType.Email:
        //                strExpr = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+{1}";
        //                break;
        //            case ValidateType.Password:
        //                strExpr = @"\d{ 6};";
        //                break;
        //            case ValidateType.Number:
        //                strExpr = @"^\d*{1}";
        //                break;
        //            case ValidateType.Id:
        //                strExpr = @" ^\w *{ 1}";
        //                break;
        //            default:
        //                return true;
        //        }
        //        Regex validateRegex = new Regex(strExpr);
        //        return validateRegex.IsMatch(validateValue);
        //    }
        //    return true;
        //}

        public static void ValidateProperty(object validateObject, string validateProperty)
        {
            System.Type t = validateObject.GetType();
            PropertyInfo pi = t.GetProperty(validateProperty);

            string validateValue = pi.GetValue(validateObject, null) as string;

            if (pi.IsDefined(typeof(MyValidateAttribute), true))
            {
                object[] atts = pi.GetCustomAttributes(true);
                MyValidateAttribute vatt = atts[0] as MyValidateAttribute;
                string strExpr = "";
                switch (vatt.ValidateType)
                {
                    case ValidateType.Email:
                        strExpr = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+{1}";
                        break;
                    case ValidateType.Password:
                        strExpr = @"\d{ 6}";
                        break;
                    case ValidateType.Number:
                        strExpr = @"^\d*{1}";
                        break;
                    case ValidateType.Id:
                        strExpr = @" ^\w *{ 1}";
                        break;
                    default:
                        return;
                }
                Regex validateRegex = new Regex(strExpr);
                if (!validateRegex.IsMatch(validateValue))
                {
                    throw new ApplicationException(validateProperty + " is invalid.");
                }
            }
        }

        public static void Validate(object validateObject)
        {
            System.Type t = validateObject.GetType();
            PropertyInfo[] ps = t.GetProperties();

            foreach (PropertyInfo pi in ps)
            {
                ValidateProperty(validateObject, pi.Name);
            }
        }

    }

}
