using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int ParentRegionId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }

        public List<pbs_basic_RegionChildren> regionChildrenList { get; set; }

    }

    public class pbs_basic_RegionChildren
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int ParentRegionId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
        public List<pbs_basic_RegionChildrenChildren> regionChildrenList { get; set; }

    }

    public class pbs_basic_RegionChildrenChildren
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int ParentRegionId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }

    }

    public class pbsBasicRegionListResult
    {
        public List<pbs_basic_Region> List { get; set; }
    }

    public class pbsBasicRegionParentSelect {
        public List<pbs_basic_Region> regionParentList { get; set; }
    }

}
