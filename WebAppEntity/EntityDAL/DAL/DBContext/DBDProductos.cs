using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityModel.Model;
using EntityDTO.DTO;

namespace EntityDAL.DAL.DBContext
{
    public class DBDProductos:DbContext
    {
        public DBDProductos() : base(new DbContextOptions<DBDProductos>()) { }
        public DBDProductos(DbContextOptions<DBDProductos> options) : base(options) { }

        public DbSet<ProductoDto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define la clave primaria
            modelBuilder.Entity<ProductoDto>()
                .HasKey(p => p.ProductoId); // Define Id como la clave primaria

            // Define el tipo de columna para la propiedad Precio
            modelBuilder.Entity<ProductoDto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)"); // Ajusta la precisión y la escala según sea necesario
        }

      


    }
}
