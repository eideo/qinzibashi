using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{

    [Serializable]
    public class pbs_basic_Comment
    {
        public int CommentId { get; set; }
        public int GoodsId { get; set; }
        public int UserId { get; set; }
        public string CommentContent { get; set; }
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Url3 { get; set; }
        public string Url4 { get; set; }
        public string Url5 { get; set; }
        public int Score { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbs_basic_CommentView: pbs_basic_Comment
    {
        public string LoginName { get; set; }
        public string PhotoUrl { get; set; }
    }
}
