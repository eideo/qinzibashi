using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PBS.Model;
using PBS.Server;
using Utility;
using Helper;

namespace PBS.Test
{
    [TestClass]
    public class pbs_basic_MyShareProfitServiceTest
    {
        [TestMethod]
        public void TestAddMyShareProfit()
        {
            string shareId = string.Empty;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            int goodsId = 1111;
            int shareLevel = 1;
            decimal profit = 0;
            int userId = 2;
            int fromShareOrderId = 2222;
            int currentShareOrderId = 3333;
            DateTime createTime = DateTime.Now; 
            DateTime updateTime = DateTime.Now;
            int creatorId = 0;
            string remark = string.Empty;
            var result= pbsBasicMyShareProfitService.AddMyShareProfit(goodsId, shareLevel, profit, userId, fromShareOrderId, currentShareOrderId, createTime, updateTime, creatorId, remark, ref shareId);

        }

        [TestMethod]
        public void TestGetMyShareProfitModelById()
        {
            int shareId = 1;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            var result = pbsBasicMyShareProfitService.GetMyShareProfitModelById(shareId);
        }

        [TestMethod]
        public void TestGetMyShareProfitList()
        {
            int userId = 2;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            var result = pbsBasicMyShareProfitService.GetMyShareProfitList(userId);
        }

        [TestMethod]
        public void TestIsExistByShareId()
        {
            int shareId = 1;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            var result = pbsBasicMyShareProfitService.IsExistByShareId(shareId);
        }

        [TestMethod]
        public void TestIsExistByFromShareOrderId()
        {
            int fromShareOrderId = 50;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            var result = pbsBasicMyShareProfitService.IsExistByFromShareOrderId(fromShareOrderId);
        }

        [TestMethod]
        public void TestIsExistByFromShareOrderIdAndShareLevel()
        {
            int fromShareOrderId = 50;
            int ShareLevel = 1;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            var result = pbsBasicMyShareProfitService.IsExistByFromShareOrderIdAndShareLevel(fromShareOrderId,ShareLevel);
        }

        [TestMethod]
        public void TestGetMyShareProfitModelByFromShareOrderId()
        {
            int fromShareOrderId = 222;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            var result = pbsBasicMyShareProfitService.GetMyShareProfitModelByFromShareOrderId(fromShareOrderId);
        }

        [TestMethod]
        public void TestUpdateMyShareProfit()
        {
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            int goodsId = 111;
            int shareLevel = 1;
            decimal profit = 0;
            int userId = 2;
            int fromShareOrderId = 222;
            int currentShareOrderId = 333;
            DateTime createTime = DateTime.Now;
            DateTime updateTime = DateTime.Now;
            int creatorId = 0;
            string remark = string.Empty;
            int shareId = 1;
            var result = pbsBasicMyShareProfitService.UpdateMyShareProfit(goodsId, shareLevel, profit, userId, fromShareOrderId, currentShareOrderId, createTime, updateTime, creatorId, remark, shareId);
        }

        [TestMethod]
        public void TestGetMyShareProfitByUserId()
        {
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            int userId = 7;
            var result = pbsBasicMyShareProfitService.GetMyShareProfitByUserId(userId);
        }
    }
}
