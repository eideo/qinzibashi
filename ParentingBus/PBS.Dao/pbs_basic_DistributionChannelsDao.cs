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
    public class pbs_basic_DistributionChannelsDao : DBOperation
    {
        public pbs_basic_DistributionChannels GetDCModelById(int dCId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT [DCId],[DC1],[DC2],[DC3] FROM pbs_basic_DistributionChannels ");
            strSql.Append(" where DCId=@DCId");
            SqlParameter[] parameters = {
                    new SqlParameter("@DCId", SqlDbType.Int,4)
            };
            parameters[0].Value = dCId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_DistributionChannels> list = Utility.ModelConvertHelper<pbs_basic_DistributionChannels>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public bool UpdateDC(int dC1, int dC2, int dC3, int dCId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_DistributionChannels set ");
            strSql.Append("DC1=@DC1,");
            strSql.Append("DC2=@DC2,");
            strSql.Append("DC3=@DC3");
            strSql.Append(" where DCId=@DCId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@DC1", SqlDbType.Int,4),
                    new SqlParameter("@DC2", SqlDbType.Int,4),
                    new SqlParameter("@DC3", SqlDbType.Int,4),
                    new SqlParameter("@DCId", SqlDbType.Int,4)};
            parameters[0].Value = dC1;
            parameters[1].Value = dC2;
            parameters[2].Value = dC3;
            parameters[3].Value = dCId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }
    }
}
