using GraphQLApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApp.Repositories
{
    public class StudentRepositry : IStudentRepositry
    {

        private readonly StudentDbContext StudentDbContext;

        public StudentRepositry(StudentDbContext StudentDbContext)
        {
            this.StudentDbContext = StudentDbContext;
        }

        public async Task<List<Students>> StudentListAsync()
        {
            return await StudentDbContext.Students.ToListAsync();
        }

        public async Task<Students> GetStudentDetailByIdAsync(int StudentId)
        {
            return await StudentDbContext.Students.Where(ele => ele.Id == StudentId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddStudentAsync(Students Students)
        {
            try
            {
                await StudentDbContext.Students.AddAsync(Students);
                var result = await StudentDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> UpdateStudentAsync(Students Students)
        {
            var isStudent = StudentsExists(Students.Id);
            if (isStudent)
            {
                StudentDbContext.Students.Update(Students);
                var result = await StudentDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteStudentAsync(int StudentId)
        {
            var findStudentData = StudentDbContext.Students.Where(_ => _.Id == StudentId).FirstOrDefault();
            if (findStudentData != null)
            {
                StudentDbContext.Students.Remove(findStudentData);
                var result = await StudentDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool StudentsExists(int StudentId)
        {
            return StudentDbContext.Students.Any(e => e.Id == StudentId);
        }
    }
}
