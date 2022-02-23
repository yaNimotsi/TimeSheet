namespace TimeSheet.DB.DAL.Interface.ModelInterface
{
    public interface IBaseEntity<TUniqueId> where TUniqueId : struct
    {
        public TUniqueId Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}