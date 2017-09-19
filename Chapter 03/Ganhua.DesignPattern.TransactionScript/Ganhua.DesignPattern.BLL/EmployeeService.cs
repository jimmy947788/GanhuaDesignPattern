using Ganhua.DesignPattern.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.BLL
{
    public class EmployeeService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["HR"].ConnectionString;

        public static void CreateEmployee(string name, int holidayEntitlement)
        {
            string insertSql = "INSERT INTO Employees " +
                              "(Name, HolidayEntitlement) VALUES " +
                              "(@Name, @HolidayEntitlement); SELECT @@identity;";

            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;

                command.Parameters.Add(new SqlParameter("@Name", name));
                command.Parameters.Add(new SqlParameter("@HolidayEntitlement", holidayEntitlement));

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            string selectSql = "SELECT * FROM Employees;";

            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectSql;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                            HolidayEntitlement = int.Parse(reader["HolidayEntitlement"].ToString())
                        });
                    }
                }
            }

            return employees;
        }
    }
}
