using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}
