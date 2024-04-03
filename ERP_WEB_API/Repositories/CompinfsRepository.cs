using ERP_WEB_API.Data;
using ERP_WEB_API.Models;

namespace ERP_WEB_API.Repositories
{
    public class CompinfsRepository : Repository<Compinf>, ICompinfsRepository
    {
        private readonly ApplicationDbContext _db;
        public CompinfsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Compinf comp)
        {
            _db.Compinfs.Update(comp);
        }
    }
}
