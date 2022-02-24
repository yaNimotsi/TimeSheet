namespace TimeSheet.API.DAL.Interface
{
    public interface IUserAccessModel
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string UserPass { get; set; }
        public bool IsDeleted { get; set; }
    }
}