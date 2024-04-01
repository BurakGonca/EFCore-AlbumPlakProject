using EFPlakApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MaratonApp.DAL.Context
{
    public class MaratonAppDbContext:DbContext
    {

       public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Album> Albumler { get; set; }
        public DbSet<Sanatci> Sanatcilar { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=BURAK;Initial Catalog=AlbumSanatciDb;Integrated Security=true;Encrypt=False");

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sanatci>().HasData(
                new Sanatci()
                {
                    Id = 1,
                    SanatciAdi="Hakan",
                    SanatciSoyadi="Grgn"
                },
                new Sanatci()
                {
                    Id = 2,
                    SanatciAdi = "Hivda",
                    SanatciSoyadi = "Krhn"
                },
                new Sanatci()
                {
                    Id = 3,
                    SanatciAdi = "Burak",
                    SanatciSoyadi = "Gnc"
                }
                );
        }
    }
}
