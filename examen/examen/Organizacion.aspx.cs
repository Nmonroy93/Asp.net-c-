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
    public partial class Organizacion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public static string valor_nodo_treeview;
        public static string habilidadades;
        public static string Nombre_empleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = this.traer_datos("Sp_traer_empleados_para_treeview");
                this.PopulateTreeView(dt, 0, null);
            }
        }

        private void PopulateTreeView(DataTable dtParent, int parentId, TreeNode treeNode)
        {
            foreach (DataRow row in dtParent.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["NombreCompleto"].ToString(),
                    Value = row["IdEmpleado"].ToString()
                };
                if (parentId == 0)
                {
                    TreeView1.Nodes.Add(child);
                    DataTable dtChild = this.traer_datos_con_valor("Sp_traer_empleados_para_treeview_2", int.Parse(child.Value));
                    PopulateTreeView(dtChild, int.Parse(child.Value), child);
                }
                else
                {
                    treeNode.ChildNodes.Add(child);
                }
            }
        }
        

        private DataTable traer_datos(string procedimiento)
        {
            DataTable dt = new DataTable();
           
            
                using (SqlCommand cmd = new SqlCommand(procedimiento))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        //cmd.CommandType = CommandType.Text;
                        cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            
        }
        private DataTable traer_datos_con_valor(string consulta,int id)
        {
            DataTable dt = new DataTable();


            using (SqlCommand cmd = new SqlCommand(consulta))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    //cmd.CommandType = CommandType.Text;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;

        }

        protected void Button1_Click(object sender, EventArgs e)
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;

            }
            else
            {
                Response.Redirect("AgregarHabilidades.aspx");

            }
        }

        protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
        {

           
            
            if (TreeView1.SelectedNode == null)
            {
                return;
            }
            else if (TreeView1.SelectedNode.Depth == 1)

            {

                valor_nodo_treeview = TreeView1.SelectedNode.Value;
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('nodo: " + valor_nodo_treeview + "');", true);

            }

            else if(TreeView1.SelectedNode.Depth == 0)

             {

                valor_nodo_treeview = TreeView1.SelectedNode.Value;
               // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('nodo: " + valor_nodo_treeview + "');", true);


            }

            //traer el nombre del empleado
            foreach (DataRow row in traer_nombre_de_empleado(Int32.Parse(valor_nodo_treeview)).Rows)
            {
                Nombre_empleado = row["nombre"].ToString();
             


            }

            string[] Habilidad = new[] {""};
            
            ///traer habilidadees de empleado
            foreach (DataRow row in traer_habilidad_de_empleado(Int32.Parse(valor_nodo_treeview)).Rows)
            {
                habilidadades = row["NombreHabilidad"].ToString();
                Habilidad = Habilidad.Concat(new[] { habilidadades }).ToArray();


            }

            var str = String.Join(",", Habilidad);

            if (str=="," || str == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+Nombre_empleado+" No Posee Habilidades" + "');", true);

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Las Habilidades de "+ Nombre_empleado +" son : " + str.Remove(0, 1) + "');", true);

            }




        }


        public DataTable traer_habilidad_de_empleado(int id_empleado)
        {
            DataTable dt_habilidad = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_traer_habilidad_por_id");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_empleado);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.Connection = con;
                da.Fill(dt_habilidad);


            }
            catch (Exception)
            {
                throw;
            }

            return dt_habilidad;
        }


        public DataTable traer_nombre_de_empleado(int id_empleado)
        {
            DataTable dt_nombre = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_traer_nombre_de_empleado_por_id");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_empleado);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.Connection = con;
                da.Fill(dt_nombre);


            }
            catch (Exception)
            {
                throw;
            }

            return dt_nombre;
        }
    }
}