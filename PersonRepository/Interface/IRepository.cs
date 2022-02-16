using System.Threading.Tasks;
using TimeSheet.DB.Entity;

namespace TimeSheet.DB.Interface
{
    public interface IRepository
    {
        public Task<bool> AddAsync(MyDBContext context, BaseEntity<int> entity);
        public Task<bool> DeleteAsync(MyDBContext context, int entityId);
    }
}
