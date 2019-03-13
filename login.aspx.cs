using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class login1 : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["makeway_login_id"] != null) {
            Response.Redirect("index.aspx");
        }

    }
   
    protected void LoginButton_Click(object sender, EventArgs e)
    {
            string loginidvalue = LoginIdText.Text;
            int last=loginidvalue.Length-1;
            string value2 = loginidvalue.Substring(1,last);
            int x = Convert.ToInt32(value2);
            conn.Open();
            DataSet ds = DBHelper.Getname(x);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string nm = ds.Tables[0].Rows[0][0].ToString();
                int id=DBHelper.Login(nm, LoginPasswordText.Text);
                if (id!=0)
                {
                    Session["makeway_login_id"] =id;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    lblErrorMessage.Text = "Invalid User name or password";
                }
            }
            else
            {
                lblErrorMessage.Text = "You are not a registered user";
            }

            conn.Close();
    }
}