using System.ComponentModel.DataAnnotations.Schema;
using TimeSheet.DB.DAL.Interface.ModelInterface;

namespace TimeSheet.DB.DAL.Entity
{
    [Table("User", Schema = "TimeSheet")]
    public sealed class User : IUserModel
    {
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
