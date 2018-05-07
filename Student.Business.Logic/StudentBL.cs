using System;
using System.Collections.Generic;
using System.Text;
using StudentCommon.Logic.Log;
using StudentCommon.Logic.Model;
using StudentDao.Repository;

namespace Student.Business.Logic
{
    public class StudentBL : IBusiness
    {
        private readonly ILogger Log;
        private readonly IRepository repository;
        public StudentBL(ILogger log , IRepository repo)
        {
            this.Log = log;
            this.repository = repo;
        }
        public Alumno Create(Alumno entity)
        {
            try
            {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.Create(entity);
            }
            catch (Exception ex )
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
            
        }

        public void Delete(int id)
        {
            try
            {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                repository.Delete(id);
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
                return repository.GetAll();
            }
            catch (Exception ex)
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
                return repository.SelectById(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
            
        }
    }
}
