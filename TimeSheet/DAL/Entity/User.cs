
using TimeSheet.API.DAL.Interface;

namespace TimeSheet.API.DAL.Entity
{
    public sealed class User : IUserModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}