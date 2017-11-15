using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2017.Models
{
    /// <summary>
    /// 标签校验
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class TagCheckAttribute : Attribute
    {
        /// <summary>
        /// 是否必填 (默认不可空)
        /// </summary>
        public bool IsRequired { get; set; } = true;
        /// <summary>
        /// 校验不通过提示信息
        /// </summary>
        protected string ErrorMessage { get; set; }

        /// <summary>
        /// 校验数据是否合法 (待命中)
        /// </summary>
        /// <param name="value">待校验的值</param>
        /// <returns></returns>
        public abstract bool StandbyCheck(object value);

        /// <summary>
        /// 获取检验不通过提示信息
        /// </summary>
        /// <param name="name">字段名称</param>
        /// <returns></returns>
        public string GetErrorMessage(string name = "")
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "该字段";
            }
            //注意
            //string.Format("XX有误", ID)=="XX有误";
            //string.Format("{0}字段有误", ID)=="ID字段有误";
            return string.Format(this.ErrorMessage, name);
        }
    }
}
