using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaIngressos.Domain.Entities;

namespace VendaIngressos.Infrastructure.Data
{
    public class VendaIngressosContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoDesconto> ProdutoDescontos { get; set; }

        public VendaIngressosContext(DbContextOptions<VendaIngressosContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para Produto
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.HasKey(p => p.Codigo);

                entity.Property(p => p.Codigo)
                    .ValueGeneratedOnAdd();

                entity.Property(p => p.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(p => p.Valor)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");

                entity.HasMany(p => p.Descontos)
                    .WithOne(d => d.Produto)
                    .HasForeignKey(d => d.ProdutoCodigo)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração para ProdutoDesconto
            modelBuilder.Entity<ProdutoDesconto>(entity =>
            {
                entity.ToTable("ProdutoDesconto");

                entity.HasKey(d => d.Codigo);

                entity.Property(d => d.Codigo)
                    .ValueGeneratedOnAdd();

                entity.Property(d => d.ProdutoCodigo)
                    .IsRequired();

                entity.Property(d => d.Quantidade)
                    .IsRequired()
                    .HasColumnType("int");

                entity.Property(d => d.Valor)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
