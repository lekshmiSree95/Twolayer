using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Twolayer
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strselect = "select count(Id) from tbl_twolayer where username='" + TextBox4.Text + "'and Password='" + TextBox5.Text + "'";
            string cid = obj.Fn_Scalar(strselect);
            if(cid== "1")
            {
                int id1 = 0;
                string str = "Select Id from Tbl_twolayer where username='" + TextBox4.Text + "' and password='" + TextBox5.Text + "'";
                SqlDataReader dr = obj.Fn_ExeReader(str);
                while(dr.Read())
                {
                    id1 = Convert.ToInt32(dr["Id"].ToString());
                }
                Session["uid"] = id1;               
                Response.Redirect("Userprofile.aspx");
            }
            else
            {
                Label5.Text = "Invalid Username and Password";
            }

        }
    }
}