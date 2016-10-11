using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PBS.Model;
using PBS.Server;
using PBSAdmin.Models;
using Utility;
using Newtonsoft.Json;

namespace PBSAdmin.Controllers
{
    public class ActivityController : Controller
    {
        #region 活动
        public ActionResult ActivityAdd(string goodsId)
        {
            #region 活动分类下拉列表
            ViewData["GoodsClassList"] = null;
            pbs_basic_GoodsClassService pbsBasicGoodsClassService = new pbs_basic_GoodsClassService();
            ResultInfo<List<pbs_basic_GoodsClass>> resultGoodsClass = pbsBasicGoodsClassService.GetAllGoodsClassList();
            if (resultGoodsClass.Result && resultGoodsClass.Data != null)
            {
                ViewData["GoodsClassList"] = resultGoodsClass.Data;
            }
            #endregion

            #region 活动筛选分类下拉列表
            ViewData["ActivityClassList"] = null;
            pbs_basic_ActivityClassService pbsBasicActivityClassService = new pbs_basic_ActivityClassService();
            ResultInfo<List<pbs_basic_ActivityClass>> resultActivityClass = pbsBasicActivityClassService.GetAllActivityClassList();
            if (resultActivityClass.Result && resultActivityClass.Data != null)
            {
                ViewData["ActivityClassList"] = resultActivityClass.Data;
            }
            #endregion

            #region 活动类型下拉列表
            ViewData["GoodsTypeList"] = null;
            pbs_basic_GoodsTypeService pbsBasicGoodsTypeService = new pbs_basic_GoodsTypeService();
            ResultInfo<List<pbs_basic_GoodsType>> resultGoodsType = pbsBasicGoodsTypeService.GetAllGoodTypeList();
            if (resultGoodsType.Result && resultGoodsType.Data != null)
            {
                ViewData["GoodsTypeList"] = resultGoodsType.Data;
            }
            #endregion

            #region 年龄范围下拉列表
            ViewData["AgeRangeList"] = null;
            pbs_basic_AgeRangeService pbsBasicAgeRangeService = new pbs_basic_AgeRangeService();
            ResultInfo<List<pbs_basic_AgeRange>> resultAgeRange = pbsBasicAgeRangeService.GetAllAgeRangeList();
            if (resultAgeRange.Result && resultAgeRange.Data != null)
            {
                ViewData["AgeRangeList"] = resultAgeRange.Data;
            }
            #endregion

            #region 区域下拉列表
            ViewData["RegionList"] = null;
            pbsBasicRegionParentSelect pbsRegionParentselect = new pbsBasicRegionParentSelect();
            pbsRegionParentselect.regionParentList = new List<pbs_basic_Region>();
            pbs_basic_RegionService pbsBasicRegionService = new pbs_basic_RegionService();
            ResultInfo<List<pbs_basic_Region>> resultParentItem = pbsBasicRegionService.GetThisRegionList(110100);
            //ResultInfo<List<pbs_basic_Region>> resultParentItem = pbsBasicRegionService.GetThisRegionList(110000);
            if (resultParentItem.Result && resultParentItem.Data != null && resultParentItem.Data.Count > 0)
            {
                foreach (pbs_basic_Region itemParent in resultParentItem.Data) //得到行集合
                {
                    pbs_basic_Region regionParent = new pbs_basic_Region();
                    regionParent.RegionId = itemParent.RegionId;
                    regionParent.RegionName = itemParent.RegionName;
                    regionParent.ParentRegionId = itemParent.ParentRegionId;
                    regionParent.CreateTime = itemParent.CreateTime;
                    regionParent.UpdateTime = itemParent.UpdateTime;
                    regionParent.CreatorId = itemParent.CreatorId;
                    regionParent.Remark = itemParent.Remark;
                    regionParent.regionChildrenList = new List<pbs_basic_RegionChildren>();
                    ResultInfo<List<pbs_basic_Region>> resultChildernItem = pbsBasicRegionService.GetThisRegionList(regionParent.RegionId);
                    if (resultChildernItem.Result && resultChildernItem.Data != null && resultChildernItem.Data.Count > 0)
                    {
                        foreach (pbs_basic_Region itemChildren in resultChildernItem.Data) //得到行集合
                        {
                            pbs_basic_RegionChildren regionChildern = new pbs_basic_RegionChildren();
                            regionChildern.RegionId = itemChildren.RegionId;
                            regionChildern.RegionName = itemChildren.RegionName;
                            regionChildern.ParentRegionId = itemChildren.ParentRegionId;
                            regionChildern.CreateTime = itemChildren.CreateTime;
                            regionChildern.UpdateTime = itemChildren.UpdateTime;
                            regionChildern.CreatorId = itemChildren.CreatorId;
                            regionChildern.Remark = itemChildren.Remark;
                            regionParent.regionChildrenList.Add(regionChildern);
                        }
                    }
                    pbsRegionParentselect.regionParentList.Add(regionParent);
                }
            }

            ViewData["RegionList"] = pbsRegionParentselect.regionParentList;
            #endregion

            #region 绑定活动信息
            pbs_basic_Goods pbsBasicGoods = new pbs_basic_Goods();
            pbsBasicGoods.GoodsId = 0;
            pbsBasicGoods.GoodsName = string.Empty;
            pbsBasicGoods.MarketPrice = 0m;
            pbsBasicGoods.SellingPrice = 0m;
            pbsBasicGoods.GoodsDesc = string.Empty;
            pbsBasicGoods.GoodsClassId = 0;
            pbsBasicGoods.GoodsTypeId = 0;
            pbsBasicGoods.AgeRangeId = 0;
            pbsBasicGoods.RegionId = 0;
            pbsBasicGoods.GoodsMainImgUrl = string.Empty;
            pbsBasicGoods.VisitTime1 = null;
            pbsBasicGoods.VisitTime2 = null;
            pbsBasicGoods.VisitTime3 = null;
            pbsBasicGoods.VisitTime4 = null;
            pbsBasicGoods.VisitTime5 = null;
            pbsBasicGoods.Longitude = string.Empty;
            pbsBasicGoods.Latitude = string.Empty;
            pbsBasicGoods.GoodsStatus = 0;
            pbsBasicGoods.IsDelete = 0;
            pbsBasicGoods.IsDisplayHome = 0;
            pbsBasicGoods.CreateTime = DateTime.Now;
            pbsBasicGoods.UpdateTime = DateTime.Now;
            pbsBasicGoods.CreatorId = 0;
            pbsBasicGoods.Remark = string.Empty;
            pbsBasicGoods.ResponsiblePerson = string.Empty;
            pbsBasicGoods.ResponsiblePersonProfit = 0m;
            pbsBasicGoods.GoodsCount = 0;
            pbsBasicGoods.GoodsCost = 0m;
            pbsBasicGoods.ActivityClassId = 0;
            pbsBasicGoods.PlatformCost = 0;
            pbsBasicGoods.OtherCost = 0;

            if (!string.IsNullOrEmpty(goodsId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(goodsId);
                pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
                ResultInfo<pbs_basic_Goods> resultGoodsItem = pbsBasicGoodsService.GetGoodsModelById(gid);
                if (resultGoodsItem.Result && resultGoodsItem.Data != null)
                {
                    pbsBasicGoods.GoodsId = resultGoodsItem.Data.GoodsId;
                    pbsBasicGoods.GoodsName = resultGoodsItem.Data.GoodsName;
                    pbsBasicGoods.MarketPrice = resultGoodsItem.Data.MarketPrice;
                    pbsBasicGoods.SellingPrice = resultGoodsItem.Data.SellingPrice;
                    pbsBasicGoods.GoodsDesc = resultGoodsItem.Data.GoodsDesc;
                    ResultInfo<bool> resultIsExistByGoodsClassId = pbsBasicGoodsClassService.IsExistByGoodsClassId(resultGoodsItem.Data.GoodsClassId);
                    if (resultIsExistByGoodsClassId.Result && resultIsExistByGoodsClassId.Data)
                    {
                        pbsBasicGoods.GoodsClassId = resultGoodsItem.Data.GoodsClassId;
                    }
                    ResultInfo<bool> resultIsExistByGoodsTypeId = pbsBasicGoodsTypeService.IsExistByGoodsTypeId(resultGoodsItem.Data.GoodsTypeId);
                    if (resultIsExistByGoodsTypeId.Result && resultIsExistByGoodsTypeId.Data)
                    {
                        pbsBasicGoods.GoodsTypeId = resultGoodsItem.Data.GoodsTypeId;
                    }
                    ResultInfo<bool> resultIsExistByAgeRangeId = pbsBasicAgeRangeService.IsExistByAgeRangeId(resultGoodsItem.Data.AgeRangeId);
                    if (resultIsExistByAgeRangeId.Result && resultIsExistByAgeRangeId.Data)
                    {
                        pbsBasicGoods.AgeRangeId = resultGoodsItem.Data.AgeRangeId;
                    }
                    pbsBasicGoods.RegionId = resultGoodsItem.Data.RegionId;
                    pbsBasicGoods.GoodsMainImgUrl = resultGoodsItem.Data.GoodsMainImgUrl;
                    pbsBasicGoods.VisitTime1 = resultGoodsItem.Data.VisitTime1;
                    pbsBasicGoods.VisitTime2 = resultGoodsItem.Data.VisitTime2;
                    pbsBasicGoods.VisitTime3 = resultGoodsItem.Data.VisitTime3;
                    pbsBasicGoods.VisitTime4 = resultGoodsItem.Data.VisitTime4;
                    pbsBasicGoods.VisitTime5 = resultGoodsItem.Data.VisitTime5;
                    pbsBasicGoods.Longitude = resultGoodsItem.Data.Longitude;
                    pbsBasicGoods.Latitude = resultGoodsItem.Data.Latitude;
                    pbsBasicGoods.GoodsStatus = resultGoodsItem.Data.GoodsStatus;
                    pbsBasicGoods.IsDelete = resultGoodsItem.Data.IsDelete;
                    pbsBasicGoods.IsDisplayHome = resultGoodsItem.Data.IsDisplayHome;
                    pbsBasicGoods.CreateTime = resultGoodsItem.Data.CreateTime;
                    pbsBasicGoods.UpdateTime = DateTime.Now;
                    pbsBasicGoods.CreatorId = resultGoodsItem.Data.CreatorId;
                    pbsBasicGoods.Remark = resultGoodsItem.Data.Remark;
                    pbsBasicGoods.ResponsiblePerson = resultGoodsItem.Data.ResponsiblePerson;
                    pbsBasicGoods.ResponsiblePersonProfit = resultGoodsItem.Data.ResponsiblePersonProfit;
                    pbsBasicGoods.GoodsCount = resultGoodsItem.Data.GoodsCount;
                    pbsBasicGoods.GoodsCost = resultGoodsItem.Data.GoodsCost;
                    pbsBasicGoods.ActivityClassId = resultGoodsItem.Data.ActivityClassId;
                    pbsBasicGoods.PlatformCost = resultGoodsItem.Data.PlatformCost;
                    pbsBasicGoods.OtherCost = resultGoodsItem.Data.OtherCost;
                }
                ViewBag.PageTitle = "修改活动";
            }
            else
            {
                ViewBag.PageTitle = "添加活动";
            }

            #endregion

            return View(pbsBasicGoods);
        }

        public ActionResult ActivityList()
        {
            pbsBasicGoodsAdminListResult result = new pbsBasicGoodsAdminListResult();
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<List<pbs_basic_GoodsAdmin>> resultinfo = pbsBasicGoodsService.GetGoodsAdminList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        /// <summary>
        /// 增加一条活动信息
        /// </summary>
        /// <param name="activitysName">活动名称</param>
        /// <param name="marketPrice">市场价</param>
        /// <param name="sellingPrice">销售价</param>
        /// <param name="activitysDesc">活动描述</param>
        /// <param name="activitysClassId">活动分类Id</param>
        /// <param name="activitysTypeId">活动类型Id</param>
        /// <param name="ageRangeId">年龄范围Id</param>
        /// <param name="regionId">区域范围Id</param>
        /// <param name="activitysMainImgUrl">活动主图路径</param>
        /// <param name="visitTime1">参加时间1</param>
        /// <param name="visitTime2">参加时间2</param>
        /// <param name="visitTime3">参加时间3</param>
        /// <param name="visitTime4">参加时间4</param>
        /// <param name="visitTime5">参加时间5</param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="activitysStatus">活动状态</param>
        /// <param name="isDisplayHome">是否首页显示</param>
        /// <param name="isDelete">是否删除</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者Id</param>
        /// <param name="remark">备注</param>
        /// <param name="responsiblePerson">负责人</param>
        /// <param name="activitysCount">名额</param>
        /// <param name="activityFilterClassId">活动筛选分类编号</param>
        /// <returns></returns>
        public JsonResult ActivityAddAjax(string activitysName, string marketPrice, string sellingPrice, string activitysDesc,
            string activitysClassId, string activitysTypeId, string ageRangeId, string regionId, string activitysMainImgUrl,
            string visitTime1, string visitTime2, string visitTime3, string visitTime4, string visitTime5,
            string longitude, string latitude, string activitysStatus, string isDisplayHome, string isDelete,
            string createTime, string updateTime, string creatorId, string remark, string responsiblePerson, string responsiblePersonProfit, string activitysCount, string activitysCost, string activityFilterClassId,string platformCost,string otherCost)
        {
            activitysDesc = HttpUtility.UrlDecode(activitysDesc);
            if (string.IsNullOrEmpty(activitysName))
            {
                return Json(new ResultModel<bool>(1, "请输入活动名称", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();

            ResultInfo<bool> resultIsExist = pbsBasicGoodsService.ExistsByGoodsName(activitysName);
            if (resultIsExist.Result && resultIsExist.Data)
            {
                return Json(new ResultModel<bool>(6, "活动名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
            }

            ResultInfo<bool> resultAddGoods = pbsBasicGoodsService.AddGoods(
                activitysName, Utility.Util.ParseHelper.ToDecimal(marketPrice), Utility.Util.ParseHelper.ToDecimal(sellingPrice), activitysDesc,
                Utility.Util.ParseHelper.ToInt(activitysClassId), Utility.Util.ParseHelper.ToInt(activitysTypeId), Utility.Util.ParseHelper.ToInt(ageRangeId), Utility.Util.ParseHelper.ToInt(regionId), activitysMainImgUrl,
                visitTime1, visitTime2, visitTime3, visitTime4, visitTime5,
                longitude, latitude, Utility.Util.ParseHelper.ToInt(activitysStatus), Utility.Util.ParseHelper.ToInt(isDisplayHome), Utility.Util.ParseHelper.ToInt(isDelete),
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime), Utility.Util.ParseHelper.ToInt(creatorId), remark, responsiblePerson,
                Utility.Util.ParseHelper.ToDecimal(responsiblePersonProfit), Utility.Util.ParseHelper.ToInt(activitysCount), Utility.Util.ParseHelper.ToDecimal(activitysCost),
                Utility.Util.ParseHelper.ToInt(activityFilterClassId),Utility.Util.ParseHelper.ToDecimal(platformCost),Utility.Util.ParseHelper.ToDecimal(otherCost)
                );
            if (resultAddGoods.Result && resultAddGoods.Data)
            {
                return Json(new ResultModel<bool>(0, "添加活动分类成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(7, "添加活动分类失败", false), JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 修改活动信息
        /// </summary>
        /// <param name="activitysName">活动名称</param>
        /// <param name="marketPrice">市场价</param>
        /// <param name="sellingPrice">销售价</param>
        /// <param name="activitysDesc">活动描述</param>
        /// <param name="activitysClassId">活动分类Id</param>
        /// <param name="activitysTypeId">活动类型Id</param>
        /// <param name="ageRangeId">年龄范围Id</param>
        /// <param name="regionId">区域范围Id</param>
        /// <param name="activitysMainImgUrl">活动主图路径</param>
        /// <param name="visitTime1">参加时间1</param>
        /// <param name="visitTime2">参加时间2</param>
        /// <param name="visitTime3">参加时间3</param>
        /// <param name="visitTime4">参加时间4</param>
        /// <param name="visitTime5">参加时间5</param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="activitysStatus">活动状态</param>
        /// <param name="isDisplayHome">是否首页显示</param>
        /// <param name="isDelete">是否删除</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者Id</param>
        /// <param name="remark">备注</param>
        /// <param name="responsiblePerson">负责人</param>
        /// <param name="activitysCount">名额</param>
        /// <param name="activityFilterClassId">活动筛选分类编号</param>
        /// <param name="platformCost">平台服务费	</param>
        /// <param name="otherCost">其他费用</param> 
        /// <param name="activitysId">活动编号</param>
        /// <returns></returns>
        public JsonResult ActivityUpdateAjax(string activitysName, string marketPrice, string sellingPrice, string activitysDesc,
            string activitysClassId, string activitysTypeId, string ageRangeId, string regionId, string activitysMainImgUrl,
            string visitTime1, string visitTime2, string visitTime3, string visitTime4, string visitTime5,
            string longitude, string latitude, string activitysStatus, string isDisplayHome, string isDelete,
            string createTime, string updateTime, string creatorId, string remark, string responsiblePerson, string responsiblePersonProfit, string activitysCount, string activitysCost, string activityFilterClassId, string platformCost, string otherCost, string activitysId)
        {
            activitysDesc = HttpUtility.UrlDecode(activitysDesc);
            if (string.IsNullOrEmpty(activitysName))
            {
                return Json(new ResultModel<bool>(1, "请输入活动名称", false), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(activitysId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activitysId);
                pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();

                //ResultInfo<bool> resultIsExist = pbsBasicGoodsService.ExistsByGoodsName(activitysName);
                //if (resultIsExist.Result && resultIsExist.Data)
                //{
                //    return Json(new ResultModel<bool>(6, "活动名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
                //}

                ResultInfo<bool> resultEditGoods = pbsBasicGoodsService.UpdateGoods(activitysName, Utility.Util.ParseHelper.ToDecimal(marketPrice), Utility.Util.ParseHelper.ToDecimal(sellingPrice), activitysDesc,
                Utility.Util.ParseHelper.ToInt(activitysClassId), Utility.Util.ParseHelper.ToInt(activitysTypeId), Utility.Util.ParseHelper.ToInt(ageRangeId), Utility.Util.ParseHelper.ToInt(regionId), activitysMainImgUrl,
                visitTime1, visitTime2, visitTime3, visitTime4, visitTime5,
                longitude, latitude, Utility.Util.ParseHelper.ToInt(activitysStatus), Utility.Util.ParseHelper.ToInt(isDisplayHome), Utility.Util.ParseHelper.ToInt(isDelete),
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime), Utility.Util.ParseHelper.ToInt(creatorId), remark, responsiblePerson,
                Utility.Util.ParseHelper.ToDecimal(responsiblePersonProfit), Utility.Util.ParseHelper.ToInt(activitysCount), Utility.Util.ParseHelper.ToDecimal(activitysCost), Utility.Util.ParseHelper.ToInt(activityFilterClassId),
                Utility.Util.ParseHelper.ToDecimal(platformCost), Utility.Util.ParseHelper.ToDecimal(otherCost), gid);
                if (resultEditGoods.Result && resultEditGoods.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改活动成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(7, "修改活动失败", false), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="activitysId">活动编号</param>
        /// <returns></returns>
        public JsonResult ActivityDeleteAjax(string activitysId)
        {
            if (!string.IsNullOrEmpty(activitysId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activitysId);
                pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
                ResultInfo<bool> resultDeleteGood = pbsBasicGoodsService.UpdateGoodsIsDelete(1, gid);
                if (resultDeleteGood.Result && resultDeleteGood.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除活动成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除活动失败", false), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 首页活动分类
        public ActionResult ActivityClassList()
        {
            pbsBasicGoodsClassListResult result = new pbsBasicGoodsClassListResult();
            pbs_basic_GoodsClassService pbsBasicGoodsClassService = new pbs_basic_GoodsClassService();
            ResultInfo<List<pbs_basic_GoodsClass>> resultinfo = pbsBasicGoodsClassService.GetAllGoodsClassList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        /// <summary>
        /// 首页活动分类详细页视图（添加/修改）
        /// </summary>
        /// <param name="activityClassId">首页活动分类编号</param>
        /// <returns></returns>
        public ActionResult ActivityClassAdd(string activityClassId)
        {
            pbs_basic_GoodsClass pbsBasicGoodsClass = new pbs_basic_GoodsClass();
            pbsBasicGoodsClass.GoodsClassId = 0;
            pbsBasicGoodsClass.GoodsClassName = string.Empty;
            pbsBasicGoodsClass.CreateTime = DateTime.Now;
            pbsBasicGoodsClass.UpdateTime = DateTime.Now;
            pbsBasicGoodsClass.CreatorId = 0;
            pbsBasicGoodsClass.Remark = string.Empty;

            pbs_basic_GoodsClassService pbsBasicGoodsClassService = new pbs_basic_GoodsClassService();

            if (!string.IsNullOrEmpty(activityClassId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activityClassId);
                ResultInfo<pbs_basic_GoodsClass> resultItem = pbsBasicGoodsClassService.GetGoodsClassModelById(gid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsBasicGoodsClass.GoodsClassId = resultItem.Data.GoodsClassId;
                    pbsBasicGoodsClass.GoodsClassName = resultItem.Data.GoodsClassName;
                    pbsBasicGoodsClass.CreateTime = resultItem.Data.CreateTime;
                    pbsBasicGoodsClass.UpdateTime = resultItem.Data.UpdateTime;
                    pbsBasicGoodsClass.CreatorId = resultItem.Data.CreatorId;
                    pbsBasicGoodsClass.Remark = resultItem.Data.Remark;
                }
                ViewBag.PageTitle = "修改首页活动分类";
            }
            else
            {
                ViewBag.PageTitle = "添加首页活动分类";
            }

            return View(pbsBasicGoodsClass);
        }

        /// <summary>
        /// 添加首页活动分类
        /// </summary>
        /// <param name="activityClassName"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public JsonResult GoodsClassAdd(string activitysClassName, string createTime, string updateTime, string creatorId, string remark)
        {
            if (string.IsNullOrEmpty(activitysClassName))
            {
                return Json(new ResultModel<bool>(1, "请输入首页活动分类名称", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_GoodsClassService pbsBasicGoodsClassService = new pbs_basic_GoodsClassService();

            ResultInfo<bool> resultIsExist = pbsBasicGoodsClassService.IsExistByGoodsClassName(activitysClassName);
            if (resultIsExist.Result && resultIsExist.Data)
            {
                return Json(new ResultModel<bool>(6, "首页活动分类名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
            }

            ResultInfo<bool> resultAddGoodClass = pbsBasicGoodsClassService.AddGoodsClass(activitysClassName,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark);
            if (resultAddGoodClass.Result && resultAddGoodClass.Data)
            {
                return Json(new ResultModel<bool>(0, "添加首页活动分类成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(7, "添加首页活动分类失败", false), JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 修改首页活动分类
        /// </summary>
        /// <param name="activityClassName"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <param name="activitysClassId"></param>
        /// <returns></returns>
        public JsonResult GoodsClassUpdate(string activitysClassName, string createTime, string updateTime, string creatorId, string remark, string activitysClassId)
        {
            if (string.IsNullOrEmpty(activitysClassName))
            {
                return Json(new ResultModel<bool>(1, "请输入首页活动分类名称", false), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(activitysClassId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activitysClassId);
                pbs_basic_GoodsClassService pbsBasicGoodsClassService = new pbs_basic_GoodsClassService();

                ResultInfo<bool> resultIsExist = pbsBasicGoodsClassService.IsExistByGoodsClassName(activitysClassName);
                if (resultIsExist.Result && resultIsExist.Data)
                {
                    return Json(new ResultModel<bool>(6, "首页活动分类名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
                }

                ResultInfo<bool> resultEditGoodClass = pbsBasicGoodsClassService.UpdateGoodsClass(activitysClassName,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, gid);
                if (resultEditGoodClass.Result && resultEditGoodClass.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改首页活动分类成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(7, "修改首页活动分类失败", false), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除首页活动分类
        /// </summary>
        /// <param name="activitysClassId">首页活动分类编号</param>
        /// <returns></returns>
        public JsonResult GoodsClassDelete(string activitysClassId)
        {
            if (!string.IsNullOrEmpty(activitysClassId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activitysClassId);
                pbs_basic_GoodsClassService pbsBasicGoodsClassService = new pbs_basic_GoodsClassService();
                ResultInfo<bool> resultDeleteGoodClass = pbsBasicGoodsClassService.DeleteGoodsClass(gid);
                if (resultDeleteGoodClass.Result && resultDeleteGoodClass.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除首页活动分类成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除首页活动分类失败", false), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 活动筛选分类
        public ActionResult ActivityFilterClassList()
        {
            pbsBasicActivityClassListResult result = new pbsBasicActivityClassListResult();
            pbs_basic_ActivityClassService pbsBasicActivityClassService = new pbs_basic_ActivityClassService();
            ResultInfo<List<pbs_basic_ActivityClass>> resultinfo = pbsBasicActivityClassService.GetAllActivityClassList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        /// <summary>
        /// 活动筛选分类详细页视图（添加/修改）
        /// </summary>
        /// <param name="activityClassId">活动筛选分类编号</param>
        /// <returns></returns>
        public ActionResult ActivityFilterClassAdd(string activityClassId)
        {
            pbs_basic_ActivityClass pbsBasicActivityClass = new pbs_basic_ActivityClass();
            pbsBasicActivityClass.ActivityClassId = 0;
            pbsBasicActivityClass.ActivityClassName = string.Empty;
            pbsBasicActivityClass.CreateTime = DateTime.Now;
            pbsBasicActivityClass.UpdateTime = DateTime.Now;
            pbsBasicActivityClass.CreatorId = 0;
            pbsBasicActivityClass.Remark = string.Empty;

            pbs_basic_ActivityClassService pbsBasicActivityClassService = new pbs_basic_ActivityClassService();

            if (!string.IsNullOrEmpty(activityClassId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activityClassId);
                ResultInfo<pbs_basic_ActivityClass> resultItem = pbsBasicActivityClassService.GetActivityClassModelById(gid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsBasicActivityClass.ActivityClassId = resultItem.Data.ActivityClassId;
                    pbsBasicActivityClass.ActivityClassName = resultItem.Data.ActivityClassName;
                    pbsBasicActivityClass.CreateTime = resultItem.Data.CreateTime;
                    pbsBasicActivityClass.UpdateTime = resultItem.Data.UpdateTime;
                    pbsBasicActivityClass.CreatorId = resultItem.Data.CreatorId;
                    pbsBasicActivityClass.Remark = resultItem.Data.Remark;
                }
                ViewBag.PageTitle = "修改活动筛选分类";
            }
            else
            {
                ViewBag.PageTitle = "添加活动筛选分类";
            }

            return View(pbsBasicActivityClass);
        }

        /// <summary>
        /// 添加活动筛选分类
        /// </summary>
        /// <param name="activityClassName"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public JsonResult ActivityFilterClassAddAjax(string activityClassName, string createTime, string updateTime, string creatorId, string remark)
        {
            if (string.IsNullOrEmpty(activityClassName))
            {
                return Json(new ResultModel<bool>(1, "请输入活动筛选分类名称", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_ActivityClassService pbsBasicActivityClassService = new pbs_basic_ActivityClassService();

            ResultInfo<bool> resultIsExist = pbsBasicActivityClassService.IsExistByActivityClassName(activityClassName);
            if (resultIsExist.Result && resultIsExist.Data)
            {
                return Json(new ResultModel<bool>(6, "活动筛选分类名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
            }

            ResultInfo<bool> resultAddGoodClass = pbsBasicActivityClassService.AddActivityClass(activityClassName,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark);
            if (resultAddGoodClass.Result && resultAddGoodClass.Data)
            {
                return Json(new ResultModel<bool>(0, "添加活动筛选分类成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(7, "添加活动筛选分类失败", false), JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 修改活动筛选分类
        /// </summary>
        /// <param name="activityClassName"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <param name="activityClassId"></param>
        /// <returns></returns>
        public JsonResult ActivityFilterClassUpdateAjax(string activityClassName, string createTime, string updateTime, string creatorId, string remark, string activityClassId)
        {
            if (string.IsNullOrEmpty(activityClassName))
            {
                return Json(new ResultModel<bool>(1, "请输入活动筛选分类名称", false), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(activityClassId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activityClassId);
                pbs_basic_ActivityClassService pbsBasicActivityClassService = new pbs_basic_ActivityClassService();

                ResultInfo<bool> resultIsExist = pbsBasicActivityClassService.IsExistByActivityClassName(activityClassName);
                if (resultIsExist.Result && resultIsExist.Data)
                {
                    return Json(new ResultModel<bool>(6, "活动筛选分类名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
                }

                ResultInfo<bool> resultEditGoodClass = pbsBasicActivityClassService.UpdateActivityClass(activityClassName,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, gid);
                if (resultEditGoodClass.Result && resultEditGoodClass.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改活动筛选分类成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(7, "修改活动筛选分类失败", false), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除活动筛选分类
        /// </summary>
        /// <param name="activityClassId">活动筛选分类编号</param>
        /// <returns></returns>
        public JsonResult ActivityFilterClassDeleteAjax(string activityClassId)
        {
            if (!string.IsNullOrEmpty(activityClassId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activityClassId);
                pbs_basic_ActivityClassService pbsBasicActivityClassService = new pbs_basic_ActivityClassService();
                ResultInfo<bool> resultDeleteGoodClass = pbsBasicActivityClassService.DeleteActivityClass(gid);
                if (resultDeleteGoodClass.Result && resultDeleteGoodClass.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除活动筛选分类成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除活动筛选分类失败", false), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 活动类型
        public ActionResult ActivityTypeList()
        {
            pbsBasicGoodsTypeListResult result = new pbsBasicGoodsTypeListResult();
            pbs_basic_GoodsTypeService pbsBasicGoodsTypeService = new pbs_basic_GoodsTypeService();
            ResultInfo<List<pbs_basic_GoodsType>> resultinfo = pbsBasicGoodsTypeService.GetAllGoodTypeList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        /// <summary>
        /// 活动类型详细页视图（添加/修改）
        /// </summary>
        /// <param name="activityTypeId">活动类型编号</param>
        /// <returns></returns>
        public ActionResult ActivityTypeAdd(string activityTypeId)
        {
            pbs_basic_GoodsType pbsBasicGoodsType = new pbs_basic_GoodsType();
            pbsBasicGoodsType.GoodsTypeId = 0;
            pbsBasicGoodsType.GoodsTypeName = string.Empty;
            pbsBasicGoodsType.CreateTime = DateTime.Now;
            pbsBasicGoodsType.UpdateTime = DateTime.Now;
            pbsBasicGoodsType.CreatorId = 0;
            pbsBasicGoodsType.Remark = string.Empty;

            pbs_basic_GoodsTypeService pbsBasicGoodsTypeService = new pbs_basic_GoodsTypeService();

            if (!string.IsNullOrEmpty(activityTypeId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activityTypeId);
                ResultInfo<pbs_basic_GoodsType> resultItem = pbsBasicGoodsTypeService.GetGoodTypeModelById(gid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsBasicGoodsType.GoodsTypeId = resultItem.Data.GoodsTypeId;
                    pbsBasicGoodsType.GoodsTypeName = resultItem.Data.GoodsTypeName;
                    pbsBasicGoodsType.CreateTime = resultItem.Data.CreateTime;
                    pbsBasicGoodsType.UpdateTime = resultItem.Data.UpdateTime;
                    pbsBasicGoodsType.CreatorId = resultItem.Data.CreatorId;
                    pbsBasicGoodsType.Remark = resultItem.Data.Remark;
                    pbsBasicGoodsType.GoodsTypeDesc = resultItem.Data.GoodsTypeDesc;
                    pbsBasicGoodsType.GoodsTypePrice = resultItem.Data.GoodsTypePrice;
                }
                ViewBag.PageTitle = "修改活动类型";
            }
            else
            {
                ViewBag.PageTitle = "添加活动类型";
            }

            return View(pbsBasicGoodsType);
        }

        /// <summary>
        /// 添加活动类型
        /// </summary>
        /// <param name="activitysTypeName"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <param name="activitysTypeDesc"></param>
        /// <param name="activitysTypePrice"></param>
        /// <returns></returns>
        public JsonResult GoodsTypeAdd(string activitysTypeName, string createTime, string updateTime, string creatorId, string remark, string activitysTypeDesc, string activitysTypePrice)
        {
            if (string.IsNullOrEmpty(activitysTypeName))
            {
                return Json(new ResultModel<bool>(1, "请输入类型名称", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_GoodsTypeService pbsBasicGoodsTypeService = new pbs_basic_GoodsTypeService();

            ResultInfo<bool> resultIsExist = pbsBasicGoodsTypeService.IsExistByGoodsTypeName(activitysTypeName);
            if (resultIsExist.Result && resultIsExist.Data)
            {
                return Json(new ResultModel<bool>(6, "活动类型名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
            }

            ResultInfo<bool> resultAddGoodType = pbsBasicGoodsTypeService.AddGoodType(activitysTypeName,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, activitysTypeDesc, Utility.Util.ParseHelper.ToDecimal(activitysTypePrice));
            if (resultAddGoodType.Result && resultAddGoodType.Data)
            {
                return Json(new ResultModel<bool>(0, "添加活动类型成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(7, "添加活动类型失败", false), JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 修改活动类型
        /// </summary>
        /// <param name="activitysTypeName"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <param name="activitysTypeDesc"></param>
        /// <param name="activitysTypePrice"></param>
        /// <param name="activitysTypeId"></param>
        /// <returns></returns>
        public JsonResult GoodsTypeUpdate(string activitysTypeName, string createTime, string updateTime, string creatorId, string remark, string activitysTypeDesc, string activitysTypePrice, string activitysTypeId)
        {
            if (string.IsNullOrEmpty(activitysTypeName))
            {
                return Json(new ResultModel<bool>(1, "请输入类型名称", false), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(activitysTypeId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activitysTypeId);
                pbs_basic_GoodsTypeService pbsBasicGoodsTypeService = new pbs_basic_GoodsTypeService();

                ResultInfo<bool> resultIsExist = pbsBasicGoodsTypeService.IsExistByGoodsTypeName(activitysTypeName);
                if (resultIsExist.Result && resultIsExist.Data)
                {
                    return Json(new ResultModel<bool>(6, "活动类型名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
                }

                ResultInfo<bool> resultEditGoodType = pbsBasicGoodsTypeService.UpdateGoodType(activitysTypeName,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, activitysTypeDesc, Utility.Util.ParseHelper.ToDecimal(activitysTypePrice), gid);
                if (resultEditGoodType.Result && resultEditGoodType.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改活动类型成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(7, "修改活动类型失败", false), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除活动类型
        /// </summary>
        /// <param name="activitysTypeId">活动类型编号</param>
        /// <returns></returns>
        public JsonResult GoodsTypeDelete(string activitysTypeId)
        {
            if (!string.IsNullOrEmpty(activitysTypeId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activitysTypeId);
                pbs_basic_GoodsTypeService pbsBasicGoodsTypeService = new pbs_basic_GoodsTypeService();
                ResultInfo<bool> resultDeleteGoodType = pbsBasicGoodsTypeService.DeleteGoodType(gid);
                if (resultDeleteGoodType.Result && resultDeleteGoodType.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除活动类型成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除活动类型失败", false), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 年龄范围
        public ActionResult AgeRangeList()
        {
            pbsBasicAgeRangeListResult result = new pbsBasicAgeRangeListResult();
            pbs_basic_AgeRangeService pbsBasicAgeRangeService = new pbs_basic_AgeRangeService();
            ResultInfo<List<pbs_basic_AgeRange>> resultinfo = pbsBasicAgeRangeService.GetAllAgeRangeList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        /// <summary>
        /// 年龄范围详细页视图（添加/修改）
        /// </summary>
        /// <param name="ageRangeId">年龄范围编号</param>
        /// <returns></returns>
        public ActionResult AgeRangeAdd(string ageRangeId)
        {
            pbs_basic_AgeRange pbsBasicAgeRange = new pbs_basic_AgeRange();
            pbsBasicAgeRange.AgeRangeId = 0;
            pbsBasicAgeRange.AgeRangeName = string.Empty;
            pbsBasicAgeRange.CreateTime = DateTime.Now;
            pbsBasicAgeRange.UpdateTime = DateTime.Now;
            pbsBasicAgeRange.CreatorId = 0;
            pbsBasicAgeRange.Remark = string.Empty;

            pbs_basic_AgeRangeService pbsBasicAgeRangeService = new pbs_basic_AgeRangeService();

            if (!string.IsNullOrEmpty(ageRangeId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(ageRangeId);
                ResultInfo<pbs_basic_AgeRange> resultItem = pbsBasicAgeRangeService.GetAgeRangeModelById(gid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsBasicAgeRange.AgeRangeId = resultItem.Data.AgeRangeId;
                    pbsBasicAgeRange.AgeRangeName = resultItem.Data.AgeRangeName;
                    pbsBasicAgeRange.CreateTime = resultItem.Data.CreateTime;
                    pbsBasicAgeRange.UpdateTime = resultItem.Data.UpdateTime;
                    pbsBasicAgeRange.CreatorId = resultItem.Data.CreatorId;
                    pbsBasicAgeRange.Remark = resultItem.Data.Remark;
                }
                ViewBag.PageTitle = "修改年龄范围";
            }
            else
            {
                ViewBag.PageTitle = "添加年龄范围";
            }

            return View(pbsBasicAgeRange);
        }

        /// <summary>
        /// 添加年龄范围
        /// </summary>
        /// <param name="ageRangeName"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public JsonResult AgeRangeAddAjax(string ageRangeName, string createTime, string updateTime, string creatorId, string remark)
        {
            if (string.IsNullOrEmpty(ageRangeName))
            {
                return Json(new ResultModel<bool>(1, "请输入类型名称", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_AgeRangeService pbsBasicAgeRangeService = new pbs_basic_AgeRangeService();

            ResultInfo<bool> resultIsExist = pbsBasicAgeRangeService.IsExistByAgeRangeName(ageRangeName);
            if (resultIsExist.Result && resultIsExist.Data)
            {
                return Json(new ResultModel<bool>(6, "年龄范围名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
            }

            ResultInfo<bool> resultAddAgeRange = pbsBasicAgeRangeService.AddAgeRange(ageRangeName,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark);
            if (resultAddAgeRange.Result && resultAddAgeRange.Data)
            {
                return Json(new ResultModel<bool>(0, "添加年龄范围成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(7, "添加年龄范围失败", false), JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 修改年龄范围
        /// </summary>
        /// <param name="ageRangeName"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <param name="ageRangeId"></param>
        /// <returns></returns>
        public JsonResult AgeRangeUpdate(string ageRangeName, string createTime, string updateTime, string creatorId, string remark, string ageRangeId)
        {
            if (string.IsNullOrEmpty(ageRangeName))
            {
                return Json(new ResultModel<bool>(1, "请输入类型名称", false), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(ageRangeId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(ageRangeId);
                pbs_basic_AgeRangeService pbsBasicAgeRangeService = new pbs_basic_AgeRangeService();

                ResultInfo<bool> resultIsExist = pbsBasicAgeRangeService.IsExistByAgeRangeName(ageRangeName);
                if (resultIsExist.Result && resultIsExist.Data)
                {
                    return Json(new ResultModel<bool>(6, "年龄范围名称已存在，请修改", false), JsonRequestBehavior.AllowGet);
                }

                ResultInfo<bool> resultEditAgeRange = pbsBasicAgeRangeService.UpdateAgeRange(ageRangeName,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, gid);
                if (resultEditAgeRange.Result && resultEditAgeRange.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改年龄范围成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(7, "修改年龄范围失败", false), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除年龄范围
        /// </summary>
        /// <param name="ageRangeId">年龄范围编号</param>
        /// <returns></returns>
        public JsonResult AgeRangeDelete(string ageRangeId)
        {
            if (!string.IsNullOrEmpty(ageRangeId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(ageRangeId);
                pbs_basic_AgeRangeService pbsBasicAgeRangeService = new pbs_basic_AgeRangeService();
                ResultInfo<bool> resultDeleteAgeRange = pbsBasicAgeRangeService.DeleteAgeRange(gid);
                if (resultDeleteAgeRange.Result && resultDeleteAgeRange.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除年龄范围成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除年龄范围失败", false), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 活动地址
        /// <summary>
        /// 显示活动地址页面
        /// </summary>
        /// <param name="regionId">区域id</param>
        /// <returns></returns>
        public ActionResult ActivityAddressAdd(string regionId)
        {
            pbs_basic_Region pbsBasicRegion = new pbs_basic_Region();
            pbsBasicRegion.RegionId = 0;
            pbsBasicRegion.RegionName = string.Empty;
            pbsBasicRegion.ParentRegionId = 0;
            pbsBasicRegion.CreateTime = DateTime.Now;
            pbsBasicRegion.UpdateTime = DateTime.Now;
            pbsBasicRegion.CreatorId = 0;
            pbsBasicRegion.Remark = string.Empty;

            #region 区域下拉列表
            ViewData["RegionList"] = null;
            pbsBasicRegionParentSelect pbsRegionParentselect = new pbsBasicRegionParentSelect();
            pbsRegionParentselect.regionParentList = new List<pbs_basic_Region>();
            pbs_basic_RegionService pbsBasicRegionListService = new pbs_basic_RegionService();
            ResultInfo<List<pbs_basic_Region>> resultParentItem = pbsBasicRegionListService.GetThisRegionList(110100);
            if (resultParentItem.Result && resultParentItem.Data != null && resultParentItem.Data.Count > 0)
            {
                foreach (pbs_basic_Region itemParent in resultParentItem.Data) //得到行集合
                {
                    pbs_basic_Region regionParent = new pbs_basic_Region();
                    regionParent.RegionId = itemParent.RegionId;
                    regionParent.RegionName = itemParent.RegionName;
                    regionParent.ParentRegionId = itemParent.ParentRegionId;
                    regionParent.CreateTime = itemParent.CreateTime;
                    regionParent.UpdateTime = itemParent.UpdateTime;
                    regionParent.CreatorId = itemParent.CreatorId;
                    regionParent.Remark = itemParent.Remark;
                    //regionParent.regionChildrenList = new List<pbs_basic_RegionChildren>();
                    pbsRegionParentselect.regionParentList.Add(regionParent);
                }
            }

            ViewData["RegionList"] = pbsRegionParentselect.regionParentList;
            #endregion

            if (!string.IsNullOrEmpty(regionId))
            {
                pbsBasicRegion.RegionId = Utility.Util.ParseHelper.ToInt(regionId);
                int rid = Utility.Util.ParseHelper.ToInt(regionId);
                pbs_basic_RegionService pbsBasicRegionService = new pbs_basic_RegionService();
                ResultInfo<pbs_basic_Region> resultItem = pbsBasicRegionService.GetRegionModelById(rid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsBasicRegion.RegionId = resultItem.Data.RegionId;
                    pbsBasicRegion.RegionName = resultItem.Data.RegionName;
                    pbsBasicRegion.ParentRegionId = resultItem.Data.ParentRegionId;
                    pbsBasicRegion.CreateTime = resultItem.Data.CreateTime;
                    pbsBasicRegion.UpdateTime = resultItem.Data.UpdateTime;
                    pbsBasicRegion.CreatorId = resultItem.Data.CreatorId;
                    pbsBasicRegion.Remark = resultItem.Data.Remark;
                }

                ViewBag.PageTitle = "修改区域";
            }
            else
            {
                ViewBag.PageTitle = "添加区域";
            }

            return View(pbsBasicRegion);
        }

        /// <summary>
        /// 修改活动地址
        /// </summary>
        /// <param name="regionName"></param>
        /// <param name="parentRegionId"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <param name="regionId"></param>
        /// <returns></returns>
        public JsonResult RegionUpdate(string regionName, string parentRegionId, string createTime, string updateTime, string creatorId, string remark, string regionId)
        {
            if (string.IsNullOrEmpty(regionName))
            {
                return Json(new ResultModel<bool>(1, "请输入分类名称", false), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(regionId))
            {
                int rid = Utility.Util.ParseHelper.ToInt(regionId);
                pbs_basic_RegionService pbsBasicRegionService = new pbs_basic_RegionService();

                ResultInfo<bool> resultRegionUpdate = pbsBasicRegionService.UpdateRegion(regionName,
                    Utility.Util.ParseHelper.ToInt(parentRegionId), Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, Utility.Util.ParseHelper.ToInt(regionId));
                if (resultRegionUpdate.Result && resultRegionUpdate.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改活动地址成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(7, "修改活动地址失败", false), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 活动地址列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivityAddressList()
        {
            pbsBasicRegionListResult result = new pbsBasicRegionListResult();
            pbs_basic_RegionService pbsBasicRegionService = new pbs_basic_RegionService();
            ResultInfo<List<pbs_basic_Region>> resultinfo = pbsBasicRegionService.GetAllRegionList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }
        #endregion

        #region 优惠券
        public ActionResult VoucherList()
        {
            pbsBasicVoucherListResult result = new pbsBasicVoucherListResult();
            pbs_basic_VoucherService pbsBasicVoucherService = new pbs_basic_VoucherService();
            ResultInfo<List<pbs_basic_Voucher>> resultinfo = pbsBasicVoucherService.GetAllVoucherList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        /// <summary>
        /// 优惠券详细页视图（添加/修改）
        /// </summary>
        /// <param name="voucherId">优惠券编号</param>
        /// <returns></returns>
        public ActionResult VoucherAdd(string voucherId)
        {
            pbs_basic_Voucher pbsBasicVoucher = new pbs_basic_Voucher();

            pbsBasicVoucher.VoucherId = 0;
            pbsBasicVoucher.VoucherPrice = 0m;
            pbsBasicVoucher.UseRole = string.Empty;
            pbsBasicVoucher.VoucherType = 1;
            pbsBasicVoucher.SRPrice = 0m;
            pbsBasicVoucher.UseStartTime = null;
            pbsBasicVoucher.UseEndTime = null;
            pbsBasicVoucher.VoucherStatus = 0;
            pbsBasicVoucher.CreateTime = DateTime.Now;
            pbsBasicVoucher.UpdateTime = DateTime.Now;
            pbsBasicVoucher.CreatorId = 0;
            pbsBasicVoucher.Remark = string.Empty;
            pbsBasicVoucher.VoucherCount = 0;

            pbs_basic_VoucherService pbsBasicVoucherService = new pbs_basic_VoucherService();

            if (!string.IsNullOrEmpty(voucherId))
            {
                int vid = Utility.Util.ParseHelper.ToInt(voucherId);
                ResultInfo<pbs_basic_Voucher> resultItem = pbsBasicVoucherService.GetVoucherModelById(vid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsBasicVoucher.VoucherId = resultItem.Data.VoucherId;
                    pbsBasicVoucher.VoucherPrice = resultItem.Data.VoucherPrice;
                    pbsBasicVoucher.UseRole = resultItem.Data.UseRole;
                    pbsBasicVoucher.VoucherType = resultItem.Data.VoucherType;
                    pbsBasicVoucher.SRPrice = resultItem.Data.SRPrice;
                    pbsBasicVoucher.UseStartTime = resultItem.Data.UseStartTime;
                    pbsBasicVoucher.UseEndTime = resultItem.Data.UseEndTime;
                    pbsBasicVoucher.VoucherStatus = resultItem.Data.VoucherStatus;
                    pbsBasicVoucher.CreateTime = resultItem.Data.CreateTime;
                    pbsBasicVoucher.UpdateTime = resultItem.Data.UpdateTime;
                    pbsBasicVoucher.CreatorId = resultItem.Data.CreatorId;
                    pbsBasicVoucher.Remark = resultItem.Data.Remark;
                    pbsBasicVoucher.VoucherCount = resultItem.Data.VoucherCount;
                }
                ViewBag.PageTitle = "修改优惠券";
            }
            else
            {
                ViewBag.PageTitle = "添加优惠券";
            }

            return View(pbsBasicVoucher);
        }

        /// <summary>
        /// 添加优惠券
        /// </summary>
        /// <param name="voucherPrice"></param>
        /// <param name="useRole"></param>
        /// <param name="voucherType"></param>
        /// <param name="sRPrice"></param>
        /// <param name="useStartTime"></param>
        /// <param name="useEndTime"></param>
        /// <param name="voucherStatus"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public JsonResult VoucherAddAjax(string voucherPrice, string useRole, string voucherType, string sRPrice, string useStartTime, string useEndTime, string voucherStatus, string createTime, string updateTime, string creatorId, string remark,string voucherCount)
        {
            if (string.IsNullOrEmpty(voucherPrice))
            {
                return Json(new ResultModel<bool>(1, "请输入优惠券价格", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_VoucherService pbsBasicVoucherService = new pbs_basic_VoucherService();

            ResultInfo<bool> resultAddVoucher = pbsBasicVoucherService.AddVoucher(Utility.Util.ParseHelper.ToDecimal(voucherPrice),
                useRole, Utility.Util.ParseHelper.ToInt(voucherType), Utility.Util.ParseHelper.ToDecimal(sRPrice),
                useStartTime, useEndTime, Utility.Util.ParseHelper.ToInt(voucherStatus),
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, Utility.Util.ParseHelper.ToInt(voucherCount));
            if (resultAddVoucher.Result && resultAddVoucher.Data)
            {
                return Json(new ResultModel<bool>(0, "添加优惠券成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(7, "添加优惠券失败", false), JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 修改优惠券
        /// </summary>
        /// <param name="voucherPrice"></param>
        /// <param name="useRole"></param>
        /// <param name="voucherType"></param>
        /// <param name="sRPrice"></param>
        /// <param name="useStartTime"></param>
        /// <param name="useEndTime"></param>
        /// <param name="voucherStatus"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public JsonResult VoucherUpdateAjax(string voucherPrice, string useRole, int voucherType, decimal sRPrice, string useStartTime, string useEndTime, string voucherStatus, string createTime, string updateTime, string creatorId, string remark, string voucherCount, string voucherId)
        {
            if (string.IsNullOrEmpty(voucherPrice))
            {
                return Json(new ResultModel<bool>(1, "请输入优惠券价格", false), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(voucherId))
            {
                int vid = Utility.Util.ParseHelper.ToInt(voucherId);
                pbs_basic_VoucherService pbsBasicVoucherService = new pbs_basic_VoucherService();

                ResultInfo<bool> resultEditVoucher = pbsBasicVoucherService.UpdateVoucher(Utility.Util.ParseHelper.ToDecimal(voucherPrice),
                useRole, Utility.Util.ParseHelper.ToInt(voucherType), Utility.Util.ParseHelper.ToDecimal(sRPrice), useStartTime, useEndTime,
                Utility.Util.ParseHelper.ToInt(voucherStatus),
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, Utility.Util.ParseHelper.ToInt(voucherCount), vid);
                if (resultEditVoucher.Result && resultEditVoucher.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改优惠券成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(7, "修改优惠券失败", false), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除优惠券
        /// </summary>
        /// <param name="voucherId">优惠券编号</param>
        /// <returns></returns>
        public JsonResult VoucherDeleteAjax(string voucherId)
        {
            if (!string.IsNullOrEmpty(voucherId))
            {
                int vid = Utility.Util.ParseHelper.ToInt(voucherId);
                pbs_basic_VoucherService pbsBasicVoucherService = new pbs_basic_VoucherService();
                ResultInfo<bool> resultDeleteVoucher = pbsBasicVoucherService.DeleteVoucher(vid);
                if (resultDeleteVoucher.Result && resultDeleteVoucher.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除优惠券成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除优惠券失败", false), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SendVoucher(string voucherId)
        {
            ViewData["VoucherId"] = voucherId;
            return View();
        }

        public JsonResult SendVoucherAjax(string voucherId)
        {
            bool flag = false;
            pbsBasicUsersListResult result = new pbsBasicUsersListResult();
            pbs_basic_UsersService pbsBasicUsersService = new pbs_basic_UsersService();
            pbs_basic_MyVoucherService pbsBasicMyVoucherService = new pbs_basic_MyVoucherService();
            ResultInfo<List<pbs_basic_Users>> resultinfo = pbsBasicUsersService.GetUsersList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                foreach (var item in resultinfo.Data)
                {
                    ResultInfo<bool> result_AddMyVoucherIsUsed = pbsBasicMyVoucherService.AddMyVoucher(item.UserId, Utility.Util.ParseHelper.ToInt(voucherId), 0, DateTime.Now, DateTime.Now, 0, string.Empty);
                    if (result_AddMyVoucherIsUsed.Result && result_AddMyVoucherIsUsed.Data)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }

            if (flag)
            {
                return Json(new ResultModel<bool>(0, "发放优惠券成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(1, "发放优惠券失败", false), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region 套餐

        public ActionResult ActivityPackageList()
        {
            pbsBasicGoodsPackageViewListResult result = new pbsBasicGoodsPackageViewListResult();
            pbs_basic_GoodsPackageService pbsBasicGoodsPackageService = new pbs_basic_GoodsPackageService();
            ResultInfo<List<pbs_basic_GoodsPackageView>> resultinfo = pbsBasicGoodsPackageService.GetAllGoodsPackageList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.list = resultinfo.Data;
            }

            return View(result);
        }

        public ActionResult ActivityPackageAdd(string activitysPackageId)
        {
            #region 活动类型下拉列表
            ViewData["GoodsTypeList"] = null;
            pbs_basic_GoodsTypeService pbsBasicGoodsTypeService = new pbs_basic_GoodsTypeService();
            ResultInfo<List<pbs_basic_GoodsType>> resultGoodsType = pbsBasicGoodsTypeService.GetAllGoodTypeList();
            if (resultGoodsType.Result && resultGoodsType.Data != null)
            {
                ViewData["GoodsTypeList"] = resultGoodsType.Data;
            }
            #endregion

            pbs_basic_GoodsPackage pbsBasicGoodsPackage = new pbs_basic_GoodsPackage();
            pbsBasicGoodsPackage.GoodsPackageId = 0;
            pbsBasicGoodsPackage.GoodsPackageName = string.Empty;
            pbsBasicGoodsPackage.GoodsPackagePrice = 0m;
            pbsBasicGoodsPackage.GoodsTypeId = 0;
            pbsBasicGoodsPackage.CreateTime = DateTime.Now;
            pbsBasicGoodsPackage.UpdateTime = DateTime.Now;
            pbsBasicGoodsPackage.CreatorId = 0;
            pbsBasicGoodsPackage.Remark = string.Empty;

            pbs_basic_GoodsPackageService pbsBasicGoodsPackageService = new pbs_basic_GoodsPackageService();

            if (!string.IsNullOrEmpty(activitysPackageId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activitysPackageId);
                ResultInfo<pbs_basic_GoodsPackage> resultItem = pbsBasicGoodsPackageService.GetGoodsPackageModelById(gid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsBasicGoodsPackage.GoodsPackageId = resultItem.Data.GoodsPackageId;
                    pbsBasicGoodsPackage.GoodsPackageName = resultItem.Data.GoodsPackageName;
                    pbsBasicGoodsPackage.GoodsPackagePrice = resultItem.Data.GoodsPackagePrice;
                    pbsBasicGoodsPackage.GoodsTypeId = resultItem.Data.GoodsTypeId;
                    pbsBasicGoodsPackage.CreateTime = resultItem.Data.CreateTime;
                    pbsBasicGoodsPackage.UpdateTime = resultItem.Data.UpdateTime;
                    pbsBasicGoodsPackage.CreatorId = resultItem.Data.CreatorId;
                    pbsBasicGoodsPackage.Remark = resultItem.Data.Remark;

                }
                ViewBag.PageTitle = "修改套餐";
            }
            else
            {
                ViewBag.PageTitle = "添加套餐";
            }

            return View(pbsBasicGoodsPackage);
        }

        public JsonResult ActivityPackageAddAjax(string activitysPackageName, string activitysPackagePrice, string activitysTypeId, string createTime, string updateTime, string creatorId, string remark)
        {
            if (string.IsNullOrEmpty(activitysPackageName))
            {
                return Json(new ResultModel<bool>(1, "请输入套餐名称", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_GoodsPackageService pbsBasicGoodsPackageService = new pbs_basic_GoodsPackageService();

            ResultInfo<bool> resultIsExist = pbsBasicGoodsPackageService.IsExistByGoodsPackageName(activitysPackageName);
            if (resultIsExist.Result && resultIsExist.Data)
            {
                return Json(new ResultModel<bool>(6, "套餐已存在，请修改", false), JsonRequestBehavior.AllowGet);
            }

            ResultInfo<bool> resultAddGoodPackage = pbsBasicGoodsPackageService.AddGoodsPackage(activitysPackageName,
                Utility.Util.ParseHelper.ToDecimal(activitysPackagePrice), Utility.Util.ParseHelper.ToInt(activitysTypeId),
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark);
            if (resultAddGoodPackage.Result && resultAddGoodPackage.Data)
            {
                return Json(new ResultModel<bool>(0, "添加活动类型成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(7, "添加活动类型失败", false), JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ActivityPackageUpdate(string activitysPackageName, string activitysPackagePrice, string activitysTypeId, string createTime, string updateTime, string creatorId, string remark, string activitysPackageId)
        {
            if (string.IsNullOrEmpty(activitysPackageName))
            {
                return Json(new ResultModel<bool>(1, "请输入套餐名称", false), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(activitysPackageId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activitysPackageId);
                pbs_basic_GoodsPackageService pbsBasicGoodsPackageService = new pbs_basic_GoodsPackageService();

                ResultInfo<bool> resultIsExist = pbsBasicGoodsPackageService.IsExistByGoodsPackageName(activitysPackageName);
                if (resultIsExist.Result && resultIsExist.Data)
                {
                    return Json(new ResultModel<bool>(6, "套餐已存在，请修改", false), JsonRequestBehavior.AllowGet);
                }

                ResultInfo<bool> resultEditGoodPackage = pbsBasicGoodsPackageService.UpdateGoodsPackage(activitysPackageName,
                Utility.Util.ParseHelper.ToDecimal(activitysPackagePrice), Utility.Util.ParseHelper.ToInt(activitysTypeId),
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, gid);
                if (resultEditGoodPackage.Result && resultEditGoodPackage.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改套餐成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(7, "修改套餐失败", false), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ActivityPackageDeleteAjax(string activitysPackageId)
        {
            if (!string.IsNullOrEmpty(activitysPackageId))
            {
                int gid = Utility.Util.ParseHelper.ToInt(activitysPackageId);
                pbs_basic_GoodsPackageService pbsBasicGoodsPackageService = new pbs_basic_GoodsPackageService();
                ResultInfo<bool> resultDeleteGoodPackage = pbsBasicGoodsPackageService.DeleteGoodsPackage(gid);
                if (resultDeleteGoodPackage.Result && resultDeleteGoodPackage.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除套餐成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除套餐失败", false), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}