using School.Data.Entities;

namespace School.Service.Abstracts
{
    public interface IDepartmentServices
    {
        public Task<Department> GetDepartmentById(int id);
    }
}
