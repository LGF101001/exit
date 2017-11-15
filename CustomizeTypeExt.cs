using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    /// <summary>
    /// 自定义类型扩展方法
    /// </summary>
    public static class CustomizeTypeExt
    {
        /// <summary>
        /// string转in类型 不适合string为"0"转换
        /// </summary>
        /// <param name="str">string类型扩展</param>
        /// <returns>转失败 int=0  </returns>
        public static int StringToInt(this string str)
        {
            int GetInt;
            int.TryParse(str, out GetInt);
            return GetInt;
        }

        /// <summary>
        /// string转long类型
        /// </summary>
        /// <param name="str">string类型扩展</param>
        /// <returns>转换失败返回0</returns>
        public static long StringToLong(this string str)
        {
            long GetLong;
            long.TryParse(str, out GetLong);
            return GetLong;
        }
        /// <summary>
        /// string转DateTime
        /// </summary>
        /// <param name="str">String类型扩展</param>
        /// <returns>转失败{0001/1/1 0:00:00}</returns>
        public static DateTime StringToDateTime(this string str)
        {
            DateTime dt;
            DateTime.TryParse(str, out dt);
            return dt;
        }
        /// <summary>
        /// String转Double 保留2位小数
        /// </summary>
        /// <param name="str">String类型扩展</param>
        /// <returns></returns>
        public static Double StringToDouble(this string str)
        {
            double db;
            Double.TryParse(str,out db);
            return Math.Round(db, 2); 
        }

        /// <summary>
        /// DateTime转为long
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ConvertDataTimeLong(DateTime dt)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan toNow = dt.Subtract(dtStart);
            long timeStamp = toNow.Ticks;
            timeStamp = long.Parse(timeStamp.ToString().Substring(0, timeStamp.ToString().Length - 4));
            return timeStamp;
        }
    }
}
