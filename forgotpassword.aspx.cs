using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using MySql.Data.MySqlClient;


public partial class forgotpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ForgotPasswordSubmit_Click(object sender, EventArgs e)
    {
        string mainId = ForgotPasswordId.Text;
        string stringId = mainId.Substring(1, 4);
        int id = Convert.ToInt32(stringId);
        DataSet ds = DBHelper.GetEmailAndPassword(id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            String name = ds.Tables[0].Rows[0][1].ToString();
            String email = ds.Tables[0].Rows[0][0].ToString();
            String password = ds.Tables[0].Rows[0][2].ToString();
            String result=MailHelper.sendMail(email, name, password);
            if (result.Equals("success"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert ",
                        "alert('Your password has been sent to ur registered email id ....')", true);
            }
            else {
                lblErrorMessage.Text = result;
            }
            ForgotPasswordId.Text = "";
        }
        else {
            lblErrorMessage.Text = "Sorry ! You are not a registered user...";
        }
    }
}
