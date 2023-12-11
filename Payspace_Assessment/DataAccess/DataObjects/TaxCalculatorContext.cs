using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Payspace_Assessment.DataAccess.DataObjects;

public partial class TaxCalculatorContext : DbContext
{
    public TaxCalculatorContext()
    {
    }

    public TaxCalculatorContext(DbContextOptions<TaxCalculatorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PostalCodeDetail> PostalCodeDetails { get; set; }

    public virtual DbSet<ProgressiveTax> ProgressiveTaxes { get; set; }

    public virtual DbSet<TaxCalculationDetail> TaxCalculationDetails { get; set; }

    public virtual DbSet<TaxCalculationType> TaxCalculationTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PG-TZ-IN-LP-077;Initial Catalog=TaxCalculator;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostalCodeDetail>(entity =>
        {
            entity.HasKey(e => e.PostalCodeId);

            entity.Property(e => e.PostalCodeId).ValueGeneratedNever();
            entity.Property(e => e.PostalCodeName).HasMaxLength(10);

            entity.HasOne(d => d.TaxCalculationType).WithMany(p => p.PostalCodeDetails)
                .HasForeignKey(d => d.TaxCalculationTypeId)
                .HasConstraintName("FK_PostalCodeDetails_TaxCalculationType");
        });

        modelBuilder.Entity<ProgressiveTax>(entity =>
        {
            entity.ToTable("ProgressiveTax");

            entity.Property(e => e.FromAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TaxPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ToAmount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TaxCalculationDetail>(entity =>
        {
            entity.HasKey(e => e.TaxCalculationId);

            entity.Property(e => e.AnnualIncome).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CalculatedOn).HasColumnType("datetime");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TaxCalculationType>(entity =>
        {
            entity.ToTable("TaxCalculationType");

            entity.Property(e => e.TaxCalculationTypeId).ValueGeneratedNever();
            entity.Property(e => e.TaxCalculationTypeName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
