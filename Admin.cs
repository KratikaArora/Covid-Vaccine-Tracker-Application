using System;
using System.Data.SqlClient;
using System.Threading;
namespace CovidVaccineTrackerApp
{
    class Admin : Employee
    {
        public bool IsAdmin { get; set; }
   
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
            var fDate = Date_check();
            fDate = Date_check(fDate);

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
            var sDate = Date_check();
            sDate = Date_check(sDate);
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
        public void ViewAllData(SqlConnection sqlConnection, int empId)
        {
            sqlConnection.Open();
            SqlDataReader reader;
            String sql, Output = "";

            sql = @"Select Employee.EmpId, Employee.EmpName, Employee.Username, Employee.EmailId, Employee.ContacNo, Employee.Department,
            Employee.IsAdmin, Employee.CompanyName, VaccinationStatus.VaccineName, VaccinationStatus.Firstdose, VaccinationStatus.SecondDose from 
            Employee join VaccinationStatus on Employee.EmpId=VaccinationStatus.EmpId where Employee.EmpId=" + empId;
            var cmd = new SqlCommand(sql, sqlConnection);

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
        public void ViewCovishieldData(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            SqlDataReader reader;
            int count=0;
            String sql, Output = "";
            const string vaccineName = "Covishield";
            sql = @"select EmpId from VaccinationStatus where VaccineName = " + "'" + vaccineName + "'";
            var cmd = new SqlCommand(sql, sqlConnection);
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                        Output=Output + "\n" + "Employee Id: " + reader.GetValue(0) + "\n"; 
                        count++;
                }
            }
            Console.WriteLine(Output);
            Console.WriteLine("Number of Employees who has taken Covishield Vaccine: " + count);
            sqlConnection.Close();
        }
        public void ViewCovaxinData(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            SqlDataReader reader;
            int count = 0;
            String sql, Output = "";
            const string vaccineName = "Covaxin";
            sql = @"select EmpId from VaccinationStatus where VaccineName = " + "'" + vaccineName + "'";
            var cmd = new SqlCommand(sql, sqlConnection);
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Output = Output + "\n" + "Employee Id: " + reader.GetValue(0) + "\n";
                    count++;
                }
            }
            Console.WriteLine(Output);
            Console.WriteLine("Number of Employees who has taken Covaxin Vaccine: " + count);
            sqlConnection.Close();
        }
        public void ViewNoDoseData(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            SqlDataReader reader;
            int count = 0;
            String sql, Output = "";

            sql = @"select EmpId from VaccinationStatus Where FirstDose is Null and SecondDose is Null";
            var cmd = new SqlCommand(sql, sqlConnection);
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Output = Output + "\n" + "Employee Id: " + reader.GetValue(0) + "\n";
                    count++;
                }
            }
            Console.WriteLine(Output);
            Console.WriteLine("Number of Employees who has not taken any Vaccination Dose: " + count);
            sqlConnection.Close();
        }
        public void ViewFirstDoseData(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            SqlDataReader reader;
            int count = 0;
            String sql, Output = "";

            sql = @"select EmpId from VaccinationStatus Where FirstDose is Not Null and SecondDose is Null";
            var cmd = new SqlCommand(sql, sqlConnection);
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Output = Output + "\n" + "Employee Id: " + reader.GetValue(0) + "\n";
                    count++;
                }
            }
            Console.WriteLine(Output);
            Console.WriteLine("Number of Employees who has taken only one Vaccination Dose: " + count);
            sqlConnection.Close();
        }
        public void ViewSecondDoseData(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            SqlDataReader reader;
            int count = 0;
            String sql, Output = "";
            
            sql = @"select EmpId from VaccinationStatus Where SecondDose is Not Null" ;
            var cmd = new SqlCommand(sql, sqlConnection);
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Output = Output + "\n" + "Employee Id: " + reader.GetValue(0) + "\n";
                    count++;
                }
            }
            Console.WriteLine(Output);
            Console.WriteLine("Number of Employees who has taken both the Vaccination Doses: " + count);
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
                            Console.WriteLine("Enter Your Choice:\n1.Do you want to see all data of the employee.\n2.Do you want to see how many employees has taken covishield.\n3.Do you want to see how many employees has taken covaxin.\n4.Number of Employees who has not taken any Vaccine Dose.\n5.Do you want to see how many employee has taken only one vaccine dose.\n6.Do you want to see how many employees has taken both doses of vaccine.\n7.Edit the details of the employee\n8.Return to the previous Menu."); 
                                var choice = Console.ReadLine();
                                switch (choice)
                                {
                                case "1":
                                    sqlConnection.Close();
                                    ViewAllData(sqlConnection, empId);
                                    Console.WriteLine("Press Any Key to Continue....");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    sqlConnection.Close();
                                    ViewCovishieldData(sqlConnection);
                                    Console.WriteLine("Press Any Key to Continue....");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    sqlConnection.Close();
                                    ViewCovaxinData(sqlConnection);
                                    Console.WriteLine("Press Any Key to Continue....");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    sqlConnection.Close();
                                    ViewNoDoseData(sqlConnection);
                                    Console.WriteLine("Press Any Key to Continue....");
                                    Console.ReadKey();
                                    break;
                                case "5":
                                    sqlConnection.Close();
                                    ViewFirstDoseData(sqlConnection);
                                    Console.WriteLine("Press Any Key to Continue....");
                                    Console.ReadKey();
                                    break;
                                case "6":
                                    sqlConnection.Close();
                                    ViewSecondDoseData(sqlConnection);
                                    Console.WriteLine("Press Any Key to Continue....");
                                    Console.ReadKey();
                                    break;
                                case "7":
                                    sqlConnection.Close();
                                    AlterData(sqlConnection, empId);
                                    Console.WriteLine("Press Any Key to Continue....");
                                    Console.ReadKey();
                                    break;
                                case "8":
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
