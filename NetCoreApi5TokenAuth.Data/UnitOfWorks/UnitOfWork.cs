using Microsoft.EntityFrameworkCore;
using NetCoreApi5TokenAuth.Core.UnitOfWork.Abstract;
using NetCoreApi5TokenAuth.Data.DbContexts;
using System.Threading.Tasks;

namespace NetCoreApi5TokenAuth.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
