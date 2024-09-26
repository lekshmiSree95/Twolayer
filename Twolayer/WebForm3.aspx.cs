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
    public partial class WebForm3 : System.Web.UI.Page
    {
            
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindstate();
                binddistrict();
            }
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "select * from  tbl_distr where state='"+DropDownList1.SelectedItem.Text+"'";
            DataSet ds = obj.Fn_ExeAdapter(str);
            DropDownList2.DataValueField = "Id";
            DropDownList2.DataTextField = "District";
            DropDownList2.DataSource = ds;
            DropDownList2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "insert into tbl_reg values('" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "')";
            int i = obj.Fn_ExeNonQuery(str);
            if (i == 1)
            {
                Label3.Text = "Inserted";
            }
        }
        public void bindstate()
        {

            string sel = "Select Id,Name from tbl_state";
            DataSet ds = obj.Fn_ExeAdapter(sel);
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataSource = ds;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "--Select--");
        }
        public void binddistrict()
        {

            string sel = "Select Id,District from tbl_distr where state='" + DropDownList1.SelectedItem.Text + "'";
            DataSet ds = obj.Fn_ExeAdapter(sel);
            DropDownList2.DataValueField = "Id";
            DropDownList2.DataTextField = "District";
            DropDownList2.DataSource = ds;
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "--Select--");
        }
    }
}