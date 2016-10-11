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
using System.Dynamic;

namespace PBSAdmin.Controllers
{
    public class SaleReportController : Controller
    {
        // GET: SaleReport
        public ActionResult SaleMemberReportList()
        {
            pbs_basic_DistributionChannels pbsBasicDistributionChannels = new pbs_basic_DistributionChannels();
            pbs_basic_DistributionChannelsService pbsBasicDistributionChannelsService = new pbs_basic_DistributionChannelsService();
            ResultInfo<pbs_basic_DistributionChannels> resultinfoDC = pbsBasicDistributionChannelsService.GetDCModelById(1);
            if (resultinfoDC.Result && resultinfoDC.Data != null)
            {
                pbsBasicDistributionChannels = resultinfoDC.Data;
            }

            List<SaleMemberReportSQL> saleMemberReportSqlList = new List<SaleMemberReportSQL>();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            ResultInfo<List<SaleMemberReportSQL>> resultinfoSQL = pbsBasicOrderService.GetSaleMemberReportSQLList();
            if (resultinfoSQL.Result && resultinfoSQL.Data != null)
            {
                saleMemberReportSqlList = resultinfoSQL.Data;
            }

            List<SaleMemberReport> saleMemberReportList = new List<SaleMemberReport>();
            if (saleMemberReportSqlList!=null&& saleMemberReportSqlList.Count>0)
            {
                foreach (var item in saleMemberReportSqlList)
                {
                    SaleMemberReport sr = new SaleMemberReport();
                    sr.GoodsName = item.GoodsName;
                    sr.OrderPrice = item.SellingPrice;
                    sr.OrderCost = item.GoodsCost;
                    sr.ActivityGrossProfit = item.SellingPrice - item.GoodsCost;
                    sr.DC1 = sr.ActivityGrossProfit*pbsBasicDistributionChannels.DC1*0.01m;
                    sr.DC2 = sr.ActivityGrossProfit * pbsBasicDistributionChannels.DC2 * 0.01m;
                    sr.DC3 = sr.ActivityGrossProfit * pbsBasicDistributionChannels.DC3 * 0.01m;
                    sr.SurplusProfit = sr.ActivityGrossProfit - sr.ActivityGrossProfit * (pbsBasicDistributionChannels.DC1 + pbsBasicDistributionChannels.DC2 + pbsBasicDistributionChannels.DC3) * 0.01m;
                    sr.PayCount = item.OrderCount;
                    sr.ResponsiblePersonProfit = item.ResponsiblePersonProfit;
                    sr.FinalGrossProfit = sr.SurplusProfit * sr.PayCount - sr.ResponsiblePersonProfit;
                    saleMemberReportList.Add(sr);
                }
            }
            ViewData["SaleMemberReportList"] = saleMemberReportList;

            return View();
        }

        public ActionResult DistributionChannels()
        {
            pbs_basic_DistributionChannels pbsBasicDistributionChannels=new pbs_basic_DistributionChannels();
            pbs_basic_DistributionChannelsService pbsBasicDistributionChannelsService=new pbs_basic_DistributionChannelsService();
            ResultInfo<pbs_basic_DistributionChannels> resultinfo = pbsBasicDistributionChannelsService.GetDCModelById(1);
            if (resultinfo.Result && resultinfo.Data != null)
            {
                pbsBasicDistributionChannels = resultinfo.Data;
            }

            ViewData["DistributionChannels"] = pbsBasicDistributionChannels;

            return View();
        }

        public JsonResult DistributionChannelsUpdate(string dC1, string dC2, string dC3, string dCId)
        {
            pbs_basic_DistributionChannelsService pbsBasicDistributionChannelsService = new pbs_basic_DistributionChannelsService();
            ResultInfo<bool> result = pbsBasicDistributionChannelsService.UpdateDC(
                Utility.Util.ParseHelper.ToInt(dC1),
                Utility.Util.ParseHelper.ToInt(dC2),
                Utility.Util.ParseHelper.ToInt(dC3),
                Utility.Util.ParseHelper.ToInt(dCId));
            if (result.Result && result.Data)
            {
                return Json(new ResultModel<bool>(0, "修改分销渠道分成成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(7, "修改分销渠道分成失败", false), JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult SaleGoodsReportList()
        {
            List<SaleGoodsReport> list = new List<SaleGoodsReport>();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            ResultInfo<List<SaleGoodsReport>> result = pbsBasicOrderService.GetSaleGoodsReportList();
            if (result.Result && result.Data != null)
            {
                list = result.Data;
            }
            ViewData["SaleGoodsReportList"] = list;

            return View();
        }

        public JsonResult ExportExcelAjax()
        {
            dynamic result = new ExpandoObject();
            result.Code = "0001";
            result.Msg = "error";
            result.Url = string.Empty;
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            ResultInfo<List<SaleGoodsReport>> resultList = pbsBasicOrderService.GetSaleGoodsReportList();
            if (resultList.Result && resultList.Data != null)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                string savePath = Server.MapPath("~/Content/export/") + fileName;
                ExportExcelHelper.ExportExcel(savePath, ParseHelper.ToDataTable(resultList.Data));

                result.Code = "0000";
                result.Msg = "ok";
                result.Url = "/Content/export/" + fileName;
            }

            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);
        }

    }
}