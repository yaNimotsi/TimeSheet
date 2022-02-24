namespace TimeSheet.DB
{
    public interface IRepository<T> where T : class
    {
        T Get(int personId);
        T Add(T newPerson);
        T Update(T newEntity);
        bool Delete(int newPerson);
    }
}
