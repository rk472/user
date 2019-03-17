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

/// <summary>
/// Summary description for Excelreator
/// </summary>
public class ExcelCreator
{
    public ExcelCreator()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static void Downloadfile(Table table)
    {
        System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("Content-Disposition", "attachment; filename=test.xls;");
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter ht = new HtmlTextWriter(sw);
        table.RenderControl(ht);
        Response.Write(sw.ToString());
        Response.End();

    }
}