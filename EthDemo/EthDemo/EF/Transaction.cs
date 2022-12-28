namespace EthDemo.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        public int transactionID { get; set; }

        public int? blockID { get; set; }

        [StringLength(66)]
        public string hash { get; set; }

        [StringLength(42)]
        public string from { get; set; }

        [StringLength(42)]
        public string to { get; set; }

        public decimal? value { get; set; }

        public decimal? gas { get; set; }

        public decimal? gasPrice { get; set; }

        public int? transactionIndex { get; set; }

        public virtual Block Block { get; set; }
    }
}
