using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen3.Clases
{
    public class Encuesta
    {
       public static string Nombre { get; set; }
       public static int Edad { get; set; }
       public static string Correo { get; set; }
       public static int Partido { get; set; }

        public Encuesta(string nombre, int edad, string correo, int partido)
        {
            Nombre = nombre;
            Edad = edad;    
            Correo = correo;
            Partido = partido;
        }
        public Encuesta() { }

        public static int Agregar(string nombre, int edad, string correo, int partido)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Conexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAR_ENCUESTA", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@EDAD", edad));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", correo));
                    cmd.Parameters.Add(new SqlParameter("@PARTIDO", partido));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

    }
}