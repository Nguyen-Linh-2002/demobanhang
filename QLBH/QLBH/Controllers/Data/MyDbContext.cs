using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }      
           public DbSet<Product> products { get; set; }
           public DbSet<Employer> employers { get; set; }
           public DbSet<Invoice> invoices { get; set; }
           public DbSet<InvoiceDetails> invoiceDetails { get; set; }
           public DbSet<Customer> customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(c =>
            {
                c.ToTable("Customer");
                c.HasKey(kh => kh.maKH);

            });
            modelBuilder.Entity<Employer>(e =>
            {
                e.ToTable("Employer");
                e.HasKey(nv => nv.maNV);

            });
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Product");
                p.HasKey(sp => sp.maSP);

            });
            modelBuilder.Entity<Invoice>(i =>
            {
                i.ToTable("Invoice");
                i.HasKey(hd => hd.maHD);

                //sai????
                i.Property(hd => hd.Nlap).HasDefaultValueSql("getutcdate()");

                // thiết lập mối quan hệ hóa đơn vs khách hàng
                i.HasOne(iv=> iv.customer)
                .WithMany(iv=> iv.invoices)
                 .HasForeignKey(iv => iv.maKH)
                .HasConstraintName("FK_Inv_Cus");

                // thiết lập mối quan hệ hóa đơn vs nhân viên
                i.HasOne(iv => iv.employer)
               .WithMany(iv => iv.invoices)
                .HasForeignKey(iv => iv.maNV)
               .HasConstraintName("FK_Inv_Emp");
            });
            modelBuilder.Entity<InvoiceDetails>(en =>
            {
                en.ToTable("InvoiceDetails");
                //khai báo khóa chính
                en.HasKey(cthd => new { cthd.maHD, cthd.maSP });
                //gán khóa ngoại và điều kiện cho hóa đơn
                en.HasOne(en => en.invoice)
                .WithMany(en => en.invoiceDetails)
                .HasForeignKey(en => en.maHD)
                .HasConstraintName("FK_IDetails_Inv");
                //gán khóa ngoại và điều kiện cho sản phẩm
                en.HasOne(en => en.product)
                .WithMany(en => en.invoiceDetails)
                .HasForeignKey(en => en.maSP)
                .HasConstraintName("FK_IDetails_Product");

            });
        }
    }
}
