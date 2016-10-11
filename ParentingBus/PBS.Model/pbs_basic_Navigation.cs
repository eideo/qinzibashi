using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{

    [Serializable]
    public class pbs_basic_Navigation
    {
        public int NavigationId { get; set; }
        public string NavigationName { get; set; }
        public string NavigationUrl { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }
    public class pbsBasicNavigationListResult
    {
        public List<pbs_basic_Navigation> List { get; set; }
    }
}
