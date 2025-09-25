using System.Data;
using System.Data.SqlClient;
namespace Sql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sql sql = new Sql();
            //sql.ExecuteCommand("INSERT INTO Students VALUES ('Test','Testov',18)");

            //foreach(DataRow row in sql.ExecuteQuery("SELECT * FROM Student").Rows)
            //{
            //    Console.WriteLine(row["Name"]);
            //}
            StudentService service = new ();
            service.Add(new Student
            {
                Name = "Test2",
                Surname = "Testov2",
                Age = 19
            });
        }
    }
}
