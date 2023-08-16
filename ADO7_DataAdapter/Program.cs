using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.PortableExecutable;

namespace ADO7_DataAdapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(configuration.GetSection("constr").Value);

            var sql = "SELECT * FROM STUDENT2";

            

            // You need to use System.Data For this 
           // command.CommandType = CommandType.Text;

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            conn.Close();


          foreach(DataRow dr in  dt.Rows)
            {
                var item = new STUDENT2
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Name = Convert.ToString(dr["FIRSTNAME"]),
                };
                Console.WriteLine("[[[[" + item.ID+"///"+item.Name
                +"]]]]");
            }
            
        }
    }
}