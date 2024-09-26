using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Twolayer
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "insert into tbl_state values('" + TextBox2.Text + "')";
            int i = obj.Fn_ExeNonQuery(str);
            if (i == 1)
            {
                Label3.Text = "Inserted";
            }
        }
    }
}