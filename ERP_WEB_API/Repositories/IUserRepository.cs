using ERP_WEB_API.Models;

namespace ERP_WEB_API.Repositories
{
    public interface IUserRepository
    {
        Task<List<Userinfs>> GetUserList();
        Task<bool> InsertUserData(List<Userinfs> userList);
        Task<bool> UpdateUserData(List<Userinfs> updatedData);
        Task<bool> DeleteUserData(string comcod, string usrid);
    }
}
