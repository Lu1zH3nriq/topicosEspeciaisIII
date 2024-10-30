﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using aula13_MTMPostgreSQL;

#nullable disable

namespace aula13_manyToMany.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PessoaHabilidade", b =>
                {
                    b.Property<int>("HabilidadeId")
                        .HasColumnType("integer");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.HasKey("HabilidadeId", "PessoaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("PessoaHabilidade");
                });

            modelBuilder.Entity("aula13_MTMPostgreSQL.Habilidade", b =>
                {
                    b.Property<int>("HabilidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HabilidadeId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("HabilidadeId");

                    b.ToTable("Habilidades");
                });

            modelBuilder.Entity("aula13_MTMPostgreSQL.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PessoaId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("PessoaHabilidade", b =>
                {
                    b.HasOne("aula13_MTMPostgreSQL.Habilidade", null)
                        .WithMany()
                        .HasForeignKey("HabilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aula13_MTMPostgreSQL.Pessoa", null)
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
