using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBS.Dao;
using PBS.Model;

namespace PBS.Server
{
    public class pbs_basic_DistributionChannelsService
    {
        private pbs_basic_DistributionChannelsDao dao = new pbs_basic_DistributionChannelsDao();
        public ResultInfo<pbs_basic_DistributionChannels> GetDCModelById(int dCId)
        {
            ResultInfo<pbs_basic_DistributionChannels> result = new ResultInfo<pbs_basic_DistributionChannels>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetDCModelById(dCId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<bool> UpdateDC(int dC1, int dC2, int dC3, int dCId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateDC(dC1, dC2, dC3, dCId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }
    }
}
