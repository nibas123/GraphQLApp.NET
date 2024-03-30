using GraphQLApp.Models;
using GraphQLApp.Repositories;

namespace GraphQLApp.GraphQL.MutationTypes
{
    public class StudentMutation
    {
        public async Task<bool> AddStudentsAsync([Service] IStudentRepositry Studentrepo,Students StudentsDetails)
        {
            return await Studentrepo.AddStudentAsync(StudentsDetails);
        }

        public async Task<bool> UpdateStudentsAsync([Service] IStudentRepositry Studentrepo, Students StudentsDetails)
        {
            return await Studentrepo.UpdateStudentAsync(StudentsDetails);
        }

        public async Task<bool> DeleteStudentsAsync([Service] IStudentRepositry Studentrepo, int StudentsId)
        {
            return await Studentrepo.DeleteStudentAsync(StudentsId);
        }
    }
}
