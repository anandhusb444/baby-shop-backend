﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using baby_shop_backend.Context;

#nullable disable

namespace baby_shop_backend.Migrations
{
    [DbContext(typeof(DbContext_Main))]
    partial class DbContext_MainModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("baby_shop_backend.Models.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("CartTable");
                });

            modelBuilder.Entity("baby_shop_backend.Models.CartItems", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cartId");

                    b.HasIndex("productId");

                    b.ToTable("CartItemsTable");
                });

            modelBuilder.Entity("baby_shop_backend.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("CategoriesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CategoriesTable");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CategoriesName = "All"
                        },
                        new
                        {
                            id = 2,
                            CategoriesName = "Toys"
                        },
                        new
                        {
                            id = 3,
                            CategoriesName = "Foods"
                        },
                        new
                        {
                            id = 4,
                            CategoriesName = "Clothing"
                        });
                });

            modelBuilder.Entity("baby_shop_backend.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("userAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("OrderTable");
                });

            modelBuilder.Entity("baby_shop_backend.Models.OrderItems", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("orderId");

                    b.HasIndex("productId");

                    b.ToTable("OrderItemsTable");
                });

            modelBuilder.Entity("baby_shop_backend.Models.Products", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("ProductsTable");
                });

            modelBuilder.Entity("baby_shop_backend.Models.UserModel.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isStatus")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            id = 3,
                            Role = "Admin",
                            isStatus = true,
                            password = "$2a$11$sUxEZb8lk/09OqzjNKdo.eN3wLgqSt5RqJRAGjh.xjolC2S3cXAa.",
                            userEmail = "admin@.com",
                            userName = "Admin"
                        });
                });

            modelBuilder.Entity("baby_shop_backend.Models.WhishList", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.HasIndex("productId");

                    b.ToTable("WhishListTable");
                });

            modelBuilder.Entity("baby_shop_backend.Models.Cart", b =>
                {
                    b.HasOne("baby_shop_backend.Models.UserModel.User", "User")
                        .WithOne("cart")
                        .HasForeignKey("baby_shop_backend.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("baby_shop_backend.Models.CartItems", b =>
                {
                    b.HasOne("baby_shop_backend.Models.Cart", "cart")
                        .WithMany("cartItems")
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("baby_shop_backend.Models.Products", "product")
                        .WithMany("cartItems")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cart");

                    b.Navigation("product");
                });

            modelBuilder.Entity("baby_shop_backend.Models.Order", b =>
                {
                    b.HasOne("baby_shop_backend.Models.UserModel.User", "User")
                        .WithMany("order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("baby_shop_backend.Models.OrderItems", b =>
                {
                    b.HasOne("baby_shop_backend.Models.Order", "order")
                        .WithMany("orderItems")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("baby_shop_backend.Models.Products", "products")
                        .WithMany("orderitems")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("products");
                });

            modelBuilder.Entity("baby_shop_backend.Models.Products", b =>
                {
                    b.HasOne("baby_shop_backend.Models.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("baby_shop_backend.Models.WhishList", b =>
                {
                    b.HasOne("baby_shop_backend.Models.UserModel.User", "User")
                        .WithMany("whishLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("baby_shop_backend.Models.Products", "Products")
                        .WithMany("whishlist")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("User");
                });

            modelBuilder.Entity("baby_shop_backend.Models.Cart", b =>
                {
                    b.Navigation("cartItems");
                });

            modelBuilder.Entity("baby_shop_backend.Models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("baby_shop_backend.Models.Order", b =>
                {
                    b.Navigation("orderItems");
                });

            modelBuilder.Entity("baby_shop_backend.Models.Products", b =>
                {
                    b.Navigation("cartItems");

                    b.Navigation("orderitems");

                    b.Navigation("whishlist");
                });

            modelBuilder.Entity("baby_shop_backend.Models.UserModel.User", b =>
                {
                    b.Navigation("cart")
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("whishLists");
                });
#pragma warning restore 612, 618
        }
    }
}
