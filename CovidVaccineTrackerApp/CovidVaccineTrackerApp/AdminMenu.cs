using System;
using System.Data.SqlClient;
using System.Threading;

namespace CovidVaccineTrackerApp
{
    class AdminMenu
    {
        public void Amenu(SqlConnection sqlConnection, int empId)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nEnter you choice: \n1.Enter Vaccine Status Info.\n2.Display Vaccine Status Info.\n3.Data Management\n4.Q&A.\n5.Back to the Main Menu.");
                var choice = Console.ReadLine();
                Console.Clear();
                var admin = new Admin();
                var login=new Login();

                switch (choice)
                {
                    case "1":
                        admin.VaccineStatus(sqlConnection, empId);
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                    case "2":
                        admin.DisplayVaccinationStatus(sqlConnection, empId);
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                    case "3":
                        
                        admin.DataManagement(sqlConnection);
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                    case "4":
                        admin.QandA();
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                    case "5":
                        login.MainPage(sqlConnection);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Enter valid choice");
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
