﻿// <auto-generated />
using Biblioteca.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca.Infraestructure.Migrations
{
    [DbContext(typeof(BibliotecaDbContext))]
    partial class BibliotecaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Biblioteca.Domain.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CiudadAutor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreAutor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PaisAutor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AutorId");

                    b.ToTable("Autors");
                });

            modelBuilder.Entity("Biblioteca.Domain.Editorial", b =>
                {
                    b.Property<int>("EditoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CiudadEditorial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreEditorial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PaisEditorial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EditoriaId");

                    b.ToTable("Editorials");
                });

            modelBuilder.Entity("Biblioteca.Domain.Libro", b =>
                {
                    b.Property<int>("LibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AutorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionLibro")
                        .HasColumnType("TEXT");

                    b.Property<int>("EditoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EditorialLibroEditoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TituloLibro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LibroId");

                    b.HasIndex("AutorId");

                    b.HasIndex("EditorialLibroEditoriaId");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Biblioteca.Domain.Libro", b =>
                {
                    b.HasOne("Biblioteca.Domain.Autor", "AutorLibro")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Editorial", "EditorialLibro")
                        .WithMany()
                        .HasForeignKey("EditorialLibroEditoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutorLibro");

                    b.Navigation("EditorialLibro");
                });
#pragma warning restore 612, 618
        }
    }
}