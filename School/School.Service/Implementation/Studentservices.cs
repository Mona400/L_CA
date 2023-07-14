using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Abstracties;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Implementation
{
    public class Studentservices : IStudentServices
    {
        private readonly IStudentRepositories _studentRepositories;

        public Studentservices(IStudentRepositories studentRepositories)
        {
            _studentRepositories = studentRepositories;
        }

        public async Task<List<Student>> GetListStudentsAsync()
        {
            return await _studentRepositories.GetListStudentsAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = _studentRepositories.GetTableNoTracking()
                                             .Include(x => x.Department)
                                             .Where(s=>s.StudID==id)
                                             .FirstOrDefault();
            return student;
                                             
        }
    }
}
