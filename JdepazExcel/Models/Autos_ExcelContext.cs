using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JdepazExcel.Models
{
    public partial class Autos_ExcelContext : DbContext
    {
        public Autos_ExcelContext()
        {
        }

        public Autos_ExcelContext(DbContextOptions<Autos_ExcelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<MarcasEmpresa> MarcasEmpresa { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sucursales> Sucursales { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-F2HN63L;Database=Autos_Excel;User Id=sa; Password=123456");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpresa)
                    .HasName("PK__Empresas__1245D0BF81FDB347");

                entity.Property(e => e.CodigoEmpresa)
                    .HasColumnName("Codigo_Empresa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasColumnName("Nombre_Empresa")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Marcas>(entity =>
            {
                entity.HasKey(e => e.CodigoMarca)
                    .HasName("PK__Marcas__0B3CE6946061A993");

                entity.Property(e => e.CodigoMarca)
                    .HasColumnName("Codigo_Marca")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Logo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMarca)
                    .IsRequired()
                    .HasColumnName("Nombre_Marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MarcasEmpresa>(entity =>
            {
                entity.ToTable("Marcas_Empresa");

                entity.Property(e => e.CodigoEmpresa)
                    .HasColumnName("Codigo_Empresa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoMarca)
                    .HasColumnName("Codigo_Marca")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSucursal)
                    .HasColumnName("Codigo_Sucursal")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.MarcasEmpresa)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .HasConstraintName("FK_Empresa");

                entity.HasOne(d => d.CodigoMarcaNavigation)
                    .WithMany(p => p.MarcasEmpresa)
                    .HasForeignKey(d => d.CodigoMarca)
                    .HasConstraintName("FK_Marca");

                entity.HasOne(d => d.CodigoSucursalNavigation)
                    .WithMany(p => p.MarcasEmpresa)
                    .HasForeignKey(d => d.CodigoSucursal)
                    .HasConstraintName("FK_Sucursales");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.CodigoRol)
                    .HasName("PK__Roles__DB4EB5873239FAF2");

                entity.Property(e => e.CodigoRol)
                    .HasColumnName("Codigo_Rol")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DetallePrivilegios)
                    .HasColumnName("Detalle_Privilegios")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasColumnName("Nombre_rol")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursales>(entity =>
            {
                entity.HasKey(e => e.CodigoSucursal)
                    .HasName("PK__Sucursal__89AA76DC9ED6CF89");

                entity.Property(e => e.CodigoSucursal)
                    .HasColumnName("Codigo_Sucursal")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NombreSucursal)
                    .IsRequired()
                    .HasColumnName("Nombre_Sucursal")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Usuarios__1788CC4C1D6108E6");

                entity.HasIndex(e => e.EmailUser)
                    .HasName("UQ__Usuarios__E3E6855C841AAF9D")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Usuarios__F3DBC57220C2067D")
                    .IsUnique();

                entity.Property(e => e.EmailUser)
                    .IsRequired()
                    .HasColumnName("email_user")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FnacUser)
                    .HasColumnName("fnac_user")
                    .HasColumnType("date");

                entity.Property(e => e.NombreUser)
                    .IsRequired()
                    .HasColumnName("nombre_user")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassUser)
                    .IsRequired()
                    .HasColumnName("pass_user")
                    .HasMaxLength(500);

                entity.Property(e => e.TelefonoUser).HasColumnName("telefono_user");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
