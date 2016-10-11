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
    public class pbs_basic_OrderMemberService
    {
        pbs_basic_OrderMemberDao dao = new pbs_basic_OrderMemberDao();

        public ResultInfo<bool> AddOrderMember(int memberId, DateTime createTime, DateTime updateTime, int creatorId, int orderId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddOrderMember(memberId, createTime, updateTime, creatorId, remark, orderId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateOrderMember(int memberId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int orderId, int OrderMemberId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateOrderMember(memberId, createTime, updateTime, creatorId, remark, orderId, OrderMemberId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteOrderMember(int orderMemberId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteOrderMember(orderMemberId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_OrderMember> GetOrderMemberModelById(int orderMemberId)
        {
            ResultInfo<pbs_basic_OrderMember> result = new ResultInfo<pbs_basic_OrderMember>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderMemberModelById(orderMemberId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_OrderMember>> GetOrderMemberList(int memberId)
        {
            ResultInfo<List<pbs_basic_OrderMember>> result = new ResultInfo<List<pbs_basic_OrderMember>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetOrderMemberList(memberId);
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
