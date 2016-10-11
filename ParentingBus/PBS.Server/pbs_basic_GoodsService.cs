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
    public class pbs_basic_GoodsService
    {
        private pbs_basic_GoodsDao dao = new pbs_basic_GoodsDao();

        /// <summary>
        /// 判断商品名称是否存在
        /// </summary>
        /// <param name="goodsName">商品名称</param>
        /// <returns></returns>
        public ResultInfo<bool> ExistsByGoodsName(string goodsName)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.ExistsByGoodsName(goodsName);
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
        /// 增加一条商品信息
        /// </summary>
        /// <param name="goodsName">商品名称</param>
        /// <param name="marketPrice">市场价</param>
        /// <param name="sellingPrice">销售价</param>
        /// <param name="goodsDesc">商品描述</param>
        /// <param name="goodsClassId">商品分类Id</param>
        /// <param name="goodsTypeId">商品类型Id</param>
        /// <param name="ageRangeId">年龄范围Id</param>
        /// <param name="regionId">区域范围Id</param>
        /// <param name="goodsMainImgUrl">商品主图路径</param>
        /// <param name="visitTime1">参加时间1</param>
        /// <param name="visitTime2">参加时间2</param>
        /// <param name="visitTime3">参加时间3</param>
        /// <param name="visitTime4">参加时间4</param>
        /// <param name="visitTime5">参加时间5</param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="goodsStatus">商品状态</param>
        /// <param name="isDisplayHome">是否首页显示</param>
        /// <param name="isDelete">是否删除</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者Id</param>
        /// <param name="remark">备注</param>
        /// <param name="responsiblePerson">负责人</param>
        /// <param name="responsiblePersonProfit">负责人收益</param>
        /// <param name="goodsCount">名额</param>
        /// <param name="activityClassId">活动筛选分类编号</param>
        /// <param name="platformCost">平台服务费	</param>
        /// <param name="otherCost">其他费用</param>
        /// <returns></returns>
        public ResultInfo<bool> AddGoods(string goodsName, decimal marketPrice, decimal sellingPrice, string goodsDesc,
            int goodsClassId, int goodsTypeId, int ageRangeId, int regionId, string goodsMainImgUrl,
            string visitTime1, string visitTime2, string visitTime3, string visitTime4, string visitTime5,
            string longitude, string latitude, int goodsStatus, int isDisplayHome, int isDelete,
            DateTime createTime, DateTime updateTime, int creatorId, string remark, string responsiblePerson, decimal responsiblePersonProfit, int goodsCount, decimal goodsCost, int activityClassId, decimal platformCost, decimal otherCost)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddGoods(goodsName, marketPrice, sellingPrice, goodsDesc,
             goodsClassId, goodsTypeId, ageRangeId, regionId, goodsMainImgUrl,
             visitTime1, visitTime2, visitTime3, visitTime4, visitTime5,
             longitude, latitude, goodsStatus, isDisplayHome, isDelete,
             createTime, updateTime, creatorId, remark, responsiblePerson, responsiblePersonProfit, goodsCount, goodsCost, activityClassId, platformCost,otherCost);
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
        /// 修改商品信息
        /// </summary>
        /// <param name="goodsName">商品名称</param>
        /// <param name="marketPrice">市场价</param>
        /// <param name="sellingPrice">销售价</param>
        /// <param name="goodsDesc">商品描述</param>
        /// <param name="goodsClassId">商品分类Id</param>
        /// <param name="goodsTypeId">商品类型Id</param>
        /// <param name="ageRangeId">年龄范围Id</param>
        /// <param name="regionId">区域范围Id</param>
        /// <param name="goodsMainImgUrl">商品主图路径</param>
        /// <param name="visitTime1">参加时间1</param>
        /// <param name="visitTime2">参加时间2</param>
        /// <param name="visitTime3">参加时间3</param>
        /// <param name="visitTime4">参加时间4</param>
        /// <param name="visitTime5">参加时间5</param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="goodsStatus">商品状态</param>
        /// <param name="isDisplayHome">是否首页显示</param>
        /// <param name="isDelete">是否删除</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者Id</param>
        /// <param name="remark">备注</param>
        /// <param name="responsiblePerson">负责人</param>
        /// <param name="responsiblePersonProfit">负责人收益</param> 
        /// <param name="goodsCount">名额</param>
        /// <param name="activityClassId">活动筛选分类编号</param>
        /// <param name="platformCost">平台服务费	</param>
        /// <param name="otherCost">其他费用</param>
        /// <param name="goodsId">商品编号</param>
        /// <returns></returns>
        public ResultInfo<bool> UpdateGoods(string goodsName, decimal marketPrice, decimal sellingPrice, string goodsDesc,
            int goodsClassId, int goodsTypeId, int ageRangeId, int regionId, string goodsMainImgUrl,
            string visitTime1, string visitTime2, string visitTime3, string visitTime4, string visitTime5,
            string longitude, string latitude, int goodsStatus, int isDisplayHome, int isDelete,
            DateTime createTime, DateTime updateTime, int creatorId, string remark, string responsiblePerson, decimal responsiblePersonProfit, int goodsCount,decimal goodsCost,int activityClassId, decimal platformCost, decimal otherCost, int goodsId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateGoods(goodsName, marketPrice, sellingPrice, goodsDesc,
             goodsClassId, goodsTypeId, ageRangeId, regionId, goodsMainImgUrl,
             visitTime1, visitTime2, visitTime3, visitTime4, visitTime5,
             longitude, latitude, goodsStatus, isDisplayHome, isDelete,
             createTime, updateTime, creatorId, remark, responsiblePerson, responsiblePersonProfit, goodsCount,goodsCost, activityClassId, platformCost,otherCost, goodsId);
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
        /// 修改商品状态
        /// </summary>
        /// <param name="goodsStatus">商品状态</param>
        /// <param name="goodsId">商品Id</param>
        /// <returns></returns>
        public ResultInfo<bool> UpdateGoodsStatus(int goodsStatus, int goodsId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateGoodsStatus(goodsStatus, goodsId);
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
        /// 删除商品（假删除）
        /// </summary>
        /// <param name="isDelete">是否删除</param>
        /// <param name="goodsId">商品Id</param>
        /// <returns></returns>
        public ResultInfo<bool> UpdateGoodsIsDelete(int isDelete, int goodsId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateGoodsIsDelete(isDelete, goodsId);
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
        /// 删除一条商品信息
        /// </summary>
        /// <param name="goodsId">商品编号</param>
        /// <returns></returns>
        public ResultInfo<bool> DeleteGoods(int goodsId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteGoods(goodsId);
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
        /// 根据商品编号获取商品对象实体
        /// </summary>
        /// <param name="goodsId">商品编号</param>
        /// <returns></returns>
        public ResultInfo<pbs_basic_Goods> GetGoodsModelById(int goodsId)
        {
            ResultInfo<pbs_basic_Goods> result = new ResultInfo<pbs_basic_Goods>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetGoodsModelById(goodsId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<pbs_basic_GoodsView> GetGoodsModelViewById(int goodsId)
        {
            ResultInfo<pbs_basic_GoodsView> result = new ResultInfo<pbs_basic_GoodsView>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetGoodsModelViewById(goodsId);
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
        /// 获取商品列表
        /// </summary>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsClassId">商品分类Id</param>
        /// <param name="goodsTypeId">商品类型Id</param>
        /// <param name="ageRangeId">年龄范围Id</param>
        /// <param name="regionId">区域Id</param>
        /// <param name="goodsStatus">商品状态</param>
        /// <param name="startPice">开始价格（销售）</param>
        /// <param name="endPrice">结束价格（销售）</param>
        /// <param name="activityClassId">活动筛选分类编号</param>
        /// <returns></returns>
        public ResultInfo<List<pbs_basic_GoodsView>> GetGoodsList(string goodsName, int goodsClassId, int goodsTypeId, int ageRangeId, int regionId, int goodsStatus, decimal startPice, decimal endPrice, int isDisplayHome,int activityClassId)
        {
            ResultInfo<List<pbs_basic_GoodsView>> result = new ResultInfo<List<pbs_basic_GoodsView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetGoodsList(goodsName, goodsClassId, goodsTypeId, ageRangeId, regionId, goodsStatus, startPice, endPrice, isDisplayHome, activityClassId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_GoodsAdmin>> GetGoodsAdminList()
        {
            ResultInfo<List<pbs_basic_GoodsAdmin>> result = new ResultInfo<List<pbs_basic_GoodsAdmin>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetGoodsAdminList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<bool> UpdateGoodsCountMinus(int goodsId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateGoodsCountMinus(goodsId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateGoodsCountPlus(int goodsId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateGoodsCountPlus(goodsId);
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
