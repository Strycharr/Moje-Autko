using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader dr;
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\admin\\source\\repos\\WebApplication3\\WebApplication3\\App_Data\\Baza_logowanie.mdf; Integrated Security = True";
        }
      

        [HttpPost]
        public ActionResult VerifyLogin(Account acc)
        {
            
            connectionString();
            conn.Open();
            Console.WriteLine("Stan połącznie"+conn);
            command.Connection = conn;
            command.CommandText = "select * from Table_logowanie where login='"+acc.Name+"' and haslo='"+acc.Password+"'";
            dr = command.ExecuteReader();

            if (dr.Read())
            {
                ViewBag.Zmienna = "Zalogowano";
                conn.Close();
                return View();

            }
            else
            {
                ViewBag.Zmienna = "Nie zalogowano";
                conn.Close();
                return View();
            }
           
            
        }
    }
}