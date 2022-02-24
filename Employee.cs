using System;
using System.Data.SqlClient;

namespace CovidVaccineTrackerApp
{
   
    class Employee : ICovidVaccineTracker
    {
        public string VaccineName { get; set; }
        //public int EmployeeID { get; set; }
        public DateTime FirstDose { get; set; }
        public DateTime? SecondDose { get; set; }
        public static DateTime Date_check()
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
        public static DateTime Date_check(DateTime i)
        { 
                var check = false;
                DateTime j = default;
                check = (DateTime.Compare(i, DateTime.Today))<=0;
                if (check)
                {
                    return i;
                }
                else
                {
                   Console.WriteLine("Date should not be of future.");
                   return j;
                }
        }
        public void VaccineStatus(SqlConnection sqlConnection , int empId)
        {
            try
            {
                SqlCommand cmd, cmd1, cmd2, cmd3;
                sqlConnection.Open();
                SqlDataReader reader, reader1, reader2, reader3;
                String query = @"SELECT VaccineName,  SecondDose from VaccinationStatus where EmpId = " + "'" + empId + "'";
                cmd = new SqlCommand(query, sqlConnection);
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    { 
                        
                        if (!reader.IsDBNull(0))
                        {
                            VaccineName = reader.GetString(0);
                        }
                        else
                        {
                            VaccineName = null;
                        }
                        if (!reader.IsDBNull(1))
                        {
                            SecondDose = reader.GetDateTime(1);
                        }
                        else
                        {
                            SecondDose = null;
                        }
                        break;
                    }
                }
                        if (VaccineName == null)
                        {
                        Console.Clear();
                        Console.WriteLine("1.Is it your First Dose?\n2.Do you want to update the dates of both First Dose and Second Dose details?");
                        var choice1 = Convert.ToInt32(Console.ReadLine());
                        if (choice1 == 1)
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
                                    DateTime fDate = Date_check();
                                    fDate = Date_check(fDate);
                                    String sql = "";
                                    string FDate = "'" + fDate + "'";
                                    const string vaccineName = "Covishield";
                                sql = @"update VaccinationStatus set VaccineName = " + "'" + vaccineName + "' , FirstDose = " +  FDate + " where EmpId =" + empId;  
                                    cmd = new SqlCommand(sql, sqlConnection);
                                    adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                                    adapter.UpdateCommand.ExecuteNonQuery();
                                sqlConnection.Close();
                            }
                            }
                            else if (choiceofVaccine == "2")
                            {
                                using (SqlDataAdapter adapter = new SqlDataAdapter())
                                {
                                    Console.WriteLine("Enter Date of your First Dose (YYYY-MM-DD): ");
                                    var fDate = Date_check();
                                    fDate = Date_check(fDate);
                                    String sql = "";
                                    string FDate = "'" + fDate + "'";
                                    const string vaccineName = "Covaxin";
                                    sql = @"update VaccinationStatus set VaccineName = " + "'" + vaccineName + "' , FirstDose = "  + FDate + " where EmpId =" + empId;
                                cmd = new SqlCommand(sql, sqlConnection);
                                    adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                                    adapter.UpdateCommand.ExecuteNonQuery();
                                sqlConnection.Close();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter valid option, No such vaccine exists.");
                            }
                        }
                        else if (choice1 == 2)
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
                                    var fDate = Date_check();
                                    fDate = Date_check(fDate);
                                    Console.WriteLine("Enter Date of your Second Dose (YYYY-MM-DD): ");
                                    var sDate = Date_check();
                                    sDate = Date_check(sDate);
                                
                                String query2 = @"SELECT FirstDose from VaccinationStatus where EmpId = " + "'" + empId + "'";
                                cmd2 = new SqlCommand(query2, sqlConnection);
                                using (reader2 = cmd2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        if (!reader2.IsDBNull(0))
                                        {
                                            FirstDose = reader2.GetDateTime(0);
                                        }
                                        else 
                                        { 
                                            FirstDose = default; 
                                        }
                                    }
                                }

                                if (DateTime.Compare(FirstDose, sDate) < 0)
                                {
                                    String sql = "";
                                    string FDate = "'" + fDate + "'";
                                    const string vaccineName = "Covishield";
                                    string SDate = "'" + sDate + "'";
                                    sql = @"update VaccinationStatus set VaccineName = " + "'" + vaccineName + "' , FirstDose = " +  FDate + " , SecondDose = " +  SDate + " where EmpId =" + empId;
                                    cmd = new SqlCommand(sql, sqlConnection);
                                    adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                                    adapter.InsertCommand.ExecuteNonQuery();
                                    sqlConnection.Close();
                                }
                                }
                            }
                            else if (choiceOfVaccine == "2")
                            {
                                using (SqlDataAdapter adapter = new SqlDataAdapter())
                                {
                                    Console.WriteLine("Enter Date of your First Dose (YYYY-MM-DD): ");
                                    var fDate = Date_check();
                                    fDate = Date_check(fDate);
                                    Console.WriteLine("Enter Date of your Second Dose (YYYY-MM-DD): ");
                                    var sDate = Date_check();
                                    sDate = Date_check(sDate);
                                    String query3 = @"SELECT FirstDose from VaccinationStatus where EmpId = " + "'" + empId + "'";
                                    cmd3 = new SqlCommand(query3, sqlConnection);
                                    using (reader3 = cmd3.ExecuteReader())
                                {
                                    while (reader3.Read())
                                    {
                                        if (!reader3.IsDBNull(0))
                                        {
                                            FirstDose = reader3.GetDateTime(0);
                                        }
                                        else
                                        {
                                            FirstDose = default;
                                        }
                                    }
                                }

                                if (DateTime.Compare(FirstDose, sDate) < 0)
                                {
                                    String sql = "";
                                    string FDate = "'" + fDate + "'";
                                    const string vaccineName = "Covaxin";
                                    string SDate = "'" + sDate + "'";
                                    sql = @"update VaccinationStatus set VaccineName = " + "'" + vaccineName + "' , FirstDose = " +  FDate + " , SecondDose = " +  SDate + " where EmpId =" + empId;
                                    cmd = new SqlCommand(sql, sqlConnection);
                                    adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                                    adapter.InsertCommand.ExecuteNonQuery();
                                    sqlConnection.Close();
                                }
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
                    else if( VaccineName != null && SecondDose == null )
                    {
                        Console.Clear();
                        Console.WriteLine("Update your Second Dose as you have already added your first dose details?\n");
                       
                        Console.WriteLine("Enter Date of your Second Dose (YYYY-MM-DD): ");
                        var sDate = Date_check();
                        sDate = Date_check(sDate);
                        String query1 = @"SELECT FirstDose from VaccinationStatus where EmpId = " + "'" + empId + "'";
                        cmd1 = new SqlCommand(query1, sqlConnection);
                        using (reader1 = cmd1.ExecuteReader())
                        {
                        while (reader1.Read())
                        {
                            if (!reader1.IsDBNull(0))
                            {
                                FirstDose = reader1.GetDateTime(0);
                            }
                            else
                            {
                                FirstDose = default;
                            }
                        }
                    }

                    if (DateTime.Compare(FirstDose, sDate) < 0)
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            String sql = "";
                            string SDate = "'" + sDate + "'";
                            sql = @"update  VaccinationStatus set SecondDose = " + SDate + "where EmpId = " + empId;
                            cmd = new SqlCommand(sql, sqlConnection);
                            adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                            adapter.InsertCommand.ExecuteNonQuery();
                            //sqlConnection.Close();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Second Dose should be before First Dose date");
                    }
                }
                else
                {
                    Console.WriteLine("You have already entered your details.");
                    DisplayVaccinationStatus(sqlConnection, empId);
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
                        if (!reader.IsDBNull(0))
                        {
                            Output = Output + "\nVaccine Name: " + reader.GetValue(0) + "\nFirst Dose: " + reader.GetValue(1) + "\nSecond Dose: " + reader.GetValue(2) + "\n";
                            // reader.Close();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You have not entered your Vaccination Details.");
                        }
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
