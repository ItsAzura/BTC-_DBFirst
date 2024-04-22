using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTC_DBFirst.Models;

public partial class CompanyDbdatabaseFirstContext : DbContext
{
    public CompanyDbdatabaseFirstContext()
    {
    }

    public CompanyDbdatabaseFirstContext(DbContextOptions<CompanyDbdatabaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CongTy> CongTies { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN;Initial Catalog=CompanyDBDatabaseFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CongTy>(entity =>
        {
            entity.HasKey(e => e.CongTyId).HasName("PK__CongTy__703C5812D9248A69");

            entity.ToTable("CongTy");

            entity.Property(e => e.TenCongTy).HasMaxLength(255);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.NhanVienId).HasName("PK__NhanVien__E27FD78AF44C4826");

            entity.ToTable("NhanVien");

            entity.Property(e => e.GioiTinh).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(255);

            entity.HasOne(d => d.PhongBan).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.PhongBanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien__PhongB__3C69FB99");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.PhongBanId).HasName("PK__PhongBan__F417DBA8F6A26605");

            entity.ToTable("PhongBan");

            entity.Property(e => e.TenPhongBan).HasMaxLength(255);

            entity.HasOne(d => d.CongTy).WithMany(p => p.PhongBans)
                .HasForeignKey(d => d.CongTyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhongBan__CongTy__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
