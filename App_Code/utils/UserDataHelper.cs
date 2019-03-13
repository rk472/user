using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserDataHelper
/// </summary>
public class UserDataHelper
{
    private DataTable dt;
	public UserDataHelper(DataTable dt)
	{
        this.dt = dt;
	}
    public Employee getUsers() {
        Employee emp = new Employee();
        emp.id = dt.Rows[0][0].ToString();
        emp.name = dt.Rows[0][1].ToString();
        emp.phone = dt.Rows[0][2].ToString();
        emp.email = dt.Rows[0][3].ToString();
        emp.dob = dt.Rows[0][4].ToString();
        emp.doj = dt.Rows[0][5].ToString();
        emp.address = dt.Rows[0][6].ToString();
        emp.photo = dt.Rows[0][7].ToString();
        emp.bloodGroup = dt.Rows[0][8].ToString();
        emp.adhar = dt.Rows[0][9].ToString();
        emp.region = dt.Rows[0][10].ToString();
        emp.hq = dt.Rows[0][11].ToString();
        emp.designation = dt.Rows[0][12].ToString();
        emp.level = dt.Rows[0][13].ToString();
        emp.gender = dt.Rows[0][14].ToString();
        emp.division = dt.Rows[0][15].ToString(); 
        
        return emp;
    }
}