using TimeSheet.DB.DAL.Interface.ModelInterface;

namespace TimeSheet.DB.DAL.Entity
{
    public class UserAccessData : IUserAccessModel
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string UserPass { get; set; }
        public bool IsDeleted { get; set; }
    }
}