using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;


public partial class EmployeeRequestDoctor : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
    MySqlDataAdapter adp;
    String id;
    protected void Page_Load(object sender, EventArgs e)
    {
        DoctorName.Focus();
        if (!IsPostBack)
        {
            GetState();
        }
        if (Session["makeway_login_id"] != null)
            id = Session["makeway_login_id"].ToString();

    }
    private void GetState()
    {
        DataSet ds = DBHelper.GetRegion();
        int i = ds.Tables[0].Rows.Count;
        if (ds.Tables[0].Rows.Count > 0)
        {
            DoctorState.DataSource = ds;
            DoctorState.DataTextField = "Name";
            DoctorState.DataValueField = "ID";
            DoctorState.DataBind();
            DoctorState.SelectedIndex = 0;
        }
        GetCity();

    }
    private void GetCity()
    {
        DataSet ds = DBHelper.GetCity(DoctorState.SelectedValue);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DoctorCity.DataSource = ds;
            DoctorCity.DataTextField = "Name";
            DoctorCity.DataValueField = "Id";
            DoctorCity.DataBind();
            DoctorCity.SelectedIndex = 0;
        }
    }
    protected void DoctorState_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCity();
    }
    protected void add_doctor(object sender, EventArgs e)
    {
        if (DoctorName.Text.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                        "danger('Doctor name must required....')", true);
        }
        else
        {
            if (DoctorSpecialization.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                        "danger('Doctor Specialization must required ...')", true);

            }
            else
            {
                if (DocotrQualification.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                        "danger('Doctor Qualification must required.....')", true);

                }
                else
                {
                    if (Session["makeway_login_id"] != null)
                        {
                            Doctor doc = new Doctor();
                            doc.Name = DoctorName.Text;
                            doc.Specialization = DoctorSpecialization.Text;
                            doc.Qualifiaction = DocotrQualification.Text;
                            doc.Category = DoctorCategory.SelectedItem.ToString();
                            doc.state = DoctorState.SelectedValue.ToString();
                            doc.city = DoctorCity.SelectedValue.ToString();
                            doc.doj = dojtxt.Text;
                            doc.doa = doatxt.Text;
                             string Text = DBHelper.createDoctor(doc, id);

                             ScriptManager.RegisterStartupScript(this, this.GetType(), "Success ",
                   "success('Doctor request sent..')", true);

                             if (Text.Equals("success"))
                             {
                                 lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                                 lblErrorMessage.Text = "Doctor request sent..";
                             }



                            //{
                            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                            //                "success('Doctor add request sent successfully...')", true);     
                            //}
                            // if (Text.Equals("fail"))
                            // {
                            //     ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                            //             "danger('Doctor request sent unsuccessful...')", true);
                            // }
                            DoctorName.Text="";
                            DoctorSpecialization.Text="";
                            DoctorName.Focus();
                            DocotrQualification.Text="";
                            dojtxt.Text="";
                            doatxt.Text="";
                        }
                 }
            }
        }
        
       
    }


}