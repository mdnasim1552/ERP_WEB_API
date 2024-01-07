using System.Data.SqlClient;

namespace ERP_WEB_API.DataAccess
{
    public interface IProcessAccess
    {
        Task<List<T>> GetAllAsync<T>(string SQLprocName, params SqlParameter[] parameters) where T : new();
        Task<bool> ExecuteTransactionalOperationAsync(string SQLprocName, params SqlParameter[] parameters);
    }
}
