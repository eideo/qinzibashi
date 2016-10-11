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
    public class pbs_basic_CommonSearchDao : DBOperation
    {
        public bool AddSearch(string searchNickName, int goodsId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_CommonSearch(");
            strSql.Append(" SearchNickName,GoodsId,CreateTime,UpdateTime,CreatorId,Remark )");
            strSql.Append(" values (");
            strSql.Append(" @SearchNickName,@GoodsId,@CreateTime,@UpdateTime,@CreatorId,@Remark )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@SearchNickName", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = searchNickName;
            parameters[1].Value = goodsId;
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

        public bool UpdateSearch(string searchNickName, int goodsId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int searchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_CommonSearch set ");
            strSql.Append("SearchNickName=@SearchNickName,");
            strSql.Append("GoodsId=@GoodsId,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where SearchId=@SearchId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SearchNickName", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@SearchId", SqlDbType.Int,4)};
            parameters[0].Value = searchNickName;
            parameters[1].Value = goodsId;
            parameters[2].Value = createTime;
            parameters[3].Value = updateTime;
            parameters[4].Value = creatorId;
            parameters[5].Value = remark;
            parameters[6].Value = searchId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteSearch(int searchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_CommonSearch ");
            strSql.Append(" where SearchId=@SearchId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SearchId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = searchId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_CommonSearch GetSearchModelById(int SearchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SearchId,SearchNickName,GoodsId,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_CommonSearch ");
            strSql.Append(" where SearchId=@SearchId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SearchId", SqlDbType.Int,4)
            };
            parameters[0].Value = SearchId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_CommonSearch> list = Utility.ModelConvertHelper<pbs_basic_CommonSearch>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_CommonSearch> GetSearchList()
        {
            List<pbs_basic_CommonSearch> list = new List<pbs_basic_CommonSearch>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SearchId,SearchNickName,GoodsId,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_CommonSearch ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_CommonSearch> ilist = Utility.ModelConvertHelper<pbs_basic_CommonSearch>.ConvertToModel(dt);
            list = new List<pbs_basic_CommonSearch>(ilist);
            return list;
        }
    }
}
