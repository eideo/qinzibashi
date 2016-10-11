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
    public class pbs_basic_AgeRangeDao : DBOperation
    {
        /// <summary>
        /// 获取所有年龄范围列表
        /// </summary>
        /// <returns></returns>
        public List<pbs_basic_AgeRange> GetAllAgeRangeList()
        {
            List<pbs_basic_AgeRange> list = new List<pbs_basic_AgeRange>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select [AgeRangeId],[AgeRangeName],[CreateTime],[UpdateTime],[CreatorId],[Remark] from [dbo].[pbs_basic_AgeRange] ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_AgeRange> ilist = Utility.ModelConvertHelper<pbs_basic_AgeRange>.ConvertToModel(dt);
            list = new List<pbs_basic_AgeRange>(ilist);
            return list;
        }

        /// <summary>
        /// 根据年龄范围获取年龄范围对象实体
        /// </summary>
        /// <param name="ageRangeId">年龄范围编号</param>
        /// <returns></returns>
        public pbs_basic_AgeRange GetAgeRangeModelById(int ageRangeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT [AgeRangeId],[AgeRangeName],[CreateTime],[UpdateTime],[CreatorId],[Remark] FROM pbs_basic_AgeRange ");
            strSql.Append(" where AgeRangeId=@AgeRangeId");
            SqlParameter[] parameters = {
                    new SqlParameter("@AgeRangeId", SqlDbType.Int,4)
            };
            parameters[0].Value = ageRangeId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_AgeRange> list = Utility.ModelConvertHelper<pbs_basic_AgeRange>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 增加一条年龄范围记录
        /// </summary>
        /// <param name="ageRangeName">年龄范围名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public bool AddAgeRange(string ageRangeName, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_AgeRange(");
            strSql.Append("AgeRangeName,CreateTime,UpdateTime,CreatorId,Remark)");
            strSql.Append(" values (");
            strSql.Append("@AgeRangeName,@CreateTime,@UpdateTime,@CreatorId,@Remark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@AgeRangeName", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = ageRangeName;
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
        /// 修改一条年龄范围记录
        /// </summary>
        /// <param name="ageRangeName">年龄范围名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <param name="ageRangeId">年龄范围编号</param>
        /// <returns></returns>
        public bool UpdateAgeRange(string ageRangeName, DateTime createTime, DateTime updateTime, int creatorId, string remark, int ageRangeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_AgeRange set ");
            strSql.Append("AgeRangeName=@AgeRangeName,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where AgeRangeId=@AgeRangeId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AgeRangeName", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@AgeRangeId", SqlDbType.Int,4)};
            parameters[0].Value = ageRangeName;
            parameters[1].Value = createTime;
            parameters[2].Value = updateTime;
            parameters[3].Value = creatorId;
            parameters[4].Value = remark;
            parameters[5].Value = ageRangeId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 删除一条年龄范围记录
        /// </summary>
        /// <param name="ageRangeId">年龄范围编号</param>
        /// <returns></returns>
        public bool DeleteAgeRange(int ageRangeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_AgeRange ");
            strSql.Append(" where AgeRangeId=@AgeRangeId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AgeRangeId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = ageRangeId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 根据年龄范围名称判断是否存在该分类
        /// </summary>
        /// <param name="ageRangeName">年龄范围名称</param>
        /// <returns></returns>
        public bool IsExistByAgeRangeName(string ageRangeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(AgeRangeId) from pbs_basic_AgeRange ");
            strSql.Append(" where AgeRangeName=@AgeRangeName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AgeRangeName", SqlDbType.NVarChar,255)
                                        };
            parameters[0].Value = ageRangeName;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public bool IsExistByAgeRangeId(int ageRangeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(AgeRangeId) from pbs_basic_AgeRange ");
            strSql.Append(" where AgeRangeId=@AgeRangeId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AgeRangeId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = ageRangeId;
            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

    }
}
