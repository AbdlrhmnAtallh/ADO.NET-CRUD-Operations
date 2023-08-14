using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO3
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
                Name = "XYZ"
            };

            var sql = "INSERT INTO STUDENT2(FIRSTNAME) VALUES (@FIRSTNAME)";

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

            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($" Student {student.Name} Added successfuly");
            }
            else
            {
                Console.WriteLine($"ERROR: Student {student.Name}");
            }

            conn.Close();
            /// This project will give the value only for Name varible
            /// and the id is 0 as it was 
             
        }
    }
}