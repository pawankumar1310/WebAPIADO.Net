using Microsoft.AspNetCore.Mvc;
using WebAPIADO.Net.Models;
using WebAPIADO.Net.Services;

namespace WebAPIADO.Net.Helper
{
    public class StudentService : IStudentServices
    {
        Task<Student> IStudentServices.AddStudentsAsync(Student student)
        {
            throw new NotImplementedException();
        }

        void IStudentServices.DeleteStudentAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        Task<Student> IStudentServices.GetStudentByIdAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Student>> IStudentServices.GetStudentsAsync()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        Task<Student> IStudentServices.UpdateStudentsAsync(IEnumerable<Student> students)
        {
            throw new NotImplementedException();
        }
    }
}
