using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_ActivityClass
    {
        public int ActivityClassId { get; set; }
        public string ActivityClassName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbsBasicActivityClassListResult
    {
        public List<pbs_basic_ActivityClass> List { get; set; }
    }
}