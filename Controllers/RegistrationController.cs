using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication2.Database_Connection;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RegistrationController : Controller
    {      
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserRegistration ur)
        {
            string connection = "Data Source=DESKTOP-8J5HIL7\\SQLEXPRESS ; Initial Catalog=Registration_System;trusted_connection=SSPI ; Encrypt=false;TrustServerCertificate=true";

            SqlConnection sqlconn1 = new SqlConnection(connection);
            string sqlquery1 = "select Username,Uemail from registrations where Username = @Username and Uemail = @Uemail";
            sqlconn1.Open();
            SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn1);
            sqlcomm1.Parameters.AddWithValue("@Username", ur.Username);
            sqlcomm1.Parameters.AddWithValue("@Uemail", ur.Uemail);
            SqlDataReader sdr = sqlcomm1.ExecuteReader();
            if (sdr.Read())
            {
                ViewData["Message"] = "The Employee " + ur.Username + " Is Already Registered...!  ";
            }
            else
            {
                using (SqlConnection sqlconn = new SqlConnection(connection))
                {
                    string sqlquery = "insert into registrations(UserName,Uemail,Pwd,ConfirmPwd,MartialStatus,Gender) values ('" + ur.Username + "','" + ur.Uemail + "','" + ur.Pwd + "','" + ur.ConfirmPwd + "','" + ur.MartialStatus + "', '" + ur.Gender + "')";

                    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                    {
                        sqlconn.Open();
                        sqlcomm.ExecuteNonQuery();
                        ViewData["Message"] = "The New Employee " + ur.Username + " Is Registered Successfully...!";
                    }
                }
            }
            sqlconn1.Close();
            return View(ur);
        }
    }
}
