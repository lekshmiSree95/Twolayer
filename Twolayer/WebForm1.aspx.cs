using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Twolayer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = "~/Image/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(path));
            string strinsert="insert into tbl_twolayer values('"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"','"+path+"','"+TextBox4.Text+"','"+TextBox5.Text+"')";
            int i = obj.Fn_ExeNonQuery(strinsert);
            if(i==1)
            {
                Label7.Text = "Inserted";
            }
        }
    }
}