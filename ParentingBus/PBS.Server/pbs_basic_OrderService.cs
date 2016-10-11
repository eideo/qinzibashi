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
    public class pbs_basic_OrderService
    {
        pbs_basic_OrderDao dao = new pbs_basic_OrderDao();

        public ResultInfo<bool> AddOrder(int goodsId, int count, DateTime visitTime, int userId, int orderMemberId, decimal orderPrice, int voucherId, int orderStatus, DateTime createTime, DateTime updateTime, int creatorId, string remark, string userName, string phone, int goodsPackageId, ref string orderId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddOrder(goodsId, count, visitTime, userId, orderMemberId, orderPrice, voucherId, orderStatus, createTime, updateTime, creatorId, remark, userName, phone, goodsPackageId, ref orderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateOrders(int orderStatus, int orderId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateOrderStatus(orderStatus, orderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateOrderVoucher(int voucherId, int orderId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateOrderVoucher(voucherId, orderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateOrderPrice(decimal orderPrice, int orderId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateOrderPrice(orderPrice, orderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateOrders(int orderStatus,decimal orderPrice, int voucherId, int orderId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateOrderStatus(orderStatus, orderPrice, voucherId, orderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_Order> GetOrderModelById(int OrderId)
        {
            ResultInfo<pbs_basic_Order> result = new ResultInfo<pbs_basic_Order>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderModelById(OrderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<pbs_basic_OrderView> GetOrderModelViewById(int orderId)
        {
            ResultInfo<pbs_basic_OrderView> result = new ResultInfo<pbs_basic_OrderView>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderModelViewById(orderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_Order>> GetOrderListByUserId(int userId)
        {
            ResultInfo<List<pbs_basic_Order>> result = new ResultInfo<List<pbs_basic_Order>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderListByUserId(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_Order>> GetOrderListByUserIdAndStatus(int userId, int orderStatus)
        {
            ResultInfo<List<pbs_basic_Order>> result = new ResultInfo<List<pbs_basic_Order>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderListByUserIdAndStatus(userId, orderStatus);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_OrderView>> GetOrderViewListByUserId(int userId)
        {
            ResultInfo<List<pbs_basic_OrderView>> result = new ResultInfo<List<pbs_basic_OrderView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderViewListByUserId(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_OrderViewRN>> GetOrderViewRNListByUserId(int userId)
        {
            ResultInfo<List<pbs_basic_OrderViewRN>> result = new ResultInfo<List<pbs_basic_OrderViewRN>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderViewRNListByUserId(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_OrderView>> GetOrderViewListByUserIdAndStatus(int userId, int orderStatus)
        {
            ResultInfo<List<pbs_basic_OrderView>> result = new ResultInfo<List<pbs_basic_OrderView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderViewListByUserIdAndStatus(userId, orderStatus);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_Order>> GetOrderList()
        {
            ResultInfo<List<pbs_basic_Order>> result = new ResultInfo<List<pbs_basic_Order>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_OrderView>> GetOrderViewList()
        {
            ResultInfo<List<pbs_basic_OrderView>> result = new ResultInfo<List<pbs_basic_OrderView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderViewList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_OrderView>> GetOrderViewList(string startTime, string endTime)
        {
            ResultInfo<List<pbs_basic_OrderView>> result = new ResultInfo<List<pbs_basic_OrderView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderViewList(startTime, endTime);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<SaleMemberReportSQL>> GetSaleMemberReportSQLList()
        {
            ResultInfo<List<SaleMemberReportSQL>> result = new ResultInfo<List<SaleMemberReportSQL>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetSaleMemberReportSQLList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<bool> DeleteOrder(int orderId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteOrder(orderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<List<SaleGoodsReport>> GetSaleGoodsReportList()
        {
            ResultInfo<List<SaleGoodsReport>> result = new ResultInfo<List<SaleGoodsReport>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetSaleGoodsReportList();
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
