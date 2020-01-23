using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EcommerceProject.Models
{
    public partial class TestEcommerceContext : DbContext
    {
        public TestEcommerceContext()
        {
        }

        public TestEcommerceContext(DbContextOptions<TestEcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TestEcommerce;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Product_Type");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }
    }
}
