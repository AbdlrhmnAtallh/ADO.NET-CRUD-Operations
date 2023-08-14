using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data;
namespace ADO2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(configuration.GetSection("constr").Value);

            var sql = "SELECT * FROM STUDENT2";

            SqlCommand command = new SqlCommand(sql, conn);

            // You need to use System.Data For this 
            command.CommandType = CommandType.Text;

            conn.Open();


            SqlDataReader reader = command.ExecuteReader();

            STUDENT2 Xstudent2;

            while (reader.Read())
            {
                Xstudent2 = new STUDENT2
                {
                    // You need to use System.Data For this 
                    ID = reader.GetInt32("ID"),
                    FNAME = reader.GetString("FIRSTNAME"),
                };
                Console.WriteLine(Xstudent2);
            }
            conn.Close();
        }
    }
}