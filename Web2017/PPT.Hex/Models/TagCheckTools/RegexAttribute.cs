using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PPT.Hex.Models
{
    /// <summary>
    /// 正则校验
    /// </summary>
    public class RegexAttribute : TagCheckAttribute
    {
        private string _regex = null;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="regex">正则</param>
        /// <param name="isRequired">是否必填</param>
        public RegexAttribute(string regex, bool isRequired = true)
            : this(regex, "{0}字段值有误")
        {
            base.IsRequired = isRequired;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="regex">正则</param>
        /// <param name="errMsg">校验不通过提示信息</param>
        /// <param name="isRequired">是否必填</param>
        public RegexAttribute(string regex, string errMsg, bool isRequired = true)
        {
            this._regex = regex;
            this.ErrMsg = errMsg;
            base.IsRequired = isRequired;
        }

        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="value">待校验的值</param>
        /// <returns></returns>
        public override bool StandbyCheck(object value)
        {
            if (value == null)
            {
                return false;
            }

            return new Regex(_regex).IsMatch(value.ToString());
        }
    }
}
