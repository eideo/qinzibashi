using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_Members
    {
        public int MembersId { get; set; }
        public string MemberName { get; set; }
        public int Sex { get; set; }
        public int RelationType { get; set; }
        public string Birthday { get; set; }
        public string IDNum { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public int CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbsBasicMembersListResult {
        public List<pbs_basic_Members> List { get; set; }
    }
}
