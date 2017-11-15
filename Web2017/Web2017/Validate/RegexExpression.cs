using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2017.Models
{
    /// <summary>
    /// 正则类型
    /// </summary>
    public class RegexCheckType
    {
        /// <summary>
        /// 手机号格式正则表达式(开放号段：13|4|5|7|8)
        /// </summary>
        public const string Mobile = "^1(3|4|5|7|8)\\d{9}$";

        /// <summary>
        /// 中文字符正则表达式（只允许输入中文且不包含任何标点符号等）
        /// </summary>
        public const string Chinese = "^[\u4E00-\u9FFF]+$";

        /// <summary>
        /// 邮箱正则表达式
        /// </summary>
        public const string Email = @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$";
    }

    /// <summary>
    /// 是否必填
    /// </summary>
    public class CheckIsRequired
    {
        /// <summary>
        /// 必填
        /// </summary>
        public const bool Required = true;
        /// <summary>
        /// 不必填
        /// </summary>
        public const bool NoRequired = false;
    }
}
