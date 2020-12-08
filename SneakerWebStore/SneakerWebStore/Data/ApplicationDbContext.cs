using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SneakerWebStore.Models;

namespace SneakerWebStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // oder relation
            builder.Entity<Order>()
                .HasOne(o => o.OrderBilling)
                .WithOne(ob => ob.Order)
                .HasForeignKey<OrderBilling>(ob => ob.Id);
            builder.Entity<Order>()
                .HasOne(o => o.OrderShipping)
                .WithOne(os => os.Order)
                .HasForeignKey<OrderShipping>(os => os.Id);


            //genericproduct many to many category
            builder.Entity<GenericProductCategory>()
                .HasKey(gpc => new { gpc.GenericProductId, gpc.CategoryId });

            builder.Entity<GenericProductCategory>()
                .HasOne(gpc => gpc.Category)
                .WithMany(c => c.GenericProductCategories)
                .HasForeignKey(gpc => gpc.CategoryId);
            builder.Entity<GenericProductCategory>()
                .HasOne(gpc => gpc.GenericProduct)
                .WithMany(gp => gp.GenericProductCategories)
                .HasForeignKey(gpc => gpc.GenericProductId);

            //size giày relation
            builder.Entity<SpecificProductSize>()
                 .HasKey(spz => new { spz.SpecificProductId, spz.SizeId });

            builder.Entity<SpecificProductSize>()
                .HasOne(spz => spz.Size)
                .WithMany(s => s.SpecificProductSizes)
                .HasForeignKey(spz => spz.SizeId);
            builder.Entity<SpecificProductSize>()
                .HasOne(spz => spz.SpecificProduct)
                .WithMany(sp => sp.SpecificProductSizes)
                .HasForeignKey(spz => spz.SpecificProductId);

            // tag relation many to many
            builder.Entity<SpecificProductTag>()
                 .HasKey(spt => new { spt.SpecificProductId, spt.TagId });

            builder.Entity<SpecificProductTag>()
                .HasOne(spt => spt.Tag)
                .WithMany(t => t.SpecificProductTags)
                .HasForeignKey(spt => spt.TagId);
            builder.Entity<SpecificProductTag>()
                .HasOne(spt => spt.SpecificProduct)
                .WithMany(sp => sp.SpecificProductTags)
                .HasForeignKey(spt => spt.SpecificProductId);

            //
            builder.Entity<GenericProductTag>()
                 .HasKey(gpt => new { gpt.GenericProductId, gpt.TagId });

            builder.Entity<GenericProductTag>()
                .HasOne(gpt => gpt.Tag)
                .WithMany(t => t.GenericProductTags)
                .HasForeignKey(gpt => gpt.TagId);

            builder.Entity<GenericProductTag>()
                .HasOne(gpt => gpt.GenericProduct)
                .WithMany(gp => gp.GenericProductTags)
                .HasForeignKey(gpt => gpt.GenericProductId);

            //OrderDetail relation many to many
            builder.Entity<OrderDetail>()
                 .HasKey(od => new { od.Id, od.OrderId, od.SpecificProductId });

            builder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            builder.Entity<OrderDetail>()
                .HasOne(od => od.SpecificProduct)
                .WithMany(sp => sp.OrderDetails)
                .HasForeignKey(od => od.SpecificProductId);


            //index
            builder.Entity<SpecificProductImage>().HasIndex(spi => new { spi.SpecificProductId, spi.Order });
            
            InitData(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<GenericProduct> GenericProducts { get; set; }
        public DbSet<GenericProductCategory> GenericProductCategories { get; set; }
        public DbSet<GenericProductTag> GenericProductTags { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBilling> OrderBillings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderShipping> OrderShippings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SpecificProduct> SpecificProducts { get; set; }
        public DbSet<SpecificProductImage> SpecificProductImages { get; set; }
        public DbSet<SpecificProductSize> SpecificProductSizes { get; set; }
        public DbSet<SpecificProductTag> SpecificProductTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        private void InitData(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category {
                    Id=1,
                    Name="Sneaker"
                },
                new Category {
                    Id=2,
                    Name="Clothes"
                },
                new Category {
                    Id=3,
                    Name="Accessory"
                });

            builder.Entity<Manufacturer>().HasData(
                new Manufacturer {
                    Id=1,
                    Name="Vans",
                },
                new Manufacturer {
                    Id=2,
                    Name="Convert",
                },
                new Manufacturer {
                    Id=3,
                    Name="Adidas",
                });
        }
    }
}
