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
    public class pbs_basic_GoodsTypeService
    {
        private pbs_basic_GoodsTypeDao dao = new pbs_basic_GoodsTypeDao();

        /// <summary>
        /// 获取所有商品类型列表
        /// </summary>
        /// <returns></returns>
        public ResultInfo<List<pbs_basic_GoodsType>> GetAllGoodTypeList()
        {
            ResultInfo<List<pbs_basic_GoodsType>> result = new ResultInfo<List<pbs_basic_GoodsType>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAllGoodTypeList();
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
        /// 根据商品类别编号获取商品类别对象实体
        /// </summary>
        /// <param name="goodsTypeId">商品类型编号</param>
        /// <returns></returns>
        public ResultInfo<pbs_basic_GoodsType> GetGoodTypeModelById(int goodsTypeId)
        {
            ResultInfo<pbs_basic_GoodsType> result = new ResultInfo<pbs_basic_GoodsType>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetGoodTypeModelById(goodsTypeId);
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
        /// 增加一条商品类型记录
        /// </summary>
        /// <param name="goodsTypeName">商品类型名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public ResultInfo<bool> AddGoodType(string goodsTypeName, DateTime createTime, DateTime updateTime, int creatorId, string remark, string goodsTypeDesc, decimal goodsTypePrice)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddGoodType(goodsTypeName, createTime, updateTime, creatorId, remark, goodsTypeDesc, goodsTypePrice);
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
        /// 修改一条商品类型记录
        /// </summary>
        /// <param name="goodsTypeName">商品类型名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <param name="goodsTypeId">商品类型编号</param>
        /// <returns></returns>
        public ResultInfo<bool> UpdateGoodType(string goodsTypeName, DateTime createTime, DateTime updateTime, int creatorId, string remark, string goodsTypeDesc, decimal goodsTypePrice, int goodsTypeId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateGoodType(goodsTypeName, createTime, updateTime, creatorId, remark, goodsTypeDesc, goodsTypePrice, goodsTypeId);
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
        /// 删除一条商品类型记录
        /// </summary>
        /// <param name="goodsTypeId">商品类型编号</param>
        /// <returns></returns>
        public ResultInfo<bool> DeleteGoodType(int goodsTypeId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteGoodType(goodsTypeId);
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
        /// 根据商品类型名称判断是否存在该类型
        /// </summary>
        /// <param name="goodsTypeName">商品类型名称</param>
        /// <returns></returns>
        public ResultInfo<bool> IsExistByGoodsTypeName(string goodsTypeName)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByGoodsTypeName(goodsTypeName);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> IsExistByGoodsTypeId(int goodsTypeId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByGoodsTypeId(goodsTypeId);
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
