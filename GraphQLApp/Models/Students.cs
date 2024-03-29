using System.ComponentModel.DataAnnotations;

namespace GraphQLApp.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public required string StudentName { get; set; }
        public string Course { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
    }
}
