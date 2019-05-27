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
    public partial class EditarRecord : System.Web.UI.Page
    {

        private static ControladorDAORecord controladorDatosGrilla;
        private static ControladorDAORecord controladorDatosGrilla2;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "";
            cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
            System.Diagnostics.Debug.WriteLine("Estado cadena conexion: " + cadenaConexion);
            controladorDatosGrilla = new ControladorDAORecord(cadenaConexion);
            controladorDatosGrilla2 = new ControladorDAORecord(cadenaConexion);

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
            DataTable tabla1 = null;
            DataTable tabla2 = null;
            tabla1 = controladorDatosGrilla2.rellenarDatosDataSource2();
            tabla2 = controladorDatosGrilla.rellenarDatosDataSource();
            this.stateList.DataSource = tabla1;
            this.stateList.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool seActualizo = controladorDatosGrilla.modificarRegistro(this.username.Text,this.stateList.SelectedValue,int.Parse(Request.QueryString["id"]));
                Response.Redirect("ModificarRecord.aspx");
        }
    }
}