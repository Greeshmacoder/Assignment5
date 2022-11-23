using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DbOperation db = new DbOperation();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridView1.DataSource = db.exedataSet("select * from tbl_employee");
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = db.exedataSet("Select * from tbl_employee");
            GridView1.DataBind();
        }

        

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            TextBox txtname = new TextBox();
            txtname = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];

            TextBox txtdesign = new TextBox();
            txtdesign = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];

            TextBox txtsalary = new TextBox();
            txtsalary = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];

            db.exenonquery("update tbl_employee set Name ='" +txtname.Text+ "',Designation='" + txtdesign.Text + "',Salary='" + txtsalary.Text + "'where Employee_id='" + id+ " ' ");


            GridView1.EditIndex = -1;
            GridView1.DataSource = db.exedataSet("select * from  tbl_employee");
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string _id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            db.exenonquery("DELETE FROM tbl_employee where Employee_id = '" + _id + " '");
            GridView1.DataSource = db.exedataSet("Select * From tbl_employee");
            GridView1.DataBind();


                }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = db.exedataSet("SELECT * FROM  tbl_employee");
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
            
                HtmlInputCheckBox chk;

                foreach (GridViewRow dh in GridView1.Rows)
                {
                    chk = (HtmlInputCheckBox)dh.FindControl("ch");

                    if (chk.Checked)
                    {
                        db.exenonquery("delete from tbl_employee where Employee_id=" + chk.Value + "");
                    }
                }

                db.fillgrid("Select * from tbl_employee", GridView1);


            
        }
    }
}