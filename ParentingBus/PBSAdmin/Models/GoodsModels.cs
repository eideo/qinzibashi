using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBSAdmin.Models
{
    public class GoodsModels
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品简称
        /// </summary>
        public string SimpleName { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SellingPrice { get; set; }
        /// <summary>
        /// 包装规格
        /// </summary>
        public string PackageFmt { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>
        public string GoodsIntro { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string GoodsDesc { get; set; }
        /// <summary>
        /// 商品分类Id
        /// </summary>
        public int GoodsClassId { get; set; }
        /// <summary>
        /// 商品品牌Id
        /// </summary>
        public int GoodsBrandId { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public int GoodsUnit { get; set; }
        /// <summary>
        /// 商品主图路径
        /// </summary>
        public string GoodsMainImgUrl { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public int GoodsStatus { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 是否首页显示(0不显示，1显示)
        /// </summary>
        public int IsDisplayHome { get; set; }

        /// <summary>
        /// 创建者Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// 是否删除 0未删除，1删除
        /// </summary>
        public int IsDelete { get; set; }

        public List<GoodsView> GoodsViewList { get; set; }

        public List<FirstClassItem> FirstItemList { get; set; }

        public List<AllBrandItem> AllItemList { get; set; }

    }

    public class GoodsView
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SellingPrice { get; set; }
        /// <summary>
        /// 商品分类Id
        /// </summary>
        public int GoodsClassId { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string GoodsClassName { get; set; }
        /// <summary>
        /// 商品品牌Id
        /// </summary>
        public int GoodsBrandId { get; set; }
        /// <summary>
        /// 商品品牌名称
        /// </summary>
        public string GoodsBrandName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public int GoodsStatus { get; set; }
        /// <summary>
        /// 创建者Id
        /// </summary>
        public int CreatorId { get; set; }
        /// <summary>
        /// 创建者名称
        /// </summary>
        public string NickName { get; set; }
    }
}