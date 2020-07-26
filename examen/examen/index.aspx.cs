using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace examen
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;

            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
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

        protected void Button2_Click(object sender, EventArgs e)
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

        protected void Button1_Click(object sender, EventArgs e)
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
    }
}