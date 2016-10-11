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
    public class pbs_basic_VoucherDao : DBOperation
    {
        /// <summary>
        /// 获取所有优惠券列表
        /// </summary>
        /// <returns></returns>
        public List<pbs_basic_Voucher> GetAllVoucherList()
        {
            List<pbs_basic_Voucher> list = new List<pbs_basic_Voucher>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select [VoucherId],[VoucherPrice],[UseRole],[VoucherType],[SRPrice],[UseStartTime],[UseEndTime],[VoucherStatus],[CreateTime],[UpdateTime],[CreatorId],[Remark],[VoucherCount] from [dbo].[pbs_basic_Voucher] ORDER BY VoucherId ASC ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_Voucher> ilist = Utility.ModelConvertHelper<pbs_basic_Voucher>.ConvertToModel(dt);
            list = new List<pbs_basic_Voucher>(ilist);
            return list;
        }

        /// <summary>
        /// 根据优惠券编号获取优惠券对象实体
        /// </summary>
        /// <param name="voucherId">优惠券编号</param>
        /// <returns></returns>
        public pbs_basic_Voucher GetVoucherModelById(int voucherId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT [VoucherId],[VoucherPrice],[UseRole],[VoucherType],[SRPrice],[UseStartTime],[UseEndTime],[VoucherStatus],[CreateTime],[UpdateTime],[CreatorId],[Remark],[VoucherCount] FROM pbs_basic_Voucher ");
            strSql.Append(" where VoucherId=@VoucherId");
            SqlParameter[] parameters = {
					new SqlParameter("@VoucherId", SqlDbType.Int,4)
			};
            parameters[0].Value = voucherId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Voucher> list = Utility.ModelConvertHelper<pbs_basic_Voucher>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 增加一条优惠券记录
        /// </summary>
        /// <param name="voucherPrice"></param>
        /// <param name="useRole"></param>
        /// <param name="voucherType"></param>
        /// <param name="sRPrice"></param>
        /// <param name="useStartTime"></param>
        /// <param name="useEndTime"></param>
        /// <param name="voucherStatus"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <param name="voucherCount"></param>
        /// <returns></returns>
        public bool AddVoucher(decimal voucherPrice,string useRole,int voucherType, decimal sRPrice, string useStartTime, string useEndTime,int voucherStatus, DateTime createTime, DateTime updateTime, int creatorId, string remark,int voucherCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_Voucher(");
            strSql.Append("VoucherPrice,UseRole,VoucherType,SRPrice,UseStartTime,UseEndTime,VoucherStatus,CreateTime,UpdateTime,CreatorId,Remark,VoucherCount)");
            strSql.Append(" values (");
            strSql.Append("@VoucherPrice,@UseRole,@VoucherType,@SRPrice,@UseStartTime,@UseEndTime,@VoucherStatus,@CreateTime,@UpdateTime,@CreatorId,@Remark,@VoucherCount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@VoucherPrice", SqlDbType.Decimal,5),
					new SqlParameter("@UseRole", SqlDbType.NVarChar,200),
                    new SqlParameter("@VoucherType", SqlDbType.Int,4),
                    new SqlParameter("@SRPrice", SqlDbType.Decimal,5),
                    new SqlParameter("@UseStartTime", SqlDbType.NVarChar,200),
					new SqlParameter("@UseEndTime", SqlDbType.NVarChar,200),
					new SqlParameter("@VoucherStatus", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@CreatorId", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@VoucherCount", SqlDbType.Int,4)};
            parameters[0].Value = voucherPrice;
            parameters[1].Value = useRole;
            parameters[2].Value = voucherType;
            parameters[3].Value = sRPrice;
            parameters[4].Value = useStartTime;
            parameters[5].Value = useEndTime;
            parameters[6].Value = voucherStatus;
            parameters[7].Value = createTime;
            parameters[8].Value = updateTime;
            parameters[9].Value = creatorId;
            parameters[10].Value = remark;
            parameters[11].Value = voucherCount;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 修改一条优惠券记录
        /// </summary>
        /// <param name="voucherPrice"></param>
        /// <param name="useRole"></param>
        /// <param name="voucherType"></param>
        /// <param name="sRPrice"></param>
        /// <param name="useStartTime"></param>
        /// <param name="useEndTime"></param>
        /// <param name="voucherStatus"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="remark"></param>
        /// <param name="voucherCount"></param>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public bool UpdateVoucher(decimal voucherPrice, string useRole, int voucherType, decimal sRPrice, string useStartTime, string useEndTime, int voucherStatus, DateTime createTime, DateTime updateTime, int creatorId, string remark,int voucherCount, int voucherId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Voucher set ");
            strSql.Append("VoucherPrice=@VoucherPrice,");
            strSql.Append("UseRole=@UseRole,");
            strSql.Append("VoucherType=@VoucherType,");
            strSql.Append("SRPrice=@SRPrice,");
            strSql.Append("UseStartTime=@UseStartTime,");
            strSql.Append("UseEndTime=@UseEndTime,");
            strSql.Append("VoucherStatus=@VoucherStatus,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("VoucherCount=@VoucherCount");
            strSql.Append(" where VoucherId=@VoucherId");
            SqlParameter[] parameters = {
					new SqlParameter("@VoucherPrice", SqlDbType.Decimal,5),
					new SqlParameter("@UseRole", SqlDbType.NVarChar,200),
                    new SqlParameter("@VoucherType", SqlDbType.Int,4),
                    new SqlParameter("@SRPrice", SqlDbType.Decimal,5),
                    new SqlParameter("@UseStartTime", SqlDbType.NVarChar,200),
					new SqlParameter("@UseEndTime", SqlDbType.NVarChar,200),
					new SqlParameter("@VoucherStatus", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@CreatorId", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@VoucherCount", SqlDbType.Int,4),
                    new SqlParameter("@VoucherId", SqlDbType.Int,4)};
            parameters[0].Value = voucherPrice;
            parameters[1].Value = useRole;
            parameters[2].Value = voucherType;
            parameters[3].Value = sRPrice;
            parameters[4].Value = useStartTime;
            parameters[5].Value = useEndTime;
            parameters[6].Value = voucherStatus;
            parameters[7].Value = createTime;
            parameters[8].Value = updateTime;
            parameters[9].Value = creatorId;
            parameters[10].Value = remark;
            parameters[11].Value = voucherCount;
            parameters[12].Value = voucherId;


            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 删除一条优惠券记录
        /// </summary>
        /// <param name="voucherId">优惠券编号</param>
        /// <returns></returns>
        public bool DeleteVoucher(int voucherId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_Voucher ");
            strSql.Append(" where VoucherId=@VoucherId ");
            SqlParameter[] parameters = {
					new SqlParameter("@VoucherId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = voucherId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

     //   /// <summary>
     //   /// 根据优惠券名称判断是否存在该分类
     //   /// </summary>
     //   /// <param name="voucherName">优惠券名称</param>
     //   /// <returns></returns>
     //   public bool IsExistByVoucherName(string voucherName)
     //   {
     //       StringBuilder strSql = new StringBuilder();
     //       strSql.Append("select COUNT(VoucherId) from pbs_basic_Voucher ");
     //       strSql.Append(" where VoucherName=@VoucherName ");
     //       SqlParameter[] parameters = {
					//new SqlParameter("@VoucherName", SqlDbType.NVarChar,255)
     //                                   };
     //       parameters[0].Value = voucherName;
     //       return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
     //   }
    }
}
