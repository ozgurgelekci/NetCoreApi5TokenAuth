using System.Threading.Tasks;

namespace NetCoreApi5TokenAuth.Core.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        void Commit();
    }
}
