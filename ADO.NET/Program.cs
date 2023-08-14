using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data;

namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            SqlConnection conn = new SqlConnection(configuration.GetSection("constr").Value);

            var sql = "SELECT * FROM TestCommandSchema.NEWNAME";

            SqlCommand command = new SqlCommand(sql, conn);

            command.CommandType = CommandType.Text;

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();
            Student student;
            while (reader.Read())
            {
                student = new Student
                {
                    ID = reader.GetInt32("ID"),
                    Name = reader.GetString("Name"),
                    PhoneNumber = reader.GetString("Phone Number"),
                    Email = reader.GetString("Email"),
                    Age = reader.GetInt32("Age")
                };
                Console.WriteLine(student);
            }

            conn.Close();
        }
    }
}