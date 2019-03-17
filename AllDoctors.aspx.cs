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

public partial class AllDoctors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String id = Session["makeway_login_id"].ToString();
        DataTable dt = DBHelper.GetAllDoctors(1,id);
        int rows = dt.Rows.Count;
        int cells = 9;
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

    }
    
    protected void DownloadButton_Click(object sender,EventArgs e)
    {
       ExcelCreator.Downloadfile(ksdatatable);
    }
}