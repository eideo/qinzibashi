using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_MyCollection
    {
        public int MyCollectionId { get; set; }
        public int UserId { get; set; }
        public int GoodsId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbs_basic_MyCollectionView : pbs_basic_MyCollection
    {
        public string GoodsName { get; set; }
        public string GoodsMainImgUrl { get; set; }
        public string VisitTime1 { get; set; }
        public string VisitTime2 { get; set; }
        public string VisitTime3 { get; set; }
        public string VisitTime4 { get; set; }
        public string VisitTime5 { get; set; }
        public decimal MarketPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string GoodsAdress { get; set; }
    }

}
