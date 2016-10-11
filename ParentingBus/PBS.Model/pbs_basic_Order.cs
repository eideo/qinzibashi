using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_Order
    {
        public int OrderId { get; set; }
        public int GoodsId { get; set; }
        public int Count { get; set; }
        public System.DateTime VisitTime { get; set; }
        public int UserId { get; set; }
        public Nullable<int> OrderMemberId { get; set; }
        public decimal OrderPrice { get; set; }
        public int VoucherId { get; set; }
        public int OrderStatus { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }

        public int GoodsPackageId { get; set; }
    }

    public class pbs_basic_OrderView: pbs_basic_Order
    {
        public string GoodsName { get; set; }

        public string GoodsMainImgUrl { get; set; }

        public string GoodsPackageName { get; set; }
    }

    public class pbs_basic_OrderViewExport
    {
        public string OrderId { get; set; }
        public string GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string Count { get; set; }
        public string VisitTime { get; set; }
        public string UserId { get; set; }
        public string OrderPrice { get; set; }
        public string OrderStatus { get; set; }
        public System.DateTime CreateTime { get; set; }
    }

    public class pbs_basic_OrderViewRN : pbs_basic_OrderView
    {
        public long RNum { get; set; }
    }

    public class SaleMemberReportSQL
    {
        public int GoodsId { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal ResponsiblePersonProfit { get; set; }
        public decimal GoodsCost { get; set; }
        public int OrderCount { get; set; }
        public string GoodsName { get; set; }
    }

    public class SaleMemberReport
    {
        public decimal OrderPrice { get; set; }
        public decimal OrderCost { get; set; }
        public decimal ActivityGrossProfit { get; set; }
        public decimal DC1 { get; set; }
        public decimal DC2 { get; set; }
        public decimal DC3 { get; set; }
        public decimal SurplusProfit { get; set; }
        public decimal PayCount { get; set; }
        public decimal ResponsiblePersonProfit { get; set; }
        public decimal FinalGrossProfit { get; set; }
        public string GoodsName { get; set; }

    }

    public class SaleGoodsReport
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public int ActShowCount { get; set; }
        public int PeopleCount { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal PlatformCost { get; set; }
        public decimal ResponsiblePersonProfit { get; set; }
        public decimal SumShareProfit { get; set; }
        public decimal OtherCost { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalProfit { get; set; }

    }

}
