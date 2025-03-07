﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyModel_DBFirst.Models;

public partial class dbStudentsContext : DbContext
{
    //6.1.3 將dbStudentsContext中所寫的空建構子註解掉(也可留著只是用不到)
    //1.2.5 在dbStudentsContext.cs裡撰寫一個空的建構子
    //public dbStudentsContext()
    //{
    //}

    public dbStudentsContext(DbContextOptions<dbStudentsContext> options)
        : base(options)
    {
    }

    //6.1.2 將dbStudentsContext中所寫的連線字串註解掉
    //1.2.4 在dbStudentsContext.cs裡撰寫連線到資料庫的程式
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //        => optionsBuilder.UseSqlServer("Data Source=IMCSD-3;Database=dbStudents;TrustServerCertificate=True;User ID=abc;Password=123");
    //範例碼
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //      => optionsBuilder.UseSqlServer("Data Source=伺服器位址;Database=資料庫名稱;TrustServerCertificate=True;User ID=帳號;Password=密碼");



    public virtual DbSet<tStudent> tStudent { get; set; }
    //5.2.4 在dbStudentsContext中加入Department的DbSet
    public virtual DbSet<Department> Department { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tStudent>(entity =>
        {
            entity.HasKey(e => e.fStuId).HasName("PK__tStudent__08E5BA95D3A3378D");

            entity.Property(e => e.fStuId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.fEmail).HasMaxLength(40);
            entity.Property(e => e.fName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
