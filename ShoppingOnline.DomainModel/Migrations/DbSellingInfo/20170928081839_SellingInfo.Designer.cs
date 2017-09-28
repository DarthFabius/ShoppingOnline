﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using ShoppingOnline.DomainModel;
using ShoppingOnline.DomainModel.Context;
using System;

namespace ShoppingOnline.DomainModel.Migrations.DbSellingInfo
{
    [DbContext(typeof(DbSellingInfoContext))]
    [Migration("20170928081839_SellingInfo")]
    partial class SellingInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingOnline.DomainModel.SellingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("Currency");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.ToTable("SellingoInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
