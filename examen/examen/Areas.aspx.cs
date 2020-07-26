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
   
    public partial class Areas : System.Web.UI.Page
    {
        public string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                traer_areas();
            }
            
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void traer_areas()
        {



            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand com = new SqlCommand("sp_traer_areas", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                con.Open();
                da.Fill(dt);
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
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = -1;
                traer_areas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            
           
            SqlConnection con = new SqlConnection(conexion);
            try
            {
            
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["IdArea"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_eliminar_Area", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Area Eliminada Exitosamente!');</script>");
                }
                else
                {

                    return;
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

            traer_areas();
            

    }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                 traer_areas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(conexion);
            try
            {

            TextBox Nombre = GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            TextBox Descripcion = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
                if (Nombre.Text == "" || Descripcion.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('El campo Nombre y Descripción son obligatorios!');</script>");
                    return;
                }
                else
                {
                    int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["IdArea"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_actualizar_Area", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", Nombre.Text);
            cmd.Parameters.AddWithValue("@Descripcion", Descripcion.Text);
            cmd.Parameters.AddWithValue("@id", id);

            int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Area Actualizada Exitosamente!');</script>");
                }
                else
                    {

                        return;
                    }

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

            GridView1.EditIndex = -1;
            traer_areas();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;

            }
            else
            {
                Response.Redirect("AgregarArea.aspx");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;

            }
            else
            {
                Response.Redirect("index.aspx");

            }
        }
    }
}