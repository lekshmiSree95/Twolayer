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
    public partial class UserProfile : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string str = "select Name,Age,Address,Photo from Tbl_twolayer where Id = " + Session["uid"] + "";
                SqlDataReader dr = obj.Fn_ExeReader(str);
                while (dr.Read())
                {
                    Label1.Text = dr["Name"].ToString();
                    Label2.Text = dr["Age"].ToString();
                    Label3.Text = dr["Address"].ToString();
                    Image1.ImageUrl = dr["Photo"].ToString();
                }
               
                DataSet ds = obj.Fn_ExeAdapter(str);
                GridView1.DataSource = ds;
                GridView1.DataBind();

                DataTable dt = obj.Fn_tableExeAdapter(str);
                DataList1.DataSource = dt;
                DataList1.DataBind();

            }
        }

      
    }
}