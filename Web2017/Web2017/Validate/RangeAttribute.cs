using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2017.Models
{
    public class RangeAttribute : TagCheckAttribute
    {
        private int min = -1;
        private int max = -1;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public RangeAttribute(int min, int max)
            : this(min, max, string.Format("{0}应在{1}到{2}之间", "{0}", min, max))
        {

        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="errorMessage">校验失败提示信息</param>
        public RangeAttribute(int min, int max, string errorMessage)
        {
            this.min = min;
            this.max = max;
            this.ErrorMessage = errorMessage;
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

            decimal v;
            if (!decimal.TryParse(value.ToString(), out v))
            {
                return false;
            }

            return v >= min && v <= max;
        }
    }
}
