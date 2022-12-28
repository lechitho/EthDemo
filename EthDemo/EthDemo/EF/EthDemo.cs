using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EthDemo.EF
{
    public partial class EthDemo : DbContext
    {
        public EthDemo()
            : base("name=EthDemo")
        {
        }

        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>()
                .Property(e => e.hash)
                .IsUnicode(false);

            modelBuilder.Entity<Block>()
                .Property(e => e.parentHash)
                .IsUnicode(false);

            modelBuilder.Entity<Block>()
                .Property(e => e.miner)
                .IsUnicode(false);

            modelBuilder.Entity<Block>()
                .Property(e => e.blockReward)
                .HasPrecision(38, 0);

            modelBuilder.Entity<Block>()
                .Property(e => e.gasLimit)
                .HasPrecision(38, 0);

            modelBuilder.Entity<Block>()
                .Property(e => e.gasUsed)
                .HasPrecision(38, 0);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.hash)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.from)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.to)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.value)
                .HasPrecision(38, 0);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.gas)
                .HasPrecision(38, 0);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.gasPrice)
                .HasPrecision(38, 0);
        }
    }
}
