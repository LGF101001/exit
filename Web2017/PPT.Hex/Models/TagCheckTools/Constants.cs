using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPT.Hex.Models
{
    /// <summary>
    /// 常量 （正则表达式）
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// 手机号验证（要求130-189的段手机号码）
        /// </summary>
        public const string Phone = "^1(3|4|5|7|8)\\d{9}$";

        /// <summary>
        /// 电话号码或传真
        /// </summary>
        public const string Fax = "^(d{3,4}-)?d{7,8}$";

        /// <summary>
        /// 中文字符正则表达式（只允许输入中文且不包含任何标点符号等）
        /// </summary>
        public const string Chinese = "^[\u4E00-\u9FFF]+$";

        /// <summary>
        /// 邮箱验证
        /// </summary>
        public const string Email = "^([a-zA-Z0-9]+[_|_|-|-|.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|_|-|-|.]?)*[a-zA-Z0-9]+.[a-zA-Z]{2,3}$";

        /// <summary>
        /// 必须存在数字和字母，最大长度为8位
        /// </summary>
        public const string EightBit_NUM_Letter = "^(?=.*?[a-zA-Z])(?=.*?[0-9])[a-zA-Z0-9]{1,8}$";

        /// <summary>
        /// 驾照验证 （可以输入数字与字母）
        /// </summary>
        public const string  License = "^[0-9a-zA-Z]*$";

        /// <summary>
        /// 数字和字母的组合
        /// </summary>
        public const string Only_NUM_Letter = "^[A-Za-z0-9]+$";

    }
}
