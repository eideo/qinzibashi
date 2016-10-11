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
    public class pbs_basic_MyCollectionService
    {
        pbs_basic_MyCollectionDao dao = new pbs_basic_MyCollectionDao();

        public ResultInfo<bool> AddMyCollection(int userId, int goodsId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddMyCollection(userId, goodsId, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_MyCollectionView>> GetMyCollectionViewListByUserId(int userId)
        {
            ResultInfo<List<pbs_basic_MyCollectionView>> result = new ResultInfo<List<pbs_basic_MyCollectionView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMyCollectionViewListByUserId(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }
    }
}
