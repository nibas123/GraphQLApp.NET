using GraphQLApp.Models;
using GraphQLApp.Repositories;

namespace GraphQLApp.GraphQL.QueryTypes
{
    public class StudentQueryTypes
    {
        //private readonly StudentRepositry Studentrepo;

        //StudentQueryTypes()
        //{
        //    this.Studentrepo = Studentrepo;
        //}
        public async Task<List<Students>> GetStudentListAsync([Service] IStudentRepositry Studentrepo)
        {
            return await Studentrepo.StudentListAsync();
        }

        public async Task<Students> GetStudentDetailsByIdAsync(Guid productId, [Service] IStudentRepositry Studentrepo)
        {
            return await Studentrepo.GetStudentDetailByIdAsync(productId);
        }
    }
}
