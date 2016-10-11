using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    /// <summary>
    /// 销售单据枚举类
    /// </summary>
    public class OrderEnum
    {
        /// <summary>
        /// 订单状态
        /// </summary>
        public enum OrderStatu
        {
            待付款 = 1,
            已付款 = 2,
            已完成 = 3,
            退款中 = 4,
            已取消 = 5,
            已结束 = 6
        }

        /// <summary>
        /// 退款状态
        /// </summary>
        public enum RefundStatus
        {
            申请退款 = 1,
            已退款 = 2
        }
       
    }
}
