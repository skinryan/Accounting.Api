using Accounting.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Accounting.Api.DbContexts
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options)
        {
        }


        public DbSet<PrimaryCategory> PrimaryCategories { get; set; }

        public DbSet<SecondaryCategory> secondaryCategories { get; set; }

        public DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrimaryCategory>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<SecondaryCategory>().Property(x => x.Id).IsRequired();

            modelBuilder.Entity<SecondaryCategory>()
                .HasOne(s => s.PrimaryCategory)
                .WithMany(p => p.SecondaryCategory)
                .HasForeignKey(s => s.PrimaryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PrimaryCategory>().HasData(
                new PrimaryCategory() { Id = 1, Name = "衣服饰品" },
                new PrimaryCategory() { Id = 2, Name = "食品酒水" },
                new PrimaryCategory() { Id = 3, Name = "居家物业" },
                new PrimaryCategory() { Id = 4, Name = "行车交通" },
                new PrimaryCategory() { Id = 5, Name = "交流通讯" },
                new PrimaryCategory() { Id = 6, Name = "休闲娱乐" },
                new PrimaryCategory() { Id = 7, Name = "人情往来" },
                new PrimaryCategory() { Id = 8, Name = "医疗保健" },
                new PrimaryCategory() { Id = 9, Name = "金融保险" },
                new PrimaryCategory() { Id = 10, Name = "其他杂项" }
            );

            modelBuilder.Entity<SecondaryCategory>().HasData(
                new SecondaryCategory() { Id = 1, PrimaryId = 1, Name = "衣服裤子" },
                new SecondaryCategory() { Id = 2, PrimaryId = 1, Name = "鞋帽包包" },
                new SecondaryCategory() { Id = 25, PrimaryId = 1, Name = "化妆饰品" },
                new SecondaryCategory() { Id = 3, PrimaryId = 2, Name = "早午晚餐" },
                new SecondaryCategory() { Id = 4, PrimaryId = 2, Name = "烟酒茶" },
                new SecondaryCategory() { Id = 5, PrimaryId = 2, Name = "水果零食" },
                new SecondaryCategory() { Id = 6, PrimaryId = 3, Name = "日常用品" },
                new SecondaryCategory() { Id = 7, PrimaryId = 3, Name = "水电煤气" },
                new SecondaryCategory() { Id = 8, PrimaryId = 3, Name = "维修保养" },
                new SecondaryCategory() { Id = 9, PrimaryId = 4, Name = "公共交通" },
                new SecondaryCategory() { Id = 10, PrimaryId = 4, Name = "打车" },
                new SecondaryCategory() { Id = 11, PrimaryId = 4, Name = "私家车" },
                new SecondaryCategory() { Id = 12, PrimaryId = 5, Name = "手机" },
                new SecondaryCategory() { Id = 13, PrimaryId = 5, Name = "网络" },
                new SecondaryCategory() { Id = 14, PrimaryId = 6, Name = "腐败聚会" },
                new SecondaryCategory() { Id = 15, PrimaryId = 6, Name = "休闲玩乐" },
                new SecondaryCategory() { Id = 16, PrimaryId = 6, Name = "旅游度假" },
                new SecondaryCategory() { Id = 17, PrimaryId = 7, Name = "送礼" },
                new SecondaryCategory() { Id = 18, PrimaryId = 7, Name = "红包" },
                new SecondaryCategory() { Id = 19, PrimaryId = 8, Name = "问诊治疗" },
                new SecondaryCategory() { Id = 20, PrimaryId = 8, Name = "药品" },
                new SecondaryCategory() { Id = 21, PrimaryId = 8, Name = "医疗器材" },
                new SecondaryCategory() { Id = 22, PrimaryId = 9, Name = "投资" },
                new SecondaryCategory() { Id = 23, PrimaryId = 9, Name = "按揭还款" },
                new SecondaryCategory() { Id = 24, PrimaryId = 10, Name = "意外丢失" }
            );


        }
    }
}
