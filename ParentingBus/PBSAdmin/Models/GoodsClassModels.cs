using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBSAdmin.Models
{
    public class GoodsClassModels
    {
        public int GoodsClassId { get; set; } //商品分类编号
        public string GoodsClassName { get; set; } //商品分类名称

        public int GoodsClassParentId { get; set; } //商品分类父编号

        public int OderBy { get; set; } //排序
        public List<FirstClassItem> FirstItemList { get; set; }

        public List<AllClassItem> AllItemList { get; set; }
    }

    public class FirstClassItem
    {
        public int GoodsClassId { get; set; } //商品分类编号
        public string GoodsClassName { get; set; } //商品分类名称

        public int GoodsClassParentId { get; set; } //商品分类父编号

        public int OderBy { get; set; } //排序
        public List<SecondClassItem> SecondItemList { get; set; }
    }

    public class SecondClassItem
    {
        public int GoodsClassId { get; set; } //商品分类编号
        public string GoodsClassName { get; set; } //商品分类名称

        public int GoodsClassParentId { get; set; } //商品分类父编号

        public int OderBy { get; set; } //排序
        public List<ThirdClassItem> ThirdItemList { get; set; }
    }

    public class ThirdClassItem
    {
        public int GoodsClassId { get; set; } //商品分类编号
        public string GoodsClassName { get; set; } //商品分类名称

        public int GoodsClassParentId { get; set; } //商品分类父编号

        public int OderBy { get; set; } //排序
    }
    public class AllClassItem
    {
        public int GoodsClassId { get; set; } //商品分类编号
        public string GoodsClassName { get; set; } //商品分类名称

        public int GoodsClassParentId { get; set; } //商品分类父编号

        public int OderBy { get; set; } //排序
    }
}