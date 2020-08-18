﻿// <auto-generated />
using System;
using Accounting.Api.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Accounting.Api.Migrations
{
    [DbContext(typeof(AccountingDbContext))]
    partial class AccountingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Accounting.Api.Entities.PrimaryCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PrimaryCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "衣服饰品"
                        },
                        new
                        {
                            Id = 2,
                            Name = "食品酒水"
                        },
                        new
                        {
                            Id = 3,
                            Name = "居家物业"
                        },
                        new
                        {
                            Id = 4,
                            Name = "行车交通"
                        },
                        new
                        {
                            Id = 5,
                            Name = "交流通讯"
                        },
                        new
                        {
                            Id = 6,
                            Name = "休闲娱乐"
                        },
                        new
                        {
                            Id = 7,
                            Name = "人情往来"
                        },
                        new
                        {
                            Id = 8,
                            Name = "医疗保健"
                        },
                        new
                        {
                            Id = 9,
                            Name = "金融保险"
                        },
                        new
                        {
                            Id = 10,
                            Name = "其他杂项"
                        });
                });

            modelBuilder.Entity("Accounting.Api.Entities.Record", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("SecondaryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("Accounting.Api.Entities.SecondaryCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PrimaryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryId");

                    b.ToTable("secondaryCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "衣服裤子",
                            PrimaryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "鞋帽包包",
                            PrimaryId = 1
                        },
                        new
                        {
                            Id = 25,
                            Name = "化妆饰品",
                            PrimaryId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "早午晚餐",
                            PrimaryId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "烟酒茶",
                            PrimaryId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "水果零食",
                            PrimaryId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "日常用品",
                            PrimaryId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "水电煤气",
                            PrimaryId = 3
                        },
                        new
                        {
                            Id = 8,
                            Name = "维修保养",
                            PrimaryId = 3
                        },
                        new
                        {
                            Id = 9,
                            Name = "公共交通",
                            PrimaryId = 4
                        },
                        new
                        {
                            Id = 10,
                            Name = "打车",
                            PrimaryId = 4
                        },
                        new
                        {
                            Id = 11,
                            Name = "私家车",
                            PrimaryId = 4
                        },
                        new
                        {
                            Id = 12,
                            Name = "手机",
                            PrimaryId = 5
                        },
                        new
                        {
                            Id = 13,
                            Name = "网络",
                            PrimaryId = 5
                        },
                        new
                        {
                            Id = 14,
                            Name = "腐败聚会",
                            PrimaryId = 6
                        },
                        new
                        {
                            Id = 15,
                            Name = "休闲玩乐",
                            PrimaryId = 6
                        },
                        new
                        {
                            Id = 16,
                            Name = "旅游度假",
                            PrimaryId = 6
                        },
                        new
                        {
                            Id = 17,
                            Name = "送礼",
                            PrimaryId = 7
                        },
                        new
                        {
                            Id = 18,
                            Name = "红包",
                            PrimaryId = 7
                        },
                        new
                        {
                            Id = 19,
                            Name = "问诊治疗",
                            PrimaryId = 8
                        },
                        new
                        {
                            Id = 20,
                            Name = "药品",
                            PrimaryId = 8
                        },
                        new
                        {
                            Id = 21,
                            Name = "医疗器材",
                            PrimaryId = 8
                        },
                        new
                        {
                            Id = 22,
                            Name = "投资",
                            PrimaryId = 9
                        },
                        new
                        {
                            Id = 23,
                            Name = "按揭还款",
                            PrimaryId = 9
                        },
                        new
                        {
                            Id = 24,
                            Name = "意外丢失",
                            PrimaryId = 10
                        });
                });

            modelBuilder.Entity("Accounting.Api.Entities.Record", b =>
                {
                    b.HasOne("Accounting.Api.Entities.SecondaryCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Accounting.Api.Entities.SecondaryCategory", b =>
                {
                    b.HasOne("Accounting.Api.Entities.PrimaryCategory", "PrimaryCategory")
                        .WithMany("SecondaryCategory")
                        .HasForeignKey("PrimaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
