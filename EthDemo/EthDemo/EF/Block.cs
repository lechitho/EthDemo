namespace EthDemo.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Block
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Block()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int blockID { get; set; }

        public int? blockNumber { get; set; }

        [StringLength(66)]
        public string hash { get; set; }

        [StringLength(66)]
        public string parentHash { get; set; }

        [StringLength(42)]
        public string miner { get; set; }

        public decimal? blockReward { get; set; }

        public decimal? gasLimit { get; set; }

        public decimal? gasUsed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
