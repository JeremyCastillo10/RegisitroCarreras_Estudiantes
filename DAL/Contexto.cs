using Microsoft.EntityFrameworkCore;
using RegistroCarreras.Entidades;
using RegistroEstudiantes.Entidades;

public class Contexto:DbContext
{
    
    public DbSet<Carreras> Carreras { get; set; } 
    public DbSet<Estudiantes> Estudiantes { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=DATA\Carreras.db");
        optionsBuilder.UseSqlite(@"Data Source=DATA\Estudiantes.db");
    }

}