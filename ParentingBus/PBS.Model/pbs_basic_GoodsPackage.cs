using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{

    [Serializable]
    public class pbs_basic_GoodsPackage
    {
        public int GoodsPackageId { get; set; }
        public string GoodsPackageName { get; set; }
        public decimal GoodsPackagePrice { get; set; }
        public int GoodsTypeId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbs_basic_GoodsPackageView: pbs_basic_GoodsPackage
    {
        public string GoodsTypeName { get; set; }
    }

    public class pbsBasicGoodsPackageListResult
    {
        public List<pbs_basic_GoodsPackage> list { get; set; }
    }

    public class pbsBasicGoodsPackageViewListResult
    {
        public List<pbs_basic_GoodsPackageView> list { get; set; }
    }

}
