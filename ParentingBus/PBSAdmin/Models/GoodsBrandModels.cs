using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBSAdmin.Models
{
    public class GoodsBrandModels
    {
        public int GoodsBrandId { get; set; } //商品品牌编号
        public string GoodsBrandName { get; set; } //商品品牌名称

        public string GoodsBrandImgUrl { get; set; } //商品品牌图片Url

        public int OderBy { get; set; } //排序

        public int GoodsClassId { get; set; } //商品分类编号

        public List<AllBrandItem> AllItemList { get; set; }
        public List<FirstClassItem> FirstItemList { get; set; }
    }

    public class AllBrandItem
    {
        public int GoodsBrandId { get; set; } //商品品牌编号
        public string GoodsBrandName { get; set; } //商品品牌名称

        public string GoodsBrandImgUrl { get; set; } //商品品牌图片Url

        public int OderBy { get; set; } //排序

        public int GoodsClassId { get; set; } //商品分类编号
    }
}