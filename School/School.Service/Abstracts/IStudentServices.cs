using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Abstracts
{
    public interface IStudentServices
    {
        public Task<List<Student>> GetListStudentsAsync();
        public  Task<Student>GetStudentByIdAsync(int id);
    }
}
