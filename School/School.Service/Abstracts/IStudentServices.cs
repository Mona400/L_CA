using School.Data.Entities;

namespace School.Service.Abstracts
{
    public interface IStudentServices
    {
        public Task<List<Student>> GetListStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);
    }
}
