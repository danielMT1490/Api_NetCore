using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentCommon.Logic.Log;
using StudentCommon.Logic.Model;
using StudentDao.DataBaseContext;
using StudentDao.Repository;
using System;
using System.Collections.Generic;

namespace RepositoryTest
{
    [TestClass]
    public class DaoTest
    {
        private  IRepository repositrory;
       

        [TestInitialize]
        public void Init()
        {
            this.repositrory = new RepositorySql(new Log4netAdapter(), new AlumnoContext());
        }

        public static IEnumerable<object[]> StudentData()
        {
            yield return new object[] { new Alumno(Guid.NewGuid(), "45687654h", "Daniel", "Madrigal", 28, Convert.ToDateTime("24/06/1990"),Convert.ToDateTime( "05/09/2017")) };
            yield return new object[] { new Alumno(Guid.NewGuid(), "46546546h", "Rebeca", "Barreira", 29, Convert.ToDateTime("24/06/1989"),Convert.ToDateTime( "07/11/2016")) };
        }
        [DataTestMethod]
        [DynamicData(nameof(StudentData), DynamicDataSourceType.Method)]
        public void SqlDaoTest(Alumno alumno)
        {

            var alumno_devuelto = repositrory.Create(alumno);

            Assert.IsTrue(alumno.Equals(alumno_devuelto));
            Assert.IsTrue(alumno.Id > 0);

        }

       
        [DataTestMethod]
        [DynamicData(nameof(StudentData), DynamicDataSourceType.Method)]
        public void GetAllTest(Alumno alumno)
        {
            repositrory.Create(alumno);
            repositrory = new RepositorySql(new Log4netAdapter(), new AlumnoContext());
            var alumnos = repositrory.GetAll();

            Assert.IsTrue(alumnos.Count>0);
            
        }

        [TestCleanup]
        public void Exit()
        {
            repositrory = new RepositorySql(new Log4netAdapter(), new AlumnoContext());
            repositrory.DeleteAll();
        }

    
    }
}
