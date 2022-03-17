﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCompra.Infra.Data;

namespace SistemaCompra.API.Migrations
{
    [DbContext(typeof(SistemaCompraContext))]
    [Migration("20220317184438_ItemSolicitacao")]
    partial class ItemSolicitacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaCompra.Domain.ProdutoAggregate.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.Property<Guid>("SolicitacaoCompraId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SolicitacaoCompraId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SolicitacaoCompra");
                });

            modelBuilder.Entity("SistemaCompra.Domain.ProdutoAggregate.Produto", b =>
                {
                    b.OwnsOne("SistemaCompra.Domain.Core.Model.Money", "Preco", b1 =>
                        {
                            b1.Property<Guid>("ProdutoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("Preco")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.Item", b =>
                {
                    b.HasOne("SistemaCompra.Domain.ProdutoAggregate.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", null)
                        .WithMany("Itens")
                        .HasForeignKey("SolicitacaoCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", b =>
                {
                    b.OwnsOne("SistemaCompra.Domain.Core.Model.Money", "TotalGeral", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("TotalGeral")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.CondicaoPagamento", "CondicaoPagamento", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasColumnName("CondicaoPagamento")
                                .HasColumnType("int");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.NomeFornecedor", "NomeFornecedor", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .HasColumnName("NomeFornecedor")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.UsuarioSolicitante", "UsuarioSolicitante", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .HasColumnName("UsuarioSolicitante")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
