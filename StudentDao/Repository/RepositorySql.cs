using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    return SelectById(entity.Id);
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
                    var result = new List<Alumno>();
                    foreach (var student in ctxAlumno.Alumnos)
                    {
                        result.Add(student);
                    }
                    return result;
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
    }
}
