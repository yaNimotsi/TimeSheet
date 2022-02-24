namespace TimeSheet.DB.DAL.Interface.ModelInterface
{
    public interface IUserAccessModel : IBaseEntity<int>
    {
        public string UserLogin { get; set; }
        public string UserPass { get; set; }
    }
}