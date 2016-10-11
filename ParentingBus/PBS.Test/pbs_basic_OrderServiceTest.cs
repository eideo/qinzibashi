using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PBS.Model;
using PBS.Server;
using Utility;
using Helper;

namespace PBS.Test
{
    [TestClass]
    public class pbs_basic_OrderServiceTest
    {
        [TestMethod]
        public void TestUpdateOrderPrice()
        {
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            ResultInfo<bool> result_UpdateOrderPrice = pbsBasicOrderService.UpdateOrderPrice(20, 90);
        }
    }
}
