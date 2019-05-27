using DemoDatos.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoDatos.crudtabla
{
    public partial class ModificarRecord : System.Web.UI.Page
    {
        private static ControladorDAORecord controladorDatosGrilla;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "";
            cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
            System.Diagnostics.Debug.WriteLine("Estado cadena conexion: " + cadenaConexion);
            controladorDatosGrilla = new ControladorDAORecord(cadenaConexion);
            
            //Verificar que la data de la grilla se cargue únicamente en el primer llamado
            //a la página desde el menú
            if (!Page.IsPostBack)
            {
                //Hacemos el cargue de la inicialización del controlador
                //solo la primera vez
                System.Diagnostics.Debug.WriteLine("Entrando por primera vez a refrescar la data de la grilla");
                refrescarDatos();
            }
    

        }

        //*********************************************
        //*********************************************
        //*********************************************
        public void refrescarDatos()
        {
            DataTable tabla = null;
            tabla = controladorDatosGrilla.rellenarDatosDataSource();
            this.userList.DataSource = tabla;
            this.userList.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarRecord.aspx?id="+this.userList.SelectedValue);
        }
    }
}