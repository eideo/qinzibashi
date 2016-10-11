using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    public class pbs_sys_users
    {
        #region Model
        private int _id;
        private string _loginid;
        private string _userpwd;
        private string _nickname;
        private DateTime? _addtime = DateTime.Now;
        private string _remark;
        private int _role;
        private string _address;
        private string _phone;
        private string _email;
        private string _photo;
        
        /// <summary>
        /// 编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string loginId
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string userPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// 备注名
        /// </summary>
        public string nickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? addTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 角色
        /// </summary>
        public int role
        {
            set { _role = value; }
            get { return _role; }
        }

        public string address
        {
            set { _address = value; }
            get { return _address; }
        }

        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }

        public string email
        {
            set { _email = value; }
            get { return _email; }
        }

        public string photo
        {
            set { _photo = value; }
            get { return _photo; }
        }


        #endregion Model
    }

    public class pbs_sys_usersView : pbs_sys_users {
        public string RoleName { get; set; }
    }

    public class pbsSysUserViewListResult {
        public List<pbs_sys_usersView> sysUsersViewList { get; set; }
    }
}
