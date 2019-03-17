using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

public partial class JuniorsReport : System.Web.UI.Page
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        String id = Session["makeway_login_id"].ToString();
        dt = DBHelper.getJuniors(id);
        int rows = dt.Rows.Count;
        lblId.Text = "Senior ID:<b><font color=\"red\">" + id + "</font></b>";
        int cells = 3;
        if (dt.Rows.Count > 0)
        {
            TableRow r = new TableRow();
            for (int i = 0; i < cells; i++)
            {
                TableHeaderCell header = new TableHeaderCell();
                if (i == 2)
                {
                    header.Text = "Report";
                }
                else
                {
                    header.Controls.Add(new LiteralControl(dt.Columns[i].Caption));
                }
               
                r.Cells.Add(header);
            }
            ksdatatable.Rows.Add(r);

            for (int j = 0; j < rows; j++)
            {
                r = new TableRow();
                for (int i = 0; i < cells-1; i++)
                {
                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl(dt.Rows[j][i].ToString()));
                    r.Cells.Add(c);
                }

                ksdatatable.Rows.Add(r);
                ksdatatable.Rows.Add(r);
                TableCell btnCell = new TableCell();
                LinkButton btn = new LinkButton();
                btn.Text = "<font color=\"Green\">View</font>";
                btn.ID = "Repot_Emp_" + j;
                btn.Click += new EventHandler(BtnView_Click);
                btnCell.Controls.Add(btn);

                r.Cells.Add(btnCell);
                ksdatatable.Rows.Add(r);
            }
        }
        else
        {
            lblReport.Text = "<font color=\"Red\">NO Juniors</font>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                       "danger('No Juniors Yet..')", true);
        }
      
    }
    protected void BtnView_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        int pos = Convert.ToInt32(btn.ID.ToString().Split('_')[2]);
        String id = (dt.Rows[pos][0].ToString());
       string name = (dt.Rows[pos][1].ToString());
        Response.Redirect("EmpDailyReport.aspx?id=" + id + "&name=" + name);
    }
    protected void DownloadButton_Click(object sender, EventArgs e)
    {
        ExcelCreator.Downloadfile(ksdatatable);
    }
}