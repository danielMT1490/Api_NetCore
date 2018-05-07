using StudentCommon.Logic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Business.Logic
{
    public interface IBusiness
    {
        Alumno Create(Alumno entity);
        List<Alumno> GetAll();
        Alumno SelectById(int id);
        void Delete(int id);
    }
}
