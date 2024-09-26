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
    public partial class district : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            bind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "insert into tbl_distr values('"+DropDownList1.SelectedItem.Text+"','" + TextBox2.Text + "')";
            int i = obj.Fn_ExeNonQuery(str);
            if (i == 1)
            {
                Label3.Text = "Inserted";
            }
        }
        public void bind()
        {
           
            string sel = "Select Id,Name from tbl_state";
            DataSet ds = obj.Fn_ExeAdapter(sel);
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataSource = ds;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "--Select--");
        }
    }
}