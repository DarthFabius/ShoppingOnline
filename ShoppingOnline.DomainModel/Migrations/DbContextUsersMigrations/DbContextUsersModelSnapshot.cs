﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ShoppingOnline.DomainModel.Context;
using System;

namespace ShoppingOnline.DomainModel.Migrations.DbContextUsersMigrations
{
    [DbContext(typeof(DbContextUsers))]
    partial class DbContextUsersModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingOnline.DomainModel.SecurityUserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastLoginDateTime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("SessionToken");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("SecurityUserInfos");
                });

            modelBuilder.Entity("ShoppingOnline.DomainModel.ShippingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Cap")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Cco");

                    b.Property<int>("City");

                    b.Property<string>("CivicNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Nation");

                    b.Property<int>("Prov");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShippingInfos");
                });

            modelBuilder.Entity("ShoppingOnline.DomainModel.ShoppingUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("SecurityInfoId");

                    b.HasKey("Id");

                    b.HasIndex("SecurityInfoId");

                    b.ToTable("ShoppingUsers");
                });

            modelBuilder.Entity("ShoppingOnline.DomainModel.ShippingInfo", b =>
                {
                    b.HasOne("ShoppingOnline.DomainModel.ShoppingUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ShoppingOnline.DomainModel.ShoppingUser", b =>
                {
                    b.HasOne("ShoppingOnline.DomainModel.SecurityUserInfo", "SecurityInfo")
                        .WithMany()
                        .HasForeignKey("SecurityInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
