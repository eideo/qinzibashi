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
    public class pbs_basic_UsersDao : DBOperation
    {
        public bool IsExistsByWeiXinCode(string weixinCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pbs_basic_Users");
            strSql.Append(" where WeiXinCode=@WeiXinCode");
            SqlParameter[] parameters = {
					new SqlParameter("@WeiXinCode", SqlDbType.NVarChar,200)
			};
            parameters[0].Value = weixinCode;

            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

        public bool AddUsers(string loginName, string pwd, string nickName, string photoUrl, string phone, int babySex, string babyBirthday,string weiXinCode, DateTime createTime, DateTime updateTime, int creatorId, string remark,string myAdress)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_Users(");
            strSql.Append(" LoginName,Pwd,NickName,PhotoUrl,Phone,BabySex,BabyBirthday,WeiXinCode,CreateTime,UpdateTime,CreatorId,Remark,MyAdress )");
            strSql.Append(" values (");
            strSql.Append(" @LoginName,@Pwd,@NickName,@PhotoUrl,@Phone,@BabySex,@BabyBirthday,@WeiXinCode,@CreateTime,@UpdateTime,@CreatorId,@Remark,@MyAdress )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.NVarChar,200),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,200),
                    new SqlParameter("@NickName", SqlDbType.NVarChar,200),
                    new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,200),
                    new SqlParameter("@BabySex", SqlDbType.Int,4),
                    new SqlParameter("@BabyBirthday", SqlDbType.NVarChar,200),
                    new SqlParameter("@WeiXinCode", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@MyAdress", SqlDbType.NVarChar,200)};
            parameters[0].Value = loginName;
            parameters[1].Value = pwd;
            parameters[2].Value = nickName;
            parameters[3].Value = photoUrl;
            parameters[4].Value = phone;
            parameters[5].Value = babySex;
            parameters[6].Value = babyBirthday;
            parameters[7].Value = weiXinCode;
            parameters[8].Value = createTime;
            parameters[9].Value = updateTime;
            parameters[10].Value = creatorId;
            parameters[11].Value = remark;
            parameters[12].Value = myAdress;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateUsers(string loginName, string pwd, string nickName, string photoUrl, string phone, int babySex, string babyBirthday, string weiXinCode, DateTime createTime, DateTime updateTime, int creatorId, string remark, string myAdress, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Users set ");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("PhotoUrl=@PhotoUrl,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("BabySex=@BabySex,");
            strSql.Append("BabyBirthday=@BabyBirthday,");
            strSql.Append("WeiXinCode=@WeiXinCode,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("MyAdress=@MyAdress");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.NVarChar,200),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,200),
                    new SqlParameter("@NickName", SqlDbType.NVarChar,200),
                    new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,200),
                    new SqlParameter("@BabySex", SqlDbType.Int,4),
                    new SqlParameter("@BabyBirthday", SqlDbType.NVarChar,200),
                    new SqlParameter("@WeiXinCode", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@MyAdress", SqlDbType.NVarChar,200),
                    new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = loginName;
            parameters[1].Value = pwd;
            parameters[2].Value = nickName;
            parameters[3].Value = photoUrl;
            parameters[4].Value = phone;
            parameters[5].Value = babySex;
            parameters[6].Value = babyBirthday;
            parameters[7].Value = weiXinCode;
            parameters[8].Value = createTime;
            parameters[9].Value = updateTime;
            parameters[10].Value = creatorId;
            parameters[11].Value = remark;
            parameters[12].Value = myAdress;
            parameters[13].Value = userId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteUsers(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_Users ");
            strSql.Append(" where UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UsersId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = userId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_Users GetUsersModelById(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,LoginName,Pwd,NickName,PhotoUrl,Phone,BabySex,BabyBirthday,WeiXinCode,CreateTime,UpdateTime,CreatorId,Remark,MyAdress from pbs_basic_Users ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Users> list = Utility.ModelConvertHelper<pbs_basic_Users>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public pbs_basic_Users GetUsersModelByWeiXinCode(string weixinCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,LoginName,Pwd,NickName,PhotoUrl,Phone,BabySex,BabyBirthday,WeiXinCode,CreateTime,UpdateTime,CreatorId,Remark,MyAdress from pbs_basic_Users ");
            strSql.Append(" where WeiXinCode=@WeiXinCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@WeiXinCode", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = weixinCode;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Users> list = Utility.ModelConvertHelper<pbs_basic_Users>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_Users> GetUsersList()
        {
            List<pbs_basic_Users> list = new List<pbs_basic_Users>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT UserId,LoginName,Pwd,NickName,PhotoUrl,Phone,BabySex,BabyBirthday,WeiXinCode,CreateTime,UpdateTime,CreatorId,Remark,MyAdress ");
            strSql.Append(" FROM pbs_basic_Users ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_Users> ilist = Utility.ModelConvertHelper<pbs_basic_Users>.ConvertToModel(dt);
            list = new List<pbs_basic_Users>(ilist);
            return list;
        }

        public List<pbs_basic_UsersDetail> GetUsersDetailList()
        {
            List<pbs_basic_UsersDetail> list = new List<pbs_basic_UsersDetail>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.NickName,a.UserId,a.BabyBirthday,a.Phone,isnull(BuyCount, 0) as BuyCount,isnull(BuyPrice, 0) as BuyPrice,isnull(SumProfit, 0) as SumProfit ");
            strSql.Append(" from pbs_basic_Users a left join ");
            strSql.Append(" (select Count(OrderId) as BuyCount,sum(OrderPrice) as BuyPrice,pbs_basic_Order.UserId from pbs_basic_Order group by pbs_basic_Order.UserId) AS b ");
            strSql.Append(" on a.UserId = b.UserId left join ");
            strSql.Append(" (select sum(Profit) as SumProfit, pbs_basic_MyShareProfit.UserId from pbs_basic_MyShareProfit group by pbs_basic_MyShareProfit.UserId) c ");
            strSql.Append(" on a.UserId = c.UserId");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_UsersDetail> ilist = Utility.ModelConvertHelper<pbs_basic_UsersDetail>.ConvertToModel(dt);
            list = new List<pbs_basic_UsersDetail>(ilist);
            return list;
        }

        public List<pbs_basic_UsersOrderDetail> GetUsersOrderDetailList(int userId)
        {
            List<pbs_basic_UsersOrderDetail> list = new List<pbs_basic_UsersOrderDetail>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.GoodsId,GoodsName,VisitTime,RegionName,SellingPrice,[Count],OrderPrice ");
            strSql.Append(" from pbs_basic_Order a, pbs_basic_Goods b,pbs_basic_Region c ");
            strSql.Append(" where a.GoodsId=b.GoodsId and b.RegionId= c.RegionId ");
            strSql.Append(" and a.UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(),parameters).Tables[0];
            IList<pbs_basic_UsersOrderDetail> ilist = Utility.ModelConvertHelper<pbs_basic_UsersOrderDetail>.ConvertToModel(dt);
            list = new List<pbs_basic_UsersOrderDetail>(ilist);
            return list;
        }

    }
}
