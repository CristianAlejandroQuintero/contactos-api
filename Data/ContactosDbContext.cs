using Microsoft.EntityFrameworkCore;
using ContactosApi.Models;

namespace ContactosApi.Data
{
    public class ContactosDbContext : DbContext
    {
        public ContactosDbContext(DbContextOptions<ContactosDbContext> options) : base(options) { }

        public DbSet<Contacto> Contactos { get; set; }

     
        public void InicializarDatos()
        {
            if (!Contactos.Any())
            {
                Contactos.AddRange(new[]
                {
                    new Contacto { Nombre = "Ana Gómez", Telefono = "3001112233", Email = "ana@example.com" },
                    new Contacto { Nombre = "Luis Torres", Telefono = "3012223344", Email = "luis@example.com" },
                    new Contacto { Nombre = "Carlos Ruiz", Telefono = "3023334455", Email = "carlos@example.com" }
                });

                SaveChanges();
            }
        }
    }
}