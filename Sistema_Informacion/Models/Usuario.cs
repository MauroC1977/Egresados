using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Informacion.Models
{
    public class Usuario
    {
        public int ID { get; set; }

        
        public string Documento { get; set; }

        
        public string TipoDocumento { get; set; }

       
        public string Nombre { get; set; }

       
        public string Celular { get; set; }

        
        public string Email { get; set; }

        
        public string Genero { get; set; }

        public int Aprendiz { get; set; }

        public int Egresado { get; set; }

        
        public string AreaFormacion { get; set; }

        
        public DateTime FechaEgresado { get; set; }

        
        public string Direccion { get; set; }

        
        public string Barrio { get; set; }

        
        public string Ciudad { get; set; }

        
        public string Departamento { get; set; }

        
        public DateTime FechaRegistro { get; set; }

    }
}