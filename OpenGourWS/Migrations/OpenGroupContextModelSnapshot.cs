﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenGourWS.Modelo;

namespace OpenGourWS.Migrations
{
    [DbContext(typeof(OpenGroupContext))]
    partial class OpenGroupContextModelSnapshot : ModelSnapshot
    {
        public Controllers.CategoriumsController CategoriumsController
        {
            get => default;
            set
            {
            }
        }

        public Controllers.ProductoesController ProductoesController
        {
            get => default;
            set
            {
            }
        }

        public Controllers.PedidoController PedidoController
        {
            get => default;
            set
            {
            }
        }

        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenGourWS.Modelo.Categorium", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Categoria_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("CategoriaId")
                        .HasName("PK__Categori__C929A16A82C0AF24");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("OpenGourWS.Modelo.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnName("Cliente_Id")
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Mail")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("OpenGourWS.Modelo.Helper.PedidoResponse", b =>
                {
                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<string>("cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pedido_Id")
                        .HasColumnType("int");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.Property<string>("producto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.ToTable("PedidoResponses");
                });

            modelBuilder.Entity("OpenGourWS.Modelo.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Pedido_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Activo")
                        .HasColumnType("bit");

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("FkClienteId")
                        .HasColumnName("Fk_Cliente_Id")
                        .HasColumnType("int");

                    b.Property<int?>("FkProductoId")
                        .HasColumnName("Fk_Producto_Id")
                        .HasColumnType("int");

                    b.Property<double?>("Precio")
                        .HasColumnType("float");

                    b.HasKey("PedidoId");

                    b.HasIndex("FkClienteId");

                    b.HasIndex("FkProductoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("OpenGourWS.Modelo.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Producto_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FkCategoriaId")
                        .HasColumnName("Fk_Categoria_Id")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<double?>("Precio")
                        .HasColumnType("float");

                    b.Property<int?>("Stock")
                        .HasColumnName("stock")
                        .HasColumnType("int");

                    b.HasKey("ProductoId");

                    b.HasIndex("FkCategoriaId")
                        .IsUnique()
                        .HasFilter("[Fk_Categoria_Id] IS NOT NULL");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("OpenGourWS.Modelo.Pedido", b =>
                {
                    b.HasOne("OpenGourWS.Modelo.Cliente", "FkCliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("FkClienteId")
                        .HasConstraintName("FK__Pedido__Fk_Clien__2C3393D0");

                    b.HasOne("OpenGourWS.Modelo.Producto", "FkProducto")
                        .WithMany("Pedidos")
                        .HasForeignKey("FkProductoId")
                        .HasConstraintName("FK__Pedido__Fk_Produ__2D27B809");
                });

            modelBuilder.Entity("OpenGourWS.Modelo.Producto", b =>
                {
                    b.HasOne("OpenGourWS.Modelo.Categorium", "FkCategoria")
                        .WithOne("Producto")
                        .HasForeignKey("OpenGourWS.Modelo.Producto", "FkCategoriaId")
                        .HasConstraintName("FK__Producto__Fk_Cat__29572725");
                });
#pragma warning restore 612, 618
        }
    }
}
