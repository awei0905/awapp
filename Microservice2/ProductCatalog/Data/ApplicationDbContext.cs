using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductCatalog.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductItem> ProductItems { get; set; } = null!;
        public virtual DbSet<ProductItemType> ProductItemTypes { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductItem>(entity =>
            {
                entity.ToTable("ProductItem");

                entity.Property(e => e.ProductItemId).HasDefaultValueSql("nextval('newtable_id_seq'::regclass)");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ProductItemType>(entity =>
            {
                entity.ToTable("ProductItemType");

                entity.HasIndex(e => new { e.ProductItemId, e.ProductTypeId }, "productitemtype_productid_idx")
                    .IsUnique();

                entity.Property(e => e.ProductItemTypeId).HasDefaultValueSql("nextval('productitemtype_productitemtypeid_seq'::regclass)");

                entity.HasOne(d => d.ProductItem)
                    .WithMany(p => p.ProductItemTypes)
                    .HasForeignKey(d => d.ProductItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productitemtype_fk");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.ProductItemTypes)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productitemtype_fk_1");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.Property(e => e.ProductTypeId).HasDefaultValueSql("nextval('productcatalogtype_id_seq'::regclass)");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
