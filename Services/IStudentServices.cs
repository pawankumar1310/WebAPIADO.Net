using WebAPIADO.Net.Models;

namespace WebAPIADO.Net.Services
{
    public interface IStudentServices
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<Student> AddStudentsAsync(Student student);
        Task<Student> UpdateStudentsAsync(IEnumerable<Student> students);
        void DeleteStudentAsync(int studentId);
    }
}
