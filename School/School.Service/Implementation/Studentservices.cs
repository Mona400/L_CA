using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Abstracties;
using School.Service.Abstracts;

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
                                             .Where(s => s.StudID == id)
                                             .FirstOrDefault();
            return student;

        }
        public async Task<string> AddAsync(Student student)
        {
            var studentResult = _studentRepositories.GetTableNoTracking()
                                                  .Where(x => x.Name.Equals(student.Name))
                                                  .FirstOrDefault();
            if (studentResult != null)
            {
                return "Exist";
            }
            await _studentRepositories.AddAsync(student);
            return "Add Successfully";
        }
        public async Task<bool> IsNameExist(string name)
        {
            //Check if the name is exist or Not
            var student = _studentRepositories.GetTableNoTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
            if (student == null)
                return false;
            return true;

        }
        public async Task<bool> IsNameExistExecuteSelf(string name, int id)
        {
            //Check if the name is exist or Not
            var student = await _studentRepositories.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null)
                return false;
            return true;
        }
        public async Task<string> EditAsync(Student student)
        {
            await _studentRepositories.UpdateAsync(student);
            return "Success";

        }
    }
}
