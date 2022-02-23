using System;
using System.Data.SqlClient;
using System.Threading;
namespace CovidVaccineTrackerApp
{
    class Admin : Employee
    {
        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-EC8T7UD\SQLEXPRESS;Initial Catalog=VaccineTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public bool IsAdmin { get; set; }
        //public DateTime Date_check()
        //{
        //    DateTime i = default;
        //    while (true)
        //    {
        //        var input = Console.ReadLine();
        //        var check = false;
        //        check = DateTime.TryParse(input, out i);
        //        if (check)
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Wrong INPut Type...Enter Date time");
        //        }
        //    }
        //    return i;
        //}
        
        void EmployeeNameUpdate(SqlConnection sqlConnection, int empId)
        {
            

            Console.WriteLine("Enter Updated Name  : ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                sqlConnection.Open();
                using (var adapter = new SqlDataAdapter())
                {
                    String sql = "";

                    name = "'" + name + "'";
                    sql = @"Update  Employee set EmpName =" + name + "  where EmpId = " + empId;

                    var cmd = new SqlCommand(sql, sqlConnection);
                    adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                    adapter.UpdateCommand.ExecuteNonQuery();

                    Console.WriteLine("Name Updated.\nPress Any key to return");
                    Console.ReadLine();
                    sqlConnection.Close();
                }
            }
            else
            {
                Console.WriteLine("Wrong Input Type.");
            }
        }
        void EmailIdUpdate(SqlConnection sqlConnection, int empId)
        {
            Console.WriteLine("Enter Updated Email : ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
            {
                sqlConnection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    String sql = "";

                    email = "'" + email + "'";
                    sql = @"update  Employee set Email = " + email + "where EmpId = " + empId;
                    var cmd = new SqlCommand(sql, sqlConnection);
                    adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                    adapter.UpdateCommand.ExecuteNonQuery();

                    Console.WriteLine("Email Updated.\nPress Any key to return");
                    Console.ReadLine();
                    sqlConnection.Close();
                }
            }
            else
            {
                Console.WriteLine("Wrong Input Type.");
            }
        }
        void ContactNoUpdate(SqlConnection sqlConnection, int empId)
        {
            Console.WriteLine("Enter Updated Contact Number : ");
            var contactNo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(contactNo))
            {
                sqlConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";

                contactNo = "'" + contactNo + "'";
                sql = @"update  Employee set ContacNo = " + contactNo + "where EmpId = " + empId;
                var cmd = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand.ExecuteNonQuery();

                sqlConnection.Close();

                Console.WriteLine("Contact Number Updated.\nPress Any key to return");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wrong Input Type.");
            }
        }
        void DepartmentUpdate(SqlConnection sqlConnection, int empId)
        {
            Console.WriteLine("Enter Updated Department of the Employee : ");
            var department = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(department))
            {
                sqlConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";

                department = "'" + department + "'";
                sql = @"update  Employee set Department = " + department + "where EmpId = " + empId;
                var cmd = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand.ExecuteNonQuery();

                sqlConnection.Close();

                Console.WriteLine("Department Updated.\nPress Any key to return");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wrong Input Type.");
            }
        }
        void CompanyUpdate(SqlConnection sqlConnection, int empId)
        {
            Console.WriteLine("Enter Updated Company of the Employee : ");
            var companyName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(companyName))
            {
                sqlConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";

                companyName = "'" + companyName + "'";
                sql = @"update  Employee set CompanyName = " + companyName + "where EmpId = " + empId;
                var cmd = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand.ExecuteNonQuery();

                sqlConnection.Close();

                Console.WriteLine("Company Updated.\nPress Any key to return");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wrong Input Type.");
            }
        }
        void VaccinationTypeUpdate(SqlConnection sqlConnection, int empId)
        {
            Console.WriteLine("Enter Updated vaccination type : ");
            var vaccineName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(vaccineName))
            {
                sqlConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";

                vaccineName = "'" + vaccineName + "'";
                sql = @"update  VaccinationStatus set VaccineName = " + vaccineName + "where EmpId = " + empId;

                var cmd = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand.ExecuteNonQuery();

                sqlConnection.Close();

                Console.WriteLine("Type of Vaccination Updated:\nPress Any key to return");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wrong Input Type.");
            }
        }
        void UpdateAdmin(SqlConnection sqlConnection, int empId)
        {
            sqlConnection.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string query = @"SELECT IsAdmin from Employee where EmpId = " + "'" + empId + "'";
            cmd = new SqlCommand(query, sqlConnection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                IsAdmin = reader.GetBoolean(0);
                //Console.WriteLine(Username + IsAdmin + EmpId);
                break;
            }
            if (IsAdmin == true)
            {
                Console.WriteLine("Employee is already an Admin.");
            }
            else
            {
                Console.WriteLine("Enter Updated Admin : ");
                var vaccineName = Console.ReadLine();

                sqlConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";

                
                sql = @"update VaccinationStatus set IsAdmin =  1  where EmpId = " + empId;

                cmd = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                adapter.UpdateCommand.ExecuteNonQuery();

                sqlConnection.Close();

                Console.WriteLine("Type of Vaccination Updated:\nPress Any key to return");
                Console.ReadLine();
            }
        }
        void FirstDoseUpdate(SqlConnection sqlConnection, int empId)
        {
            Console.WriteLine("Enter Updated First Dose Date (YYYY-MM-DD) : ");
            var fDate = Date_check1();
            fDate = Date_check2(fDate);

            sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string FDate = "'" + fDate + "'";
            sql = @"update  VaccinationStatus set FirstDose = " + FDate + "where EmpId = " + empId;

            var cmd = new SqlCommand(sql, sqlConnection);
            adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
            adapter.UpdateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            Console.WriteLine("First Dose Date of Vaccination Updated:\nPress Any key to return");
            Console.ReadLine();
        }
        void SecondDoseUpdate(SqlConnection sqlConnection, int empId)
        {
            Console.WriteLine("Enter Updated First Dose Date (YYYY-MM-DD) : ");
            var sDate = Date_check1();
            sDate = Date_check2(sDate);
            sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string SDate = "'" + sDate + "'";
            sql = @"update  VaccinationStatus set SecondDose = " + SDate + "where EmpId = " + empId;

            var cmd = new SqlCommand(sql, sqlConnection);
            adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
            adapter.UpdateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            Console.WriteLine("First Dose Date of Vaccination Updated:\nPress Any key to return");
            Console.ReadLine();
        }
        public void ViewData(SqlConnection sqlConnection, int empId)
        {
            //Console.WriteLine("HEl");
            //Thread.Sleep(5000);
            //SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-EC8T7UD\SQLEXPRESS;Initial Catalog=VaccineTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();
            SqlDataReader reader;
            String sql, Output = "";
           
            sql = @"Select Employee.EmpId, Employee.EmpName, Employee.Username, Employee.EmailId, Employee.ContacNo, Employee.Department,
            Employee.IsAdmin, Employee.CompanyName, VaccinationStatus.VaccineName, VaccinationStatus.Firstdose, VaccinationStatus.SecondDose from 
            Employee join VaccinationStatus on Employee.EmpId=VaccinationStatus.EmpId where Employee.EmpId=" + empId;
            var cmd = new SqlCommand(sql, sqlConnection);
            //Console.WriteLine("HEl");
            //Thread.Sleep(5000);
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Output = Output + "Employee Id: " + reader.GetValue(0) + "\n" + "Employee Name:  " + reader.GetValue(1) + "\n"
                        + "Username: " + reader.GetValue(2) + "\n" + "Email Id: " + reader.GetValue(3) + "\n" + "Contact Number: " +
                        reader.GetValue(4) + "\n" + "Department: " + reader.GetValue(5) + "\n" + "Employee is Admin or not: " + reader.GetValue(6) + "\n" +
                         "Company Name: " + reader.GetValue(7) + "\n" + "Name of the Vaccination: " + reader.GetValue(8) + "\n" + "Date of the First Dose: " + reader.GetValue(9) +
                        "\n" + "Date of the Second Dose:" + reader.GetValue(10);
                }
            }
            Console.WriteLine(Output);
            
            sqlConnection.Close();
        }
        void AlterData(SqlConnection sqlConnection, int empId)
        {
            while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Edit the Employee Information:\n1. Edit Employee Name\n2. Edit Email Id of the Employee\n" +
                        "3. Edit Contact Number of the Employee\n4. Edit Department of the Employee\n5. Change the Admin of the Company\n" +
                        "6. Edit the Company of the Employee\n7. Change the type of vaccination employee has taken\n8. Change the Date of the First Dose\n" +
                        "9. Change the date of the Second Dose\n10.Back to the previous menu. ");
                
                    var choice = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (choice)
                    {
                        case 1:
                            EmployeeNameUpdate(sqlConnection, empId);
                            break;
                        case 2:
                            EmailIdUpdate(sqlConnection, empId);
                            break;
                        case 3:
                            ContactNoUpdate(sqlConnection, empId);
                            break;
                        case 4:
                            DepartmentUpdate(sqlConnection, empId);
                            break;
                        case 5:
                            UpdateAdmin(sqlConnection, empId);
                            break;
                        case 6:
                            CompanyUpdate(sqlConnection, empId);
                            break;
                        case 7:
                            VaccinationTypeUpdate(sqlConnection, empId);
                            break;
                        case 8:
                            FirstDoseUpdate(sqlConnection, empId);
                            break;
                        case 9:
                            SecondDoseUpdate(sqlConnection, empId);
                            break;
                        case 10:
                            DataManagement(sqlConnection);
                            break;
                        default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice");
                        Console.WriteLine("Press Any Key to Continue....");
                        Console.ReadKey();
                        break;
                    }
                }  
        }
        public void DataManagement(SqlConnection sqlConnection)
        {
            
            SqlDataReader reader;
            
            while (true)
            {
                sqlConnection.Open();
                Console.WriteLine("Enter the Employee Id: ");
                int empId;
                var right = int.TryParse(Console.ReadLine(), out empId);
                if (right == true)
                {
                    string query = @"SELECT *  from Employee where EmpId = " + "'" + empId + "'";
                    var cmd = new SqlCommand(query, sqlConnection);
                    reader = cmd.ExecuteReader();
                    
                        if (reader.HasRows)
                        {
                            var adminMenu = new AdminMenu();
                            while (true)
                            {
                            Console.Clear();
                            Console.WriteLine("What you want to do:\n1.View the details of the employee\n2.Edit the details of the employee\n3.Back to the Previous Menu.");
                                var choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1":
                                        ViewData(sqlConnection, empId);
                                        //Console.WriteLine("Press Any Key to Continue....");
                                        //Console.ReadKey();
                                        break;
                                    case "2":
                                        AlterData(sqlConnection, empId);
                                        break;
                                    case "3":
                                        adminMenu.Amenu(sqlConnection, empId);
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
                        else
                        {
                            Console.WriteLine("Employee doesn't exist.");
                            //Console.WriteLine("Press Any Key to Continue....");
                            //Console.ReadKey();
                        }
                    
                }
                else
                {
                    Console.WriteLine("Wrong Employee Id.");
                    Console.WriteLine("Press Any Key to Continue....");
                    Console.ReadKey();
                    DataManagement(sqlConnection);
                }
                //sqlConnection.Close();
            }
            
        }
    }
}
