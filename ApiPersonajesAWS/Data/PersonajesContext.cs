using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ApiPersonajesAWS.Data
{
    public class PersonajesContext:DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options)
            :base(options)
        {

        }

        public DbSet<Personaje> Personajes { get; set; }
    }
}
