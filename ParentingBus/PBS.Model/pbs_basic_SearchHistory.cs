using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_SearchHistory
    {
        public int HistoryId { get; set; }
        public int SearchId { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbs_basic_SearchHistoryView: pbs_basic_SearchHistory
    {
        public string SearchNickName { get; set; }
        public int GoodsId { get; set; }
    }

}
