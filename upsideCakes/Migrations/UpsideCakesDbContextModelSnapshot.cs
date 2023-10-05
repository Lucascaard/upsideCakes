﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using upsideCakes.Data;

#nullable disable

namespace upsideCakes.Migrations
{
    [DbContext(typeof(UpsideCakesDbContext))]
    partial class UpsideCakesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("upsideCakes.Models.Cardapio", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("_id");

                    b.ToTable("Cardapio");
                });

            modelBuilder.Entity("upsideCakes.Models.Cliente", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("_dataNasc")
                        .HasColumnType("TEXT");

                    b.Property<string>("_email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("_endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("_nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("_telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("_id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("upsideCakes.Models.Funcionario", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("_cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("_dataNasc")
                        .HasColumnType("TEXT");

                    b.Property<string>("_email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("_endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("_login")
                        .HasColumnType("TEXT");

                    b.Property<string>("_nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("_senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("_telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("_id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("upsideCakes.Models.Gerente", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("_cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("_dataNasc")
                        .HasColumnType("TEXT");

                    b.Property<string>("_email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("_endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("_login")
                        .HasColumnType("TEXT");

                    b.Property<string>("_nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("_senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("_telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("_id");

                    b.ToTable("Gerente");
                });

            modelBuilder.Entity("upsideCakes.Models.ItemCardapio", b =>
                {
                    b.Property<string>("_nome")
                        .HasColumnType("TEXT");

                    b.Property<double>("_preco")
                        .HasColumnType("REAL");

                    b.HasKey("_nome");

                    b.ToTable("ItemCardapio");
                });

            modelBuilder.Entity("upsideCakes.Models.Pagamento", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("_data")
                        .HasColumnType("TEXT");

                    b.Property<string>("_formaDePagamento")
                        .HasColumnType("TEXT");

                    b.Property<float>("_valor")
                        .HasColumnType("REAL");

                    b.HasKey("_id");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("upsideCakes.Models.Pedido", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("_dataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("_funcionarioID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_gerenteID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_qtde")
                        .HasColumnType("INTEGER");

                    b.HasKey("_id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("upsideCakes.Models.Produto", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Pedido_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("_categoria")
                        .HasColumnType("TEXT");

                    b.Property<string>("_nome")
                        .HasColumnType("TEXT");

                    b.Property<double>("_preco")
                        .HasColumnType("REAL");

                    b.HasKey("_id");

                    b.HasIndex("Pedido_id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("upsideCakes.Models.Produto", b =>
                {
                    b.HasOne("upsideCakes.Models.Pedido", null)
                        .WithMany("_itens")
                        .HasForeignKey("Pedido_id");
                });

            modelBuilder.Entity("upsideCakes.Models.Pedido", b =>
                {
                    b.Navigation("_itens");
                });
#pragma warning restore 612, 618
        }
    }
}
