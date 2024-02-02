using ERP_WEB_API.Models;

namespace ERP_WEB_API.Repositories
{
    public interface IUserRepository
    {
        Task<List<Userinf>> GetUserList();
        Task<bool> InsertUserData(List<Userinf> userList);
        Task<bool> UpdateUserData(List<Userinf> updatedData);
        Task<bool> DeleteUserData(string comcod, string usrid);
    }
}
