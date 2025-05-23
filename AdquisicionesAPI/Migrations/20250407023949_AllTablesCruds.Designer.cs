﻿// <auto-generated />
using System;
using AdquisicionesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdquisicionesAPI.Migrations
{
    [DbContext(typeof(AdquisicionContext))]
    [Migration("20250407023949_AllTablesCruds")]
    partial class AllTablesCruds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdquisicionesAPI.Models.Adquisicion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Documentacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAdquisicion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaDesactivacion")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Presupuesto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProveedorID")
                        .HasColumnType("int");

                    b.Property<string>("TipoBienServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadID")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ProveedorID");

                    b.HasIndex("UnidadID");

                    b.ToTable("Adquisiciones");
                });

            modelBuilder.Entity("AdquisicionesAPI.Models.DocumentoAdquisicion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AdquisicionID")
                        .HasColumnType("int");

                    b.Property<string>("Archivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDocumento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AdquisicionID");

                    b.ToTable("DocumentosAdquisicion");
                });

            modelBuilder.Entity("AdquisicionesAPI.Models.HistorialAdquisicion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AdquisicionID")
                        .HasColumnType("int");

                    b.Property<string>("CamposModificados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AdquisicionID");

                    b.ToTable("HistorialAdquisiciones");
                });

            modelBuilder.Entity("AdquisicionesAPI.Models.Proveedor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("InformacionContacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("AdquisicionesAPI.Models.UnidadAdministrativa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NombreUnidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UnidadesAdministrativas");
                });

            modelBuilder.Entity("AdquisicionesAPI.Models.Adquisicion", b =>
                {
                    b.HasOne("AdquisicionesAPI.Models.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdquisicionesAPI.Models.UnidadAdministrativa", "UnidadAdministrativa")
                        .WithMany()
                        .HasForeignKey("UnidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");

                    b.Navigation("UnidadAdministrativa");
                });

            modelBuilder.Entity("AdquisicionesAPI.Models.DocumentoAdquisicion", b =>
                {
                    b.HasOne("AdquisicionesAPI.Models.Adquisicion", "Adquisicion")
                        .WithMany("Documentos")
                        .HasForeignKey("AdquisicionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adquisicion");
                });

            modelBuilder.Entity("AdquisicionesAPI.Models.HistorialAdquisicion", b =>
                {
                    b.HasOne("AdquisicionesAPI.Models.Adquisicion", "Adquisicion")
                        .WithMany("Historial")
                        .HasForeignKey("AdquisicionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adquisicion");
                });

            modelBuilder.Entity("AdquisicionesAPI.Models.Adquisicion", b =>
                {
                    b.Navigation("Documentos");

                    b.Navigation("Historial");
                });
#pragma warning restore 612, 618
        }
    }
}
