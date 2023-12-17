using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExpenseReport.Models;

public partial class ExpenseReportDbContext : DbContext
{
    public ExpenseReportDbContext()
    {
    }

    public ExpenseReportDbContext(DbContextOptions<ExpenseReportDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExpenseReportMaster> ExpenseReportMasters { get; set; }

    public virtual DbSet<UserData> UserData { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=(localdb)\\ProjectModels; database=ExpenseReportDb;integrated security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseReportMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3213E83FD4D28505");

            entity.ToTable("ExpenseReportMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.ExpenseReportMasters)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK__ExpenseRe__useri__34C8D9D1");
        });

        modelBuilder.Entity<UserData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserData__3213E83F28B28BDD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
