using System.Threading;
using System.Threading.Tasks;
using TimeSheet.DB.DAL.Interface.ModelInterface;

namespace TimeSheet.DB.DAL.Interface.RepositoryInterface
{
    public interface IUserAccessRepository
    {
        Task<IUserAccessModel> FindUser(CancellationToken token, IUserAccessModel entity);
    }
}