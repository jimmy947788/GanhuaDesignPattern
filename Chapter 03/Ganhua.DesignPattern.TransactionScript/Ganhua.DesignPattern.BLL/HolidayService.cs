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
    public class HolidayService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["HR"].ConnectionString;

        public static bool BookHolidayFor(int employeeId, DateTime From, DateTime To)
        {
            bool booked = false;
            TimeSpan numberOfDaysRequestedForHoliday = To - From;

            //檢查使用者亂選日期
            if (numberOfDaysRequestedForHoliday.Days > 0)
            {
                //要求假期不與現有假期衝突
                if (RequestHolidayDoesNotClashWithExistingHoliday(employeeId, From, To))
                {
                    //取得可休假天數
                    int holidayAvailable = GetHolidayRemainingFor(employeeId);

                    //檢查休假天數是否合理
                    if (holidayAvailable >= numberOfDaysRequestedForHoliday.Days)
                    {
                        //保存資料
                        SumitHolidayBookingFor(employeeId, From, To);
                        booked = true;
                    }
                }
            }

            return booked;
        }

        private static int GetHolidayRemainingFor(int employeeId)
        {
            List<BookedLeave> bookedLeave = GetBookedLeaveFor(employeeId);

            int daysTaken = bookedLeave.Sum(hol => hol.DaysTaken);
            int holidayEntitlement = GetHolidayEntitlementFor(employeeId);

            int daysRemaining = holidayEntitlement - daysTaken;

            return daysRemaining;
        }

        public static List<Employee> GetAllEmployeesOnLeaveBetween(DateTime From, DateTime To)
        {
            // ... Example of Transaction Script Method ...
            throw new NotImplementedException();
        }

        public static List<Employee> GetAllEmployeesWithHolidayRemaing()
        {
            // ... Example of Transaction Script Method ...
            throw new NotImplementedException();
        }

        private static bool RequestHolidayDoesNotClashWithExistingHoliday(int employeeId, DateTime From, DateTime To)
        {
            return true;
        }

        // Data Access methods

        private static void SumitHolidayBookingFor(int employeeId, DateTime From, DateTime To)
        {
            string insertSql = "INSERT INTO Holidays (EmployeeId, LeaveFrom, LeaveTo) VALUES " +
                               "(@EmployeeId, @LeaveFrom, @LeaveTo);";

            using (SqlConnection connection =
                 new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;

                command.Parameters.Add(new SqlParameter("@EmployeeId", employeeId));
                command.Parameters.Add(new SqlParameter("@LeaveFrom", From));
                command.Parameters.Add(new SqlParameter("@LeaveTo", To));

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static List<BookedLeave> GetBookedLeaveFor(int employeeId)
        {
            List<BookedLeave> bookedLeave = new List<BookedLeave>();

            string selectSql = "SELECT * FROM Holidays WHERE EmployeeId = @EmployeeId;";

            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectSql;
                command.Parameters.Add(new SqlParameter("@EmployeeId", employeeId));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookedLeave.Add(new BookedLeave
                        {
                            From = DateTime.Parse(reader["LeaveFrom"].ToString()),
                            To = DateTime.Parse(reader["LeaveTo"].ToString()),
                            DaysTaken = ((TimeSpan)(DateTime.Parse(reader["LeaveTo"].ToString()) - DateTime.Parse(reader["LeaveFrom"].ToString()))).Days
                        });
                    }
                }
            }

            return bookedLeave;
        }

        private static int GetHolidayEntitlementFor(int employeeId)
        {
            string selectSql = "SELECT HolidayEntitlement FROM Employees WHERE Id = @EmployeeId;";

            int holidayEntitlement = 0;

            using (SqlConnection connection =
                 new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectSql;

                command.Parameters.Add(new SqlParameter("@EmployeeId", employeeId));

                connection.Open();

                holidayEntitlement = int.Parse(command.ExecuteScalar().ToString());
            }

            return holidayEntitlement;
        }
    }
}
