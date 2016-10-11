using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_Users
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Pwd { get; set; }
        public string NickName { get; set; }
        public string PhotoUrl { get; set; }
        public string Phone { get; set; }
        public int BabySex { get; set; }
        public string BabyBirthday { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
        public string WeiXinCode { get; set; }
        public string MyAdress { get; set; }
    }

    public class pbsBasicUsersListResult
    {
        public List<pbs_basic_Users> List { get; set; }
    }

    public class pbs_basic_UsersDetail
    {
        public string NickName { get; set; }
        public int UserId { get; set; }
        public string BabyBirthday { get; set; }
        public string Phone { get; set; }
        public int BuyCount { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SumProfit { get; set; }

    }

    public class pbsBasicUsersDetailListResult
    {
        public List<pbs_basic_UsersDetail> List { get; set; }
    }

    public class pbs_basic_UsersOrderDetail
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public System.DateTime VisitTime { get; set; }
        public string RegionName { get; set; }
        public decimal SellingPrice { get; set; }
        public int Count { get; set; }
        public decimal OrderPrice { get; set; }

    }

    public class pbsBasicUsersOrderDetailListResult
    {
        public List<pbs_basic_UsersOrderDetail> List { get; set; }
    }

}
