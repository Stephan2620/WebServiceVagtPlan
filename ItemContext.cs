namespace WebServiceVagtPlan
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ItemContext : DbContext
    {
        public ItemContext()
            : base("name=ItemContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<VagtPlan> VagtPlans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VagtPlan>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<VagtPlan>()
                .Property(e => e.Stilling)
                .IsUnicode(false);
        }
    }
}
