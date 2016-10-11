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
    public class pbs_basic_OrderDao : DBOperation
    {
        public bool AddOrder( int goodsId, int count, DateTime visitTime, int userId, int orderMemberId, decimal orderPrice, int voucherId, int orderStatus,DateTime createTime, DateTime updateTime, int creatorId, string remark,string userName, string phone,int goodsPackageId, ref string orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_Order(");
            strSql.Append(" GoodsId,Count,VisitTime,UserId,OrderMemberId,OrderPrice,VoucherId,OrderStatus,CreateTime,UpdateTime,CreatorId,Remark,UserName,Phone,GoodsPackageId )");
            strSql.Append(" values (");
            strSql.Append(" @GoodsId,@Count,@VisitTime,@UserId,@OrderMemberId,@OrderPrice,@VoucherId,@OrderStatus,@CreateTime,@UpdateTime,@CreatorId,@Remark,@UserName,@Phone,@GoodsPackageId )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsId", SqlDbType.Int,4),
                    new SqlParameter("@Count", SqlDbType.Int,4),
                    new SqlParameter("@VisitTime", SqlDbType.DateTime),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@OrderMemberId", SqlDbType.Int,4),
                    new SqlParameter("@OrderPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@VoucherId", SqlDbType.Int,4),
                    new SqlParameter("@OrderStatus", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,200),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsPackageId", SqlDbType.Int,4)
            };
            parameters[0].Value = goodsId;
            parameters[1].Value = count;
            parameters[2].Value = visitTime;
            parameters[3].Value = userId;
            parameters[4].Value = orderMemberId;
            parameters[5].Value = orderPrice;
            parameters[6].Value = voucherId;
            parameters[7].Value = orderStatus;
            parameters[8].Value = createTime;
            parameters[9].Value = updateTime;
            parameters[10].Value = creatorId;
            parameters[11].Value = remark;
            parameters[12].Value = userName;
            parameters[13].Value = phone;
            parameters[14].Value = goodsPackageId;

            object obj = ExecuteScalar(strSql.ToString(), parameters);
            if (obj != null && obj != DBNull.Value)
            {
                orderId = obj.ToString();
                return true;
            }
            return false;
        }

        public bool UpdateOrderStatus(int orderStatus, int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Order set ");
            strSql.Append("OrderStatus=@OrderStatus");
            strSql.Append(" where OrderId=@OrderId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderStatus", SqlDbType.Int, 4),
                new SqlParameter("@OrderId", SqlDbType.Int, 4)
            };
            parameters[0].Value = orderStatus;
            parameters[1].Value = orderId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateOrderVoucher(int voucherId, int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Order set ");
            strSql.Append("VoucherId=@VoucherId");
            strSql.Append(" where OrderId=@OrderId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@VoucherId", SqlDbType.Int, 4),
                new SqlParameter("@OrderId", SqlDbType.Int, 4)
            };

            parameters[0].Value = voucherId;
            parameters[1].Value = orderId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateOrderPrice(decimal orderPrice, int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Order set ");
            strSql.Append("OrderPrice=@OrderPrice");
            strSql.Append(" where OrderId=@OrderId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderPrice", SqlDbType.Decimal, 9),
                new SqlParameter("@OrderId", SqlDbType.Int, 4)
            };

            parameters[0].Value = orderPrice;
            parameters[1].Value = orderId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateOrderStatus(int orderStatus, decimal orderPrice, int voucherId, int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Order set ");
            strSql.Append("OrderStatus=@OrderStatus,");
            strSql.Append("OrderPrice=@OrderPrice,");
            strSql.Append("VoucherId=@VoucherId");
            strSql.Append(" where OrderId=@OrderId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderStatus", SqlDbType.Int, 4),
                new SqlParameter("@OrderPrice", SqlDbType.Decimal,9),
                new SqlParameter("@VoucherId", SqlDbType.Int, 4),
                new SqlParameter("@OrderId", SqlDbType.Int, 4)
            };
            parameters[0].Value = orderStatus;
            parameters[1].Value = orderPrice;
            parameters[2].Value = voucherId;
            parameters[3].Value = orderId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public pbs_basic_Order GetOrderModelById(int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderId,GoodsId,Count,VisitTime,UserId,OrderMemberId,OrderPrice,VoucherId,OrderStatus,CreateTime,UpdateTime,CreatorId,Remark,UserName,Phone,GoodsPackageId from pbs_basic_Order ");
            strSql.Append(" where OrderId=@OrderId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.Int,4)
            };
            parameters[0].Value = orderId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Order> list = Utility.ModelConvertHelper<pbs_basic_Order>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public pbs_basic_OrderView GetOrderModelViewById(int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.OrderId,a.GoodsId,a.Count,a.VisitTime,a.UserId,a.OrderMemberId,a.OrderPrice,a.VoucherId, ");
            strSql.Append(" a.OrderStatus,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,a.UserName,a.Phone,a.GoodsPackageId,b.GoodsName,b.GoodsMainImgUrl,c.GoodsPackageName ");
            strSql.Append(" FROM pbs_basic_Order a left join pbs_basic_Goods b on a.GoodsId = b.GoodsId ");
            strSql.Append(" left join pbs_basic_GoodsPackage c on a.GoodsPackageId = c.GoodsPackageId ");

            strSql.Append(" WHERE OrderId=@OrderId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.Int,4)
            };
            parameters[0].Value = orderId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_OrderView> list = Utility.ModelConvertHelper<pbs_basic_OrderView>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_Order> GetOrderListByUserId(int userId)
        {
            List<pbs_basic_Order> list = new List<pbs_basic_Order>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OrderId,GoodsId,Count,VisitTime,UserId,OrderMemberId,OrderPrice,VoucherId,OrderStatus,CreateTime,UpdateTime,CreatorId,Remark,UserName,Phone,GoodsPackageId ");
            strSql.Append(" FROM pbs_basic_Order ");
            strSql.Append(" WHERE UserId=@UserId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Order> ilist = Utility.ModelConvertHelper<pbs_basic_Order>.ConvertToModel(dt);
            list = new List<pbs_basic_Order>(ilist);
            return list;
        }

        public List<pbs_basic_Order> GetOrderListByUserIdAndStatus(int userId,int orderStatus)
        {
            List<pbs_basic_Order> list = new List<pbs_basic_Order>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OrderId,GoodsId,Count,VisitTime,UserId,OrderMemberId,OrderPrice,VoucherId,OrderStatus,CreateTime,UpdateTime,CreatorId,Remark,UserName,Phone,GoodsPackageId ");
            strSql.Append(" FROM pbs_basic_Order ");
            strSql.Append(" WHERE UserId=@UserId ");
            if (orderStatus!=-1)
            {
                strSql.Append(" AND  OrderStatus=@OrderStatus ");
            }
            
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@OrderStatus", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            parameters[1].Value = orderStatus;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Order> ilist = Utility.ModelConvertHelper<pbs_basic_Order>.ConvertToModel(dt);
            list = new List<pbs_basic_Order>(ilist);
            return list;
        }

        public List<pbs_basic_OrderView> GetOrderViewListByUserId(int userId)
        {
            List<pbs_basic_OrderView> list = new List<pbs_basic_OrderView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.OrderId,a.GoodsId,a.Count,a.VisitTime,a.UserId,a.OrderMemberId,a.OrderPrice,a.VoucherId, ");
            strSql.Append(" a.OrderStatus,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,a.UserName,a.Phone,a.GoodsPackageId,b.GoodsName,b.GoodsMainImgUrl,c.GoodsPackageName ");
            strSql.Append(" FROM pbs_basic_Order a left join pbs_basic_Goods b on a.GoodsId = b.GoodsId ");
            strSql.Append(" left join pbs_basic_GoodsPackage c on a.GoodsPackageId = c.GoodsPackageId ");
            strSql.Append(" where UserId =@UserId ");
            strSql.Append(" ORDER BY a.CreateTime desc ");

            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_OrderView> ilist = Utility.ModelConvertHelper<pbs_basic_OrderView>.ConvertToModel(dt);
            list = new List<pbs_basic_OrderView>(ilist);
            return list;
        }

        public List<pbs_basic_OrderViewRN> GetOrderViewRNListByUserId(int userId)
        {
            List<pbs_basic_OrderViewRN> list = new List<pbs_basic_OrderViewRN>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY a.OrderId ) AS RNum, a.OrderId,a.GoodsId,a.Count,a.VisitTime,a.UserId,a.OrderMemberId,a.OrderPrice,a.VoucherId,a.OrderStatus,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,a.UserName,a.Phone,a.GoodsPackageId,b.GoodsName,b.GoodsMainImgUrl,c.GoodsPackageName ");
            strSql.Append(" FROM pbs_basic_Order a,pbs_basic_Goods b,pbs_basic_GoodsPackage c ");
            strSql.Append(" WHERE a.GoodsId=b.GoodsId AND a.GoodsPackageId=c.GoodsPackageId AND UserId=@UserId ORDER BY a.CreateTime desc ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_OrderViewRN> ilist = Utility.ModelConvertHelper<pbs_basic_OrderViewRN>.ConvertToModel(dt);
            list = new List<pbs_basic_OrderViewRN>(ilist);
            return list;
        }

        public List<pbs_basic_OrderView> GetOrderViewListByUserIdAndStatus(int userId, int orderStatus)
        {
            List<pbs_basic_OrderView> list = new List<pbs_basic_OrderView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.OrderId,a.GoodsId,a.Count,a.VisitTime,a.UserId,a.OrderMemberId,a.OrderPrice,a.VoucherId, ");
            strSql.Append(" a.OrderStatus,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,a.UserName,a.Phone,a.GoodsPackageId,b.GoodsName,b.GoodsMainImgUrl,c.GoodsPackageName ");
            strSql.Append(" FROM pbs_basic_Order a left join pbs_basic_Goods b on a.GoodsId = b.GoodsId ");
            strSql.Append(" left join pbs_basic_GoodsPackage c on a.GoodsPackageId = c.GoodsPackageId ");
            strSql.Append(" where UserId =@UserId ");

            if (orderStatus != -1)
            {
                strSql.Append(" AND a.OrderStatus=@OrderStatus ");
            }

            strSql.Append(" ORDER BY a.CreateTime desc ");

            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@OrderStatus", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            parameters[1].Value = orderStatus;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_OrderView> ilist = Utility.ModelConvertHelper<pbs_basic_OrderView>.ConvertToModel(dt);
            list = new List<pbs_basic_OrderView>(ilist);
            return list;
        }

        public List<pbs_basic_Order> GetOrderList()
        {
            List<pbs_basic_Order> list = new List<pbs_basic_Order>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OrderId,GoodsId,Count,VisitTime,UserId,OrderMemberId,OrderPrice,VoucherId,OrderStatus,CreateTime,UpdateTime,CreatorId,Remark,UserName,Phone,GoodsPackageId ");
            strSql.Append(" FROM pbs_basic_Order ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_Order> ilist = Utility.ModelConvertHelper<pbs_basic_Order>.ConvertToModel(dt);
            list = new List<pbs_basic_Order>(ilist);
            return list;
        }

        public List<pbs_basic_OrderView> GetOrderViewList()
        {
            List<pbs_basic_OrderView> list = new List<pbs_basic_OrderView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.OrderId,a.GoodsId,a.Count,a.VisitTime,a.UserId,a.OrderMemberId,a.OrderPrice,a.VoucherId,a.OrderStatus,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,a.UserName,a.Phone,a.GoodsPackageId,b.GoodsName,b.GoodsMainImgUrl ");
            strSql.Append(" FROM pbs_basic_Order a,pbs_basic_Goods b where a.GoodsId=b.GoodsId ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_OrderView> ilist = Utility.ModelConvertHelper<pbs_basic_OrderView>.ConvertToModel(dt);
            list = new List<pbs_basic_OrderView>(ilist);
            return list;
        }

        public List<pbs_basic_OrderView> GetOrderViewList(string startTime, string endTime)
        {
            DateTime st = Utility.Util.ParseHelper.ToDatetime(startTime);
            DateTime et = Utility.Util.ParseHelper.ToDatetime(endTime);
            List<pbs_basic_OrderView> list = new List<pbs_basic_OrderView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.OrderId,a.GoodsId,a.Count,a.VisitTime,a.UserId,a.OrderMemberId,a.OrderPrice,a.VoucherId,a.OrderStatus,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,a.UserName,a.Phone,a.GoodsPackageId,b.GoodsName,b.GoodsMainImgUrl ");
            strSql.Append(" FROM pbs_basic_Order a,pbs_basic_Goods b where a.GoodsId=b.GoodsId ");

            if (startTime!=null&& endTime!=null)
            {
                //strSql.Append(" AND a.CreateTime>='@StartTime' AND a.CreateTime<='@EndTime' ");
                strSql.Append(" AND a.CreateTime BETWEEN @StartTime AND @EndTime ");
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@StartTime", SqlDbType.DateTime),
                    new SqlParameter("@EndTime", SqlDbType.DateTime)
            };
            parameters[0].Value = st;
            parameters[1].Value = et;

            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_OrderView> ilist = Utility.ModelConvertHelper<pbs_basic_OrderView>.ConvertToModel(dt);
            list = new List<pbs_basic_OrderView>(ilist);
            return list;
        }

        public List<SaleMemberReportSQL> GetSaleMemberReportSQLList()
        {
            List<SaleMemberReportSQL> list = new List<SaleMemberReportSQL>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.GoodsId,c.GoodsName,c.SellingPrice,c.ResponsiblePersonProfit,c.GoodsCost,count(0) as OrderCount ");
            strSql.Append(" from(select a.GoodsId,a.GoodsName,a.SellingPrice,ISNULL(a.ResponsiblePersonProfit,0) as ResponsiblePersonProfit,ISNULL(a.GoodsCost,0) as GoodsCost ");
            strSql.Append(" from pbs_basic_Goods a,pbs_basic_Order b where a.GoodsId=b.GoodsId) c ");
            strSql.Append(" group by c.GoodsId,c.SellingPrice,c.ResponsiblePersonProfit,c.GoodsCost,c.GoodsName ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<SaleMemberReportSQL> ilist = Utility.ModelConvertHelper<SaleMemberReportSQL>.ConvertToModel(dt);
            list = new List<SaleMemberReportSQL>(ilist);
            return list;
        }

        public bool DeleteOrder(int orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_Order ");
            strSql.Append(" where OrderId=@OrderId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = orderId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public List<SaleGoodsReport> GetSaleGoodsReportList()
        {
            List<SaleGoodsReport> list = new List<SaleGoodsReport>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select a.GoodsId,a.GoodsName,isnull(ActShowCount, 0) as ActShowCount,isnull(PeopleCount, 0) as PeopleCount,a.SellingPrice ");
            strSql.Append(", isnull((SellingPrice * PeopleCount), 0) as TotalIncome,isnull(PlatformCost, 0) as PlatformCost ");
            strSql.Append(", isnull(ResponsiblePersonProfit, 0) as ResponsiblePersonProfit,isnull(SumShareProfit, 0) as SumShareProfit,isnull(OtherCost, 0) as OtherCost ");
            strSql.Append(", (isnull(PlatformCost, 0) + isnull(ResponsiblePersonProfit, 0) + isnull(SumShareProfit, 0) + isnull(OtherCost, 0)) as TotalPrice ");
            strSql.Append(", (isnull((SellingPrice * PeopleCount), 0) - (isnull(PlatformCost, 0) + isnull(ResponsiblePersonProfit, 0) + isnull(SumShareProfit, 0) + isnull(OtherCost, 0))) as TotalProfit ");
            strSql.Append("from pbs_basic_Goods a ");
            strSql.Append("left join ");
            strSql.Append("(select b.GoodsId,count(distinct(b.VisitTime)) as ActShowCount,sum(b.[count]) as PeopleCount from pbs_basic_Order b group by b.GoodsId) as c ");
            strSql.Append("on a.GoodsId = c.GoodsId ");
            strSql.Append("left join ");
            strSql.Append("(select sum(Profit) as SumShareProfit, pbs_basic_MyShareProfit.GoodsId from pbs_basic_MyShareProfit group by pbs_basic_MyShareProfit.GoodsId) as d ");
            strSql.Append("on a.GoodsId = d.GoodsId ");

            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<SaleGoodsReport> ilist = Utility.ModelConvertHelper<SaleGoodsReport>.ConvertToModel(dt);
            list = new List<SaleGoodsReport>(ilist);
            return list;
        }

    }
}
