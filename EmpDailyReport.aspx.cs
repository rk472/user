using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmpDailyReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        string name = Request.QueryString["name"];
        DataTable dt = DBHelper.GetEmpReportDailly(id);
        int rows = dt.Rows.Count;
        lblId.Text = "Emp ID:<b><font color=\"red\">" + id + "</font></b>";
        lblEmpName.Text = "Name:<b><font color=\"red\">" + name + "<br/></font></b><br/><br/><br/>";
        int cells = 4;
        if (dt.Rows.Count > 0)
        {
            TableRow r = new TableRow();
            for (int i = 0; i < cells; i++)
            {
                TableHeaderCell header = new TableHeaderCell();
                header.Controls.Add(new LiteralControl(dt.Columns[i].Caption));
                r.Cells.Add(header);
            }
            ksdatatable.Rows.Add(r);

            for (int j = 0; j < rows; j++)
            {
                r = new TableRow();
                for (int i = 0; i < cells; i++)
                {
                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl(dt.Rows[j][i].ToString()));
                    r.Cells.Add(c);
                }
                ksdatatable.Rows.Add(r);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Danger ",
                       "danger('No Report Yet..')", true);
        }


    }
}