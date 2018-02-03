using Ganhua.QueryObject.Infrastructure.Query;
using Ganhua.QueryObject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.QueryObject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Order> FindBy(Query query)
        {
            // Move to method below with Index and count

            IList<Order> orders = new List<Order>();

            using (SqlConnection connection =
                      new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                query.TranslateInto(command);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            CustomerId = new Guid(reader["CustomerId"].ToString()),
                            OrderDate = DateTime.Parse(reader["OrderDate"].ToString()),
                            Id = new Guid(reader["Id"].ToString())
                        });

                    }
                }
            }

            return orders;
        }

        public IEnumerable<Order> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }
    }
}
