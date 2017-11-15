using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPT.Hex.Models
{
    /// <summary>
    /// 整数范围校验
    /// </summary>
    public class IntRangeAttribute : TagCheckAttribute
    {
        private int _min = -1;
        private int _max = -1; 

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="isRequired">是否必填</param>
        public IntRangeAttribute(int min, int max, bool isRequired = true)
            : this(min, max, string.Format("{0}应在{1}到{2}之间", "{0}", min, max))
        {
            this.IsRequired = isRequired;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="errMsg">校验失败提示信息</param>
        /// <param name="isRequired">是否必填</param>
        public IntRangeAttribute(int min, int max, string errMsg, bool isRequired = true)
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

            int v;
            if (!int.TryParse(value.ToString(), out v))
            {
                return false;
            }

            return v >= _min && v <= _max;
        }
    }
}
