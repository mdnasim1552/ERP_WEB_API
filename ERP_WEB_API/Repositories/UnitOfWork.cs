using ERP_WEB_API.Data;

namespace ERP_WEB_API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICompinfsRepository Comp {  get;private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Comp=new CompinfsRepository(context);
        }

       

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Saved()
        {
            _context.SaveChanges();
        }
    }
}
