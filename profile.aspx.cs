using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
   
    private String id;
    private Employee emp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["makeway_login_id"] != null)
        {
            id = Session["makeway_login_id"].ToString();
            Employee emp = new UserDataHelper(DBHelper.GetAllUserData(id)).getUsers();
            if (!emp.photo.Equals("na"))
            {
                ProfileImage.ImageUrl = "~/assets/profile_pics/" + id + ".jpg";
                ParentImage.ImageUrl = "~/assets/profile_pics/Parent" + id + ".jpg";
            }
            ProfileHeaderName.Text = emp.name;
            ProfileHeaderDesignation.Text = emp.designation;
            ProfileName.Text = emp.name;
            ProfileId.Text = emp.id;
            ProfilePhone.Text = emp.phone;
            ProfileEmail.Text = emp.email;
            ProfileDob.Text = emp.dob;
            ProfileDoj.Text = emp.doj;
            ProfileAddress.Text = emp.address;
            ProfileBloodgroup.Text = emp.bloodGroup;
            ProfileAdharCard.Text = emp.adhar;
            ProfileRegion.Text = emp.region;
            ProfileHq.Text = emp.hq;
            ProfileLevel.Text = emp.level;
            ProfileDesignation.Text = emp.designation;
            ProfileDivision.Text = emp.division;
        }
    }

    protected void upload(object sender, EventArgs e)
    {
         String id;
        id = Session["makeway_login_id"].ToString();
        if (fileUpload.HasFile)
        {
            fileUpload.SaveAs(Server.MapPath("~/assets/profile_pics/"+id + ".jpg" ));
            ProfileImage.ImageUrl = "~/assets/profile_pics/" + id + ".jpg";
            //(this.Master as MasterPage).loadDp();
         }
        else
        {
            lbl.Text = id.ToString();
        }

    }
    protected void upload1(object sender, EventArgs e)
    {
        String id;
        id = Session["makeway_login_id"].ToString();
        if (parentsupload.HasFile)
        {
            parentsupload.SaveAs(Server.MapPath("~/assets/profile_pics/Parent" + id + ".jpg"));
            ParentImage.ImageUrl = "~/assets/profile_pics/Parent" + id + ".jpg";
            
            (this.Master as MasterPage).loadDp();
        }
        else
        {
            lbl.Text = id.ToString();
        }

    }

    protected void goToSeniorUpdate(object sender, EventArgs e)
    {
        Response.Redirect("updatesenior.aspx");
    }
}