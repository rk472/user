using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class updatesenior : System.Web.UI.Page
{
    String id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["makeway_login_id"] != null)
            id = Session["makeway_login_id"].ToString();
        else
            Response.Redirect("login.aspx");
        if (!IsPostBack)
        {
            getSeniors();
        }
       
    }
    private void getSeniors()
    {
        if (Session["makeway_login_id"] != null && id!=null && id.Length!=0)
        {
            DataSet ds = DBHelper.getSeniors(id);
            int i = ds.Tables[0].Rows.Count;
            //if (ds.Tables[0].Rows.Count > 0)
            {
                seniorDropDown.DataSource = ds;
                seniorDropDown.DataTextField = "name";
                seniorDropDown.DataValueField = "id";
                seniorDropDown.DataBind();
                //seniorDropDown.SelectedIndex = 0;
            }
        }
        //GetCity();

    }
    protected void update(object sender, EventArgs e)
    {
        String senior = seniorDropDown.SelectedValue;
        if (DBHelper.setSenior(id, senior).Equals("fail")) {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Success ",
                   "danger('Some error occurred..')", true);
            return;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Success ",
                   "success('Senior updated successfully..')", true);
    }
}