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
    public class pbs_basic_ActivityClassDao : DBOperation
    {
        /// <summary>
        /// 获取所有商品筛选分类列表
        /// </summary>
        /// <returns></returns>
        public List<pbs_basic_ActivityClass> GetAllActivityClassList()
        {
            List<pbs_basic_ActivityClass> list = new List<pbs_basic_ActivityClass>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select [ActivityClassId],[ActivityClassName],[CreateTime],[UpdateTime],[CreatorId],[Remark] from [dbo].[pbs_basic_ActivityClass] ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_ActivityClass> ilist = Utility.ModelConvertHelper<pbs_basic_ActivityClass>.ConvertToModel(dt);
            list = new List<pbs_basic_ActivityClass>(ilist);
            return list;
        }

        /// <summary>
        /// 根据商品类别编号获取商品类别对象实体
        /// </summary>
        /// <param name="activityClassId">商品筛选分类编号</param>
        /// <returns></returns>
        public pbs_basic_ActivityClass GetActivityClassModelById(int activityClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT [ActivityClassId],[ActivityClassName],[CreateTime],[UpdateTime],[CreatorId],[Remark] FROM pbs_basic_ActivityClass ");
            strSql.Append(" where ActivityClassId=@ActivityClassId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ActivityClassId", SqlDbType.Int,4)
            };
            parameters[0].Value = activityClassId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_ActivityClass> list = Utility.ModelConvertHelper<pbs_basic_ActivityClass>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 增加一条商品筛选分类记录
        /// </summary>
        /// <param name="activityClassName">商品筛选分类名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public bool AddActivityClass(string activityClassName, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_ActivityClass(");
            strSql.Append("ActivityClassName,CreateTime,UpdateTime,CreatorId,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ActivityClassName,@CreateTime,@UpdateTime,@CreatorId,@Remark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ActivityClassName", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = activityClassName;
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
        /// 修改一条商品筛选分类记录
        /// </summary>
        /// <param name="activityClassName">商品筛选分类名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <param name="activityClassId">商品筛选分类编号</param>
        /// <returns></returns>
        public bool UpdateActivityClass(string activityClassName, DateTime createTime, DateTime updateTime, int creatorId, string remark, int activityClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_ActivityClass set ");
            strSql.Append("ActivityClassName=@ActivityClassName,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ActivityClassId=@activityClassId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ActivityClassName", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@ActivityClassId", SqlDbType.Int,4)};
            parameters[0].Value = activityClassName;
            parameters[1].Value = createTime;
            parameters[2].Value = updateTime;
            parameters[3].Value = creatorId;
            parameters[4].Value = remark;
            parameters[5].Value = activityClassId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 删除一条商品筛选分类记录
        /// </summary>
        /// <param name="activityClassId">商品筛选分类编号</param>
        /// <returns></returns>
        public bool DeleteActivityClass(int activityClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_ActivityClass ");
            strSql.Append(" where ActivityClassId=@ActivityClassId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ActivityClassId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = activityClassId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 根据商品筛选分类名称判断是否存在该分类
        /// </summary>
        /// <param name="activityClassName">商品筛选分类名称</param>
        /// <returns></returns>
        public bool IsExistByActivityClassName(string activityClassName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(ActivityClassId) from pbs_basic_ActivityClass ");
            strSql.Append(" where ActivityClassName=@ActivityClassName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ActivityClassName", SqlDbType.NVarChar,255)
                                        };
            parameters[0].Value = activityClassName;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public bool IsExistByActivityClassId(int activityClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(ActivityClassId) from pbs_basic_ActivityClass ");
            strSql.Append(" where ActivityClassId=@ActivityClassId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ActivityClassId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = activityClassId;

            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

    }
}
