using System;
using System.Data.Entity;
using System.Linq;

namespace Phan4_2.Data
{
    public class CtyModel : DbContext
    {
        public CtyModel()
            : base("name=CtyModel")
        {
        }

        public DbSet<PhongBan> phongban { get; set; }
        public DbSet<Luong> luong { get; set; }
        public DbSet<NhanSu> nhansu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.nhansu)
                .WithRequired(e => e.phongban)
                .HasForeignKey(e => e.MaPB);

            modelBuilder.Entity<Luong>()
                .HasMany(e => e.nhansu)
                .WithRequired(e => e.luong)
                .HasForeignKey(e => e.ID_Luong);

            modelBuilder.Entity<Luong>()
                .Property(e => e.Bac_Luong)
                .HasPrecision(4, 2);
        }
    }
}