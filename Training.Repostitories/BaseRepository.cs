using Training.Entities;
using Training.Repostitories.Interface;

namespace Training.Repostitories
{
    public abstract class BaseRepository:IBaseRepository
    {
        protected TrainingDbContext dbContext;

        public BaseRepository(TrainingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int SaveCommit()
        {
            return dbContext.SaveChanges();
        }
    }
}