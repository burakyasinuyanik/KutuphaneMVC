﻿// <auto-generated />
using Kutuphane.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kutuphane.Data.Migrations
{
    [DbContext(typeof(KutuphaneContext))]
    [Migration("20230819115432_kitapilişkilerivetabloeklendi")]
    partial class kitapilişkilerivetabloeklendi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KitapYayinEvi", b =>
                {
                    b.Property<int>("KitaplarId")
                        .HasColumnType("int");

                    b.Property<int>("YayinEvleriId")
                        .HasColumnType("int");

                    b.HasKey("KitaplarId", "YayinEvleriId");

                    b.HasIndex("YayinEvleriId");

                    b.ToTable("KitapYayinEvi");
                });

            modelBuilder.Entity("KitapYazar", b =>
                {
                    b.Property<int>("KitaplarId")
                        .HasColumnType("int");

                    b.Property<int>("YazarlarId")
                        .HasColumnType("int");

                    b.HasKey("KitaplarId", "YazarlarId");

                    b.HasIndex("YazarlarId");

                    b.ToTable("KitapYazar");
                });

            modelBuilder.Entity("Kutuphane.Models.Kitap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kitaplar");
                });

            modelBuilder.Entity("Kutuphane.Models.YayinEvi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("YayinEvleri");
                });

            modelBuilder.Entity("Kutuphane.Models.Yazar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ozgecmis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Yazarlar");
                });

            modelBuilder.Entity("YayinEviYazar", b =>
                {
                    b.Property<int>("YayinEvleriId")
                        .HasColumnType("int");

                    b.Property<int>("YazarlarId")
                        .HasColumnType("int");

                    b.HasKey("YayinEvleriId", "YazarlarId");

                    b.HasIndex("YazarlarId");

                    b.ToTable("YayinEviYazar");
                });

            modelBuilder.Entity("KitapYayinEvi", b =>
                {
                    b.HasOne("Kutuphane.Models.Kitap", null)
                        .WithMany()
                        .HasForeignKey("KitaplarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kutuphane.Models.YayinEvi", null)
                        .WithMany()
                        .HasForeignKey("YayinEvleriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KitapYazar", b =>
                {
                    b.HasOne("Kutuphane.Models.Kitap", null)
                        .WithMany()
                        .HasForeignKey("KitaplarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kutuphane.Models.Yazar", null)
                        .WithMany()
                        .HasForeignKey("YazarlarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YayinEviYazar", b =>
                {
                    b.HasOne("Kutuphane.Models.YayinEvi", null)
                        .WithMany()
                        .HasForeignKey("YayinEvleriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kutuphane.Models.Yazar", null)
                        .WithMany()
                        .HasForeignKey("YazarlarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
