using System;
using System.Data.SqlClient;
using System.Threading;

namespace CovidVaccineTrackerApp
{
    class EmpMenu
    {
        public void Emenu(SqlConnection sqlConnection, int empId)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("\nEnter you choice: \n1.Enter Vaccine Status Info .\n2. Display Vaccine Status Info\n3.Q&A.\n4.Back to the Main Menu.");
                var choice = Console.ReadLine();
                Console.Clear();
                if (choice == null)
                {
                    Console.WriteLine("Enter valid choice.");
                }
                var employee = new Employee();
                var login=new Login();
                switch (choice)
                {
                    case "1":
                        employee.VaccineStatus(sqlConnection, empId);
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                    case "2":
                        employee.DisplayVaccinationStatus(sqlConnection, empId);
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                    case "3":
                        employee.QandA();
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                    case "4":
                        login.MainPage(sqlConnection);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Enter valid choice.");
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                } 
            }
        }
    }
}
