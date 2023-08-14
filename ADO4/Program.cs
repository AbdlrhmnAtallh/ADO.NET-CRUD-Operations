using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ADO4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(configuration.GetSection("constr").Value);

            STUDENT2 student = new STUDENT2
            {
                Name = "ADO4"
            };

            var sql = "INSERT INTO STUDENT2(FIRSTNAME) VALUES (@FIRSTNAME);" +
                "SELECT CAST (scope_identity() AS INT)";

            SqlParameter NameParameter = new SqlParameter
            {
                ParameterName = "@FIRSTNAME",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = student.Name
            };


            SqlCommand command = new SqlCommand(sql, conn);

            command.CommandType = CommandType.Text;
            command.Parameters.Add(NameParameter);

            conn.Open();

            student.ID =(int) command.ExecuteScalar();

            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($" Student [{student.ID}]  {student.Name} Added successfuly");
            }
            else
            {
                Console.WriteLine($"ERROR: Student {student.Name}");
            }

            conn.Close();
        }
    }
}