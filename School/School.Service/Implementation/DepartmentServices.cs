using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Abstracties;
using School.Service.Abstracts;

namespace School.Service.Implementation
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepositories _departmentRepositories;

        public DepartmentServices(IDepartmentRepositories departmentRepositories)
        {
            _departmentRepositories = departmentRepositories;
        }


        public async Task<Department> GetDepartmentById(int id)
        {
            var student = await _departmentRepositories.GetTableNoTracking().Where(x => x.DID.Equals(id))
                                                          .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
                                                          .Include(x => x.Instructors)
                                                          .Include(x => x.Instructor)
                                                          .FirstOrDefaultAsync();
            return student;
        }
    }
}
