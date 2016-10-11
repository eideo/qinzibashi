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
    public class pbs_basic_MyVoucherDao : DBOperation
    {
        public bool AddMyVoucher(int userId, int voucherId, int isUsed, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_MyVoucher(");
            strSql.Append(" UserId,VoucherId,IsUsed,CreateTime,UpdateTime,CreatorId,Remark )");
            strSql.Append(" values (");
            strSql.Append(" @UserId,@VoucherId,@IsUsed,@CreateTime,@UpdateTime,@CreatorId,@Remark )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@VoucherId", SqlDbType.Int,4),
                    new SqlParameter("@IsUsed", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = userId;
            parameters[1].Value = voucherId;
            parameters[2].Value = isUsed;
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

        public bool UpdateMyVoucherIsUsed(int isUsed, int voucherId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_MyVoucher set ");
            strSql.Append("IsUsed=@IsUsed");
            strSql.Append(" where VoucherId=@VoucherId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsUsed", SqlDbType.Int, 4),
                new SqlParameter("@VoucherId", SqlDbType.Int, 4)
            };
            parameters[0].Value = isUsed;
            parameters[1].Value = voucherId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public pbs_basic_MyVoucher GetMyVoucherModelById(int myVoucherId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MyVoucherId,UserId,VoucherId,IsUsed,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_MyVoucher ");
            strSql.Append(" where MyVoucherId=@MyVoucherId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MyVoucherId", SqlDbType.Int,4)
            };
            parameters[0].Value = myVoucherId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_MyVoucher> list = Utility.ModelConvertHelper<pbs_basic_MyVoucher>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_MyVoucher> GetMyVoucherList(int userId)
        {
            List<pbs_basic_MyVoucher> list = new List<pbs_basic_MyVoucher>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MyVoucherId,UserId,VoucherId,IsUsed,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_MyVoucher ");
            strSql.Append(" WHERE UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_MyVoucher> ilist = Utility.ModelConvertHelper<pbs_basic_MyVoucher>.ConvertToModel(dt);
            list = new List<pbs_basic_MyVoucher>(ilist);
            return list;
        }

        public List<pbs_basic_MyVoucherView> GetMyVoucherViewList(int userId)
        {
            List<pbs_basic_MyVoucherView> list = new List<pbs_basic_MyVoucherView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.MyVoucherId,a.UserId,a.VoucherId,a.IsUsed,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,b.VoucherPrice,b.UseRole,b.UseStartTime,b.UseEndTime,b.VoucherStatus ");
            strSql.Append(" FROM pbs_basic_MyVoucher a,pbs_basic_Voucher b ");
            strSql.Append(" WHERE UserId=@UserId AND a.VoucherId=b.VoucherId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_MyVoucherView> ilist = Utility.ModelConvertHelper<pbs_basic_MyVoucherView>.ConvertToModel(dt);
            list = new List<pbs_basic_MyVoucherView>(ilist);
            return list;
        }
    }
}
