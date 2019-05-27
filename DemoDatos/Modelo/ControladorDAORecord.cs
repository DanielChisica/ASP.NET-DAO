using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DemoDatos.Modelo
{

    public class ControladorDAORecord
    {
        private static SqlConnection con;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapt;

        //Constructor sobrecargado del DAO
        public ControladorDAORecord(string cadenaConexion)
        {
            con = new SqlConnection(cadenaConexion);
            System.Diagnostics.Debug.WriteLine("Conexión establecida: " + con);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        //Método para realizar la inserción del registro
        public bool insertarRegistro(string nombre, string estado)
        {
            bool seInserto = false;
            try
            {
                cmd = new SqlCommand("insert into tbl_Record(Name,State) values(@name,@state)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", nombre);
                cmd.Parameters.AddWithValue("@state", estado);
                cmd.ExecuteNonQuery();
                seInserto = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de inserción: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (seInserto);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        //Método para realizar la modificación del registro
        public bool modificarRegistro(string nombre, string estado, int id)
        {
            bool seModifico = false;
            try
            {
                cmd = new SqlCommand("update tbl_Record set Name=@name,State=@state where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", nombre);
                cmd.Parameters.AddWithValue("@state", estado);
                cmd.ExecuteNonQuery();
                seModifico = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de modificación: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (seModifico);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        public bool eliminarRegistro(int id)
        {
            bool seElimino = false;
            try
            {
                cmd = new SqlCommand("delete tbl_Record where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                seElimino = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de eliminación: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (seElimino);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        public DataTable rellenarDatosDataSource()
        {
            DataTable tablaDatos = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.tbl_Record", con);
            adapt.Fill(tablaDatos);
            con.Close();

            return (tablaDatos);
        }

        public DataTable rellenarDatosDataSource2()
        {
            DataTable tablaDatos = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.tbl_States", con);
            adapt.Fill(tablaDatos);
            con.Close();

            return (tablaDatos);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        public RecordVO consultarRegistroRecord(string idRegistro)
        {
            RecordVO registroConsultado = new RecordVO();
            string queryString =
            "select Name, State from dbo.tbl_Record where id = @id";
            SqlCommand command = null;
            SqlDataReader cursor = null;


            try
            {
                con.Open();
                command = new SqlCommand(queryString, con);
                command.Parameters.AddWithValue("@id", idRegistro);

                //Recorremos el cursor de la consulta para obtener
                //los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        registroConsultado.Nombre = cursor.GetString(0);
                        registroConsultado.IdEstado = cursor.GetInt32(1);
                    }

                    //Verificamos los datos
                    System.Diagnostics.Debug.WriteLine("NOMBRE = " + registroConsultado.Nombre 
                        + " ID DEPTO = " + registroConsultado.IdEstado);
                }
            }

            catch (Exception errorLectura)
            {
                System.Diagnostics.Debug.WriteLine("Error de consulta: " + errorLectura.Message);
                RecordVO registroVacio = new RecordVO();
                registroVacio.Nombre = "SIN REGISTRO";
                registroVacio.IdEstado = 0;
                return (registroVacio);
            }

            finally
            {
                //Libera los recursos de la transacción DML de consulta
                if (command != null)
                {
                    command.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (registroConsultado);
        }

        
        //************************************************************************
        //************************************************************************
    }//Fin de la clase
}