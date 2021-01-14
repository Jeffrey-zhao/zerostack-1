﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZeroStack.DeviceCenter.Infrastructure.EntityFrameworks;

namespace ZeroStack.DeviceCenter.Infrastructure.Migrations
{
    [DbContext(typeof(DeviceCenterDbContext))]
    partial class DeviceCenterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Coordinate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Online")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SerialNo")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.DeviceTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("DeviceTags");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProjectAggregate.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProjectAggregate.ProjectGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId1")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Sorting")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ProjectId1");

                    b.ToTable("ProjectGroups");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.Device", b =>
                {
                    b.HasOne("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.Product", "Product")
                        .WithMany("Devices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.DeviceAddress", "Address", b1 =>
                        {
                            b1.Property<int>("DeviceId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DeviceId");

                            b1.ToTable("DeviceAddresses");

                            b1.WithOwner()
                                .HasForeignKey("DeviceId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.DeviceTag", b =>
                {
                    b.HasOne("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.Device", null)
                        .WithMany("Tags")
                        .HasForeignKey("DeviceId");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProjectAggregate.ProjectGroup", b =>
                {
                    b.HasOne("ZeroStack.DeviceCenter.Domain.Aggregates.ProjectAggregate.ProjectGroup", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("ZeroStack.DeviceCenter.Domain.Aggregates.ProjectAggregate.Project", null)
                        .WithMany("Groups")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZeroStack.DeviceCenter.Domain.Aggregates.ProjectAggregate.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId1");

                    b.Navigation("Parent");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.Device", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate.Product", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProjectAggregate.Project", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("ZeroStack.DeviceCenter.Domain.Aggregates.ProjectAggregate.ProjectGroup", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
