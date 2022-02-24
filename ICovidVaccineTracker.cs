using System.Data.SqlClient;
namespace CovidVaccineTrackerApp
{
    public interface ICovidVaccineTracker
    {
        void VaccineStatus(SqlConnection sqlConnection , int empId);
        void DisplayVaccinationStatus(SqlConnection sqlConnection , int empId);
        void QandA();
        
    }
}
