﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDo.Infrastructure.EF;

#nullable disable

namespace ToDo.Infrastructure.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20230226095617_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToDo.Core.Entities.ToDoItem", b =>
                {
                    b.Property<Guid>("ToDoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("ToDoListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ToDoItemId");

                    b.HasIndex("ToDoListId");

                    b.ToTable("ToDoItems");

                    b.HasData(
                        new
                        {
                            ToDoItemId = new Guid("867fc645-0b1e-4037-a80b-6836ad733a90"),
                            CreatedDate = new DateTime(2023, 2, 26, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5627),
                            Description = "first item",
                            DueDate = new DateTime(2023, 2, 27, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5620),
                            Name = "Item1",
                            Notes = "high priority",
                            Status = 0,
                            ToDoListId = new Guid("1c4b2224-996e-42b7-9507-c74d0e555d9d")
                        },
                        new
                        {
                            ToDoItemId = new Guid("47d21314-6489-4bd4-9b81-cbf433c585f4"),
                            CreatedDate = new DateTime(2023, 2, 26, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5635),
                            Description = "second item",
                            DueDate = new DateTime(2023, 3, 5, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5634),
                            Name = "Item2",
                            Notes = "low priority",
                            Status = 0,
                            ToDoListId = new Guid("1c4b2224-996e-42b7-9507-c74d0e555d9d")
                        },
                        new
                        {
                            ToDoItemId = new Guid("298b4d1d-a6b4-4d9d-a8ef-d1ee66327083"),
                            CreatedDate = new DateTime(2023, 2, 26, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5638),
                            Description = "first item",
                            DueDate = new DateTime(2023, 3, 1, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5637),
                            Name = "Item1",
                            Notes = "high priority",
                            Status = 0,
                            ToDoListId = new Guid("b42cf5f2-ff2d-4242-a3ea-18fe532322dc")
                        },
                        new
                        {
                            ToDoItemId = new Guid("b526968a-a7e8-4630-b811-0a032528f8f0"),
                            CreatedDate = new DateTime(2023, 2, 26, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5640),
                            Description = "first item",
                            DueDate = new DateTime(2023, 3, 3, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5640),
                            Name = "First user item",
                            Notes = "high priority",
                            Status = 0,
                            ToDoListId = new Guid("7c607b0b-de07-4e12-8f94-c2bcc59bd58b")
                        });
                });

            modelBuilder.Entity("ToDo.Core.Entities.ToDoList", b =>
                {
                    b.Property<Guid>("ToDoListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HiddenFinishedItems")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Visibility")
                        .HasColumnType("bit");

                    b.HasKey("ToDoListId");

                    b.HasIndex("UserId");

                    b.ToTable("ToDoLists");

                    b.HasData(
                        new
                        {
                            ToDoListId = new Guid("1c4b2224-996e-42b7-9507-c74d0e555d9d"),
                            HiddenFinishedItems = false,
                            Name = "Admin list1",
                            UserId = new Guid("7aa75f54-70fb-4732-8f16-d95e39f7a5ff"),
                            Visibility = true
                        },
                        new
                        {
                            ToDoListId = new Guid("b42cf5f2-ff2d-4242-a3ea-18fe532322dc"),
                            HiddenFinishedItems = false,
                            Name = "Admin list2",
                            UserId = new Guid("7aa75f54-70fb-4732-8f16-d95e39f7a5ff"),
                            Visibility = true
                        },
                        new
                        {
                            ToDoListId = new Guid("7c607b0b-de07-4e12-8f94-c2bcc59bd58b"),
                            HiddenFinishedItems = false,
                            Name = "test list1",
                            UserId = new Guid("7aa75f54-70fb-4732-8f16-d95e39f7a5ff"),
                            Visibility = true
                        });
                });

            modelBuilder.Entity("ToDo.Core.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("7aa75f54-70fb-4732-8f16-d95e39f7a5ff"),
                            Password = "AQAAAAEAACcQAAAAELb8RYqJdzn7PLBd+LYUfJn41mOC14H7ygPPLYW0R5eQxEoMVo3ztNlSNSaZ+Kcl7w==",
                            Username = "admin"
                        },
                        new
                        {
                            UserId = new Guid("20a772cb-4f2c-4d59-9f12-ee961def6846"),
                            Password = "AQAAAAEAACcQAAAAEIPSI/aIdKAHjhvblFJggL1gRyOx5vHTHgGtovz03EPuOfgZ8Tm7o4vWgXk9YWyHKw==",
                            Username = "test"
                        });
                });

            modelBuilder.Entity("ToDo.Core.Entities.ToDoItem", b =>
                {
                    b.HasOne("ToDo.Core.Entities.ToDoList", "ToDoList")
                        .WithMany("Items")
                        .HasForeignKey("ToDoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDoList");
                });

            modelBuilder.Entity("ToDo.Core.Entities.ToDoList", b =>
                {
                    b.HasOne("ToDo.Core.Entities.User", "User")
                        .WithMany("ToDoLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDo.Core.Entities.ToDoList", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ToDo.Core.Entities.User", b =>
                {
                    b.Navigation("ToDoLists");
                });
#pragma warning restore 612, 618
        }
    }
}
