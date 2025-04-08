using Ecommerce.Data.Data;

namespace Ecommerce.Data.Repository.IRepo
{
    public class Repo<T1, T2>
    {
        public Repo(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }
    }
}