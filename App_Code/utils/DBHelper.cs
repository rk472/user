using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for DBHelper
/// </summary>
public class DBHelper
{
    public DBHelper()
    {

    }
     public static int Login(String userName, String password)
     {
         String src = userName + password;
         String hash = Hash.GetHash(src);
         MySqlParameter param = new MySqlParameter();
         param.ParameterName = "@hash";
         param.Value = hash;
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             string query = "select t_emp_hash.id from t_emp_hash,t_users where t_emp_hash.hash=@hash and t_emp_hash.id=t_users.id and t_users.status=1";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             cmd.Parameters.Add(param);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             adp.Fill(dt);
             if (dt.Rows.Count > 0)
             {
                 return Convert.ToInt32(dt.Rows[0][0].ToString());
             }
             else {
                 return 0;
             }
         }
         catch (MySqlException e)
         {
             Console.WriteLine(e);
             return 0;
         }
     }
     public static DataSet Getname(int id)
     {
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             conn.Open();
             DataSet ds = new DataSet();
             string query = "select name from  t_users where id=@val";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             param.ParameterName = "@val";
             param.Value = id;
             cmd.Parameters.Add(param);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             conn.Close();
             return ds;
         }
         catch (MySqlException e) { return new DataSet(); }
     }
     public static DataSet GetEmailAndPassword(int id)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             DataSet ds = new DataSet();
             string query = "select t_users.Email,t_users.name,t_user_password.password from  t_users,t_user_password where t_users.id=@id and t_users.id=t_user_password.id";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             param.ParameterName = "@id";
             param.Value = id;
             cmd.Parameters.Add(param);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             return ds;
         }
         catch (MySqlException e)
         {
             return null;
         }
         finally {
             conn.Close();
         }
     }
     public static DataTable GetAllUserData(String id) {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             DataSet ds = new DataSet();
             string query = "SELECT t_users.id,t_users.name,t_users.phone,t_users.email,t_users.dob,t_users.doj,t_users.address,t_users.dp,t_users.blood_group,t_users.adhar_card,t_region.name,t_headquarter.headquarter_name,t_users.designation,t_users.level,t_users.gender,t_division.div_name from t_users,t_region,t_division,t_headquarter where t_users.id=@id and t_users.region_id=t_region.id and t_users.hq_id=t_headquarter.headquarter_id and t_users.division_id=t_division.div_id";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             param.ParameterName = "@id";
             param.Value = id;
             cmd.Parameters.Add(param);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             return ds.Tables[0];
         }
         catch (MySqlException e) { return null; }
         finally { conn.Close(); }
     }
     public static DataSet GetRegion()
     {
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             DataSet ds = new DataSet();
             string query = "select * from  t_region";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             conn.Close();
             return ds;
         }
         catch (MySqlException e)
         {
             return new DataSet();
         }
     }
     public static DataSet GetHeadQuarters(String region)
     {
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             DataSet ds = new DataSet();
             string query = "select * from  t_headquarter where state_id=@region";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             param.ParameterName = "@region";
             param.Value = region;
             cmd.Parameters.Add(param);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             conn.Close();
             return ds;
         }
         catch (MySqlException e)
         {
             return new DataSet();
         }
     }
     public static String createReport(EmployeeReport empr)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             string query = "insert into t_report(emp_id, date, type, reason, no_of_doc) values(@emp_id, @date, @type, @reason, @no_of_doc)";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             cmd.Parameters.Add(new MySqlParameter("@emp_id", empr.emp_id));
             cmd.Parameters.Add(new MySqlParameter("@date", empr.date));
             cmd.Parameters.Add(new MySqlParameter("@type", empr.type));
             cmd.Parameters.Add(new MySqlParameter("@reason", empr.reason));
             //cmd.Parameters.Add(new MySqlParameter("@doc_name", empr.doc_name));
             //cmd.Parameters.Add(new MySqlParameter("@medicine", empr.meidicine));
             cmd.Parameters.Add(new MySqlParameter("@no_of_doc", empr.no_of_doc));
             if (cmd.ExecuteNonQuery() > 0)
             {
                 return "success";
                
             }
             else
             {
                 return "fail";
             }

         }
         catch (MySqlException e)
         {
             return e.Message;
         }
         finally
         {
             conn.Close();
         }
     }
     public static DataTable GetAllReport(string ReportFromDatetxt, string ReportToDatetxt)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             DataSet ds = new DataSet();
             string query = "SELECT t_report.date as Date, t_report.type as Type,t_report.reason as Reason,t_report.no_of_doc as No_Of_Doc from t_report where t_report.date between @fromdate and @todate";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             param.ParameterName = "@fromdate";
             param.Value = ReportFromDatetxt;
             MySqlParameter param2 = new MySqlParameter();
             param2.ParameterName = "@todate";
             param2.Value = ReportToDatetxt;
             cmd.Parameters.Add(param);
             cmd.Parameters.Add(param2);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             return ds.Tables[0];
         }
         catch (MySqlException e) { return null; }
         finally { conn.Close(); }
     }
     public static DataSet GetCity(String state)
     {
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             DataSet ds = new DataSet();
             string query = "select * from  t_city where state_id=@state";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             param.ParameterName = "@state";
             param.Value = state;
             cmd.Parameters.Add(param);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             conn.Close();
             return ds;
         }
         catch (MySqlException e)
         {
             return new DataSet();
         }
     }
     public static DataSet getSeniors(String id)
     {
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             DataSet ds = new DataSet();
             string query = "select ss.id,ss.name from t_users ss,t_users js where ss.level=js.level+1 and js.id=@id";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             param.ParameterName = "@id";
             param.Value = id;
             cmd.Parameters.Add(param);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             conn.Close();
             return ds;
         }
         catch (MySqlException e)
         {
             return null;
         }
     }
     public static String createDoctor(Doctor doc, string id)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             string query = "insert into t_doctor(Id,Name,Specialization,Qualification,Category,State,City,status,Emp_id, doj,doa) values(@Id, @Name, @Specialization, @Qualifiaction, @Category, @state, @city,@Status,@Emp_id,@doj,@doa);";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             cmd.Parameters.Add(new MySqlParameter("@Id", doc.Id));
             cmd.Parameters.Add(new MySqlParameter("@Name", doc.Name));
             cmd.Parameters.Add(new MySqlParameter("@Specialization", doc.Specialization));
             cmd.Parameters.Add(new MySqlParameter("@Qualifiaction", doc.Qualifiaction));
             cmd.Parameters.Add(new MySqlParameter("@Category", doc.Category));
             cmd.Parameters.Add(new MySqlParameter("@State", doc.state));
             cmd.Parameters.Add(new MySqlParameter("@City", doc.city));
             cmd.Parameters.Add(new MySqlParameter("@Status", "0"));
             cmd.Parameters.Add(new MySqlParameter("@Emp_id",id));
             cmd.Parameters.Add(new MySqlParameter("@doj", doc.doj));
             cmd.Parameters.Add(new MySqlParameter("@doa", doc.doa));


             if (cmd.ExecuteNonQuery() > 0)
             {
                 return "success";
             }
             else
                 return "fail";

         }
         catch (MySqlException e)
         {
             return e.Message;
         }
         finally
         {
             conn.Close();
         }

     }
     public static String createChemist(Chemist chem, string id)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             string query = "insert into t_chemist(Name,Address,State,City,status,Emp_id) values( @Name,@Address,@state, @city,@Status,@Emp_id);";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             cmd.Parameters.Add(new MySqlParameter("@Name", chem.name));
             cmd.Parameters.Add(new MySqlParameter("@Address", chem.address));
             cmd.Parameters.Add(new MySqlParameter("@State", chem.state));
             cmd.Parameters.Add(new MySqlParameter("@City", chem.city));
             cmd.Parameters.Add(new MySqlParameter("@Status", "0"));
             cmd.Parameters.Add(new MySqlParameter("@Emp_id",id));



             if (cmd.ExecuteNonQuery() > 0)
             {
                 return "<center> Chemist Added Successfully..</center>";
             }
             else
                 return "";

         }
         catch (MySqlException e)
         {
             return e.Message;
         }
         finally
         {
             conn.Close();
         }

     }
     public static String createstockist(Stockist stock, string id)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             string query = "insert into t_stockist(Name,Address,State,City,status,Emp_id) values( @Name,@Address,@state, @city,@Status,@Emp_id);";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             cmd.Parameters.Add(new MySqlParameter("@Name", stock.name));
             cmd.Parameters.Add(new MySqlParameter("@Address", stock.address));
             cmd.Parameters.Add(new MySqlParameter("@State", stock.state));
             cmd.Parameters.Add(new MySqlParameter("@City", stock.city));
             cmd.Parameters.Add(new MySqlParameter("@Status", "0"));
             cmd.Parameters.Add(new MySqlParameter("@Emp_id", id));



             if (cmd.ExecuteNonQuery() > 0)
             {
                 return "success";
             }
             else
                 return "fail";

         }
         catch (MySqlException e)
         {
             return e.Message;
         }
         finally
         {
             conn.Close();
         }

     }
     public static DataTable empPendingDoctor(string id)
     {
         DataTable dt = new DataTable ();
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             
             conn.Open();
             //DataSet ds = new DataSet();
             string query = "SELECT t_doctor.id as Id, t_doctor.name Name,t_doctor.category Catagory,t_doctor.Specialization Specialization,t_doctor.Qualification as Qualification,t_region.name  as state,t_city.name as city  from t_doctor,t_users,t_region,t_city where t_doctor.state=t_region.id and  t_city.id=t_doctor.city and t_doctor.status='0' and t_users.id=@empid ";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             cmd.Parameters.Add(new MySqlParameter("@empid",id));
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(dt);
             return dt;
             
         }
         catch (MySqlException e) { return new DataTable(); }
         finally
         {
             conn.Close();

         }


     }
     public static DataTable GetAllDoctors(int status,String id)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             DataSet ds = new DataSet();
             string query = "SELECT t_doctor.id as Id, t_doctor.name Name,t_doctor.category Catagory,t_doctor.Specialization Specialization,t_doctor.Qualification as Qualification,t_region.name  as state,t_city.name as city, t_doctor.Emp_id Emp_id,t_users.name as Employee from t_doctor,t_users,t_region,t_city where t_doctor.state=t_region.id and  t_city.id=t_doctor.city and t_doctor.status=@status and t_users.id=t_doctor.Emp_id and t_doctor.emp_id=@id";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             param.ParameterName = "@status";
             param.Value = status;
             cmd.Parameters.Add(param);
            cmd.Parameters.Add(new MySqlParameter("@id", id));
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             return ds.Tables[0];
         }
         catch (MySqlException e) { return null; }
         finally { conn.Close(); }
     }
     public static String createDeleteDoctor(DeleteDoctor doc)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             string query = "insert into t_doctor_delete(emp_id, Doctor_id, Reason) values(@emp_id, @Doctor_id, @Reason);";

             MySqlCommand cmd = new MySqlCommand(query, conn);
             cmd.Parameters.Add(new MySqlParameter("@emp_id", doc.emp_id));
             cmd.Parameters.Add(new MySqlParameter("@Doctor_id",doc.Doctor_id));
             cmd.Parameters.Add(new MySqlParameter("@Reason", doc.Reason));

            
             if (cmd.ExecuteNonQuery() > 0)
             {
                 return " Delete Doctor Request sent successfully...";
             }
             else
                 return "";

         }
         catch (MySqlException e)
         {
             return e.Message;
         }
         finally
         {
             conn.Close();
         }

     }
     public static DataSet GetDoctorName(String city,String id)
     {
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             DataSet ds = new DataSet();
             string query = "select * from  t_doctor where  city=@city and ( emp_id=@id or emp_id=0 )";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             cmd.Parameters.Add(new MySqlParameter("@city",city));
            cmd.Parameters.Add(new MySqlParameter("@id", id));
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             conn.Close();
             return ds;
         }
         catch (MySqlException e)
         {
             return new DataSet();
         }
     }
     public static DataSet GetMedicine()
     {
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             DataSet ds = new DataSet();
             string query = "select * from  t_medicine";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             conn.Close();
             return ds;
         }
         catch (MySqlException e)
         {
             return new DataSet();
         }
     }
     public static DataSet GetStockist()
     {
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             DataSet ds = new DataSet();
             string query = "select * from  t_stockist";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             conn.Close();
             return ds;
         }
         catch (MySqlException e)
         {
             return new DataSet();
         }
     }
     public static bool GetReportLeave(string date,String id)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             //int count = 0;
             conn.Open();
             string query = "select type from t_report where date= @date and emp_id=@id and type='Leave'";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             cmd.Parameters.Add(new MySqlParameter("@date", date));
             cmd.Parameters.Add(new MySqlParameter("@id", id));
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             adp.Fill(dt);
             return (dt.Rows.Count > 0);
           
         }
         catch (MySqlException e)
         {
             return false;
            
         }
         finally
         {
             conn.Close();
         }



     }
     public static String setSenior(String id,String senior){
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             string query = "update t_users set senior_id=@senior where id=@id";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             cmd.Parameters.Add(new MySqlParameter("@id", id));
             cmd.Parameters.Add(new MySqlParameter("@senior", senior));
             if (cmd.ExecuteNonQuery() > 0)
             {
                 return "success";
             }
             else
                 return "fail";

         }
         catch (MySqlException e)
         {
             return e.Message;
         }
         finally
         {
             conn.Close();
         }
     }
     public static DataTable GetAllData()
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             DataSet ds = new DataSet();
             string query = "SELECT t_users.id,t_users.name,t_users.phone,t_users.email,t_users.dob,t_users.doj,t_users.address,t_users.blood_group,t_users.adhar_card,t_region.name,t_headquarter.headquarter_name,t_users.designation,t_users.level,t_users.gender,t_division.div_name from t_users,t_region,t_division,t_headquarter where t_users.region_id=t_region.id and t_users.hq_id=t_headquarter.headquarter_id and t_users.division_id=t_division.div_id";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             return ds.Tables[0];
         }
         catch (MySqlException e) { return null; }
         finally { conn.Close(); }
     }
     public static DataTable getJuniors(String id)
     {
         try
         {
             MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
             DataSet ds = new DataSet();
             string query = "select js.id,js.name from t_users js,t_users ss where js.senior_id=ss.id and ss.id=@id";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             param.ParameterName = "@id";
             param.Value = id;
             cmd.Parameters.Add(param);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             conn.Close();
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
                return dt;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                String newId = dt.Rows[i][0].ToString();
                DataTable newDt = getJuniors(newId);
                for (int j = 0; j < newDt.Rows.Count; j++)
                {
                    dt.Rows.Add(newDt.Rows[j].ItemArray);
                }
            }
            return dt;
         
         }
         catch (MySqlException e)
         {
             return new DataTable();
         }
     }
     public static DataTable GetEmpReportDailly(string id)
     {
         MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
         try
         {
             conn.Open();
             DataSet ds = new DataSet();
             string query = "SELECT t_report.date as Date, t_report.type as Type,t_report.reason as Reason,t_report.no_of_doc as No_Of_Doc from t_report  where t_report.emp_id=@empid";
             MySqlCommand cmd = new MySqlCommand(query, conn);
             MySqlParameter param = new MySqlParameter();
             cmd.Parameters.Add(new MySqlParameter("@empid", id));

             //cmd.Parameters.Add(param);
             MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
             adp.Fill(ds);
             return ds.Tables[0];
         }
         catch (MySqlException e) { return null; }
         finally { conn.Close(); }
     }
     public static String getDoctorName(String id)
    {
        MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
        try
        {
           
            //DataSet ds = new DataSet();
            conn.Open();
            string query = "select Name from  t_doctor where  id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.Add(new MySqlParameter("@id", id));
            var queryResult = cmd.ExecuteScalar();
            if (queryResult != null)
               
                return(Convert.ToString(queryResult));
            else
                
                return  null;

            //MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            //adp.Fill(ds);
            //conn.Close();
            //return ds.Tables[0];
        }
        catch (MySqlException e)
        {
            return null;
        }
        finally
        {
            conn.Close();
        }

    }
    public static bool inputDetailedReport(String docId,String docName,string date,Employee employee)
    {
       
        MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
        try
        {
            conn.Open();
            string query = "insert into t_doctor_report(doc_id,doc_name,emp_name,hq,state,date) values(@doc_id,@doc_name,@emp_name,@hq,@state,@date);";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.Add(new MySqlParameter("@doc_id", docId));
            cmd.Parameters.Add(new MySqlParameter("@doc_name",docName));
            cmd.Parameters.Add(new MySqlParameter("@emp_name",employee.name));
            cmd.Parameters.Add(new MySqlParameter("@hq", employee.hq));
            cmd.Parameters.Add(new MySqlParameter("@state", employee.region));
            cmd.Parameters.Add(new MySqlParameter("@date",date ));


            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
                return false;

        }
        catch (MySqlException e)
        {
            return false;
        }
        finally
        {
            conn.Close();
        }
    }
    public static bool isAlreadyExist(List<String> ids,String date)
    {
       
        MySqlConnection conn = new MySqlConnection(Constants.CONNECTION_STRING);
        conn.Open();
        DataSet ds = new DataSet();
        try
        {
            
            for (int i = 0; i < ids.Count; i++)
            {
                string docId = ids[i];
                string query = "SELECT id FROM t_doctor_report WHERE doc_id=@id AND date=@date";
                MySqlCommand cmd = new MySqlCommand(query, conn);
           
                cmd.Parameters.AddWithValue("@id", docId);
                cmd.Parameters.AddWithValue("@date", date);
                 MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(ds);
                if(ds.Tables[0].Rows.Count>0)
                {
                    return false;
                }
                
            //MySqlDataReader reader = cmd.ExecuteReader();

                //if (reader.HasRows)
                //{
                //    return false;

                //}
                // result = Convert.ToInt32(cmd.ExecuteScalar());
                //if (result > 0)
                //{
                //    return false ;

                //}

            }
            return true;

        }
        catch (MySqlException e)
        { 


           return false;
        }
        finally
        {
            conn.Close();
        }

    }
    

}



