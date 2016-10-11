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
    public class pbs_basic_GoodsTypeDao : DBOperation
    {
        /// <summary>
        /// 获取所有商品类型列表
        /// </summary>
        /// <returns></returns>
        public List<pbs_basic_GoodsType> GetAllGoodTypeList()
        {
            List<pbs_basic_GoodsType> list = new List<pbs_basic_GoodsType>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select [GoodsTypeId],[GoodsTypeName],[CreateTime],[UpdateTime],[CreatorId],[Remark],[GoodsTypeDesc],[GoodsTypePrice] from [dbo].[pbs_basic_GoodsType] ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_GoodsType> ilist = Utility.ModelConvertHelper<pbs_basic_GoodsType>.ConvertToModel(dt);
            list = new List<pbs_basic_GoodsType>(ilist);
            return list;
        }

        /// <summary>
        /// 根据商品类别编号获取商品类别对象实体
        /// </summary>
        /// <param name="goodsTypeId">商品类型编号</param>
        /// <returns></returns>
        public pbs_basic_GoodsType GetGoodTypeModelById(int goodsTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT [GoodsTypeId],[GoodsTypeName],[CreateTime],[UpdateTime],[CreatorId],[Remark],[GoodsTypeDesc],[GoodsTypePrice] FROM pbs_basic_GoodsType ");
            strSql.Append(" where GoodsTypeId=@GoodsTypeId");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsTypeId", SqlDbType.Int,4)
            };
            parameters[0].Value = goodsTypeId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_GoodsType> list = Utility.ModelConvertHelper<pbs_basic_GoodsType>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
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
        public bool AddGoodType(string goodsTypeName, DateTime createTime, DateTime updateTime, int creatorId, string remark,string goodsTypeDesc,decimal goodsTypePrice)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_GoodsType(");
            strSql.Append("GoodsTypeName,CreateTime,UpdateTime,CreatorId,Remark,GoodsTypeDesc,GoodsTypePrice)");
            strSql.Append(" values (");
            strSql.Append("@GoodsTypeName,@CreateTime,@UpdateTime,@CreatorId,@Remark,@GoodsTypeDesc,@GoodsTypePrice)");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsTypeName", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsTypeDesc", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsTypePrice", SqlDbType.Decimal,9)
            };
            parameters[0].Value = goodsTypeName;
            parameters[1].Value = createTime;
            parameters[2].Value = updateTime;
            parameters[3].Value = creatorId;
            parameters[4].Value = remark;
            parameters[5].Value = goodsTypeDesc;
            parameters[6].Value = goodsTypePrice;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
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
        public bool UpdateGoodType(string goodsTypeName, DateTime createTime, DateTime updateTime, int creatorId, string remark, string goodsTypeDesc, decimal goodsTypePrice, int goodsTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_GoodsType set ");
            strSql.Append("GoodsTypeName=@GoodsTypeName,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("GoodsTypeDesc=@GoodsTypeDesc,");
            strSql.Append("GoodsTypePrice=@GoodsTypePrice");
            strSql.Append(" where GoodsTypeId=@goodsTypeId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsTypeName", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsTypeDesc", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsTypePrice", SqlDbType.Decimal,9),
                    new SqlParameter("@GoodsTypeId", SqlDbType.Int,4)};
            parameters[0].Value = goodsTypeName;
            parameters[1].Value = createTime;
            parameters[2].Value = updateTime;
            parameters[3].Value = creatorId;
            parameters[4].Value = remark;
            parameters[5].Value = goodsTypeDesc;
            parameters[6].Value = goodsTypePrice;
            parameters[7].Value = goodsTypeId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 删除一条商品类型记录
        /// </summary>
        /// <param name="goodsTypeId">商品类型编号</param>
        /// <returns></returns>
        public bool DeleteGoodType(int goodsTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_GoodsType ");
            strSql.Append(" where GoodsTypeId=@GoodsTypeId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsTypeId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = goodsTypeId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 根据商品类型名称判断是否存在该类型
        /// </summary>
        /// <param name="goodsTypeName">商品类型名称</param>
        /// <returns></returns>
        public bool IsExistByGoodsTypeName(string goodsTypeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(GoodsTypeId) from pbs_basic_GoodsType ");
            strSql.Append(" where GoodsTypeName=@GoodsTypeName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsTypeName", SqlDbType.NVarChar,255)
                                        };
            parameters[0].Value = goodsTypeName;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public bool IsExistByGoodsTypeId(int goodsTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(GoodsTypeId) from pbs_basic_GoodsType ");
            strSql.Append(" where GoodsTypeId=@GoodsTypeId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsTypeId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = goodsTypeId;
            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

    }
}
