using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace examen
{
    public partial class Empleados : System.Web.UI.Page
    {
        public static string area;
        public static string jefe;
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                

                traer_empleados();

                traer_areas_lista();

                

               
            }

        }

      
        
        public void traer_areas_lista()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_traer_lista_de_areas");
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt_areas = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;
            da.Fill(dt_areas);
            DropDownList1.DataSource = dt_areas;
            DropDownList1.DataTextField = "Nombre";
            DropDownList1.DataValueField = "IdArea";
            DropDownList1.DataBind();
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

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string item = DropDownList1.SelectedItem.Value;
            int id_area= Int32.Parse(item);
            filtrar_tabla_por_area(id_area);
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void filtrar_tabla_por_area(int id)
        {
            if (id==0)
            {
                traer_empleados();
            }
            else
            {

            
            
            DataTable dt = new DataTable();
            SqlCommand com = new SqlCommand("Sp_traer_empleados_por_area", con);
            com.Parameters.AddWithValue("@id", id);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
              
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

        }
        public DataTable traer_jefe_por_id(int id)
        {


            
            DataTable dt = new DataTable();
            SqlCommand com = new SqlCommand("Sp_traer_jefe_por_id", con);
            com.Parameters.AddWithValue("@id", id);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
               
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

            return dt;


        }
        public DataTable traer_area_por_id(int id)
        {
            

               
                DataTable dt = new DataTable();
                SqlCommand com = new SqlCommand("Sp_traer_area_por_id", con);
                com.Parameters.AddWithValue("@id", id);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                try
                {
                    
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

            return dt;
                

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
            
            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                SqlCommand cmd = new SqlCommand("Sp_eliminar_empleado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Empleado Eliminado Exitosamente!');</script>");
                }
     
                con.Close();
                cmd.Dispose();
                traer_empleados();

               
            }

            if (e.CommandName == "Seleccionar")
            {

               
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string NombreCompleto = (row.FindControl("Label1") as Label).Text;
              
                string FechaNacimiento = (row.FindControl("Label13") as Label).Text;
                string FechaIngreso = (row.FindControl("Label23") as Label).Text;
                string cedula = (row.FindControl("Label2") as Label).Text;
                string correo = (row.FindControl("Label3") as Label).Text;
                string id_area= (row.FindControl("area") as Label).Text;
                string id_jefe = (row.FindControl("jefe") as Label).Text;

               

                foreach (DataRow dr in traer_area_por_id(Int32.Parse(id_area)).Rows)
                {
                    area = dr["area"].ToString();

                }


                foreach (DataRow dr in traer_jefe_por_id(Int32.Parse(id_jefe)).Rows)
                {
                    jefe = dr["jefe"].ToString();

                }





                int edad = CalcularEdad(DateTime.Parse(FechaNacimiento));
                int edad_ingreso = CalcularEdad(DateTime.Parse(FechaIngreso));
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Nombre: " + NombreCompleto
                    + "\\nJefe: " + jefe
                    + "\\nArea: " + area
                    + "\\nCedula Numero: " + cedula
                     + "\\nCorreo Electronico: " + correo
                    + "\\nNacimiento: " + DateTime.Parse(FechaNacimiento).ToString("dd'/'MM'/'yyyy") + " con Edad de: "+edad +" años."
                    + "\\nReclutamiento: " + DateTime.Parse(FechaIngreso).ToString("dd'/'MM'/'yyyy") + " con: " + edad_ingreso + " años de permanencia en la empresa." + "');", true);


            }

            if (e.CommandName == "Actualizar")
            {
                
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[rowIndex];
                    string id = (row.FindControl("Label11") as Label).Text;
                    Session["id"] = id;
                    Response.Redirect("EditarEmpleado.aspx");

            }
            if (e.CommandName == "EditarFoto")
                {

                    
                        
                    int rowIndex2 = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row2 = GridView1.Rows[rowIndex2];
               
                try
                    {
                    string id_empleado = (row2.FindControl("Label11") as Label).Text;
                    FileUpload FileUpload1 = (row2.FindControl("FileUpload1") as FileUpload);
                        if (!FileUpload1.HasFile)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe  Seleccionar una Foto para el empleado!');</script>");

                        }
                        else
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
                        SqlCommand cmd = new SqlCommand("Sp_actualizar_foto", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@foto", bytes);
                        cmd.Parameters.AddWithValue("@id", id_empleado);


                            //cmd.Parameters.AddWithValue("@contentType", contentType);
                            int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Foto Actualizada Exitosamente!');</script>");



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
                traer_empleados();
            }
        
            
        }

       
      
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            traer_empleados();
        }
        public void guardar_empleado_editado(string Nombre,string cedula,string correo,DateTime f1,DateTime f2,int id_area,int id_jefe,int id_empleado)
        {
           
            if (Nombre == "")
            {


                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Escribir un Nombre!');</script>");
                return;
            }
            else if (cedula == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Escribir una Cedula!');</script>");
                return;

            }


            else if (validar_email(correo) == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe Escribir un Correo Valido!');</script>");
                return;

            }


            
            else
            {

                try
                {
                    
                    

                       
                        SqlCommand cmd = new SqlCommand("Sp_guardar_empleado_editado", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nombre", Nombre);
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@f1", f1);//Convert.ToDateTime(fecha.Text));
                        cmd.Parameters.AddWithValue("@f2", f2);//Convert.ToDateTime(fecha2.Text));
                        cmd.Parameters.AddWithValue("@id_area", id_area);// Int16.Parse(area.SelectedValue));
                        cmd.Parameters.AddWithValue("@id_jefe", id_jefe);//Int16.Parse(jefe.SelectedValue));
                        cmd.Parameters.AddWithValue("@id", id_empleado);


                        //cmd.Parameters.AddWithValue("@contentType", contentType);
                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Empleado Actualizado Exitosamente!');</script>");



                        }
                        else
                        {

                            return;
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
                traer_empleados();
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
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {


                string jefe = (GridView1.Rows[e.RowIndex].FindControl("ddljefe") as DropDownList).SelectedItem.Value;
                string area = (GridView1.Rows[e.RowIndex].FindControl("ddlarea") as DropDownList).SelectedItem.Value;
                string Nombre = (GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text.ToString();
                string cedula = (GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text.ToString();
                string correo = (GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox).Text.ToString();
                string f1 = (GridView1.Rows[e.RowIndex].FindControl("fecha2") as TextBox).Text.ToString();
                string f2 = (GridView1.Rows[e.RowIndex].FindControl("fecha") as TextBox).Text.ToString();
                string id_empleado = GridView1.DataKeys[e.RowIndex].Value.ToString();
                 guardar_empleado_editado(Nombre,  cedula,  correo, Convert.ToDateTime(f1), Convert.ToDateTime(f2), Int32.Parse(area), Int32.Parse(jefe), Int32.Parse(id_empleado));
                
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
        public void traer_empleados()
        {


            
            DataTable dt = new DataTable();
            SqlCommand com = new SqlCommand("Sp_traer_empleados", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                
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



        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_agregar_empleado_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;

            }
            else
            {
                Response.Redirect("AgregarEmpleado.aspx");

            }
        }

        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;
            

            if (fechaNacimiento > fechaActual)
            {
                //"La fecha de nacimiento es mayor que la actual."
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;


                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }
        protected void btn_menu_Click(object sender, EventArgs e)
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Foto"]);
                (e.Row.FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;
            }


            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
               
                DropDownList DropDownList_jefe = new DropDownList();
                DropDownList_jefe = (DropDownList)e.Row.FindControl("ddljefe");

                DropDownList DropDownList_area = new DropDownList();
                DropDownList_area = (DropDownList)e.Row.FindControl("ddlarea");

                if (DropDownList_jefe != null)
                {
                        string sql = "sp_traer_jefe_dropdowlist";
                    
                    
                        using (SqlDataAdapter sda_jefe = new SqlDataAdapter(sql, con))
                        {
                            using (DataTable dt_jefe = new DataTable())
                            {
                            sda_jefe.Fill(dt_jefe);
                            DropDownList_jefe.DataSource = dt_jefe;
                            DropDownList_jefe.DataTextField = "nombre";
                            DropDownList_jefe.DataValueField = "IdJefe";
                            DropDownList_jefe.DataBind();
                            string selectedCity = DataBinder.Eval(e.Row.DataItem, "IdJefe").ToString();
                            DropDownList_jefe.Items.FindByValue(selectedCity).Selected = true;
                            }
                        }
                    


                }


                if (DropDownList_area != null)
                {
                    string sql = "sp_traer_area_dropdowlist";


                    using (SqlDataAdapter sda_Area = new SqlDataAdapter(sql, con))
                    {
                        using (DataTable dt_area = new DataTable())
                        {
                            sda_Area.Fill(dt_area);
                            DropDownList_area.DataSource = dt_area;
                            DropDownList_area.DataTextField = "nombre";
                            DropDownList_area.DataValueField = "IdArea";
                            DropDownList_area.DataBind();
                            string selectedCity = DataBinder.Eval(e.Row.DataItem, "IdArea").ToString();
                            DropDownList_area.Items.FindByValue(selectedCity).Selected = true;
                        }
                    }



                }
            }

        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            traer_empleados();
        }

        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            traer_empleados();
        }
    }
}