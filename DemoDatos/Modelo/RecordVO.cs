using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDatos.Modelo
{
    public class RecordVO
    {
        private string nombre;
        private int idEstado;
        private string name;

        public string Nombre { get => nombre; set => nombre = value; }
        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string Name { get => name; set => name = value; }
    }
}