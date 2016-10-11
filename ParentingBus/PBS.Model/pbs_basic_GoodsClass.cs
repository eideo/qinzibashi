using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_GoodsClass
    {
        public int GoodsClassId { get; set; }
        public string GoodsClassName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbsBasicGoodsClassListResult
    {
        public List<pbs_basic_GoodsClass> List { get; set; }
    }
}
