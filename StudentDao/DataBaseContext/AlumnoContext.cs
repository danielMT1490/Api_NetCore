using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StudentCommon.Logic.Model;
using StudentCommon.Logic;

namespace StudentDao.DataBaseContext
{
    public class AlumnoContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        
        public AlumnoContext() : base()
        {
            
        }
        //realciona un atabla de la bbdd con un modelo
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppGetConfiguration.GetConnectionString(GetType()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
