using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_HomePicture
    {
        public int HomePictureId { get; set; }
        public string Url { get; set; }
        public int OrderBy { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
        public string LinkUrl { get; set; }
    }

    public class pbsBasicHomePictureListResult
    {
        public List<pbs_basic_HomePicture> List { get; set; }
    }
}
