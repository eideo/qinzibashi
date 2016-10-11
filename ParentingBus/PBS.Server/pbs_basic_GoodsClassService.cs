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
    public class pbs_basic_GoodsClassService
    {
        private pbs_basic_GoodsClassDao dao = new pbs_basic_GoodsClassDao();

        /// <summary>
        /// 获取所有商品分类列表
        /// </summary>
        /// <returns></returns>
        public ResultInfo<List<pbs_basic_GoodsClass>> GetAllGoodsClassList()
        {
            ResultInfo<List<pbs_basic_GoodsClass>> result = new ResultInfo<List<pbs_basic_GoodsClass>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAllGoodsClassList();
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
        /// <param name="goodsClassId">商品分类编号</param>
        /// <returns></returns>
        public ResultInfo<pbs_basic_GoodsClass> GetGoodsClassModelById(int goodsClassId)
        {
            ResultInfo<pbs_basic_GoodsClass> result = new ResultInfo<pbs_basic_GoodsClass>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetGoodsClassModelById(goodsClassId);
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
        /// 增加一条商品分类记录
        /// </summary>
        /// <param name="goodsClassName">商品分类名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public ResultInfo<bool> AddGoodsClass(string goodsClassName, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddGoodsClass(goodsClassName, createTime, updateTime, creatorId, remark);
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
        /// 修改一条商品分类记录
        /// </summary>
        /// <param name="goodsClassName">商品分类名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <param name="goodsClassId">商品分类编号</param>
        /// <returns></returns>
        public ResultInfo<bool> UpdateGoodsClass(string goodsClassName, DateTime createTime, DateTime updateTime, int creatorId, string remark, int goodsClassId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateGoodsClass(goodsClassName, createTime, updateTime, creatorId, remark, goodsClassId);
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
        /// 删除一条商品分类记录
        /// </summary>
        /// <param name="goodsClassId">商品分类编号</param>
        /// <returns></returns>
        public ResultInfo<bool> DeleteGoodsClass(int goodsClassId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteGoodsClass(goodsClassId);
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
        /// 根据商品分类名称判断是否存在该分类
        /// </summary>
        /// <param name="goodsClassName">商品分类名称</param>
        /// <returns></returns>
        public ResultInfo<bool> IsExistByGoodsClassName(string goodsClassName)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByGoodsClassName(goodsClassName);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> IsExistByGoodsClassId(int goodsClassId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByGoodsClassId(goodsClassId);
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
