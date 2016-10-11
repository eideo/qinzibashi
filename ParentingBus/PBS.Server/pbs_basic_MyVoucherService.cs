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
    public class pbs_basic_MyVoucherService
    {
        pbs_basic_MyVoucherDao dao = new pbs_basic_MyVoucherDao();

        public ResultInfo<bool> AddMyVoucher(int userId, int voucherId, int isUsed, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddMyVoucher(userId, voucherId, isUsed, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateMyVoucherIsUsed(int isUsed, int voucherId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateMyVoucherIsUsed(isUsed, voucherId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_MyVoucher> GetMyVoucherModelById(int myVoucherId)
        {
            ResultInfo<pbs_basic_MyVoucher> result = new ResultInfo<pbs_basic_MyVoucher>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMyVoucherModelById(myVoucherId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_MyVoucher>> GetMyVoucherList(int userId)
        {
            ResultInfo<List<pbs_basic_MyVoucher>> result = new ResultInfo<List<pbs_basic_MyVoucher>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMyVoucherList(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_MyVoucherView>> GetMyVoucherViewList(int userId)
        {
            ResultInfo<List<pbs_basic_MyVoucherView>> result = new ResultInfo<List<pbs_basic_MyVoucherView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMyVoucherViewList(userId);
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
