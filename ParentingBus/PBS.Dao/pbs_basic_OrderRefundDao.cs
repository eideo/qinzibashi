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
    public class pbs_basic_OrderRefundDao : DBOperation
    {
        public bool AddOrderRefund(int orderId,int userId, string reason,  DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_OrderRefund(");
            strSql.Append(" OrderId,UserId,Reason,CreateTime,UpdateTime,CreatorId,Remark )");
            strSql.Append(" values (");
            strSql.Append(" @OrderId,@UserId,@Reason,@CreateTime,@UpdateTime,@CreatorId,@Remark )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.Int,4),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@Reason", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = orderId;
            parameters[1].Value = userId;
            parameters[2].Value = reason;
            parameters[3].Value = createTime;
            parameters[4].Value = updateTime;
            parameters[5].Value = creatorId;
            parameters[6].Value = remark;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateOrderRefund(int orderId, int userId, string reason, DateTime createTime, DateTime updateTime, int creatorId, string remark, int refundId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_OrderRefund set ");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("Reason=@Reason,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where OrderRefundId=@OrderRefundId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.Int,4),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@Reason", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@OrderRefundId", SqlDbType.Int,4)};
            parameters[0].Value = orderId;
            parameters[1].Value = userId;
            parameters[2].Value = reason;
            parameters[3].Value = createTime;
            parameters[4].Value = updateTime;
            parameters[5].Value = creatorId;
            parameters[6].Value = remark;
            parameters[7].Value = refundId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteOrderRefund(int refundId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_OrderRefund ");
            strSql.Append(" where OrderRefundId=@OrderRefundId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderRefundId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = refundId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_OrderRefund GetOrderRefundModelById(int refundId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderId,UserId,Reason,OrderBy,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_OrderRefund ");
            strSql.Append(" where RefundId=@RefundId");
            SqlParameter[] parameters = {
                    new SqlParameter("@RefundId", SqlDbType.Int,4)
            };
            parameters[0].Value = refundId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_OrderRefund> list = Utility.ModelConvertHelper<pbs_basic_OrderRefund>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_OrderRefund> GetOrderRefundList(int userId)
        {
            List<pbs_basic_OrderRefund> list = new List<pbs_basic_OrderRefund>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OrderRefundId,Url,OrderBy,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_OrderRefund ");
            strSql.Append(" WHERE UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_OrderRefund> ilist = Utility.ModelConvertHelper<pbs_basic_OrderRefund>.ConvertToModel(dt);
            list = new List<pbs_basic_OrderRefund>(ilist);
            return list;
        }
    }
}
