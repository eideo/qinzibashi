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
    public class pbs_basic_OrderMemberDao : DBOperation
    {
        public bool AddOrderMember(int memberId, DateTime createTime, DateTime updateTime, int creatorId, string remark,int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_OrderMember(");
            strSql.Append(" MemberId,CreateTime,UpdateTime,CreatorId,Remark,OrderId )");
            strSql.Append(" values (");
            strSql.Append(" @MemberId,@CreateTime,@UpdateTime,@CreatorId,@Remark,@OrderId )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@MemberId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@OrderId", SqlDbType.Int,4)};
            parameters[0].Value = memberId;
            parameters[1].Value = createTime;
            parameters[2].Value = updateTime;
            parameters[3].Value = creatorId;
            parameters[4].Value = remark;
            parameters[5].Value = orderId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateOrderMember(int memberId, DateTime createTime, DateTime updateTime, int creatorId, string remark,int orderId, int orderMemberId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_OrderMember set ");
            strSql.Append("MemberId=@MemberId,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("OrderId=@OrderId");
            strSql.Append(" where OrderMemberId=@OrderMemberId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderBy", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@OrderId", SqlDbType.Int,4),
                    new SqlParameter("@OrderMemberId", SqlDbType.Int,4)};
            parameters[0].Value = memberId;
            parameters[1].Value = createTime;
            parameters[2].Value = updateTime;
            parameters[3].Value = creatorId;
            parameters[4].Value = remark;
            parameters[5].Value = orderId;
            parameters[6].Value = orderMemberId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteOrderMember(int orderMemberId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_OrderMember ");
            strSql.Append(" where OrderMemberId=@OrderMemberId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderMemberId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = orderMemberId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_OrderMember GetOrderMemberModelById(int orderMemberId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderMemberId,MemberId,CreateTime,UpdateTime,CreatorId,Remark,OrderId from pbs_basic_OrderMember ");
            strSql.Append(" where OrderMemberId=@OrderMemberId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderMemberId", SqlDbType.Int,4)
            };
            parameters[0].Value = orderMemberId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_OrderMember> list = Utility.ModelConvertHelper<pbs_basic_OrderMember>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_OrderMember> GetOrderMemberList(int memberId)
        {
            List<pbs_basic_OrderMember> list = new List<pbs_basic_OrderMember>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OrderMemberId,MemberId,CreateTime,UpdateTime,CreatorId,Remark,OrderId ");
            strSql.Append(" FROM pbs_basic_OrderMember ");
            strSql.Append(" WHERE MemberId=@MemberId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MemberId", SqlDbType.Int,4)
            };
            parameters[0].Value = memberId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_OrderMember> ilist = Utility.ModelConvertHelper<pbs_basic_OrderMember>.ConvertToModel(dt);
            list = new List<pbs_basic_OrderMember>(ilist);
            return list;
        }
    }
}
