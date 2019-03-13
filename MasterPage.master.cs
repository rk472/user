using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private String id;
    private Employee emp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["makeway_login_id"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else {
            id = Session["makeway_login_id"].ToString();
            emp = new UserDataHelper(DBHelper.GetAllUserData(id)).getUsers();
            MasterUserName.Text = emp.name;
            MasterUserDesignation.Text = emp.designation;
            if (!emp.photo.Equals("na"))
            {
                loadDp();
            }
          
        }
        
    }
    public void loadDp(){
        MasterNavProfileImage.ImageUrl = "~/assets/profile_pics/Parent" + id + ".jpg";
        MasterSideBarProfileImage.ImageUrl = "~/assets/profile_pics/" + id + ".jpg";
    }
    protected void logout(object sender, EventArgs e) {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
    protected void upload(object sender, EventArgs e)
    {
       /* if (FileUpload1.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/assets/profile_pics/"+id+".jpg"));

            }
            catch (Exception ex)
            {
                MasterUserName.Text = ex.Message;
            }
        }
        * */
    }
}
