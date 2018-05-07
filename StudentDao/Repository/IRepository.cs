using StudentCommon.Logic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentDao.Repository
{
    public interface IRepository
    {
        Alumno Create(Alumno entity);
        List<Alumno> GetAll();
        Alumno SelectById(int id);
        void Delete(int id);
    }
}
