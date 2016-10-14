namespace DailyTaskMang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.FK_Categories);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.FK_Categories);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
