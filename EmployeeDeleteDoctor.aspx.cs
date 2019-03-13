using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EmployeeDeleteDoctor : System.Web.UI.Page
{
    DataTable dt;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        loadTable();
    }
    protected void loadTable()
    {
        String id = Session["makeway_login_id"].ToString();
        ksdatatable.Rows.Clear();
        dt = DBHelper.GetAllDoctors(1,id);
        int rows = dt.Rows.Count;
        int cells = 11;
        if (dt.Rows.Count > 0)
        {
            TableRow r = new TableRow();
            for (int i = 0; i < cells; i++)
            {
                TableHeaderCell header = new TableHeaderCell();
                if (i > 8)
                {
                    header.Text = (i == 9) ? "Reason" : "Delete";
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
                for (int i = 0; i < cells - 2; i++)
                {
                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl(dt.Rows[j][i].ToString()));
                    r.Cells.Add(c);
                }
                TableCell textCell = new TableCell();
                TextBox txt = new TextBox();
                txt.ToolTip = "Whats your reason";
                txt.ID = "reason_doctor_" + j;
                textCell.Controls.Add(txt);
                r.Cells.Add(textCell);
                ksdatatable.Rows.Add(r);
                TableCell btnCell = new TableCell();
                Button btn = new Button();
                btnCell = new TableCell();
                btn = new Button();
                btn.Text = "Delete";
                btn.ID = "request_delete_doctor_" + j;
                btn.Click += new EventHandler(BtnDelete_Click);
                btnCell.Controls.Add(btn);
                r.Cells.Add(btnCell);
                ksdatatable.Rows.Add(r);
            }
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        
        Button btn = (Button)sender;
        int pos = Convert.ToInt32(btn.ID.ToString().Split('_')[3]);
        
        DeleteDoctor doc = new DeleteDoctor();
        doc.Doctor_id = dt.Rows[pos][0].ToString();
        doc.emp_id = dt.Rows[pos][7].ToString();
        doc.Reason = ((TextBox)ksdatatable.FindControl("reason_doctor_" + pos)).Text;
        lblErrorMessage.Text = DBHelper.createDeleteDoctor(doc);
        loadTable();

    }
   
}