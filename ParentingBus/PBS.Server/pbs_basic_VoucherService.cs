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
    public class pbs_basic_VoucherService
    {
        private pbs_basic_VoucherDao dao = new pbs_basic_VoucherDao();

        /// <summary>
        /// 获取所有优惠券列表
        /// </summary>
        /// <returns></returns>
        public ResultInfo<List<pbs_basic_Voucher>> GetAllVoucherList()
        {
            ResultInfo<List<pbs_basic_Voucher>> result = new ResultInfo<List<pbs_basic_Voucher>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAllVoucherList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        /// <summary>
        /// 根据优惠券编号获取优惠券对象实体
        /// </summary>
        /// <param name="voucherId">优惠券编号</param>
        /// <returns></returns>
        public ResultInfo<pbs_basic_Voucher> GetVoucherModelById(int voucherId)
        {
            ResultInfo<pbs_basic_Voucher> result = new ResultInfo<pbs_basic_Voucher>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetVoucherModelById(voucherId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        /// <summary>
        /// 增加一条优惠券记录
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
        /// <param name="voucherCount"></param>
        /// <returns></returns>
        public ResultInfo<bool> AddVoucher(decimal voucherPrice, string useRole, int voucherType, decimal sRPrice, string useStartTime, string useEndTime, int voucherStatus, DateTime createTime, DateTime updateTime, int creatorId, string remark,int voucherCount)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddVoucher(voucherPrice, useRole, voucherType, sRPrice, useStartTime, useEndTime, voucherStatus, createTime, updateTime, creatorId, remark, voucherCount);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        /// <summary>
        /// 修改一条优惠券记录
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
        /// <param name="voucherCount"></param>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public ResultInfo<bool> UpdateVoucher(decimal voucherPrice, string useRole, int voucherType, decimal sRPrice, string useStartTime, string useEndTime, int voucherStatus, DateTime createTime, DateTime updateTime, int creatorId, string remark,int voucherCount, int voucherId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateVoucher(voucherPrice, useRole, voucherType, sRPrice, useStartTime, useEndTime, voucherStatus, createTime, updateTime, creatorId, remark, voucherCount, voucherId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        /// <summary>
        /// 删除一条优惠券记录
        /// </summary>
        /// <param name="voucherId">优惠券编号</param>
        /// <returns></returns>
        public ResultInfo<bool> DeleteVoucher(int voucherId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteVoucher(voucherId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        ///// <summary>
        ///// 根据优惠券名称判断是否存在该分类
        ///// </summary>
        ///// <param name="voucherName">优惠券名称</param>
        ///// <returns></returns>
        //public ResultInfo<bool> IsExistByVoucherName(string voucherName)
        //{
        //    ResultInfo<bool> result = new ResultInfo<bool>();
        //    result.Result = false;
        //    try
        //    {
        //        result.Result = true;
        //        result.Data = dao.IsExistByVoucherName(voucherName);
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.LogHelper.LogWriterFromFilter(ex);
        //        result.Result = false;
        //        result.Data = false;
        //    }
        //    return result;
        //}
    }
}
