using ERP_WEB_API.Models;

namespace ERP_WEB_API.Repositories
{
    public interface ICompinfsRepository:IRepository<Compinf>
    {
        void Update(Compinf comp);
    }
}
