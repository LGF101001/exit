using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPT.Hex.Models
{
    /// <summary>
    /// 字符串长度校验
    /// </summary>
    public class StringLengthAttribute : TagCheckAttribute
    {
        private int _min = -1;
        private int _max = -1;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="min">最小长度</param>
        /// <param name="max">最大长度</param>
        /// <param name="isRequired">是否必填</param>
        public StringLengthAttribute(int min, int max, bool isRequired = true)
            : this(min, max, string.Format("{0}应在{1}到{2}之间", "{0}", min, max))
        {
            this.IsRequired = isRequired;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="min">最小长度</param>
        /// <param name="max">最大长度</param>
        /// <param name="errMsg">校验失败提示信息</param>
        /// <param name="isRequired">是否必填</param>
        public StringLengthAttribute(int min, int max, string errMsg, bool isRequired = true)
        {
            this._min = min;
            this._max = max;
            this.ErrMsg = errMsg;
            this.IsRequired = isRequired;
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

            int len = value.ToString().Length;

            return len >= _min && len <= _max;
        }
    }
}
