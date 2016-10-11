using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Helper;
using PBS.Model;
using Utility;

namespace PBS.Dao
{
    public class pbs_basic_GoodsDao : DBOperation
    {
        /// <summary>
        /// 判断商品名称是否存在
        /// </summary>
        /// <param name="goodsName">商品名称</param>
        /// <returns></returns>
        public bool ExistsByGoodsName(string goodsName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pbs_basic_Goods");
            strSql.Append(" where GoodsName=@goodsName");
            SqlParameter[] parameters = {
                    new SqlParameter("@goodsName", SqlDbType.NVarChar,100)
            };
            parameters[0].Value = goodsName;

            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
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
        /// <param name="goodsCost">成本</param>
        /// <param name="activityClassId">活动筛选分类编号</param>
        /// <param name="platformCost">平台服务费	</param>
        /// <param name="otherCost">其他费用</param>
        /// <returns></returns>
        public bool AddGoods(string goodsName, decimal marketPrice, decimal sellingPrice, string goodsDesc,
            int goodsClassId, int goodsTypeId, int ageRangeId, int regionId, string goodsMainImgUrl,
            string visitTime1, string visitTime2, string visitTime3, string visitTime4, string visitTime5,
            string longitude, string latitude, int goodsStatus, int isDisplayHome, int isDelete,
            DateTime createTime, DateTime updateTime, int creatorId, string remark,string responsiblePerson,
            decimal responsiblePersonProfit, int goodsCount, decimal goodsCost,int activityClassId,decimal platformCost,decimal otherCost)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_Goods(");
            strSql.Append("GoodsName,MarketPrice,SellingPrice,GoodsDesc,GoodsClassId,GoodsTypeId,AgeRangeId,RegionId,GoodsMainImgUrl,VisitTime1,VisitTime2,VisitTime3,VisitTime4,VisitTime5,Longitude,Latitude,GoodsStatus,IsDisplayHome,IsDelete,CreateTime,UpdateTime,CreatorId,Remark,ResponsiblePerson,ResponsiblePersonProfit,GoodsCount,GoodsCost,ActivityClassId,PlatformCost,OtherCost)");
            strSql.Append(" values (");
            strSql.Append("@GoodsName,@MarketPrice,@SellingPrice,@GoodsDesc,@GoodsClassId,@GoodsTypeId,@AgeRangeId,@RegionId,@GoodsMainImgUrl,@VisitTime1,@VisitTime2,@VisitTime3,@VisitTime4,@VisitTime5,@Longitude,@Latitude,@GoodsStatus,@IsDisplayHome,@IsDelete,@CreateTime,@UpdateTime,@CreatorId,@Remark,@ResponsiblePerson,@ResponsiblePersonProfit,@GoodsCount,@GoodsCost,@ActivityClassId,@PlatformCost,@OtherCost)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters =
            {
                new SqlParameter("@GoodsName", SqlDbType.NVarChar, 200),
                new SqlParameter("@MarketPrice", SqlDbType.Decimal, 9),
                new SqlParameter("@SellingPrice", SqlDbType.Decimal, 9),
                new SqlParameter("@GoodsDesc", SqlDbType.NVarChar, -1),
                new SqlParameter("@GoodsClassId", SqlDbType.Int, 4),
                new SqlParameter("@GoodsTypeId", SqlDbType.Int, 4),
                new SqlParameter("@AgeRangeId", SqlDbType.Int, 4),
                new SqlParameter("@RegionId", SqlDbType.Int, 4),
                new SqlParameter("@GoodsMainImgUrl", SqlDbType.NVarChar, 200),
                new SqlParameter("@VisitTime1", SqlDbType.NVarChar, 200),
                new SqlParameter("@VisitTime2", SqlDbType.NVarChar, 200),
                new SqlParameter("@VisitTime3", SqlDbType.NVarChar, 200),
                new SqlParameter("@VisitTime4", SqlDbType.NVarChar, 200),
                new SqlParameter("@VisitTime5", SqlDbType.NVarChar, 200),
                new SqlParameter("@Longitude", SqlDbType.NVarChar, 200),
                new SqlParameter("@Latitude", SqlDbType.NVarChar, 200),
                new SqlParameter("@GoodsStatus", SqlDbType.Int, 4),
                new SqlParameter("@IsDisplayHome", SqlDbType.Int, 4),
                new SqlParameter("@IsDelete", SqlDbType.Int, 4),
                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                new SqlParameter("@CreatorId", SqlDbType.Int, 4),
                new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
                new SqlParameter("@ResponsiblePerson", SqlDbType.NVarChar, 200),
                new SqlParameter("@ResponsiblePersonProfit", SqlDbType.Decimal, 9),
                new SqlParameter("@GoodsCount", SqlDbType.Int, 4),
                new SqlParameter("@GoodsCost", SqlDbType.Decimal, 9),
                new SqlParameter("@ActivityClassId", SqlDbType.Int, 4),
                new SqlParameter("@PlatformCost", SqlDbType.Decimal, 9),
                new SqlParameter("@OtherCost", SqlDbType.Decimal, 9)
            };

            parameters[0].Value = goodsName;
            parameters[1].Value = marketPrice;
            parameters[2].Value = sellingPrice;
            parameters[3].Value = goodsDesc;
            parameters[4].Value = goodsClassId;
            parameters[5].Value = goodsTypeId;
            parameters[6].Value = ageRangeId;
            parameters[7].Value = regionId;
            parameters[8].Value = goodsMainImgUrl;
            parameters[9].Value = visitTime1;
            parameters[10].Value = visitTime2;
            parameters[11].Value = visitTime3;
            parameters[12].Value = visitTime4;
            parameters[13].Value = visitTime5;
            parameters[14].Value = longitude;
            parameters[15].Value = latitude;
            parameters[16].Value = goodsStatus;
            parameters[17].Value = isDisplayHome;
            parameters[18].Value = isDelete;
            parameters[19].Value = createTime;
            parameters[20].Value = updateTime;
            parameters[21].Value = creatorId;
            parameters[22].Value = remark;
            parameters[23].Value = responsiblePerson;
            parameters[24].Value = responsiblePersonProfit;
            parameters[25].Value = goodsCount;
            parameters[26].Value = goodsCost;
            parameters[27].Value = activityClassId;
            parameters[28].Value = platformCost;
            parameters[29].Value = otherCost;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
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
        /// <param name="goodsId">商品编号</param>
        /// <param name="goodsCost">成本</param>
        /// <param name="activityClassId">活动筛选分类编号</param>
        /// <param name="platformCost">平台服务费	</param>
        /// <param name="otherCost">其他费用</param>
        /// <returns></returns>
        public bool UpdateGoods(string goodsName, decimal marketPrice, decimal sellingPrice, string goodsDesc,
            int goodsClassId, int goodsTypeId, int ageRangeId, int regionId, string goodsMainImgUrl,
            string visitTime1, string visitTime2, string visitTime3, string visitTime4, string visitTime5,
            string longitude, string latitude, int goodsStatus, int isDisplayHome, int isDelete,
            DateTime createTime, DateTime updateTime, int creatorId, string remark, string responsiblePerson,
            decimal responsiblePersonProfit, int goodsCount, decimal goodsCost, int activityClassId, decimal platformCost, decimal otherCost, int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Goods set ");
            strSql.Append("GoodsName=@GoodsName,");
            strSql.Append("MarketPrice=@MarketPrice,");
            strSql.Append("SellingPrice=@SellingPrice,");
            strSql.Append("GoodsDesc=@GoodsDesc,");
            strSql.Append("GoodsClassId=@GoodsClassId,");
            strSql.Append("GoodsTypeId=@GoodsTypeId,");
            strSql.Append("AgeRangeId=@AgeRangeId,");
            strSql.Append("RegionId=@RegionId,");
            strSql.Append("GoodsMainImgUrl=@GoodsMainImgUrl,");
            strSql.Append("VisitTime1=@VisitTime1,");
            strSql.Append("VisitTime2=@VisitTime2,");
            strSql.Append("VisitTime3=@VisitTime3,");
            strSql.Append("VisitTime4=@VisitTime4,");
            strSql.Append("VisitTime5=@VisitTime5,");
            strSql.Append("Longitude=@Longitude,");
            strSql.Append("Latitude=@Latitude,");
            strSql.Append("GoodsStatus=@GoodsStatus,");
            strSql.Append("IsDisplayHome=@IsDisplayHome,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("ResponsiblePerson=@ResponsiblePerson,");
            strSql.Append("ResponsiblePersonProfit=@ResponsiblePersonProfit,");
            strSql.Append("GoodsCount=@GoodsCount,");
            strSql.Append("GoodsCost=@GoodsCost,");
            strSql.Append("ActivityClassId=@ActivityClassId,");
            strSql.Append("PlatformCost=@PlatformCost,");
            strSql.Append("OtherCost=@OtherCost");
            strSql.Append(" where GoodsId=@GoodsId");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsName", SqlDbType.NVarChar,200),
                    new SqlParameter("@MarketPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@SellingPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@GoodsDesc", SqlDbType.NVarChar,-1),
                    new SqlParameter("@GoodsClassId", SqlDbType.Int,4),
                    new SqlParameter("@GoodsTypeId", SqlDbType.Int,4),
                    new SqlParameter("@AgeRangeId", SqlDbType.Int,4),
                    new SqlParameter("@RegionId", SqlDbType.Int,4),
                    new SqlParameter("@GoodsMainImgUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@VisitTime1", SqlDbType.NVarChar,200),
                    new SqlParameter("@VisitTime2", SqlDbType.NVarChar,200),
                    new SqlParameter("@VisitTime3", SqlDbType.NVarChar,200),
                    new SqlParameter("@VisitTime4", SqlDbType.NVarChar,200),
                    new SqlParameter("@VisitTime5", SqlDbType.NVarChar,200),
                    new SqlParameter("@Longitude", SqlDbType.NVarChar,200),
                    new SqlParameter("@Latitude", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsStatus", SqlDbType.Int,4),
                    new SqlParameter("@IsDisplayHome", SqlDbType.Int,4),
                    new SqlParameter("@IsDelete", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@ResponsiblePerson", SqlDbType.NVarChar,200),
                    new SqlParameter("@ResponsiblePersonProfit", SqlDbType.Decimal,9),
                    new SqlParameter("@GoodsCount", SqlDbType.Int,4),
                    new SqlParameter("@GoodsCost", SqlDbType.Decimal, 9),
                    new SqlParameter("@ActivityClassId", SqlDbType.Int, 4),
                    new SqlParameter("@PlatformCost", SqlDbType.Decimal, 9),
                    new SqlParameter("@OtherCost", SqlDbType.Decimal, 9),
                    new SqlParameter("@GoodsId", SqlDbType.Int,4)};
            parameters[0].Value = goodsName;
            parameters[1].Value = marketPrice;
            parameters[2].Value = sellingPrice;
            parameters[3].Value = goodsDesc;
            parameters[4].Value = goodsClassId;
            parameters[5].Value = goodsTypeId;
            parameters[6].Value = ageRangeId;
            parameters[7].Value = regionId;
            parameters[8].Value = goodsMainImgUrl;
            parameters[9].Value = visitTime1;
            parameters[10].Value = visitTime2;
            parameters[11].Value = visitTime3;
            parameters[12].Value = visitTime4;
            parameters[13].Value = visitTime5;
            parameters[14].Value = longitude;
            parameters[15].Value = latitude;
            parameters[16].Value = goodsStatus;
            parameters[17].Value = isDisplayHome;
            parameters[18].Value = isDelete;
            parameters[19].Value = createTime;
            parameters[20].Value = updateTime;
            parameters[21].Value = creatorId;
            parameters[22].Value = remark;
            parameters[23].Value = responsiblePerson;
            parameters[24].Value = responsiblePersonProfit;
            parameters[25].Value = goodsCount;
            parameters[26].Value = goodsCost;
            parameters[27].Value = activityClassId;
            parameters[28].Value = platformCost;
            parameters[29].Value = otherCost;
            parameters[30].Value = goodsId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 修改商品状态
        /// </summary>
        /// <param name="goodsStatus">商品状态</param>
        /// <param name="goodsId">商品Id</param>
        /// <returns></returns>
        public bool UpdateGoodsStatus(int goodsStatus, int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Goods set ");
            strSql.Append("IsDelete=@IsDelete");
            strSql.Append(" where GoodsId=@GoodsId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@GoodsStatus", SqlDbType.Int, 4),
                new SqlParameter("@GoodsId", SqlDbType.Int, 4)
            };
            parameters[0].Value = goodsStatus;
            parameters[1].Value = goodsId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 删除商品（假删除）
        /// </summary>
        /// <param name="isDelete">是否删除</param>
        /// <param name="goodsId">商品Id</param>
        /// <returns></returns>
        public bool UpdateGoodsIsDelete(int isDelete, int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Goods set ");
            strSql.Append("IsDelete=@IsDelete");
            strSql.Append(" where GoodsId=@GoodsId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsDelete", SqlDbType.Int, 4),
                new SqlParameter("@GoodsId", SqlDbType.Int, 4)
            };

            parameters[0].Value = isDelete;
            parameters[1].Value = goodsId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 删除一条商品信息
        /// </summary>
        /// <param name="goodsId">商品编号</param>
        /// <returns></returns>
        public bool DeleteGoods(int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_Goods ");
            strSql.Append(" where GoodsId=@GoodsId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = goodsId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 根据商品编号获取商品对象实体
        /// </summary>
        /// <param name="goodsId">商品编号</param>
        /// <returns></returns>
        public pbs_basic_Goods GetGoodsModelById(int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [GoodsId],[GoodsName],[MarketPrice],[SellingPrice],[GoodsDesc],[GoodsClassId],[GoodsTypeId],[AgeRangeId],[RegionId],[GoodsMainImgUrl],[VisitTime1],[VisitTime2],[VisitTime3],[VisitTime4],[VisitTime5],[Longitude],[Latitude],[GoodsStatus],[IsDisplayHome],[IsDelete],[CreateTime],[UpdateTime],[CreatorId],[Remark],[ResponsiblePerson],[ResponsiblePersonProfit],[GoodsCount],[GoodsCost],[ActivityClassId],[PlatformCost],[OtherCost] from pbs_basic_Goods ");
            strSql.Append(" where GoodsId=@GoodsId");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsId", SqlDbType.Int,4)
            };
            parameters[0].Value = goodsId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Goods> list = Utility.ModelConvertHelper<pbs_basic_Goods>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public pbs_basic_GoodsView GetGoodsModelViewById(int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.GoodsId,a.GoodsName,a.MarketPrice,a.SellingPrice,a.GoodsClassId,b.GoodsClassName,a.GoodsTypeId,c.GoodsTypeName,a.AgeRangeId,e.AgeRangeName,a.RegionId,f.RegionName,a.GoodsStatus,a.CreateTime,a.CreatorId,");
            strSql.Append(" a.GoodsDesc, a.GoodsMainImgUrl,a.VisitTime1,a.VisitTime2,a.VisitTime3,a.VisitTime4,a.VisitTime5,a.Longitude,a.Latitude,a.GoodsStatus,a.IsDisplayHome,a.IsDelete,a.Remark,a.ResponsiblePerson,a.ResponsiblePersonProfit,a.GoodsCount,a.GoodsCost,a.ActivityClassId ");
            strSql.Append(" FROM pbs_basic_Goods a,pbs_basic_GoodsClass b,pbs_basic_GoodsType c,pbs_basic_AgeRange e,pbs_basic_Region f");
            strSql.Append(" WHERE a.GoodsClassId=b.GoodsClassId AND a.GoodsTypeId=c.GoodsTypeId AND a.AgeRangeId=e.AgeRangeId AND a.RegionId=f.RegionId AND a.IsDelete=0 ");
            strSql.Append(" AND a.GoodsId=@GoodsId");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsId", SqlDbType.Int,4)
            };
            parameters[0].Value = goodsId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_GoodsView> list = Utility.ModelConvertHelper<pbs_basic_GoodsView>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
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
        /// <returns></returns>
        public List<pbs_basic_GoodsView> GetGoodsList(string goodsName, int goodsClassId, int goodsTypeId, int ageRangeId, int regionId, int goodsStatus, decimal startPice, decimal endPrice, int isDisplayHome, int activityClassId)
        {
            List<pbs_basic_GoodsView> list = new List<pbs_basic_GoodsView>();
            StringBuilder strSql = new StringBuilder();
            //GoodsId,GoodsName,MarketPrice,SellingPrice,GoodsDesc,GoodsClassId,GoodsTypeId,AgeRangeId,RegionId,GoodsMainImgUrl,VisitTime1,VisitTime2,VisitTime3,VisitTime4,VisitTime5,Longitude,Latitude,GoodsStatus,IsDisplayHome,IsDelete

            strSql.Append("with cte1 as ( ");
            strSql.Append("SELECT a.GoodsId,a.GoodsName,a.MarketPrice,a.SellingPrice,a.GoodsClassId,b.GoodsClassName,a.GoodsTypeId,c.GoodsTypeName,a.AgeRangeId,e.AgeRangeName,a.RegionId,f.RegionName,a.GoodsStatus,a.CreateTime,a.CreatorId,");
            strSql.Append(" a.GoodsDesc, a.GoodsMainImgUrl,a.VisitTime1,a.VisitTime2,a.VisitTime3,a.VisitTime4,a.VisitTime5,a.Longitude,a.Latitude,a.IsDisplayHome,a.IsDelete,a.ResponsiblePerson,a.ResponsiblePersonProfit,a.GoodsCount,a.GoodsCost,a.ActivityClassId ");
            strSql.Append(" FROM pbs_basic_Goods a,pbs_basic_GoodsClass b,pbs_basic_GoodsType c,pbs_basic_AgeRange e,pbs_basic_Region f,pbs_basic_ActivityClass g");
            strSql.Append(" WHERE a.GoodsClassId=b.GoodsClassId AND a.GoodsTypeId=c.GoodsTypeId AND a.AgeRangeId=e.AgeRangeId AND a.RegionId=f.RegionId AND a.ActivityClassId=g.ActivityClassId AND a.IsDelete=0 ");
            if (!string.IsNullOrEmpty(goodsName))
            {
                strSql.Append(" AND (a.GoodsName like '%'+@GoodsName+'%') ");
            }

            if (goodsClassId != -1)
            {
                strSql.Append(" AND a.GoodsClassId=@GoodsClassId ");
            }

            if (goodsTypeId != -1)
            {
                strSql.Append(" AND a.GoodsTypeId=@GoodsTypeId ");
            }
            if (ageRangeId != -1)
            {
                strSql.Append(" AND a.AgeRangeId=@AgeRangeId ");
            }
            if (regionId != -1)
            {
                strSql.Append(" AND a.RegionId=@RegionId ");
            }

            if (goodsStatus != -1)
            {
                strSql.Append(" AND a.GoodsStatus=@GoodsStatus ");
            }

            if (isDisplayHome != -1)
            {
                strSql.Append(" AND a.IsDisplayHome=@IsDisplayHome ");
            }

            //if (Utility.Util.ValidateHelper.IsDate(startTime.ToString()))
            //{
            //    strSql.Append(" AND a.CreateTime>='@StartTime' ");
            //}

            //if (Utility.Util.ValidateHelper.IsDate(endTime.ToString()))
            //{
            //    strSql.Append(" AND a.CreateTime<='@EndTime' ");
            //}

            if (startPice != -1)
            {
                strSql.Append(" AND a.SellingPrice>='@StartPrice' ");
            }

            if (endPrice != -1)
            {
                strSql.Append(" AND a.SellingPrice<='@EndPrice' ");
            }

            if (activityClassId != -1)
            {
                strSql.Append(" AND a.ActivityClassId=@ActivityClassId ");
            }

            //if (isOrderBy != -1)
            //{
            //    strSql.Append(" order by a.GoodsId desc ");
            //}

            strSql.Append("), cte2 as ( select GoodsId,count(GoodsId) as gCount from pbs_basic_Order group by GoodsId)");
            strSql.Append("select x.*,IsNull(y.gCount,0) as SellCount from cte1 x left join cte2 y on x.GoodsId = y.GoodsId ");

            SqlParameter[] parameters ={
                new SqlParameter("@GoodsName",SqlDbType.NVarChar,200),
                new SqlParameter("@GoodsClassId",SqlDbType.Int,4),
                new SqlParameter("@GoodsTypeId",SqlDbType.Int,4),
                new SqlParameter("@AgeRangeId",SqlDbType.Int,4),
                new SqlParameter("@RegionId",SqlDbType.Int,4),
                new SqlParameter("@GoodsStatus",SqlDbType.Int,4),
                //new SqlParameter("@StartTime",SqlDbType.DateTime),
                //new SqlParameter("@EndTime",SqlDbType.DateTime),
                new SqlParameter("@StartPice",SqlDbType.Decimal),
                new SqlParameter("@EndPrice",SqlDbType.Decimal),
                new SqlParameter("@IsDisplayHome",SqlDbType.Int,4),
                new SqlParameter("@ActivityClassId",SqlDbType.Int,4)
            };

            parameters[0].Value = goodsName;
            parameters[1].Value = goodsClassId;
            parameters[2].Value = goodsTypeId;
            parameters[3].Value = ageRangeId;
            parameters[4].Value = regionId;
            parameters[5].Value = goodsStatus;
            //parameters[6].Value = startTime;
            //parameters[7].Value = endTime;
            parameters[6].Value = startPice;
            parameters[7].Value = endPrice;
            parameters[8].Value = isDisplayHome;
            parameters[9].Value = activityClassId;

            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];

            IList<pbs_basic_GoodsView> ilist = Utility.ModelConvertHelper<pbs_basic_GoodsView>.ConvertToModel(dt);
            list = new List<pbs_basic_GoodsView>(ilist);

            return list;
        }

        public List<pbs_basic_GoodsAdmin> GetGoodsAdminList()
        {
            List<pbs_basic_GoodsAdmin> list = new List<pbs_basic_GoodsAdmin>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" with cte1 as (  ");
            strSql.Append(" SELECT a.GoodsId,a.GoodsName,a.MarketPrice,a.SellingPrice,a.GoodsClassId,a.GoodsTypeId,a.AgeRangeId,a.RegionId,f.RegionName,a.GoodsStatus,a.CreateTime,a.CreatorId,a.GoodsDesc,  ");
            strSql.Append(" a.GoodsMainImgUrl,a.VisitTime1,a.VisitTime2,a.VisitTime3,a.VisitTime4,a.VisitTime5,a.Longitude,a.Latitude,a.IsDisplayHome,a.IsDelete,a.ResponsiblePerson,a.ResponsiblePersonProfit,a.GoodsCount,a.GoodsCost ");
            strSql.Append(" FROM pbs_basic_Goods a,pbs_basic_Region f ");
            strSql.Append(" WHERE a.RegionId=f.RegionId AND a.IsDelete=0 ");
            strSql.Append(" ), cte2 as ( select GoodsId,count(GoodsId) as gCount from pbs_basic_Order group by GoodsId) ");
            strSql.Append(" select x.*,IsNull(y.gCount,0) as SellCount from cte1 x left join cte2 y on x.GoodsId = y.GoodsId ");
            strSql.Append(" order by GoodsId ");

            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_GoodsAdmin> ilist = Utility.ModelConvertHelper<pbs_basic_GoodsAdmin>.ConvertToModel(dt);
            list = new List<pbs_basic_GoodsAdmin>(ilist);
            return list;
        }

        public bool UpdateGoodsCountMinus(int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Goods set ");
            strSql.Append("GoodsCount=GoodsCount-1");
            strSql.Append(" where GoodsId=@GoodsId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@GoodsId", SqlDbType.Int, 4)
            };
            parameters[0].Value = goodsId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateGoodsCountPlus(int goodsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Goods set ");
            strSql.Append("GoodsCount=GoodsCount+1");
            strSql.Append(" where GoodsId=@GoodsId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@GoodsId", SqlDbType.Int, 4)
            };
            parameters[0].Value = goodsId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

    }
}
