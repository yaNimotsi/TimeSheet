using TimeSheet.BusinessLogic.DAL.Interface;

namespace TimeSheet.BusinessLogic.DAL.Entity
{
    public class UserAccessModel : IUserAccessModel
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string UserPass { get; set; }
        public bool IsDeleted { get; set; }
    }
}