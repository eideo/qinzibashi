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
    public class pbs_basic_MembersDao : DBOperation
    {
        public bool AddMembers(string memberName, int sex, int relationType, string birthday, string iDNum, int userId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_Members(");
            strSql.Append(" MemberName,Sex,RelationType,Birthday,IDNum,UserId,CreateTime,UpdateTime,CreatorId,Remark )");
            strSql.Append(" values (");
            strSql.Append(" @MemberName,@Sex,@RelationType,@Birthday,@IDNum,@UserId,@CreateTime,@UpdateTime,@CreatorId,@Remark )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@MemberName", SqlDbType.NVarChar,200),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                    new SqlParameter("@RelationType", SqlDbType.Int,4),
                    new SqlParameter("@Birthday", SqlDbType.NVarChar,200),
                    new SqlParameter("@IDNum", SqlDbType.NVarChar,200),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = memberName;
            parameters[1].Value = sex;
            parameters[2].Value = relationType;
            parameters[3].Value = birthday;
            parameters[4].Value = iDNum;
            parameters[5].Value = userId;
            parameters[6].Value = createTime;
            parameters[7].Value = updateTime;
            parameters[8].Value = creatorId;
            parameters[9].Value = remark;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateMembers(string memberName, int sex, int relationType, string birthday, string iDNum, int userId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int membersId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Members set ");
            strSql.Append("MemberName=@MemberName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("RelationType=@RelationType,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("IDNum=@IDNum,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where MembersId=@MembersId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MemberName", SqlDbType.NVarChar,200),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                    new SqlParameter("@RelationType", SqlDbType.Int,4),
                    new SqlParameter("@Birthday", SqlDbType.NVarChar,200),
                    new SqlParameter("@IDNum", SqlDbType.NVarChar,200),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@MembersId", SqlDbType.Int,4)};
            parameters[0].Value = memberName;
            parameters[1].Value = sex;
            parameters[2].Value = relationType;
            parameters[3].Value = birthday;
            parameters[4].Value = iDNum;
            parameters[5].Value = userId;
            parameters[6].Value = createTime;
            parameters[7].Value = updateTime;
            parameters[8].Value = creatorId;
            parameters[9].Value = remark;
            parameters[10].Value = membersId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteMembers(int membersId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_Members ");
            strSql.Append(" where MembersId=@MembersId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MembersId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = membersId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_Members GetMembersModelById(int membersId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MembersId,MemberName,Sex,RelationType,Birthday,IDNum,UserId,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_Members ");
            strSql.Append(" where MembersId=@MembersId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MembersId", SqlDbType.Int,4)
            };
            parameters[0].Value = membersId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Members> list = Utility.ModelConvertHelper<pbs_basic_Members>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_Members> GetMembersList()
        {
            List<pbs_basic_Members> list = new List<pbs_basic_Members>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MembersId,MemberName,Sex,RelationType,Birthday,IDNum,UserId,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_Members ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_Members> ilist = Utility.ModelConvertHelper<pbs_basic_Members>.ConvertToModel(dt);
            list = new List<pbs_basic_Members>(ilist);
            return list;
        }

        public List<pbs_basic_Members> GetMembersListByUserId(int userId)
        {
            List<pbs_basic_Members> list = new List<pbs_basic_Members>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MembersId,MemberName,Sex,RelationType,Birthday,IDNum,UserId,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_Members ");
            strSql.Append(" WHERE UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Members> ilist = Utility.ModelConvertHelper<pbs_basic_Members>.ConvertToModel(dt);
            list = new List<pbs_basic_Members>(ilist);
            return list;
        }

    }
}
