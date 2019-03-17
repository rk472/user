using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;


public partial class report : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
    MySqlDataAdapter adp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRegion();
            GetMedicine();
            GetStockist();
            GetDoctorname();
        }
       
    }
    private void GetRegion()
    {
        DataSet ds = DBHelper.GetRegion();
        if (ds.Tables[0].Rows.Count > 0)
            {
                StateDropdown.DataSource = ds;
                StateDropdown.DataTextField = "Name";
                StateDropdown.DataValueField = "ID";
                StateDropdown.DataBind();
                StateDropdown.SelectedIndex = 0;
            }
        GetHeadQuarters();
        
    }
    private void GetHeadQuarters() {
        DataSet ds = DBHelper.GetHeadQuarters(StateDropdown.SelectedValue);

        if (ds.Tables[0].Rows.Count > 0)
        {
            CityDropdown.DataSource = ds;
            CityDropdown.DataTextField = "Headquarter_name";
            CityDropdown.DataValueField = "Headquarter_id";
            CityDropdown.DataBind();
            CityDropdown.SelectedIndex = 0;
        }

    }
    protected void GetDoctorname()
    {
        String id = Session["makeway_login_id"].ToString();
        DataSet ds = DBHelper.GetDoctorName(CityDropdown.SelectedValue,id);
       
        //if (ds.Tables[0].Rows.Count > 0)
        {
            DoctorDropdown.DataSource = ds;
            DoctorDropdown.DataTextField = "name";
            DoctorDropdown.DataValueField = "id";
            DoctorDropdown.DataBind();
        }
    }
    protected void StateDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetHeadQuarters();
        GetDoctorname();
    }
    protected void CityDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDoctorname();
    }
    protected void Leavereport(object sender, EventArgs e)
    {
        EmployeeReport empr = new EmployeeReport();
        String id = Session["makeway_login_id"].ToString();
        empr.emp_id = id;
        empr.date = ReportDatetxt.Text;
        empr.type = "Leave";
        empr.reason = "For "+Leavetxt.Text;
        empr.doc_name = "";
        empr.meidicine = "";
        empr.no_of_doc = "";
        if (!DBHelper.GetReportLeave(ReportDatetxt.Text, id))
        {
       
            string Text=DBHelper.createReport(empr);
            if (Text.Equals("success"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                "success('Successfully reported')", true);
            }
         }
         
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                "danger('You  have reported as leave in that day')", true);
        }

        Meetingtxt.Text = "";
        Leavetxt.Text = "";
        Conferencetxt.Text = "";
        Travelfromtxt.Text = "";
        Traveltotxt.Text = "";
        Trainingtxt.Text = "";
        Camptxt.Text = "";
        Othertxt.Text = "";
   
    }
    protected void Conferencereport(object sender, EventArgs e)
    {
        String id = Session["makeway_login_id"].ToString();
            if (!DBHelper.GetReportLeave(ReportDatetxt.Text, id))
            {
                
                EmployeeReport empr = new EmployeeReport();
                empr.emp_id = Session["makeway_login_id"].ToString();
                empr.date = ReportDatetxt.Text;
                empr.type = "Conference";
                empr.reason = "At "+Conferencetxt.Text;
                empr.doc_name = "";
                empr.meidicine = "";
                empr.no_of_doc = "";
                string Text = DBHelper.createReport(empr);
                if (Text.Equals("success"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "success('Successfully reported')", true);
                    Meetingtxt.Text = "";
                    Leavetxt.Text = "";
                    Conferencetxt.Text = "";
                    Travelfromtxt.Text = "";
                    Traveltotxt.Text = "";
                    Trainingtxt.Text = "";
                    Camptxt.Text = "";
                    Othertxt.Text = "";
   
                }
                if (Text.Equals("fail"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "danger('Not Successfully reported')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "danger('You have reported as leave in this day')", true);
            }
       
    }
    protected void Meetingreport(object sender, EventArgs e)
    {
        String id = Session["makeway_login_id"].ToString();
            if (!DBHelper.GetReportLeave(ReportDatetxt.Text, id))
            {
                EmployeeReport empr = new EmployeeReport();
                empr.emp_id = Session["makeway_login_id"].ToString();
                empr.date = ReportDatetxt.Text;
                empr.type = "Meeting";
                empr.reason = "At " + Meetingtxt.Text;
                empr.doc_name = "";
                empr.meidicine = "";
                empr.no_of_doc = "";
                string Text = DBHelper.createReport(empr);
                if (Text.Equals("success"))
                {
                    Meetingtxt.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "success('Successfully reported')", true);
                    Meetingtxt.Text = "";
                    Leavetxt.Text = "";
                    Conferencetxt.Text = "";
                    Travelfromtxt.Text = "";
                    Traveltotxt.Text = "";
                    Trainingtxt.Text = "";
                    Camptxt.Text = "";
                    Othertxt.Text = "";
   
                }
                if (Text.Equals("fail"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "danger('Not Successfully reported')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "danger('You  have reported as leave')", true);
            }
      
   
   
    }
    protected void Closingreport(object sender, EventArgs e)
    {
        String id = Session["makeway_login_id"].ToString();
        if (!DBHelper.GetReportLeave(ReportDatetxt.Text, id))
                {
                    EmployeeReport empr = new EmployeeReport();
                    empr.emp_id = Session["makeway_login_id"].ToString();
                    empr.date = ReportDatetxt.Text;
                    empr.type = "Closing Day";
                    empr.reason = "";
                    foreach (ListItem item in StockistDropdown.Items)
                    {
                        if (item.Selected)
                        {
                            empr.reason += item.Text + " ";
                        }
                    }
                    empr.doc_name = "";
                    empr.meidicine = "";
                    empr.no_of_doc = "";
                    string Text = DBHelper.createReport(empr);
                    if (Text.Equals("success"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "success('Successfully reported')", true);
                    }
                    if (Text.Equals("fail"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "danger('Not Successfully reported')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "danger('You have reported as leave in this day')", true);
                }
       
        Meetingtxt.Text = "";
        Leavetxt.Text = "";
        Conferencetxt.Text = "";
        Travelfromtxt.Text = "";
        Traveltotxt.Text = "";
        Trainingtxt.Text = "";
        Camptxt.Text = "";
        Othertxt.Text = "";
   
    }
    protected void Travelreport(object sender, EventArgs e)
    {
         String id = Session["makeway_login_id"].ToString();
           if(!DBHelper.GetReportLeave(ReportDatetxt.Text,id)) 
            {
                EmployeeReport empr = new EmployeeReport();
                empr.emp_id = id;
                empr.date = ReportDatetxt.Text;
                empr.type = "Travel";
                empr.reason = " From: " + Travelfromtxt.Text + " To: " + Traveltotxt.Text;
                empr.doc_name = "";
                empr.meidicine = "";
                empr.no_of_doc = "";
                string Text = DBHelper.createReport(empr);
                if (Text.Equals("success"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "success('Successfully reported')", true);
                    Meetingtxt.Text = "";
                    Leavetxt.Text = "";
                    Conferencetxt.Text = "";
                    Travelfromtxt.Text = "";
                    Traveltotxt.Text = "";
                    Trainingtxt.Text = "";
                    Camptxt.Text = "";
                    Othertxt.Text = "";
                }
                if (Text.Equals("fail"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "danger('Some error occured')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "danger('You have already reported as leave')", true);
            }
  
       
     
         
        
   
   
    }
    protected void Trainingreport(object sender, EventArgs e)
    {
        String id = Session["makeway_login_id"].ToString();
       
            if (!DBHelper.GetReportLeave(ReportDatetxt.Text, id))
            {
                EmployeeReport empr = new EmployeeReport();
                empr.emp_id = Session["makeway_login_id"].ToString();
                empr.date = ReportDatetxt.Text;
                empr.type = "Training";
                empr.reason = "At "+Trainingtxt.Text;
                empr.doc_name = "";
                empr.meidicine = "";
                empr.no_of_doc = "";
                string Text = DBHelper.createReport(empr);
                if (Text.Equals("success"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "success('Successfully reported')", true);

                    Meetingtxt.Text = "";
                    Leavetxt.Text = "";
                    Conferencetxt.Text = "";
                    Travelfromtxt.Text = "";
                    Traveltotxt.Text = "";
                    Trainingtxt.Text = "";
                    Camptxt.Text = "";
                    Othertxt.Text = "";
   
                }
                if (Text.Equals("fail"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "danger('Error in Report')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                    "danger('You have reported as leave in this day')", true);
            }
        
   
    }
    protected void Campreport(object sender, EventArgs e)
    {
        String id = Session["makeway_login_id"].ToString();
        if (!DBHelper.GetReportLeave(ReportDatetxt.Text, id))
                {
                    EmployeeReport empr = new EmployeeReport();
                    empr.emp_id = Session["makeway_login_id"].ToString();
                    empr.date = ReportDatetxt.Text;
                    empr.type = "Camp";
                    empr.reason = "At " +Camptxt.Text;
                    empr.doc_name = "";
                    empr.meidicine = "";
                    empr.no_of_doc = "";
                    string Text = DBHelper.createReport(empr);
                    if (Text.Equals("success"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "success('Successfully reported')", true);

                        Meetingtxt.Text = "";
                        Leavetxt.Text = "";
                        Conferencetxt.Text = "";
                        Travelfromtxt.Text = "";
                        Traveltotxt.Text = "";
                        Trainingtxt.Text = "";
                        Camptxt.Text = "";
                        Othertxt.Text = "";
   
                    }
                    if (Text.Equals("fail"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "danger('Not Successfully reported')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "danger('You have reported as leave in this day')", true);
                }
       
   
    }
    protected void Otherreport(object sender, EventArgs e)
    {
        String id = Session["makeway_login_id"].ToString();
                if (!DBHelper.GetReportLeave(ReportDatetxt.Text, id))
                {
                    EmployeeReport empr = new EmployeeReport();
                    empr.emp_id = Session["makeway_login_id"].ToString();
                    empr.date = ReportDatetxt.Text;
                    empr.type = "Others";
                    empr.reason = Othertxt.Text;
                    empr.doc_name = "";
                    empr.meidicine = "";
                    empr.no_of_doc = "";
                    string Text = DBHelper.createReport(empr);
                    if (Text.Equals("success"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "success('Successfully reported')", true);

                    }
                    if (Text.Equals("fail"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "danger('Not Successfully reported')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "danger('You have reported as leave in this day')", true);
                }
        
   
    }
    private void GetMedicine()
    {
        DataSet ds = DBHelper.GetMedicine();
        if (ds.Tables[0].Rows.Count > 0)
        {
            MedicineDropdown.DataSource = ds;
            MedicineDropdown.DataTextField = "Name";
            MedicineDropdown.DataValueField = "ID";
            MedicineDropdown.DataBind();
            MedicineDropdown.SelectedIndex = 0;
        }

    }
    private void GetStockist()
    {
        DataSet ds = DBHelper.GetStockist();
        if (ds.Tables[0].Rows.Count > 0)
        {
            StockistDropdown.DataSource = ds;
            StockistDropdown.DataTextField = "Name";
            StockistDropdown.DataValueField = "ID";
            StockistDropdown.DataBind();
        }

    }
    protected void Normalreport(object sender, EventArgs e)
    {
        int count = 0;
        EmployeeReport empr = new EmployeeReport();
        String id = Session["makeway_login_id"].ToString();
        empr.emp_id = id;
        empr.date = ReportDatetxt.Text;
        empr.type = "Normal";
        List<String> ids = new List<string>();
        empr.doc_name = "";
        foreach (ListItem item in DoctorDropdown.Items)
        {
            if (item.Selected)
            {
                empr.doc_name += item.Text + " ";
                ids.Add(item.Value);
                count++;
            }
        }

        empr.meidicine = "";
        foreach (ListItem item in MedicineDropdown.Items)
        {
            if (item.Selected)
            {
                empr.meidicine += item.Text + " ";
            }
        }
        empr.reason = "Consolted doctors :" + empr.doc_name + "Medicines promoted : " + empr.meidicine;
        empr.no_of_doc = count + "";
        if (!DBHelper.GetReportLeave(ReportDatetxt.Text, id))
        {
            if (DBHelper.isAlreadyExist(ids, ReportDatetxt.Text)) { 
                string Text = DBHelper.createReport(empr);
                if (Text.Equals("success"))
                {
                    Employee employee = new UserDataHelper(DBHelper.GetAllUserData(id)).getUsers();
                    for (int i = 0; i < ids.Count; i++)
                    {
                        String docId = ids[i];
                        String docName = DBHelper.getDoctorName(docId);
                        if (DBHelper.inputDetailedReport(docId, docName, ReportDatetxt.Text, employee))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "success('Successfully reported')", true);
                            Meetingtxt.Text = "";
                            Leavetxt.Text = "";
                            Conferencetxt.Text = "";
                            Travelfromtxt.Text = "";
                            Traveltotxt.Text = "";
                            Trainingtxt.Text = "";
                            Camptxt.Text = "";
                            Othertxt.Text = "";
                        }else {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                        "danger('Some Error occured')", true);
                        }
                    }
                }else if (Text.Equals("fail")){
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                                "danger('Some Error occured')", true);
                }
            } else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                           "danger(' same doctor cannot be reported twice on this day')", true);
            }
        }
    }
}