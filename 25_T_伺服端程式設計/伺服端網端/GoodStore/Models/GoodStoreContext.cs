﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GoodStore.Models;

public partial class GoodStoreContext : DbContext
{
    public GoodStoreContext(DbContextOptions<GoodStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<Member> Member { get; set; }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<OrderDetail> OrderDetail { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CateID).HasName("PK__Category__27638D745C0DB1F2");

            entity.Property(e => e.CateID)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.CateName).HasMaxLength(20);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberID).HasName("PK__Member__0CF04B38A211F86A");

            entity.HasIndex(e => e.Account, "UQ__Member__B0C3AC4646969FD1").IsUnique();

            entity.Property(e => e.MemberID)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.Account).HasMaxLength(12);
            entity.Property(e => e.Name).HasMaxLength(27);
            entity.Property(e => e.Password).HasMaxLength(64);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderID).HasName("PK__Order__C3905BAF8A771EC4");

            entity.Property(e => e.OrderID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.ContactAddress).HasMaxLength(60);
            entity.Property(e => e.ContactName).HasMaxLength(27);
            entity.Property(e => e.MemberID)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.Order)
                .HasForeignKey(d => d.MemberID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__MemberID__4316F928");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderID, e.ProductID }).HasName("PK__OrderDet__08D097C18C8C14BB");

            entity.Property(e => e.OrderID)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.ProductID)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Qty).HasDefaultValue(1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetail)
                .HasForeignKey(d => d.OrderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__440B1D61");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetail)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__44FF419A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductID).HasName("PK__Product__B40CC6EDC0F8A90C");

            entity.Property(e => e.ProductID)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.CateID)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Picture).HasMaxLength(12);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductName).HasMaxLength(40);

            entity.HasOne(d => d.Cate).WithMany(p => p.Product)
                .HasForeignKey(d => d.CateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__CateID__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
