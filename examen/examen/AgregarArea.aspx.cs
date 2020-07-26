using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace examen
{
    public partial class AgregarArea : System.Web.UI.Page
    {
        public string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                guardar_area(Nombre.Text,Descripcion.Text);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;

            }
            else
            {
                Response.Redirect("Areas.aspx");

            }

        }


        public void guardar_area(string nombre,string descripcion)
        {
            if (nombre=="" || descripcion =="")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('El campo Nombre y Descripción son obligatorios!');</script>");
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection(conexion);
            try
            {
            
        
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_agregar_Area", con);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
           cmd.CommandType = CommandType.StoredProcedure;
                int i = cmd.ExecuteNonQuery();

                if (i==1 )
                {
                    Nombre.Text = "";
                    Descripcion.Text = "";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Area Almacenada Exitosamente!');</script>");
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            }
        }
    }
}