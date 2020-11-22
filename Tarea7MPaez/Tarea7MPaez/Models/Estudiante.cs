using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace Tarea7MPaez.Models
{
    public class Estudiante 
    {
       

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(255)]
        public string nombre { get; set; }
        [MaxLength(255)]
        public string usuario { get; set; }
        [MaxLength(255)]
        public string password { get; set; }
    }
}