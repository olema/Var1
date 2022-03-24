﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Var1.Data;

#nullable disable

namespace Var1.Migrations
{
    [DbContext(typeof(MyDataBaseVar1Context))]
    partial class MyDataBaseVar1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Var1.Models.Emk", b =>
                {
                    b.Property<int>("EmkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmkID"));

                    b.Property<DateTime>("InputDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("OperID")
                        .HasColumnType("integer");

                    b.Property<int>("PacientID")
                        .HasColumnType("integer");

                    b.Property<int>("WUserID")
                        .HasColumnType("integer");

                    b.HasKey("EmkID");

                    b.HasIndex("OperID");

                    b.HasIndex("PacientID");

                    b.HasIndex("WUserID");

                    b.ToTable("Emk", (string)null);
                });

            modelBuilder.Entity("Var1.Models.Oper", b =>
                {
                    b.Property<int>("OperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OperID"));

                    b.Property<string>("OperName")
                        .HasColumnType("text");

                    b.HasKey("OperID");

                    b.ToTable("Oper", (string)null);
                });

            modelBuilder.Entity("Var1.Models.Pacient", b =>
                {
                    b.Property<int>("PacientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PacientID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("MedPol")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("PacientID");

                    b.ToTable("Pacient", (string)null);
                });

            modelBuilder.Entity("Var1.Models.WDoljn", b =>
                {
                    b.Property<int>("WDoljnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WDoljnID"));

                    b.Property<string>("DoljnName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("WDoljnID");

                    b.ToTable("Doljn", (string)null);
                });

            modelBuilder.Entity("Var1.Models.WUser", b =>
                {
                    b.Property<int>("WUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WUserID"));

                    b.Property<int>("DoljnForeignKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Passw")
                        .HasColumnType("text");

                    b.HasKey("WUserID");

                    b.HasIndex("DoljnForeignKey")
                        .IsUnique();

                    b.ToTable("WUser", (string)null);
                });

            modelBuilder.Entity("Var1.Models.Emk", b =>
                {
                    b.HasOne("Var1.Models.Oper", "Oper")
                        .WithMany()
                        .HasForeignKey("OperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Var1.Models.Pacient", "Pacient")
                        .WithMany("Emk")
                        .HasForeignKey("PacientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Var1.Models.WUser", "WUser")
                        .WithMany()
                        .HasForeignKey("WUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oper");

                    b.Navigation("Pacient");

                    b.Navigation("WUser");
                });

            modelBuilder.Entity("Var1.Models.WUser", b =>
                {
                    b.HasOne("Var1.Models.WDoljn", "WDoljn")
                        .WithOne("Wuser")
                        .HasForeignKey("Var1.Models.WUser", "DoljnForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WDoljn");
                });

            modelBuilder.Entity("Var1.Models.Pacient", b =>
                {
                    b.Navigation("Emk");
                });

            modelBuilder.Entity("Var1.Models.WDoljn", b =>
                {
                    b.Navigation("Wuser");
                });
#pragma warning restore 612, 618
        }
    }
}
