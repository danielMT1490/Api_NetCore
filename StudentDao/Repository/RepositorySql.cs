using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentCommon.Logic.Log;
using StudentCommon.Logic.Model;
using StudentDao.DataBaseContext;

namespace StudentDao.Repository
{
    public class RepositorySql : IRepository
    {
        private readonly ILogger Log;
        private readonly AlumnoContext context;

        public RepositorySql(ILogger log , AlumnoContext context)
        {
            this.Log = log;
            this.context = context;
        }
     
        public Alumno Create(Alumno entity)
        {
            try
            {
                using (var ctxAlumno = this.context)
                {
                    ctxAlumno.Alumnos.Add(entity);
                    ctxAlumno.SaveChanges();
                    return entity;
                }
               
            }
            catch (Exception ex)
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
           
        }

        public void Delete(int id)
        {
            try
            {
                using (var ctxAlumno = this.context)
                {
                    var studentToDelete = ctxAlumno.Alumnos
                        .Find(id);
                    context.Alumnos.Remove(studentToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
           
        }

        public List<Alumno> GetAll()
        {
            try
            {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);

                using (var ctxAlumno = this.context)
                {
                    return ctxAlumno.Alumnos.ToList();
                }
            }
            catch (Exception ex )
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
            
        }

        public Alumno SelectById(int id)
        {
            try
            {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                using (var ctxAlumno = this.context)
                {
                    return ctxAlumno.Alumnos
                    .Find(id);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
           
        }

        public int DeleteAll()
        {
            using (var ctxAlumno = this.context)
            {
                return ctxAlumno.Database.ExecuteSqlCommand("TRUNCATE TABLE [Alumnos]");
            }
            
        }
    }
}
