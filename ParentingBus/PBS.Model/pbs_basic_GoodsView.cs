using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    public class pbs_basic_GoodsView:pbs_basic_Goods
    {
        public string GoodsClassName { get; set; }
        public string GoodsTypeName { get; set; }
        public string AgeRangeName { get; set; }
        public string RegionName { get; set; }
        public int SellCount { get; set; }
    }

    public class pbsBasicGoodsViewListResult
    {
        public List<pbs_basic_GoodsView> List { get; set; }
    }

}
