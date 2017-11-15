using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PPT.Hex.Models
{
    /// <summary>
    /// 标签校验接口扩展方法
    /// </summary>
    public static class TagCheckExtension
    {
        private static TagCheckResult _tagResult = null;

        /// <summary>
        /// 执行校验对象属性值是否合法
        /// </summary>
        /// <param name="obj">待校验对象</param>
        /// <returns></returns>
        public static TagCheckResult ExecTagCheck(this ITagCheck obj)
        {
            _tagResult = new TagCheckResult();

            Type type = obj.GetType();
            if (!(!type.IsAbstract && type.IsClass && type.IsPublic))
            {
                _tagResult.IsOK = false;
                _tagResult.ErrMsg = "对象类型错误";

                return _tagResult;
            }

            //PropertyInfo[] propInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //IEnumerable<PropertyInfo> propList = new  List<PropertyInfo>();
            //if (propInfos.Length > 0)
            //{
            //    propList = propInfos.Where(prop => prop.CustomAttributes.Count() > 0);
            //}

            IEnumerable<PropertyInfo> propInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(prop => prop.CustomAttributes.Count() > 0);

            foreach (PropertyInfo prop in propInfos)
            {
                //IEnumerable<CustomAttributeData> AttrData = prop
                //                                .CustomAttributes
                //                                .Where(cusAttrData => cusAttrData.AttributeType.BaseType== typeof(TagCheckAttribute));

                //获取数据校验特性。
                Attribute[] attrs = Attribute.GetCustomAttributes(prop, typeof(TagCheckAttribute), false);
                if (attrs.Length <= 0)
                {
                    continue;
                }

                foreach (Attribute attr in attrs)
                {
                    TagCheckAttribute tagAttr = attr as TagCheckAttribute;
                    object value = prop.GetValue(obj);

                    if (/*不可空类型 必须校验*/
                          tagAttr.IsRequired ||
                          /* 可空类型 当值不为空时校验*/
                          (!tagAttr.IsRequired && value != null && !string.IsNullOrEmpty(value.ToString()))
                        )
                    {
                        _tagResult = GetCheckResult(tagAttr, value, prop.Name);
                        if (!_tagResult.IsOK)
                        {
                            return _tagResult;
                        }
                    }
                }
            }
            return _tagResult;
        }


        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="tagAttr">校验标签</param>
        /// <param name="value">待校验值</param>
        /// <param name="propName">属性名</param>
        /// <returns></returns>
        private static TagCheckResult GetCheckResult(TagCheckAttribute tagAttr, object value, string propName)
        {
            _tagResult = new TagCheckResult();

            if (!tagAttr.StandbyCheck(value))
            {
                _tagResult.IsOK = false;
                _tagResult.ErrMsg = tagAttr.GetErrMsg(propName);
            }
            return _tagResult;
        }
    }
}
