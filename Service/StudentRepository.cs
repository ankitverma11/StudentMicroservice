using StudentService.Model;
using System.Reflection;

namespace StudentService.Service
{
    public class StudentRepository : List<Model.Student>, IStudentRepository
    {
        private readonly static List<Model.Student> _students = StudentsSeed();

        private static List<Student> StudentsSeed()
        {
            var result = new List<Model.Student>()
            {
                new Student
                {
                    Id = 1,
                    Name = "Ankit",
                    School = "ST Fort"                    
                },
                new Student
                {
                    Id = 2,
                    Name = "Gaurav",
                    School = "Secret Heart"
                },
                new Student {
                    Id = 3, 
                    Name = "Manoj", 
                    School = "GIC"
                },
                new Student {
                    Id = 4,
                    Name = "Ankur",
                    School = "Bachpan"
                }

            };

            return result;
        }

        public Student Get(int id)
        {
            return _students[id];
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public async Task Create(Student student)
        {
            _students.Add(student);
        }

        public async Task Update(int id, Student student)
        {
             _students.Remove(_students.First(x => x.Id == id));
            _students.Add(student);
        }

        public async Task Delete(int id)
        {
            _students.Remove(_students.First(x => x.Id == id));
        }
    }
}
