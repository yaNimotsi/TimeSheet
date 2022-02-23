namespace TimeSheet.DB.DAL.Interface.ModelInterface
{
    public interface IUserModel : IBaseEntity<int>
    {
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}