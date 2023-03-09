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
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public object ProductType { get; internal set; }

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

                entity.Property(e => e.ProductCatalogTypeId).HasDefaultValueSql("nextval('\"ProductItem_productcatalogtypeid_seq\"'::regclass)");

                entity.HasOne(d => d.ProductCatalogType)
                    .WithMany(p => p.ProductItems)
                    .HasForeignKey(d => d.ProductCatalogTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productitem_fk");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.ProductCatelogId)
                    .HasName("productcatalogtype_pk");

                entity.ToTable("ProductType");

                entity.Property(e => e.ProductCatelogId).HasDefaultValueSql("nextval('productcatalogtype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
