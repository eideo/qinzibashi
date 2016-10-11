using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_OrderMember
    {
        public int OrderMemberId { get; set; }
        public int MemberId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }
}
