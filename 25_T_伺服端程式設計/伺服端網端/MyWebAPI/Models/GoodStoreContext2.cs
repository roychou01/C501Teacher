﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.DTOs;

namespace MyWebAPI.Models;

//4.7.2 修改類別、建構子名稱及繼承父類別
public partial class GoodStoreContext2 : GoodStoreContext
{
    public GoodStoreContext2(DbContextOptions<GoodStoreContext> options)
        : base(options)
    {
    }


    //4.7.3 只留下DTO的DbSet其他的DbSet全數刪除
    public virtual DbSet<ProductDTO> ProductDTO { get; set; }

    //4.7.4 OnModelCreating方法中只留下ProductDTO的Entity設定其他刪除
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDTO>(entity => entity.HasNoKey());

        //4.7.5 加入base.OnModelCreating(modelBuilder);來繼承父類別所的方法
        base.OnModelCreating(modelBuilder);
    }


}
