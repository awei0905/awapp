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

        public virtual DbSet<ProductCatalogType> ProductCatalogTypes { get; set; } = null!;
        public virtual DbSet<ProductItem> ProductItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCatalogType>(entity =>
            {
                entity.HasKey(e => e.ProductCatelogId)
                    .HasName("productcatalogtype_pk");

                entity.ToTable("ProductCatalogType");

                entity.Property(e => e.ProductCatelogId).HasDefaultValueSql("nextval('productcatalogtype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Subname).HasMaxLength(100);
            });

            modelBuilder.Entity<ProductItem>(entity =>
            {
                entity.ToTable("ProductItem");

                entity.Property(e => e.ProductItemId).HasDefaultValueSql("nextval('newtable_id_seq'::regclass)");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PictureFileName).HasMaxLength(128);

                entity.Property(e => e.ProductCatalogTypeId).HasDefaultValueSql("nextval('\"ProductItem_productcatalogtypeid_seq\"'::regclass)");

                entity.HasOne(d => d.ProductCatalogType)
                    .WithMany(p => p.ProductItems)
                    .HasForeignKey(d => d.ProductCatalogTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productitem_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
