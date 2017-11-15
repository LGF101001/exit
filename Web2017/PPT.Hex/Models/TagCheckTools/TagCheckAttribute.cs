using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPT.Hex.Models
{
    /// <summary>
    /// 标签校验抽象类
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class TagCheckAttribute : Attribute
    {
        /// <summary>
        /// 是否必填 (默认必填)
        /// </summary>
        public bool IsRequired { get; set; } = true;
        /// <summary>
        /// 校验不通过提示信息
        /// </summary>
        protected string ErrMsg { get; set; }

        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="value">待校验的值</param>
        /// <returns></returns>
        public abstract bool StandbyCheck(object value);

        /// <summary>
        /// 获取检验不通过提示信息
        /// </summary>
        /// <param name="name">字段名称</param>
        /// <returns></returns>
        public string GetErrMsg(string name = "")
        {
            return string.Format(this.ErrMsg, name);
        }
    }
}
