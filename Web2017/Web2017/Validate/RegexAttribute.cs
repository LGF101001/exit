using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web2017.Models
{
    public class RegexAttribute : TagCheckAttribute
    {
        private string regex = null;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="regex">正则</param>
        /// <param name="isRequired">是否必填</param>
        public RegexAttribute(string regex, bool isRequired = false)
            : this(regex, "{0}字段有误")
        {
            base.IsRequired = isRequired;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="regex">正则</param>
        /// <param name="errorMessage">校验失败提示信息</param>
        /// <param name="isRequired">是否必填</param>
        public RegexAttribute(string regex, string errorMessage, bool isRequired = false)
        {
            this.regex = regex;
            this.ErrorMessage = errorMessage;
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

            return new Regex(regex).IsMatch(value.ToString());
        }
    }
}
