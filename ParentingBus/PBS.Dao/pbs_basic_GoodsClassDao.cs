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
    public class pbs_basic_GoodsClassDao : DBOperation
    {
        /// <summary>
        /// 获取所有商品分类列表
        /// </summary>
        /// <returns></returns>
        public List<pbs_basic_GoodsClass> GetAllGoodsClassList()
        {
            List<pbs_basic_GoodsClass> list = new List<pbs_basic_GoodsClass>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select [GoodsClassId],[GoodsClassName],[CreateTime],[UpdateTime],[CreatorId],[Remark] from [dbo].[pbs_basic_GoodsClass] ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_GoodsClass> ilist = Utility.ModelConvertHelper<pbs_basic_GoodsClass>.ConvertToModel(dt);
            list = new List<pbs_basic_GoodsClass>(ilist);
            return list;
        }

        /// <summary>
        /// 根据商品类别编号获取商品类别对象实体
        /// </summary>
        /// <param name="goodsClassId">商品分类编号</param>
        /// <returns></returns>
        public pbs_basic_GoodsClass GetGoodsClassModelById(int goodsClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT [GoodsClassId],[GoodsClassName],[CreateTime],[UpdateTime],[CreatorId],[Remark] FROM pbs_basic_GoodsClass ");
            strSql.Append(" where GoodsClassId=@GoodsClassId");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsClassId", SqlDbType.Int,4)
			};
            parameters[0].Value = goodsClassId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_GoodsClass> list = Utility.ModelConvertHelper<pbs_basic_GoodsClass>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
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
        public bool AddGoodsClass(string goodsClassName, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_GoodsClass(");
            strSql.Append("GoodsClassName,CreateTime,UpdateTime,CreatorId,Remark)");
            strSql.Append(" values (");
            strSql.Append("@GoodsClassName,@CreateTime,@UpdateTime,@CreatorId,@Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsClassName", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = goodsClassName;
            parameters[1].Value = createTime;
            parameters[2].Value = updateTime;
            parameters[3].Value = creatorId;
            parameters[4].Value = remark;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
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
        public bool UpdateGoodsClass(string goodsClassName, DateTime createTime, DateTime updateTime, int creatorId, string remark, int goodsClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_GoodsClass set ");
            strSql.Append("GoodsClassName=@GoodsClassName,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where GoodsClassId=@goodsClassId ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsClassName", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsClassId", SqlDbType.Int,4)};
            parameters[0].Value = goodsClassName;
            parameters[1].Value = createTime;
            parameters[2].Value = updateTime;
            parameters[3].Value = creatorId;
            parameters[4].Value = remark;
            parameters[5].Value = goodsClassId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 删除一条商品分类记录
        /// </summary>
        /// <param name="goodsClassId">商品分类编号</param>
        /// <returns></returns>
        public bool DeleteGoodsClass(int goodsClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_GoodsClass ");
            strSql.Append(" where GoodsClassId=@GoodsClassId ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsClassId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = goodsClassId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 根据商品分类名称判断是否存在该分类
        /// </summary>
        /// <param name="goodsClassName">商品分类名称</param>
        /// <returns></returns>
        public bool IsExistByGoodsClassName(string goodsClassName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(GoodsClassId) from pbs_basic_GoodsClass ");
            strSql.Append(" where GoodsClassName=@GoodsClassName ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsClassName", SqlDbType.NVarChar,255)
                                        };
            parameters[0].Value = goodsClassName;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public bool IsExistByGoodsClassId(int goodsClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(GoodsClassId) from pbs_basic_GoodsClass ");
            strSql.Append(" where GoodsClassId=@GoodsClassId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsClassId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = goodsClassId;

            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

    }
}
