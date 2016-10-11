using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_ReviewHistory
    {
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewContent { get; set; }
        public string ReviewUrl { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbsBasicReviewHistoryListResult
    {
        public List<pbs_basic_ReviewHistory> List { get; set; }
    }
}
