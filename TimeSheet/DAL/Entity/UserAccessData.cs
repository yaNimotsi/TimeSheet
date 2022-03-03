using TimeSheet.API.DAL.Interface;

namespace TimeSheet.API.DAL.Entity
{
    public class UserAccessData : IUserAccessData
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string UserPass { get; set; }
        public bool IsDeleted { get; set; }
    }
}