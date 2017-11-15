using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Web2017.Models
{
    /// <summary>
    /// 标签校验接口扩展方法
    /// </summary>
    public static class TagCheckExtension
    {
        private static TagCheckResult _result = null;

        /// <summary>
        /// 执行校验对象属性值是否合法
        /// </summary>
        /// <param name="obj">待校验对象</param>
        /// <returns></returns>
        public static TagCheckResult ExecTagCheck(this ITagCheck obj)
        {
            _result = new TagCheckResult();

            PropertyInfo[] infos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in infos)
            {
                //获取数据校验特性。
                Attribute[] attrs = Attribute.GetCustomAttributes(p, typeof(TagCheckAttribute), false);
                if (attrs.Length <= 0)
                {
                    continue;
                }

                //获取名称描述特性
                //CaptionAttribute caption = Attribute.GetCustomAttribute(p, typeof(CaptionAttribute), false) as CaptionAttribute;
                object value = p.GetValue(obj);

                foreach (Attribute attr in attrs)
                {
                    TagCheckAttribute validate = attr as TagCheckAttribute;

                    if (
                        validate != null
                        && (/*必填字段 必须校验*/
                          validate.IsRequired ||
                          /* 不必填 当值不为空时校验*/
                          (!validate.IsRequired && value != null && !string.IsNullOrEmpty(value.ToString())))
                        )
                    {
                        _result = GetCheckResult(validate, value, p.Name);
                        //_result = GetCheckResult(validate, value, caption);
                        if (!_result.IsSuccess)
                        {
                            return _result;
                        }
                    }
                }
            }
            return _result;
        }

        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="validate">校验规则</param>
        /// <param name="value">待校验值</param>
        /// <param name="caption">描述</param>
        /// <returns></returns>
        private static TagCheckResult GetCheckResult(TagCheckAttribute validate, object value, string propName)
        {
            _result = new TagCheckResult();

            if (!validate.StandbyCheck(value))
            {
                _result.IsSuccess = false;
                _result.ErrorMessage = validate.GetErrorMessage(propName);
            }
            return _result;
        }
        //private static TagCheckResult GetCheckResult(TagCheckAttribute validate, object value, CaptionAttribute caption)
        //{
        //    _result = new TagCheckResult();

        //    if (!validate.StandbyCheck(value))
        //    {
        //        _result.IsSuccess = false;
        //        if (caption == null)
        //        {
        //            _result.ErrorMessage = validate.GetErrorMessage();
        //        }
        //        else
        //        {
        //            _result.ErrorMessage = validate.GetErrorMessage(caption.Name);
        //        }
        //    }
        //    return _result;
        //}
    }
}
