using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoDatos.Modelo;
using System.Data;

namespace DemoDatos.crudtabla
{
    public partial class ConsultarRecords : System.Web.UI.Page
    {
        //*********************************************
        //*********************************************
        //*********************************************
        //*********************************************
        //*********************************************
        //*********************************************
        private static ControladorDAORecord controladorDatosGrilla;
        //*********************************************
        //*********************************************
        //*********************************************
        //Método para cargar los datos de la base en la grilla por
        //primera vez
        protected void Page_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "";
            cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
            System.Diagnostics.Debug.WriteLine("Estado cadena conexion: " + cadenaConexion);
            controladorDatosGrilla = new ControladorDAORecord(cadenaConexion);
            System.Diagnostics.Debug.WriteLine("**************************************");
            System.Diagnostics.Debug.WriteLine("Controlador de acceso datos ADO.NET: " + controladorDatosGrilla.ToString());
            System.Diagnostics.Debug.WriteLine("**************************************");

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
            this.tablaDatosRecords.DataSource = tabla;
            this.tablaDatosRecords.DataBind();
        }
        //*********************************************
        //*********************************************
        //*********************************************
        protected void tablaDatosRecords_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            this.tablaDatosRecords.EditIndex = -1;

            TextBox name = this.tablaDatosRecords.Rows[e.RowIndex].FindControl("Name") as TextBox;
            //Antes era un campo de texto
            //TextBox state = this.tablaDatosRecords.Rows[e.RowIndex].FindControl("State") as TextBox;

            //Combobox para el ítem del departamento escogido por el usuario
            DropDownList state = this.tablaDatosRecords.Rows[e.RowIndex].FindControl("state") as DropDownList;

            int id = Int32.Parse(tablaDatosRecords.DataKeys[e.RowIndex].Values["id"].ToString());

            //bool seActualizo = controladorDatosGrilla.modificarRegistro(name.Text, state.Text, id);
            bool seActualizo = controladorDatosGrilla.modificarRegistro(name.Text, state.SelectedValue, id);

            refrescarDatos();

            //Sincronización con los eventos JavaScript
            string radconfirmscript =
            "<script languaje='javascript'>function f() {  actualizarRegistro('" 
            + name.Text + 
            "'); Sys.Application.remove_load(f); }; Sys.Application.add_load(f);</script>";

            Page.ClientScript.RegisterStartupScript
            (this.GetType(), "radconfirm", radconfirmscript);
        }

        protected void tablaDatosRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Int32.Parse(tablaDatosRecords.DataKeys[e.RowIndex].Values["id"].ToString());
            RecordVO registroAEliminar = controladorDatosGrilla.consultarRegistroRecord(id.ToString());

            bool seElimino = controladorDatosGrilla.eliminarRegistro(id);
            System.Diagnostics.Debug.WriteLine("SE BORRO EL REGISTRO DEL CONTACTO: " + seElimino);
            refrescarDatos();

            string radconfirmscript =
            "<script languaje='javascript'>function f() {  actualizarRegistroEliminacion('"
            + registroAEliminar.Nombre +
            "'); Sys.Application.remove_load(f); }; Sys.Application.add_load(f);</script>";

            Page.ClientScript.RegisterStartupScript
            (this.GetType(), "radconfirm", radconfirmscript);

        }

        protected void tablaDatosRecords_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.tablaDatosRecords.EditIndex = -1;
            refrescarDatos();
        }

        protected void tablaDatosRecords_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.tablaDatosRecords.EditIndex = e.NewEditIndex;
            System.Diagnostics.Debug.WriteLine("Indice de la fila a editar: " + this.tablaDatosRecords.EditIndex);
            refrescarDatos();
        }

        protected void enlaceRetorno_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
    }

}