using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBSAdmin.Models
{
    public class MenuModels
    {
        public List<ParentItem> ParentItemList { get; set; }
        public string UserId { get; set; }
        public string RoleCode { get; set; }
    }
    public class ParentItem //最外层栏目
    {
        public string NodeId { get; set; }
        public string NodeName { get; set; }
        public string ParentId { get; set; }
        public string NodeUrl { get; set; }
        public string NodeGroup { get; set; }
        public bool IsOrNullExists { get; set; }
        public List<BrotherItem> BrotherList { get; set; }
    }

    public class BrotherItem //中间层栏目
    {
        public string NodeId { get; set; }
        public string NodeName { get; set; }
        public string ParentId { get; set; }
        public string NodeUrl { get; set; }
        public string NodeGroup { get; set; }
        public bool IsOrNullExists { get; set; }
        public List<ChildrenItem> ChildrenList { get; set; }
    }

    public class ChildrenItem //子栏目
    {
        public string NodeId { get; set; }
        public string NodeName { get; set; }
        public string ParentId { get; set; }
        public string NodeUrl { get; set; }
        public string NodeGroup { get; set; }
        public bool IsOrNullExists { get; set; }
    }
}