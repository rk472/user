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


public partial class AllJuniorsReport : System.Web.UI.Page
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

          dt = DBHelper.GetAllData();

        int rows = dt.Rows.Count;
        int cells = 16;
        if (dt.Rows.Count > 0)
        {
            
                TableRow r = new TableRow();
                for (int i = 0; i < cells; i++)
                {
                    TableHeaderCell header = new TableHeaderCell();
                    if (i == 15)
                    {
                        header.Text = "Juniors";
                    }
                    else
                    {
                        header.Controls.Add(new LiteralControl(dt.Columns[i].Caption));
                    }
                    r.Cells.Add(header);
                }
                ksdatatable.Rows.Add(r);
                DataTable dtstatus = new DataTable();
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
                btn.Text = "View";
                btn.ID = "Repot_Emp_" + j;
                btn.Click += new EventHandler(BtnView_Click);
                btnCell.Controls.Add(btn);
                r.Cells.Add(btnCell);
                ksdatatable.Rows.Add(r);

                 }
        }
       
    }
    protected void BtnView_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        int pos = Convert.ToInt32(btn.ID.ToString().Split('_')[2]);
        String result = (dt.Rows[pos][0].ToString());
        string name=(dt.Rows[pos][1].ToString());
       Response.Redirect("JuniorsReport.aspx?id=" + result+"&name="+name);
    }
    protected void DownloadButton_Click(object sender, EventArgs e)
    {
        ExcelCreator.Downloadfile(ksdatatable);
    }


}