using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_MyShareProfit
    {
        public int ShareId { get; set; }
        public int GoodsId { get; set; }
        public int ShareLevel { get; set; }
        public decimal Profit { get; set; }
        public int UserId { get; set; }
        public int FromShareOrderId { get; set; }
        public int CurrentShareOrderId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class MyShareProfitResult {
        public decimal Profit { get; set; }
        public string Dtime { get; set; }
        public string PCount { get; set; }
    }

    public class pbs_basic_ShareDetail
    {
        public long Id { get; set; }
        public string NickName { get; set; }
        public int UserId { get; set; }
        public int ShareCount { get; set; }
        public decimal Profit { get; set; }
    }


}
