using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBS.Dao;
using PBS.Model;

namespace PBS.Server
{
    public class pbs_basic_MyShareProfitService
    {
        pbs_basic_MyShareProfitDao dao = new pbs_basic_MyShareProfitDao();

        public ResultInfo<bool> AddMyShareProfit(int goodsId, int shareLevel, decimal profit, int userId, int fromShareOrderId, int currentShareOrderId, DateTime createTime, DateTime updateTime, int creatorId, string remark,ref string shareId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddMyShareProfit(goodsId,shareLevel,profit,userId,fromShareOrderId,currentShareOrderId,createTime,updateTime,creatorId,remark,ref shareId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_MyShareProfit> GetMyShareProfitModelById(int shareId)
        {
            ResultInfo<pbs_basic_MyShareProfit> result = new ResultInfo<pbs_basic_MyShareProfit>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMyShareProfitModelById(shareId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_MyShareProfit>> GetMyShareProfitListAll()
        {
            ResultInfo<List<pbs_basic_MyShareProfit>> result = new ResultInfo<List<pbs_basic_MyShareProfit>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMyShareProfitListAll();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_MyShareProfit>> GetMyShareProfitList(int userId)
        {
            ResultInfo<List<pbs_basic_MyShareProfit>> result = new ResultInfo<List<pbs_basic_MyShareProfit>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMyShareProfitList(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<bool> IsExistByShareId(int shareId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByShareId(shareId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> IsExistByFromShareOrderId(int fromShareOrderId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByFromShareOrderId(fromShareOrderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> IsExistByFromShareOrderIdAndShareLevel(int fromShareOrderId, int ShareLevel)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByFromShareOrderIdAndShareLevel(fromShareOrderId, ShareLevel);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_MyShareProfit> GetMyShareProfitModelByFromShareOrderId(int fromShareOrderId)
        {
            ResultInfo<pbs_basic_MyShareProfit> result = new ResultInfo<pbs_basic_MyShareProfit>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMyShareProfitModelByFromShareOrderId(fromShareOrderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<bool> UpdateMyShareProfit(int goodsId, int shareLevel, decimal profit, int userId, int fromShareOrderId, int currentShareOrderId, DateTime createTime, DateTime updateTime, int creatorId, string remark,int shareId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateMyShareProfit(goodsId, shareLevel, profit, userId, fromShareOrderId, currentShareOrderId, createTime, updateTime, creatorId, remark, shareId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<decimal> GetMyShareProfitByUserId(int userId)
        {
            ResultInfo<decimal> result = new ResultInfo<decimal>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMyShareProfitByUserId(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = 0m;
            }
            return result;
        }

        //public ResultInfo<List<MyShareProfitResult>> GetMyShareProfitResultList(int userId)
        //{
        //    ResultInfo<List<MyShareProfitResult>> result = new ResultInfo<List<MyShareProfitResult>>();
        //    result.Result = false;
        //    try
        //    {
        //        result.Result = true;
        //        result.Data = dao.GetMyShareProfitResultList(userId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.LogHelper.LogWriterFromFilter(ex);
        //        result.Result = false;
        //        result.Data = null;
        //    }
        //    return result;
        //}

        public ResultInfo<List<pbs_basic_ShareDetail>> GetShareDetailList()
        {
            ResultInfo<List<pbs_basic_ShareDetail>> result = new ResultInfo<List<pbs_basic_ShareDetail>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetShareDetailList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }
    }
}
