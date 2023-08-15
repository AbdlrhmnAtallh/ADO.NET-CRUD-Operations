using Microsoft.Extensions.Configuration.Json;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace ADO5UpdateData
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
                Name = "UPDATED FROM ADO5"
            };

            var sql = "UPDATE STUDENT2 SET FIRSTNAME = @FIRSTNAME " +
                "WHER ID = @ID";

            SqlParameter IDParameter = new SqlParameter
            {
                ParameterName = "@ID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = 1
            };


            SqlParameter NameParameter = new SqlParameter
            {
                ParameterName = "@FIRSTNAME",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = "qq"
            };


            SqlCommand command = new SqlCommand(sql, conn);

            command.CommandType = CommandType.Text;
            command.Parameters.Add(IDParameter);
            command.Parameters.Add(NameParameter);

            conn.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($" Student {student.Name} Added successfuly");
            }
            else
            {
                Console.WriteLine($"ERROR: Student {student.Name}");
            }

            conn.Close();
           

        }
    }
}