using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductCatalog.Model;
using SmartphoneShop.Model;

namespace ProductCatalog.Service
{
    internal class DbContextService : DbContext
    {
        public DbContextService()
        {
            Database.EnsureCreated();
        }

        public DbSet<UserRoleModel> userroles { get; set; } = null!;
        public DbSet<UserModel> users { get; set; } = null!;
        public DbSet<ProductModel> products { get; set; } = null!;
        public DbSet<BasketItemModel> basketItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=10.8.0.1;Port=5432;Database=productcatalog;Username=postgres;Password=postgres");
        }
    }
}
