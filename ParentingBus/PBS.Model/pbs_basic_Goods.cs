using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_Goods
    {
        public pbs_basic_Goods()
        { }
        #region Model
        private int _goodsid;
        private string _goodsname;
        private decimal _marketprice = 0M;
        private decimal _sellingprice = 0M;
        private string _goodsdesc;
        private int _goodsclassid;
        private int _goodstypeid;
        private int _agerangeid;
        private int _regionid;
        private string _goodsmainimgurl;
        private string _visittime1;
        private string _visittime2;
        private string _visittime3;
        private string _visittime4;
        private string _visittime5;
        private string _longitude;
        private string _latitude;
        private int _goodsstatus = 0;
        private int _isdelete;
        private int _isdisplayhome = 0;
        private DateTime _createtime = DateTime.Now;
        private DateTime _updatetime = DateTime.Now;
        private Nullable<int> _creatorid;
        private string _remark;
        private string _responsibleperson;
        private decimal _responsiblepersonprofit = 0M;
        private int _goodscount;
        private decimal _goodscost;
        private int _activityclassId;
        private decimal _platformcost;
        private decimal _othercost;

        /// <summary>
        /// 商品ID
        /// </summary>
        public int GoodsId
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            set { _goodsname = value; }
            get { return _goodsname; }
        }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice
        {
            set { _marketprice = value; }
            get { return _marketprice; }
        }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SellingPrice
        {
            set { _sellingprice = value; }
            get { return _sellingprice; }
        }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string GoodsDesc
        {
            set { _goodsdesc = value; }
            get { return _goodsdesc; }
        }
        /// <summary>
        /// 商品分类Id
        /// </summary>
        public int GoodsClassId
        {
            set { _goodsclassid = value; }
            get { return _goodsclassid; }
        }
        /// <summary>
        /// 商品类型Id
        /// </summary>
        public int GoodsTypeId
        {
            set { _goodstypeid = value; }
            get { return _goodstypeid; }
        }
        /// <summary>
        /// 年龄范围Id
        /// </summary>
        public int AgeRangeId
        {
            set { _agerangeid = value; }
            get { return _agerangeid; }
        }
        /// <summary>
        /// 区域Id
        /// </summary>
        public int RegionId
        {
            set { _regionid = value; }
            get { return _regionid; }
        }
        /// <summary>
        /// 商品主图路径
        /// </summary>
        public string GoodsMainImgUrl
        {
            set { _goodsmainimgurl = value; }
            get { return _goodsmainimgurl; }
        }
        /// <summary>
        /// 参加时间1
        /// </summary>
        public string VisitTime1
        {
            set { _visittime1 = value; }
            get { return _visittime1; }
        }
        /// <summary>
        /// 参加时间2
        /// </summary>
        public string VisitTime2
        {
            set { _visittime2 = value; }
            get { return _visittime2; }
        }
        /// <summary>
        /// 参加时间3
        /// </summary>
        public string VisitTime3
        {
            set { _visittime3 = value; }
            get { return _visittime3; }
        }
        /// <summary>
        /// 参加时间4
        /// </summary>
        public string VisitTime4
        {
            set { _visittime4 = value; }
            get { return _visittime4; }
        }
        /// <summary>
        /// 参加时间5
        /// </summary>
        public string VisitTime5
        {
            set { _visittime5 = value; }
            get { return _visittime5; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude
        {
            set { _longitude = value; }
            get { return _longitude; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude
        {
            set { _latitude = value; }
            get { return _latitude; }
        }
        /// <summary>
        /// 商品状态
        /// </summary>
        public int GoodsStatus
        {
            set { _goodsstatus = value; }
            get { return _goodsstatus; }
        }
        /// <summary>
        /// 是否首页显示(0不显示，1显示)
        /// </summary>
        public int IsDisplayHome
        {
            set { _isdisplayhome = value; }
            get { return _isdisplayhome; }
        }
        /// <summary>
        /// 是否删除 0未删除，1删除
        /// </summary>
        public int IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }

        /// <summary>
        /// 创建者Id
        /// </summary>
        public Nullable<int> CreatorId
        {
            set { _creatorid = value; }
            get { return _creatorid; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        public string ResponsiblePerson
        {
            set { _responsibleperson = value; }
            get { return _responsibleperson; }
        }

        public decimal ResponsiblePersonProfit
        {
            set { _responsiblepersonprofit = value; }
            get { return _responsiblepersonprofit; }
        }

        public int GoodsCount
        {
            set { _goodscount = value; }
            get { return _goodscount; }
        }

        public decimal GoodsCost
        {
            set { _goodscost = value; }
            get { return _goodscost; }
        }

        public int ActivityClassId
        {
            set { _activityclassId = value; }
            get { return _activityclassId; }
        }

        public decimal PlatformCost
        {
            set { _platformcost = value; }
            get { return _platformcost; }
        }

        public decimal OtherCost
        {
            set { _othercost = value; }
            get { return _othercost; }
        }

        #endregion Model

    }

    public class pbs_basic_GoodsAdmin : pbs_basic_Goods
    {
        public string RegionName { get; set; }
        public int SellCount { get; set; }
    }

    public class pbsBasicGoodsAdminListResult
    {
        public List<pbs_basic_GoodsAdmin> List { get; set; }
    }


}
