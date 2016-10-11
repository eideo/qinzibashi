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
    public class pbs_basic_NavigationDao : DBOperation
    {
        public bool AddNavigation(string navigationName, string navigationUrl, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_Navigation(");
            strSql.Append(" NavigationName,NavigationUrl,CreateTime,UpdateTime,CreatorId,Remark )");
            strSql.Append(" values (");
            strSql.Append(" @NavigationName,@NavigationUrl,@CreateTime,@UpdateTime,@CreatorId,@Remark )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@NavigationName", SqlDbType.NVarChar,200),
                    new SqlParameter("@NavigationUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = navigationName;
            parameters[1].Value = navigationUrl;
            parameters[2].Value = createTime;
            parameters[3].Value = updateTime;
            parameters[4].Value = creatorId;
            parameters[5].Value = remark;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateNavigation(string navigationName, string navigationUrl, DateTime createTime, DateTime updateTime, int creatorId, string remark, int NavigationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Navigation set ");
            strSql.Append("NavigationName=@NavigationName,");
            strSql.Append("NavigationUrl=@NavigationUrl,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where NavigationId=@NavigationId");
            SqlParameter[] parameters = {
                    new SqlParameter("@NavigationName", SqlDbType.NVarChar,200),
                    new SqlParameter("@NavigationUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@NavigationId", SqlDbType.Int,4)};
            parameters[0].Value = navigationName;
            parameters[1].Value = navigationUrl;
            parameters[2].Value = createTime;
            parameters[3].Value = updateTime;
            parameters[4].Value = creatorId;
            parameters[5].Value = remark;
            parameters[6].Value = NavigationId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteNavigation(int navigationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_Navigation ");
            strSql.Append(" where NavigationId=@NavigationId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@NavigationId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = navigationId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_Navigation GetNavigationModelById(int NavigationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NavigationId,NavigationName,NavigationUrl,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_Navigation ");
            strSql.Append(" where NavigationId=@NavigationId");
            SqlParameter[] parameters = {
                    new SqlParameter("@NavigationId", SqlDbType.Int,4)
            };
            parameters[0].Value = NavigationId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Navigation> list = Utility.ModelConvertHelper<pbs_basic_Navigation>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_Navigation> GetNavigationList()
        {
            List<pbs_basic_Navigation> list = new List<pbs_basic_Navigation>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT NavigationId,NavigationName,NavigationUrl,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_Navigation ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_Navigation> ilist = Utility.ModelConvertHelper<pbs_basic_Navigation>.ConvertToModel(dt);
            list = new List<pbs_basic_Navigation>(ilist);
            return list;
        }
    }
}
