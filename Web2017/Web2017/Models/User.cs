using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2017.Models
{
    public class User : ITagCheck
    {
        //[Caption("手机号码")]
        [Regex(RegexCheckType.Mobile, "手机号码有误", CheckIsRequired.NoRequired)]
        public string Mobile { get; set; }

        //[Caption("年龄")]
        //[Range(1, 120)]
        public int Age { get; set; }

        //[Range(30, 280, "身高数据异常")]
        public decimal Height { get; set; }
        //[Caption("自定义信息")]
        [Regex(RegexCheckType.Mobile, "自定义信息格式不正确", CheckIsRequired.Required)]
        public string UserMsg { get; set; }
    }
}
