using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PCGerenteFacturacion.DBModels;

public partial class PcgerentetestContext : DbContext
{
    public PcgerentetestContext()
    {
    }

    public PcgerentetestContext(DbContextOptions<PcgerentetestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceHead> InvoiceHeads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-R601H3RA\\SQLEXPRESS; Database=pcgerentetest; Trusted_Connection=true; TrustServerCertificate=true; Persist Security Info=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.IdInvoiceDetail);

            entity.ToTable("invoice_detail");

            entity.Property(e => e.IdInvoiceDetail).HasColumnName("idInvoiceDetail");
            entity.Property(e => e.IdInvoiceHead).HasColumnName("idInvoiceHead");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasColumnType("text")
                .HasColumnName("productName");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdInvoiceHeadNavigation).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.IdInvoiceHead)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_invoice_detail_invoice_head");
        });

        modelBuilder.Entity<InvoiceHead>(entity =>
        {
            entity.HasKey(e => e.IdInvoiceHead);

            entity.ToTable("invoice_head");

            entity.Property(e => e.IdInvoiceHead).HasColumnName("idInvoiceHead");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("dateTime");
            entity.Property(e => e.TaxTwelve).HasColumnName("taxTwelve");
            entity.Property(e => e.TaxZero).HasColumnName("taxZero");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
