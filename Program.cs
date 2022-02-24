using System;
using System.Data.SqlClient;

namespace CovidVaccineTrackerApp
{
    class Program
    {
        static void Main()
        {
            var sqlConnection = new SqlConnection(@"Data Source=DESKTOP-EC8T7UD\SQLEXPRESS;Initial Catalog=VaccineTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var login = new Login();
            login.MainPage(sqlConnection);
        }
    }
}
