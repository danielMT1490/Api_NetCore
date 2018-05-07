using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentCommon.Logic.Model
{
    public class Alumno
    {
        #region Propiedades
        public Guid Guid { get; set; }
        //declaramos primary key para que lo lea entity por linq
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public DateTime Nacimiento { get; set; }
        public DateTime Registro { get; set; }
        #endregion

        #region Constructores

        public Alumno()
        {
            this.Guid = Guid.NewGuid();
        }

        public Alumno(Guid guid, int Id, string dni, string nombre, string apellidos, int edad, DateTime nacimiento, DateTime registro)
        {
            this.Guid = guid;
            this.Id = Id;
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.Nacimiento = nacimiento;
            this.Registro = registro;
        }
        #endregion

        #region ToStrings

        public override string ToString()
        {
            StringBuilder Sbt = new StringBuilder();
            string studentserializer = String.Format($"{Guid},{Id},{Dni},{Nombre},{Apellidos},{Edad},{Nacimiento.ToShortDateString()},{Registro.ToShortDateString()}");
            return Sbt.Insert(0, studentserializer, 1).ToString();
        }

        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            return obj is Alumno student &&
                   Id == student.Id &&
                   Nombre == student.Nombre &&
                   Apellidos == student.Apellidos &&
                   Dni == student.Dni && Guid == student.Guid
                   && student.Edad == Edad;
        }

        public override int GetHashCode()
        {
            var hashCode = -818402288;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Guid.ToString());
            return hashCode;
        }
        #endregion
    }
}

