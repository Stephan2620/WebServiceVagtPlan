namespace WebServiceVagtPlan
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context2")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Medarbejder> Medarbejders { get; set; }
        public virtual DbSet<Vagt> Vagts { get; set; }
        public virtual DbSet<VagtPlan> VagtPlans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medarbejder>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejder>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<Vagt>()
                .Property(e => e.Afdeling)
                .IsUnicode(false);

            modelBuilder.Entity<Vagt>()
                .Property(e => e.Lokation)
                .IsUnicode(false);

            modelBuilder.Entity<Vagt>()
                .Property(e => e.Tid)
                .IsUnicode(false);

            modelBuilder.Entity<VagtPlan>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<VagtPlan>()
                .Property(e => e.Stilling)
                .IsUnicode(false);
        }
    }
}
