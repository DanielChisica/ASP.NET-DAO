using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoDatos.Modelo;

namespace DemoDatos.crudtabla
{
    public partial class CrearRecord : System.Web.UI.Page
    {
        //********************************************************
        //********************************************************
        //********************************************************
        //********************************************************
        //********************************************************
        private static ControladorDAORecord controladorAccesoDatos;
        //********************************************************
        //********************************************************
        //********************************************************
        //Método que enlaza el controlador con el modelo al cargarse la página del
        //formulario de creación de registros
        protected void Page_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "";
            cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
            System.Diagnostics.Debug.WriteLine("Estado cadena conexion: " + cadenaConexion);
            controladorAccesoDatos = new ControladorDAORecord(cadenaConexion);
            System.Diagnostics.Debug.WriteLine("**************************************");
            System.Diagnostics.Debug.WriteLine("Controlador de acceso datos ADO.NET: " + controladorAccesoDatos.ToString());
            System.Diagnostics.Debug.WriteLine("**************************************");
        }
        //********************************************************
        //********************************************************
        //********************************************************
        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            //Variables locales del método
            string nombre = "";
            int idDepartamento = 0;
            bool seInserto = false;

            try
            {
                //1.  Recuperamos la data de la vista
                nombre = this.txt_Name.Text;
                idDepartamento = Int32.Parse(this.sel_Departamentos.SelectedValue);

                System.Diagnostics.Debug.WriteLine("nombre de la persona: " + nombre);
                System.Diagnostics.Debug.WriteLine("departamento seleccionado: " + idDepartamento);

                //2.  Llamar el modelo
                seInserto = controladorAccesoDatos.insertarRegistro(nombre, idDepartamento.ToString());

                //3.  Actualizamos la vista
                if (seInserto == true)
                {
                    this.lbl_Confirmacion.Text = "El registro del usuario " + nombre 
                        + " se insertó correctamente en la base de datos";
                }
                else
                {
                    this.lbl_Confirmacion.Text = "El registro del usuario " + nombre
                        + " no pudo ser insertado";
                }

                //Limpiamos los controles
                this.txt_Name.Text = "";
                this.sel_Departamentos.SelectedIndex = 0;
            }

            catch (Exception errorBotonAceptar)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + errorBotonAceptar.Message);
            }
        }
        //********************************************************
        //********************************************************
        //********************************************************
        protected void btn_Reestablecer_Click(object sender, EventArgs e)
        {
            this.txt_Name.Text = "";
            this.sel_Departamentos.SelectedIndex = 0;
        }

        protected void enlaceRetorno_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
        //********************************************************
        //********************************************************
        //********************************************************
        //********************************************************
        //********************************************************
        //********************************************************
    }
}