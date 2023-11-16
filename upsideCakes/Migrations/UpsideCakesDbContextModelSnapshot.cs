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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Cardapio");
                });

            modelBuilder.Entity("upsideCakes.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("dataNasc")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("upsideCakes.Models.Filial", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cep")
                        .HasColumnType("TEXT");

                    b.Property<string>("cidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("rua")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Filial");
                });

            modelBuilder.Entity("upsideCakes.Models.Funcionario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("dataNasc")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("login")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("upsideCakes.Models.Gerente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("dataNasc")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("login")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Gerente");
                });

            modelBuilder.Entity("upsideCakes.Models.Pagamento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("data")
                        .HasColumnType("TEXT");

                    b.Property<string>("formaDePagamento")
                        .HasColumnType("TEXT");

                    b.Property<int>("idCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("idPedido")
                        .HasColumnType("INTEGER");

                    b.Property<float>("valor")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.HasIndex("idCliente");

                    b.HasIndex("idPedido");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("upsideCakes.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("dataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("funcionarioID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("gerenteID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("qtde")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("upsideCakes.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Cardapioid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("categoria")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .HasColumnType("TEXT");

                    b.Property<double>("preco")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.HasIndex("Cardapioid");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("upsideCakes.Models.Pagamento", b =>
                {
                    b.HasOne("upsideCakes.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("idCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("upsideCakes.Models.Pedido", "pedido")
                        .WithMany()
                        .HasForeignKey("idPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("upsideCakes.Models.Produto", b =>
                {
                    b.HasOne("upsideCakes.Models.Cardapio", null)
                        .WithMany("itens")
                        .HasForeignKey("Cardapioid");
                });

            modelBuilder.Entity("upsideCakes.Models.Cardapio", b =>
                {
                    b.Navigation("itens");
                });
#pragma warning restore 612, 618
        }
    }
}
