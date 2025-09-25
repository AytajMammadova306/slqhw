using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sql
{
    internal class StudentService
    {
        private static Sql _sql = new Sql();

        public void Add(Student student)
        {
            int result=_sql.ExecuteCommand($"INSERT INTO Students VALUES ('{student.Name}','{student.Surname}',{student.Age})");
            if (result > 0)
            {
                Console.WriteLine("Complited Succesfully");
            }
            else { Console.WriteLine("Error Occured"); }
        }

        public List<Student> GetAll()
        {
            DataTable table = _sql.ExecuteQuery("SELECT * FROM Students");
            List<Student> students = new();
            foreach (DataRow row in table.Rows)
            {
                students.Add(new Student
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    Age = (int)row["Age"],

                });
            }
            return students;
        }


        public Student GetId(int id)
        {
            DataTable table = _sql.ExecuteQuery("SELECT * FROM Students");
            Student student = new();
            foreach (DataRow row in table.Rows)
            {
                student=new Student
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    Age = (int)row["Age"],

                };
            }
            return student;
        }

        public void Remove(int id)
        {
            _sql.ExecuteCommand($"DELETE FROM Students WHERE Id={id}");
        }

        public void Update(Student student)
        {
            Remove(student.Id);
            Add(student);
        }
    }
}
