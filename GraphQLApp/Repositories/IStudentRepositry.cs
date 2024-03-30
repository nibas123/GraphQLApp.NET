using GraphQLApp.Models;

namespace GraphQLApp.Repositories
{
    public interface IStudentRepositry
    {
        Task<bool> AddStudentAsync(Students Students);
        Task<bool> DeleteStudentAsync(int StudentId);
        Task<Students> GetStudentDetailByIdAsync(int StudentId);
        Task<List<Students>> StudentListAsync();
        Task<bool> UpdateStudentAsync(Students Students);
    }
}