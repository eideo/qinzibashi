using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_MyVoucher
    {
        public int MyVoucherId { get; set; }
        public int UserId { get; set; }
        public int VoucherId { get; set; }
        public int IsUsed { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
    }

    public class pbs_basic_MyVoucherView: pbs_basic_MyVoucher
    {
        public decimal VoucherPrice { get; set; }
        public string UseRole { get; set; }
        public string UseStartTime { get; set; }
        public string UseEndTime { get; set; }
        public int VoucherStatus { get; set; }
    }
}
