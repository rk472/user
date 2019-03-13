using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class reportlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblerrormsg.Text = "";
    }
    protected void showreport(object sender, EventArgs e)
    {
        DataTable dt = DBHelper.GetAllReport(ReportFromDatetxt.Text,ReportToDatetxt.Text);
        int rows = dt.Rows.Count;
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
            lblerrormsg.Text = "No Records Found";
        }
       
    }
}