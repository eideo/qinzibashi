using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_GoodsType
    {
        public int GoodsTypeId { get; set; }
        public string GoodsTypeName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }

        public string GoodsTypeDesc { get; set; }

        public decimal GoodsTypePrice { get; set; }
    }

    public class pbsBasicGoodsTypeListResult
    {
        public List<pbs_basic_GoodsType> List { get; set; }
    }
}
