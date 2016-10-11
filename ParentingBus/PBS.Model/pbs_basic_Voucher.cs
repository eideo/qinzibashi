using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBS.Model
{
    [Serializable]
    public class pbs_basic_Voucher
    {
        public int VoucherId { get; set; }
        public decimal VoucherPrice { get; set; }
        public string UseRole { get; set; }
        public int VoucherType { get; set; }
        public decimal SRPrice { get; set; }
        public string UseStartTime { get; set; }
        public string UseEndTime { get; set; }
        public int VoucherStatus { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<int> CreatorId { get; set; }
        public string Remark { get; set; }
        public int VoucherCount { get; set; }
    }
    public class pbsBasicVoucherListResult
    {
        public List<pbs_basic_Voucher> List { get; set; }
    }
}
