using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{

    [Serializable]
    public class pbs_basic_AgeRange
    {
        public int AgeRangeId { get; set; }
        public string AgeRangeName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbsBasicAgeRangeListResult
    {
        public List<pbs_basic_AgeRange> List { get; set; }
    }
}
