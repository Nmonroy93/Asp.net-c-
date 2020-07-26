using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace examen
{
    
    public partial class AgregarEmpleado : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                traer_lista_de_jefe();

                traer_areas_lista();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                guardar_empleado();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void guardar_empleado()
        {

            if (Nombre.Text == "")
            {


                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Escribir un Nombre!');</script>");
                return;
            }
            else if (cedula.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Escribir una Cedula!');</script>");
                return;

            }
            

            else if (validar_email(correo.Text) == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Escribir un Correo Valido!');</script>");
                return;

            }
            //else if (nacimiento.SelectedDate.Date == DateTime.MinValue.Date)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Seleccionar una fecha de Nacimiento!');</script>");
            //    return;

            //}
            //else if (reclutamiento.SelectedDate.Date == DateTime.MinValue.Date)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe  Seleccionar una fecha de Reclutamiento!');</script>");
            //    return;

            //}
            
                else if (area.SelectedValue == "0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe  Seleccionar un Area de la lista!');</script>");
                return;

            }
            else if (jefe.SelectedValue == "0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe  Seleccionar un Jefe de la lista!');</script>");
                return;

            }
            else if(!FileUpload1.HasFile) 
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe  Seleccionar una Foto para el empleado!');</script>");
                return;
            }
            else
            {

                try
                {
                    HttpPostedFile postedFile = FileUpload1.PostedFile;
                    string filename = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(filename);
                    int fileSize = postedFile.ContentLength;
                     
                    if (fileExtension.ToLower() == ".jpg")
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                        
                 con.Open();
                SqlCommand cmd = new SqlCommand("Sp_guardar_empleado_nuevo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", Nombre.Text);
                cmd.Parameters.AddWithValue("@cedula", cedula.Text);
                cmd.Parameters.AddWithValue("@correo", correo.Text);
                cmd.Parameters.AddWithValue("@f1", Convert.ToDateTime(fecha.Text));
                cmd.Parameters.AddWithValue("@f2", Convert.ToDateTime(fecha2.Text));
                cmd.Parameters.AddWithValue("@id_area", Int16.Parse(area.SelectedValue));
                cmd.Parameters.AddWithValue("@id_jefe", Int16.Parse(jefe.SelectedValue));
                cmd.Parameters.AddWithValue("@foto", bytes);
                //cmd.Parameters.AddWithValue("@contentType", contentType);
                            int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Empleado Ingresado Exitosamente!');</script>");
                                Nombre.Text = "";
                                cedula.Text = "";
                                correo.Text = "";
                                fecha.Text = "";
                                fecha2.Text = "";
                                area.SelectedValue ="0";
                                area.SelectedValue ="0";

                            }
                else
                {

                    return;
                }
                        }

                    else
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Solo se aceptan imagenes de tipo(.jpg)!');</script>");
                        

                    }
                }

                //}
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

        public Boolean validar_email(string correo)
        {

            string email = correo;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;


        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;

            }
            else
            {
                Response.Redirect("Empleados.aspx");

            }
        }


        public void traer_lista_de_jefe()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_traer_lista_de_jefes2");
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt_areas = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.Connection = con;
                da.Fill(dt_areas);
                jefe.DataSource = dt_areas;
                jefe.DataTextField = "jefe";
                jefe.DataValueField = "id";
                jefe.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void traer_areas_lista()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_traer_lista_de_areas2");
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt_areas = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.Connection = con;
                da.Fill(dt_areas);
                area.DataSource = dt_areas;
                area.DataTextField = "Nombre";
                area.DataValueField = "IdArea";
                area.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}