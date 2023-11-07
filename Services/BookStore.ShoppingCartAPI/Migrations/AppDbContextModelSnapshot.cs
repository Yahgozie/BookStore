﻿// <auto-generated />
using BookStore.ShoppingCartAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.ShoppingCartAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("BookStore.ShoppingCartAPI.Models.CartDetails", b =>
                {
                    b.Property<int>("CartDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CartHeaderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartDetailsId");

                    b.HasIndex("CartHeaderId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("BookStore.ShoppingCartAPI.Models.CartHeader", b =>
                {
                    b.Property<int>("CartHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("CartHeaderId");

                    b.ToTable("CartHeaders");
                });

            modelBuilder.Entity("BookStore.ShoppingCartAPI.Models.CartDetails", b =>
                {
                    b.HasOne("BookStore.ShoppingCartAPI.Models.CartHeader", "CartHeader")
                        .WithMany()
                        .HasForeignKey("CartHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartHeader");
                });
#pragma warning restore 612, 618
        }
    }
}
