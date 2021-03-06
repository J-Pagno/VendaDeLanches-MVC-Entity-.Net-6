// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendaDeLanches.Context;

#nullable disable

namespace VendaDeLanches.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VendaDeLanches.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("VendaDeLanches.Models.ShoppingCart", b =>
                {
                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartItemId")
                        .HasMaxLength(200)
                        .HasColumnType("int");

                    b.Property<int?>("SnackId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("SnackId");

                    b.ToTable("ShoppingCartItens");
                });

            modelBuilder.Entity("VendaDeLanches.Models.Snack", b =>
                {
                    b.Property<int>("SnackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SnackId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionDetailed")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImageThumnailURL")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPreferred")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SnackName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("SnackId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Snacks");
                });

            modelBuilder.Entity("VendaDeLanches.Models.ShoppingCart", b =>
                {
                    b.HasOne("VendaDeLanches.Models.Snack", "Snack")
                        .WithMany()
                        .HasForeignKey("SnackId");

                    b.Navigation("Snack");
                });

            modelBuilder.Entity("VendaDeLanches.Models.Snack", b =>
                {
                    b.HasOne("VendaDeLanches.Models.Category", "Category")
                        .WithMany("Snacks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("VendaDeLanches.Models.Category", b =>
                {
                    b.Navigation("Snacks");
                });
#pragma warning restore 612, 618
        }
    }
}
