using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using OpenGourWS.Modelo.Helper;

#nullable disable

namespace OpenGourWS.Modelo
{
    public partial class OpenGroupContext : DbContext
    {
        public OpenGroupContext()
        {
        }

        public OpenGroupContext(DbContextOptions<OpenGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<PedidoResponse> PedidoResponses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MQBAK55; Initial catalog=OpenGroup; user id=sa; password=123456");
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<PedidoResponse>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.pedido_Id);
                entity.Property(e => e.total);
                entity.Property(e => e.cliente);
                entity.Property(e => e.producto);
                entity.Property(e => e.precio);
                entity.Property(e => e.cantidad);
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__C929A16A82C0AF24");

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_Id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("Cliente_Id");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.Property(e => e.PedidoId).HasColumnName("Pedido_Id");

                entity.Property(e => e.FkClienteId).HasColumnName("Fk_Cliente_Id");

                entity.Property(e => e.FkProductoId).HasColumnName("Fk_Producto_Id");

                entity.HasOne(d => d.FkCliente)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.FkClienteId)
                    .HasConstraintName("FK__Pedido__Fk_Clien__2C3393D0");

                entity.HasOne(d => d.FkProducto)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.FkProductoId)
                    .HasConstraintName("FK__Pedido__Fk_Produ__2D27B809");
                //entity.Property<bool>("isDeleted");
                //entity.HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                //entity.HasIndex(e => e.FkCategoriaId, "UQ__Producto__562717FA7D46EAC2")
                  //  .IsUnique();

                entity.Property(e => e.ProductoId).HasColumnName("Producto_Id");

                entity.Property(e => e.FkCategoriaId).HasColumnName("Fk_Categoria_Id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.FkCategoria)
                    .WithOne(p => p.Producto)
                    .HasForeignKey<Producto>(d => d.FkCategoriaId)
                    .HasConstraintName("FK__Producto__Fk_Cat__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
