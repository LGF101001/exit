using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPT.Hex.Models
{
    public class AuditFeedback : ITagCheck
    {
        public AuditFeedback()
        { }
        #region Model
        private long _afid;
        private long? _afcompanyid;
        private int? _aftype;
        private bool _afisusable;
        private DateTime? _afaddtime;
        private long? _addlgaccid;
        private long? _afrelevanceid;
        private string _afauditopinion;
        private string _afremark;
        /// <summary>
        /// 表AuditFeedback主键ID
        /// </summary>
        public long AFID
        {
            set { _afid = value; }
            get { return _afid; }
        }
        /// <summary>
        /// 所属公司ID
        /// </summary>
        public long? AFCompanyID
        {
            set { _afcompanyid = value; }
            get { return _afcompanyid; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public int? AFType
        {
            set { _aftype = value; }
            get { return _aftype; }
        }
        /// <summary>
        /// 是否可用 默认为1  0 不可用 1 可用
        /// </summary>
        public bool AFIsUsable
        {
            set { _afisusable = value; }
            get { return _afisusable; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AFAddTime
        {
            set { _afaddtime = value; }
            get { return _afaddtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? AddLgAccID
        {
            set { _addlgaccid = value; }
            get { return _addlgaccid; }
        }
        /// <summary>
        /// 关联ID
        /// </summary>
        public long? AFRelevanceID
        {
            set { _afrelevanceid = value; }
            get { return _afrelevanceid; }
        }

        /// <summary>
        /// 审核意见
        /// </summary>
        [StringLength(0, 20, PropNecessity.NoNeed)]
        public string AFAuditOpinion
        {
            set { _afauditopinion = value; }
            get { return _afauditopinion; }
        }
        /// <summary>
        ///备注
        /// </summary>
        //[Regex(RegexCheckType.Chinese, "备注有误", PropNecessity.Need)]
        [StringLength(0, 100, PropNecessity.Need)]
        public string AFRemark
        {
            set { _afremark = value; }
            get { return _afremark; }
        }

        private string _email;
        [Regex(Constants.Email, "Email格式不正确", PropNecessity.Need)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _phone;
        [Regex(Constants.Phone, "手机号码格式不正确", PropNecessity.NoNeed)]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        #endregion Model
    }
}
