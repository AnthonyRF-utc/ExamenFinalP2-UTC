using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3
{
    public partial class Encuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                LlenarGrid();
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }


        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM PARTIDO"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddPartido.DataSource = dt;
                            ddPartido.DataTextField = dt.Columns["NOMBRE"].ToString();
                            ddPartido.DataValueField= dt.Columns["IDPartido"].ToString();
                            ddPartido.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Encuesta.Agregar(tNombre.Text, int.Parse(tEdad.Text), tCorreo.Text, int.Parse(ddPartido.SelectedValue.ToString()));


            if (resultado > 0)
            {
                alertas("El voto ha sido ingresado con exito");
                tNombre.Text = string.Empty;
                tEdad.Text = string.Empty;
                tCorreo.Text = string.Empty;
                
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar voto");

            }

        }
    }


   

}