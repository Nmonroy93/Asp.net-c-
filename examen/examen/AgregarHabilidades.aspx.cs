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
    public partial class AgregarHabilidades : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                traer_lista_de_empleados();
            }
            else
            {
                return;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                guardar_Habilidad(Int32.Parse(empleado_lista.SelectedValue), habilidades_lista.SelectedItem.Text);
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
                Response.Redirect("Organizacion.aspx");

            }
        }

        public void traer_lista_de_empleados()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_traer_lista_de_empleados_para_habilidad");
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt_empleados = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.Connection = con;
                da.Fill(dt_empleados);
                empleado_lista.DataSource = dt_empleados;
                empleado_lista.DataTextField = "empleado";
                empleado_lista.DataValueField = "id";
                empleado_lista.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void guardar_Habilidad(int empleado, string habilidad)
        {
            if (empleado ==0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Seleccionar un Empleado!');</script>");
                return;
            }
            else if (habilidad =="")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Seleccionar una Habilidad!');</script>");
                return;
            }
            else if (habilidades_lista.SelectedValue == "-1")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Seleccionar una Habilidad!');</script>");
                return;
            }
            else
            {
                
                try
                {


                    con.Open();
                    SqlCommand cmd = new SqlCommand("Sp_agregar_Habilidad", con);
                    cmd.Parameters.AddWithValue("@empleado", empleado);
                    cmd.Parameters.AddWithValue("@habilidad", habilidad);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        empleado_lista.SelectedIndex = -1;
                        habilidades_lista.SelectedIndex = -1;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Habilidad Agregada Exitosamente!');</script>");
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