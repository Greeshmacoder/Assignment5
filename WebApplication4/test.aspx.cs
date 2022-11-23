using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class test : System.Web.UI.Page
    {
        DbOperation db = new DbOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
             
            if(!IsPostBack)
            {
                string _id = Request.QueryString["id"].ToString();
                DataTable dt = db.exedatatable("Select * from tbl_employee where Employee_id='" +_id + " '");
                Label1.Text = dt.Rows[0]["Name"].ToString();
                Label2.Text = dt.Rows[0]["Designation"].ToString();
                Label3.Text = dt.Rows[0]["Salary"].ToString();

            }
        }
    }
}