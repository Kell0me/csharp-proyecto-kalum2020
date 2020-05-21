
using System.IO;
using Kalum2020v1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kalum2020v1.DataContext
{
    public class KalumDbContext : DbContext
    {
        public KalumDbContext(DbContextOptions<KalumDbContext> options) 
            :base(options){
            }

        public DbSet<Alumno> Alumnos {get;set;}

        public DbSet<AsignacionAlumno> AsignacionAlumnos {get;set;}

        public DbSet<Horario> Horarios {get;set;}

        public DbSet<CarreraTecnica> CarreraTecnicas {get;set;}

        public DbSet<Salon> Salones {get;set;}

        public DbSet<Instructor> Instructores {get;set;}

        public DbSet<Clase> Clases {get;set;}

        public DbSet<Religion> Religiones {get;set;}
        public DbSet<Rol> RolesApp {get;set;}

        public DbSet<Usuario> UsuariosApp {get;set;}

        public DbSet<UsuarioRol> Usuariosroles{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<UsuarioRol>()
                .HasKey(x => new {x.UsuarioId, x.RoleId});//para definir las llaves primarias con Fluent Api sin anotaciones
            }


        public KalumDbContext()
        {
            
        }


    }
}