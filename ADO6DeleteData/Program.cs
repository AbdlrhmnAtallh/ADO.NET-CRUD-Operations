using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ADO6DeleteData
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(configuration.GetSection("constr").Value);

         

            var sql = "DELETE FROM STUDENT2 " +
                $"WHERE ID = @ID";

            SqlParameter IDParameter = new SqlParameter
            {
                ParameterName = "@ID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = 11
            };


            SqlCommand command = new SqlCommand(sql, conn);

            command.CommandType = CommandType.Text;
            command.Parameters.Add(IDParameter);

            conn.Open();


            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($" Student  DELETED successfuly");
            }
            else
            {
                Console.WriteLine($"ERROR: Student");
            }

            conn.Close();
        }
    }
}