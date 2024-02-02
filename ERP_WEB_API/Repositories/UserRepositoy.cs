using ERP_WEB_API.DataAccess;
using ERP_WEB_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealERPLIB.Extensions;
using System.Data.SqlClient;
using System.Net;

namespace ERP_WEB_API.Repositories
{
    public class UserRepositoy:IUserRepository
    {
        private readonly IProcessAccess _processAccess;
        public UserRepositoy(IProcessAccess processAccess)
        {
            _processAccess = processAccess;
        }
        public async Task<List<Userinf>> GetUserList()
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "SHOWUSER";
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@CallType", Calltype)
            };
            var userList = await _processAccess.GetAllAsync<Userinf>(procedureName, parameters);
            return userList;
        }

        public async Task<bool> InsertUserData(List<Userinf> userList)
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "INSERTUSER";
            foreach (var user in userList)
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                         new SqlParameter("@CallType", Calltype),
                         new SqlParameter("@Comp1", user.comcod),
                         new SqlParameter("@Desc1", user.usrsname),
                         new SqlParameter("@Desc2", user.usrname),
                         new SqlParameter("@Desc3", user.usrdesig),
                         new SqlParameter("@Desc4", user.usractive.ToString()),
                         new SqlParameter("@Desc5", ASTUtility.EncodePassword(user.usrpass)),
                         new SqlParameter("@Desc6", user.mailid),
                         new SqlParameter("@Desc7", user.userrole.ToString()),
                         new SqlParameter("@Desc8", user.usrid),
                         new SqlParameter("@Desc9", user.empid)
                };
                bool result = await _processAccess.ExecuteTransactionalOperationAsync(procedureName, parameters);
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> UpdateUserData(List<Userinf> updatedData)
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "UPDATEUSER";

            foreach (var user in updatedData)
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@CallType", Calltype),
                        new SqlParameter("@Comp1", user.comcod),
                        new SqlParameter("@Desc1", user.usrsname),
                        new SqlParameter("@Desc2", user.usrname),
                        new SqlParameter("@Desc3", user.usrdesig),
                        new SqlParameter("@Desc4", user.usractive.ToString()),
                        new SqlParameter("@Desc5", user.usrpass),
                        new SqlParameter("@Desc6", user.mailid),
                        new SqlParameter("@Desc7", user.userrole.ToString()),
                        new SqlParameter("@Desc8", user.usrid)

                };
                bool result = await _processAccess.ExecuteTransactionalOperationAsync(procedureName, parameters);
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<bool> DeleteUserData(string comcod, string usrid)
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "DELETEUSER";
            SqlParameter[] parameters = new SqlParameter[]
               {
                        new SqlParameter("@CallType", Calltype),
                        new SqlParameter("@Comp1", comcod),
                        new SqlParameter("@Desc8", usrid)

               };
            bool result = await _processAccess.ExecuteTransactionalOperationAsync(procedureName, parameters);
            if (!result)
            {
                return false;
            }
            return true;
        }


    }
}
