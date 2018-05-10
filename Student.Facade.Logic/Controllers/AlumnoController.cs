using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Business.Logic;
using StudentCommon.Logic.Log;
using StudentCommon.Logic.Model;

namespace Student.Facade.Logic.Controllers
{
    //[Route("api/[controller]")]
    public class AlumnoController : Controller
    {
        private readonly ILogger Log;
        private readonly IBusiness studentBL;

        public AlumnoController(ILogger log , IBusiness studentBL)
        {
            this.Log = log;
            this.studentBL = studentBL;
        }

        // GET api/Alumno
        [HttpGet("api/Alumno.{format}"),FormatFilter]
        public IActionResult GetAll()
        {
            return Ok(studentBL.GetAll());
        }

        // GET api/Alumno/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(studentBL.SelectById(id));
        }

        // POST api/Alumno
        [HttpPost]
        public IActionResult Create( [FromBody] Alumno entity)
        {
            return Ok(studentBL.Create(entity));
        }

     
        // DELETE api/Alumno/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            studentBL.Delete(id);
        }
    }
}
