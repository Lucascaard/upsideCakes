﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using upsideCakes.Data;

#nullable disable

namespace upsideCakes.Migrations
{
    [DbContext(typeof(UpsideCakesDbContext))]
    [Migration("20230929170842_databaseCriado")]
    partial class databaseCriado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("upsideCakes.Models.Gerente", b =>
                {
                    b.Property<int>("_idGerente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_cpfGerente")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("_email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("_nomeGerente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("_telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("_idGerente");

                    b.HasIndex("_cpfGerente")
                        .IsUnique();

                    b.ToTable("Gerente");
                });

            modelBuilder.Entity("upsideCakes.Models.Pagamento", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("_data")
                        .HasColumnType("TEXT");

                    b.Property<string>("_formaDePagamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("_valor")
                        .HasColumnType("REAL");

                    b.HasKey("_id");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("upsideCakes.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("_preco")
                        .HasColumnType("REAL");

                    b.HasKey("Id")
                        .HasAnnotation("Sqlite:Autoincrement", true);

                    b.ToTable("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
