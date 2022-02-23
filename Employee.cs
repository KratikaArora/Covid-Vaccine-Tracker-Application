using System;
using System.Data.SqlClient;

namespace CovidVaccineTrackerApp
{
   
    class Employee : ICovidVaccineTracker
    {
        //public string VaccineName { get; set; }
        //public int EmployeeID { get; set; }
        public DateTime? FirstDose { get; set; }
        public DateTime? SecondDose { get; set; }
        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-EC8T7UD\SQLEXPRESS;Initial Catalog=VaccineTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static DateTime Date_check1()
        {
            DateTime i = default;
            while (true)
            {
                var input = (Console.ReadLine());
                var check = false;
                check = DateTime.TryParse(input, out i);
                if (check)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input Type...Enter valid Date time");
                }
            }
            return i;
        }
        public static DateTime Date_check2(DateTime i)
        { 
                var check = 0;
                check = DateTime.Compare(i, DateTime.Today);
                if (check <= 0)
                {
                    return i;
                }
                else
                {
                   Console.WriteLine("Date should not be of future.");
                }
            
            return i;
        }
        public void VaccineStatus(SqlConnection sqlConnection , int empId)
        {
            try
            {
                SqlCommand cmd;
                sqlConnection.Open();
                SqlDataReader reader;
                String query = @"SELECT FirstDose, SecondDose from VaccinationStatus where EmpId = " + "'" + empId + "'";
                cmd = new SqlCommand(query, sqlConnection);
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //if (reader.IsDBNull(reader.GetDateTime("FirstDose"))

                        FirstDose = reader.GetDateTime(0); 
                        SecondDose = reader.GetDateTime(1);
                        break;
                    }
                }
                if (FirstDose == null || SecondDose == null)
                {
                    Console.Clear();
                    Console.WriteLine("1.Is it your First Dose?\n2.Do you want to update your Second Dose?\n3.Do you want to update the dates of both First Dose and Second Dose details?");
                    var choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Which of the vaccine you have taken:\n1.Covishield 2.Covaxine ");
                        var choiceofVaccine = Console.ReadLine();

                        
                        //sqlConnection.Open();
                        //Define variables
                        if (choiceofVaccine == "1")
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter())
                            {
                                Console.WriteLine("Enter Date of your First Dose (YYYY-MM-DD): ");
                                var fDate = Date_check1();
                                fDate = Date_check2(fDate);
                                String sql = "";
                                string FDate = "'" + fDate + "'";
                                const string vaccineName = "Covishield";
                                sql = @"insert into VaccinationStatus (EmpId, VaccineName, FirstDose) values (" + empId + "," + "'" + vaccineName + "'" + "," + FDate + ") ";
                                cmd = new SqlCommand(sql, sqlConnection);
                                adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                //sqlConnection.Close();
                            }
                        }
                        else if(choiceofVaccine == "2")
                        {
                            using(SqlDataAdapter adapter = new SqlDataAdapter())
                            {
                                Console.WriteLine("Enter Date of your First Dose (YYYY-MM-DD): ");
                                var fDate = Date_check1();
                                fDate = Date_check2(fDate);
                                String sql = "";
                                string FDate = "'" + fDate + "'";
                                const string vaccineName = "Covaxin";
                                sql = @"insert into VaccinationStatus (EmpId, VaccineName, FirstDose) values (" + empId + "," + "'" + vaccineName + "'" + "," + FDate + ") ";
                                cmd = new SqlCommand(sql, sqlConnection);
                                adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                //sqlConnection.Close();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enter valid option, No such vaccine exists.");
                        }
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter Date of your Second Dose (YYYY-MM-DD): ");
                        var sDate = Date_check1();
                        sDate = Date_check2(sDate);
                        //sqlConnection.Open();
                        //Define variables

                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            String sql = "";
                            string SDate = "'" + sDate + "'";

                            sql = @"insert into VaccinationStatus (EmpId, SecondDose) values (" + empId + "," + SDate + ") ";
                            cmd = new SqlCommand(sql, sqlConnection);
                            adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                            adapter.InsertCommand.ExecuteNonQuery();
                            //sqlConnection.Close();
                        }
                    }
                    else if (choice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the name of the Vaccine:\n1.Covishield 2.Covaxine ");
                        var choiceOfVaccine = Console.ReadLine();

                        
                        //sqlConnection.Open();
                        //Define variables
                        if (choiceOfVaccine == "1")
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter())
                            {
                                Console.WriteLine("Enter Date of your First Dose (YYYY-MM-DD): ");
                                var fDate = Date_check1();
                                fDate = Date_check2(fDate);
                                Console.WriteLine("Enter Date of your Second Dose (YYYY-MM-DD): ");
                                var sDate = Date_check1();
                                sDate = Date_check2(sDate);
                                String sql = "";
                                string FDate = "'" + fDate + "'";
                                const string vaccineName = "Covishield";
                                string SDate = "'" + sDate + "'";
                                sql = @"insert into VaccinationStatus (EmpId, VaccineName, FirstDose, SecondDose) values (" + empId + "," + "'" + vaccineName + "'" + "," + FDate + "," + SDate + ") ";
                                cmd = new SqlCommand(sql, sqlConnection);
                                adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                //sqlConnection.Close();
                            }
                        }
                        else if(choiceOfVaccine == "2")
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter())
                            {
                                Console.WriteLine("Enter Date of your First Dose (YYYY-MM-DD): ");
                                var fDate = Date_check1();
                                fDate = Date_check2(fDate);
                                Console.WriteLine("Enter Date of your Second Dose (YYYY-MM-DD): ");
                                var sDate = Date_check1();
                                sDate = Date_check2(sDate);
                                String sql = "";
                                string FDate = "'" + fDate + "'";
                                const string vaccineName =  "Covaxin" ;
                                string SDate = "'" + sDate + "'";
                                sql = @"insert into VaccinationStatus (EmpId, VaccineName, FirstDose, SecondDose) values (" + empId + "," + "'" + vaccineName + "'" + "," + FDate + "," + SDate + ") ";
                                cmd = new SqlCommand(sql, sqlConnection);
                                adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                                adapter.InsertCommand.ExecuteNonQuery();
                                //sqlConnection.Close();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enter valid option, No such vaccine exists.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice");
                    }
                }
                else
                {
                    Console.WriteLine("You have already entered your details.");
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
        public void DisplayVaccinationStatus(SqlConnection sqlConnection , int empId)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand cmd;
                SqlDataReader reader;
                String sql, Output = "";

                sql = @"Select Vaccinename, FirstDose, SecondDose from VaccinationStatus where EmpId=" + empId;

                cmd = new SqlCommand(sql, sqlConnection);
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Output = Output + "\nVaccine Name: " + reader.GetValue(0) + "\nFirst Dose: " + reader.GetValue(1) + "\nSecond Dose: " + reader.GetValue(2) + "\n";
                        // reader.Close();
                        break;
                    }
                }
                Console.Write(Output);
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void QandA()
        {
            
            Console.WriteLine("Q. What are the different Vaacines available in India?");
            Console.WriteLine("A. 1.Covishield\n2.Covaccine");
            Console.WriteLine("Q. What is the time period between first dose and second dose of Covishield?");
            Console.WriteLine("A. 84 days.");
            Console.WriteLine("Q. What is the time period between first dose and second dose of Covaccine?");
            Console.WriteLine("A. 30 days.");
            
        }
    }
}
