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
    public class pbs_basic_SearchHistoryDao : DBOperation
    {
        public bool AddSearchHistory(int searchId, int userId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_SearchHistory(");
            strSql.Append(" SearchId,UserId,CreateTime,UpdateTime,CreatorId,Remark )");
            strSql.Append(" values (");
            strSql.Append(" @SearchId,@UserId,@CreateTime,@UpdateTime,@CreatorId,@Remark )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@SearchId", SqlDbType.NVarChar,200),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = searchId;
            parameters[1].Value = userId;
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

        public bool UpdateSearchHistory(int searchId, int userId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int historyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_SearchHistory set ");
            strSql.Append("SearchId=@SearchId,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where HistoryId=@HistoryId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SearchId", SqlDbType.NVarChar,200),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@SearchHistoryId", SqlDbType.Int,4)};
            parameters[0].Value = searchId;
            parameters[1].Value = userId;
            parameters[2].Value = createTime;
            parameters[3].Value = updateTime;
            parameters[4].Value = creatorId;
            parameters[5].Value = remark;
            parameters[6].Value = historyId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteSearchHistory(int historyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_SearchHistory ");
            strSql.Append(" where HistoryId=@HistoryId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@HistoryId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = historyId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_SearchHistory GetSearchHistoryModelById(int historyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 HistoryId,SearchId,UserId,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_SearchHistory ");
            strSql.Append(" where HistoryId=@HistoryId");
            SqlParameter[] parameters = {
                    new SqlParameter("@HistoryId", SqlDbType.Int,4)
            };
            parameters[0].Value = historyId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_SearchHistory> list = Utility.ModelConvertHelper<pbs_basic_SearchHistory>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_SearchHistory> GetSearchHistoryList(int userId)
        {
            List<pbs_basic_SearchHistory> list = new List<pbs_basic_SearchHistory>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT HistoryId,SearchId,UserId,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_SearchHistory ");
            strSql.Append(" WHERE UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_SearchHistory> ilist = Utility.ModelConvertHelper<pbs_basic_SearchHistory>.ConvertToModel(dt);
            list = new List<pbs_basic_SearchHistory>(ilist);
            return list;
        }

        public List<pbs_basic_SearchHistoryView> GetSearchHistoryViewList(int userId)
        {
            List<pbs_basic_SearchHistoryView> list = new List<pbs_basic_SearchHistoryView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.HistoryId,a.SearchId,a.UserId,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,b.SearchNickName,b.GoodsId  ");
            strSql.Append(" FROM pbs_basic_SearchHistory a,pbs_basic_CommonSearch b ");
            strSql.Append(" WHERE a.SearchId=b.SearchId AND a.UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_SearchHistoryView> ilist = Utility.ModelConvertHelper<pbs_basic_SearchHistoryView>.ConvertToModel(dt);
            list = new List<pbs_basic_SearchHistoryView>(ilist);
            return list;
        }

    }
}
