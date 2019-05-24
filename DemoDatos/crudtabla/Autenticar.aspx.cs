using DemoDatos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoDatos.crudtabla
{
    public partial class Autenticar : System.Web.UI.Page
    {
        private static ControladorDAORecord controlador;
        private static UsuarioVO usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "";
            cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
            System.Diagnostics.Debug.WriteLine("Estado cadena conexion: " + cadenaConexion);
            controlador = new ControladorDAORecord(cadenaConexion);
            
            System.Diagnostics.Debug.WriteLine("Controlador de acceso datos ADO.NET: " + controlador.ToString());
            System.Diagnostics.Debug.WriteLine("**************************************");
        }

        protected void btn_Ingresar_Click(object sender, EventArgs e)
        {
            var x = controlador.Autenticar(txt_User.Text, txt_password.Text);
            if(x == true)
            {
                System.Diagnostics.Debug.WriteLine("Usuario ingreso correctamente");
                usuario = controlador.consultar(txt_User.Text);
                txt_DatosAtuenticacion.Text = " Bienvenido " + usuario.Nombres + " " + usuario.Apellidos + "- Nombre de usuario " + usuario.Username + " Ultimo inicio de sesion registrada " + usuario.Fecha_ingreso.Year +" - "+ usuario.Fecha_ingreso.Month + " - " + usuario.Fecha_ingreso.Day;
            }

        }

        
    }
}