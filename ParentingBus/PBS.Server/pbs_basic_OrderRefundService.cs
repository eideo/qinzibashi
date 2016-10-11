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
    public class pbs_basic_OrderRefundService
    {
        pbs_basic_OrderRefundDao dao = new pbs_basic_OrderRefundDao();

        public ResultInfo<bool> AddOrderRefund(int orderId, int userId, string reason, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddOrderRefund(orderId, userId, reason, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateOrderRefund(int orderId, int userId, string reason, DateTime createTime, DateTime updateTime, int creatorId, string remark, int refundId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateOrderRefund(orderId, userId, reason, createTime, updateTime, creatorId, remark, refundId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteOrderRefund(int refundId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteOrderRefund(refundId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_OrderRefund> GetOrderRefundModelById(int refundId)
        {
            ResultInfo<pbs_basic_OrderRefund> result = new ResultInfo<pbs_basic_OrderRefund>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderRefundModelById(refundId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_OrderRefund>> GetOrderRefundList(int userId)
        {
            ResultInfo<List<pbs_basic_OrderRefund>> result = new ResultInfo<List<pbs_basic_OrderRefund>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderRefundList(userId);
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
