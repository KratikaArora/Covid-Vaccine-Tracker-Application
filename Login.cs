using System;
using System.Data.SqlClient;
using System.Threading;

namespace CovidVaccineTrackerApp
{
    public class Login
    {
            public string Username { get; set; }
            public bool IsAdmin { get; set; }
            public int EmpId { get; set; }
        
        public void MainPage(SqlConnection sqlConnection)
        {
            string choice;
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("                       Covid Vaccine Tracker App for Employees of an Organization\n");
                Console.WriteLine("1.Login\n2.Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        loginCheck(sqlConnection);
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Input, Enter valid Choice.");
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void loginCheck(SqlConnection sqlConnection)
        {
            try
            {
                while (true)
                {
                    bool flag = false;
                    sqlConnection.Open();
                    SqlDataReader reader;
                    Console.Clear();

                    Console.WriteLine("Enter Username:");
                    var username = Console.ReadLine();
                    string query = @"SELECT Username,IsAdmin,EmpId  from Employee where username = " + "'" + username + "'";
                    var cmd = new SqlCommand(query, sqlConnection);
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            flag = true;
                            Username = reader.GetString(0);
                            IsAdmin = reader.GetBoolean(1);
                            EmpId = reader.GetInt32(2);
                            //Console.WriteLine(Username + IsAdmin + EmpId);
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (IsAdmin)
                        {
                            var adminMenu = new AdminMenu();
                            sqlConnection.Close();
                            adminMenu.Amenu(sqlConnection, EmpId);
                            
                        }
                        else
                        {
                            var empMenu = new EmpMenu();
                            sqlConnection.Close();
                            empMenu.Emenu(sqlConnection, EmpId);
                            
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Enter valid Username, User doesn't exist.");
                        sqlConnection.Close();
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}

