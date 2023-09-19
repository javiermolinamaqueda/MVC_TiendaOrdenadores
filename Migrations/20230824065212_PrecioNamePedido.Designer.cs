﻿// <auto-generated />
using System;
using MVC_ComponenteCodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_ComponenteCodeFirst.Migrations
{
    [DbContext(typeof(TiendaContext))]
    [Migration("20230824065212_PrecioNamePedido")]
    partial class PrecioNamePedido
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("MVC_ComponenteCodeFirst.Models.Componente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Almacenamiento")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cores")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrdenadorId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoComponente")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrdenadorId");

                    b.ToTable("Componentes");
                });

            modelBuilder.Entity("MVC_ComponenteCodeFirst.Models.Ordenador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Ordenadores");
                });

            modelBuilder.Entity("MVC_ComponenteCodeFirst.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("MVC_ComponenteCodeFirst.Models.Componente", b =>
                {
                    b.HasOne("MVC_ComponenteCodeFirst.Models.Ordenador", "Ordenador")
                        .WithMany("Componentes")
                        .HasForeignKey("OrdenadorId");

                    b.Navigation("Ordenador");
                });

            modelBuilder.Entity("MVC_ComponenteCodeFirst.Models.Ordenador", b =>
                {
                    b.HasOne("MVC_ComponenteCodeFirst.Models.Pedido", "Pedido")
                        .WithMany("Ordenadores")
                        .HasForeignKey("PedidoId");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("MVC_ComponenteCodeFirst.Models.Ordenador", b =>
                {
                    b.Navigation("Componentes");
                });

            modelBuilder.Entity("MVC_ComponenteCodeFirst.Models.Pedido", b =>
                {
                    b.Navigation("Ordenadores");
                });
#pragma warning restore 612, 618
        }
    }
}
