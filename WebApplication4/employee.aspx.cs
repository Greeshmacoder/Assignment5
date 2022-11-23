using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class employee : System.Web.UI.Page
    {
        DbOperation db = new DbOperation();
        protected void Page_Load(object sender, EventArgs e)
        {

          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String sql = "insert into tbl_employee values('" + TextBox1.Text + "','" + TextBox2.Text + "', '" + TextBox3.Text + "')";
            int i = db.exenonquery(sql);
            if (i == 1)
            {
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                Response.Write("failed");
            }
        }
    }
}