using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Var1.Models;

namespace Var1.Data
{
    public class MyDataBaseVar1Context : DbContext
    {
        public MyDataBaseVar1Context (DbContextOptions<MyDataBaseVar1Context> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)  => 
            options
                .UseNpgsql(@"Host=localhost;Username=efuser;Password=12345678;Database=efuser");

        public DbSet<Var1.Models.WUser> WUsers { get; set; }

        public DbSet<Var1.Models.Pacient> Pacients { get; set; }
        public DbSet<Var1.Models.Emk> Emks { get; set; }
        public DbSet<Var1.Models.WDoljn> WDoljns { get; set; }
        public DbSet<Var1.Models.Oper> Opers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WUser>().ToTable("WUser")
                .Property(p => p.DoljnForeignKey)
                .HasDefaultValue(1);
            modelBuilder.Entity<Pacient>().ToTable("Pacient");
            modelBuilder.Entity<Emk>()
                .ToTable("Emk")
                .Property(e => e.InputDate)
                .HasDefaultValueSql("now()");
            modelBuilder.Entity<WDoljn>().ToTable("Doljn")
                .HasOne(b => b.Wuser)
                .WithOne(i => i.WDoljn)
                .HasForeignKey<WUser>(b => b.DoljnForeignKey);
            modelBuilder.Entity<Oper>().ToTable("Oper");
        }
    }
}
