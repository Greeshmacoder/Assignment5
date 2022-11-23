using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public class DbOperation
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();


        public DbOperation()
        {
            con.ConnectionString = "Data Source=NTP-LAP-834\\SQL_SERVER;Initial Catalog=Employee;Integrated Security=True";
            cmd.Connection = con;

        }

        public SqlConnection Getcon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            return con;
        }

        public void dbClose()
        {
            con.Close();
        }

        public int exenonquery(string sql)
        {
            Getcon();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        public void fillgrid( string sql,GridView dv)
        {
            dv.DataSource = exedataSet(sql);
            dv.DataBind();
        }

        public object exescalar(string sql)
        {
            Getcon();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            object ob = cmd.ExecuteScalar();
            return ob;
        }


        public DataSet exedataSet(String sql)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable exedatatable(String sql)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



    }
}