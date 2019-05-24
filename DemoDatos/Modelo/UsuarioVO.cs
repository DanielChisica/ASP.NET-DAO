using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDatos.Modelo
{
    public class UsuarioVO
    {
        private int idUuario;
        private string nombres;
        private string apellidos;
        private string username;
        private DateTime fecha_ingreso;
        private string rol;

        public int IdUuario { get => idUuario; set => idUuario = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime Fecha_ingreso { get => fecha_ingreso; set => fecha_ingreso = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Username { get => username; set => username = value; }
    }
}