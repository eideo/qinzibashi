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
    public class pbs_basic_MyShareProfitDao : DBOperation
    {
        public bool AddMyShareProfit(int goodsId,int shareLevel, decimal profit,int userId,int fromShareOrderId,int currentShareOrderId, DateTime createTime, DateTime updateTime, int creatorId, string remark, ref string shareId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_MyShareProfit(");
            strSql.Append(" GoodsId,ShareLevel,Profit,UserId,FromShareOrderId,CurrentShareOrderId,CreateTime,UpdateTime,CreatorId,Remark )");
            strSql.Append(" values (");
            strSql.Append(" @GoodsId,@ShareLevel,@Profit,@UserId,@FromShareOrderId,@CurrentShareOrderId,@CreateTime,@UpdateTime,@CreatorId,@Remark )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsId", SqlDbType.Int,4),
                    new SqlParameter("@ShareLevel", SqlDbType.Int,4),
                    new SqlParameter("@Profit", SqlDbType.Decimal,9),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@FromShareOrderId", SqlDbType.Int,4),
                    new SqlParameter("@CurrentShareOrderId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = goodsId;
            parameters[1].Value = shareLevel;
            parameters[2].Value = profit;
            parameters[3].Value = userId;
            parameters[4].Value = fromShareOrderId;
            parameters[5].Value = currentShareOrderId;
            parameters[6].Value = createTime;
            parameters[7].Value = updateTime;
            parameters[8].Value = creatorId;
            parameters[9].Value = remark;

            object obj = ExecuteScalar(strSql.ToString(), parameters);
            if (obj != null && obj != DBNull.Value)
            {
                shareId = obj.ToString();
                return true;
            }
            return false;
        }

        public pbs_basic_MyShareProfit GetMyShareProfitModelById(int shareId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ShareId,GoodsId,ShareLevel,Profit,UserId,FromShareOrderId,CurrentShareOrderId,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_MyShareProfit ");
            strSql.Append(" where ShareId=@ShareId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ShareId", SqlDbType.Int,4)
            };
            parameters[0].Value = shareId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_MyShareProfit> list = Utility.ModelConvertHelper<pbs_basic_MyShareProfit>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_MyShareProfit> GetMyShareProfitListAll()
        {
            List<pbs_basic_MyShareProfit> list = new List<pbs_basic_MyShareProfit>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ShareId,GoodsId,ShareLevel,Profit,UserId,FromShareOrderId,CurrentShareOrderId,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_MyShareProfit ");
            
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_MyShareProfit> ilist = Utility.ModelConvertHelper<pbs_basic_MyShareProfit>.ConvertToModel(dt);
            list = new List<pbs_basic_MyShareProfit>(ilist);
            return list;
        }

        public List<pbs_basic_MyShareProfit> GetMyShareProfitList(int userId)
        {
            List<pbs_basic_MyShareProfit> list = new List<pbs_basic_MyShareProfit>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ShareId,GoodsId,ShareLevel,Profit,UserId,FromShareOrderId,CurrentShareOrderId,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_MyShareProfit ");
            strSql.Append(" WHERE UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_MyShareProfit> ilist = Utility.ModelConvertHelper<pbs_basic_MyShareProfit>.ConvertToModel(dt);
            list = new List<pbs_basic_MyShareProfit>(ilist);
            return list;
        }

        public bool IsExistByShareId(int shareId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(ShareId) from pbs_basic_MyShareProfit ");
            strSql.Append(" where ShareId=@ShareId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ShareId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = shareId;
            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

        public bool IsExistByFromShareOrderId(int fromShareOrderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(FromShareOrderId) from pbs_basic_MyShareProfit ");
            strSql.Append(" where FromShareOrderId=@FromShareOrderId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@FromShareOrderId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = fromShareOrderId;
            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

        public bool IsExistByFromShareOrderIdAndShareLevel(int fromShareOrderId,int ShareLevel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(ShareId) from pbs_basic_MyShareProfit ");
            strSql.Append(" where FromShareOrderId=@FromShareOrderId and ShareLevel=@ShareLevel ");
            SqlParameter[] parameters = {
                    new SqlParameter("@FromShareOrderId", SqlDbType.Int,20),
                    new SqlParameter("@ShareLevel", SqlDbType.Int,20)
                                        };
            parameters[0].Value = fromShareOrderId;
            parameters[1].Value = ShareLevel;
            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

        public pbs_basic_MyShareProfit GetMyShareProfitModelByFromShareOrderId(int fromShareOrderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ShareId,GoodsId,ShareLevel,Profit,UserId,FromShareOrderId,CurrentShareOrderId,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_MyShareProfit ");
            strSql.Append(" where FromShareOrderId=@FromShareOrderId");
            SqlParameter[] parameters = {
                    new SqlParameter("@FromShareOrderId", SqlDbType.Int,4)
            };
            parameters[0].Value = fromShareOrderId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_MyShareProfit> list = Utility.ModelConvertHelper<pbs_basic_MyShareProfit>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public bool UpdateMyShareProfit(int goodsId, int shareLevel, decimal profit, int userId, int fromShareOrderId, int currentShareOrderId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int shareId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_MyShareProfit set ");
            strSql.Append("GoodsId=@GoodsId,");
            strSql.Append("ShareLevel=@ShareLevel,");
            strSql.Append("Profit=@Profit,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("FromShareOrderId=@FromShareOrderId,");
            strSql.Append("CurrentShareOrderId=@CurrentShareOrderId,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ShareId=@ShareId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsId", SqlDbType.Int,4),
                    new SqlParameter("@ShareLevel", SqlDbType.Int,4),
                    new SqlParameter("@Profit", SqlDbType.Decimal,9),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@FromShareOrderId", SqlDbType.Int,4),
                    new SqlParameter("@CurrentShareOrderId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@ShareId", SqlDbType.Int,4)};
            parameters[0].Value = goodsId;
            parameters[1].Value = shareLevel;
            parameters[2].Value = profit;
            parameters[3].Value = userId;
            parameters[4].Value = fromShareOrderId;
            parameters[5].Value = currentShareOrderId;
            parameters[6].Value = createTime;
            parameters[7].Value = updateTime;
            parameters[8].Value = creatorId;
            parameters[9].Value = remark;
            parameters[10].Value = shareId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public decimal GetMyShareProfitByUserId(int userId)
        {
            decimal result = 0m;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Profit) from pbs_basic_MyShareProfit ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            if (ds!=null&&ds.Rows.Count>0&&!string.IsNullOrEmpty(ds.Rows[0][0].ToString()))
            {
                result = Utility.Util.ParseHelper.ToDecimal(ds.Rows[0][0].ToString());
            }

            return result;
        }

        //public List<MyShareProfitResult> GetMyShareProfitResultList(int userId)
        //{
        //    List<MyShareProfitResult> list = new List<MyShareProfitResult>();
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select SUM(Profit) as Profit,CONVERT(varchar(12) , CreateTime, 111 ) as DTime,COUNT(ShareId) as Pcount ");
        //    strSql.Append(" FROM pbs_basic_MyShareProfit ");
        //    strSql.Append(" WHERE AND UserId=@UserId ");
        //    strSql.Append(" group by CONVERT(varchar(12) , CreateTime, 111 ) ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@UserId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = userId;
        //    DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
        //    IList<MyShareProfitResult> ilist = Utility.ModelConvertHelper<MyShareProfitResult>.ConvertToModel(dt);
        //    list = new List<MyShareProfitResult>(ilist);
        //    return list;
        //}

        public List<pbs_basic_ShareDetail> GetShareDetailList()
        {
            List<pbs_basic_ShareDetail> list = new List<pbs_basic_ShareDetail>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, NickName, c.UserId,ShareCount,Profit from pbs_basic_Users a left join ");
            strSql.Append("(select ROW_NUMBER() over(order by b.UserId) as Id, b.UserId, COUNT(b.ShareId) as ShareCount, SUM(b.Profit) as Profit ");
            strSql.Append("from pbs_basic_MyShareProfit b group by UserId) as c ");
            strSql.Append("on a.UserId = c.UserId where Id is not null ");

            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_ShareDetail> ilist = Utility.ModelConvertHelper<pbs_basic_ShareDetail>.ConvertToModel(dt);
            list = new List<pbs_basic_ShareDetail>(ilist);
            return list;
        }

    }
}
