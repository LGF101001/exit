using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2017.Models
{
    /// <summary>
    /// 执行标签检查结果
    /// </summary>
    public class TagCheckResult
    {
        public TagCheckResult()
        {
            this.IsSuccess = true;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="isSuccess">是否校验通过</param>
        /// <param name="errorMessage">检验不通过提示信息</param>
        public TagCheckResult(bool isSuccess, string errorMessage)
        {

            this.IsSuccess = isSuccess;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 是否校验通过
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 检验不通过提示信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
