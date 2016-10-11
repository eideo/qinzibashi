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
    public class pbs_basic_GoodsPackageService
    {
        private pbs_basic_GoodsPackageDao dao = new pbs_basic_GoodsPackageDao();

        public ResultInfo<List<pbs_basic_GoodsPackageView>> GetAllGoodsPackageList()
        {
            ResultInfo<List<pbs_basic_GoodsPackageView>> result = new ResultInfo<List<pbs_basic_GoodsPackageView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAllGoodsPackageList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_GoodsPackage>> GetAllGoodsPackageListByGoodsTypeId(int goodsTypeId)
        {
            ResultInfo<List<pbs_basic_GoodsPackage>> result = new ResultInfo<List<pbs_basic_GoodsPackage>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAllGoodsPackageListByGoodsTypeId(goodsTypeId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<pbs_basic_GoodsPackage> GetGoodsPackageModelById(int goodsPackageId)
        {
            ResultInfo<pbs_basic_GoodsPackage> result = new ResultInfo<pbs_basic_GoodsPackage>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetGoodsPackageModelById(goodsPackageId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<bool> AddGoodsPackage(string goodsPackageName, decimal goodsPackagePrice, int goodsTypeId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddGoodsPackage(goodsPackageName, goodsPackagePrice, goodsTypeId, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateGoodsPackage(string goodsPackageName, decimal goodsPackagePrice, int goodsTypeId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int goodsPackageId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateGoodsPackage(goodsPackageName, goodsPackagePrice, goodsTypeId, createTime, updateTime, creatorId, remark, goodsPackageId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteGoodsPackage(int goodsPackageId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteGoodsPackage(goodsPackageId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> IsExistByGoodsPackageName(string goodsPackageName)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByGoodsPackageName(goodsPackageName);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> IsExistByGoodsPackageId(int goodsPackageId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByGoodsPackageId(goodsPackageId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

    }
}
