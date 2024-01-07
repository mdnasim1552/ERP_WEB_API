using ERP_WEB_API.DataAccess;
using ERP_WEB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ERP_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IProcessAccess _processAccess;
        public UsersController(IProcessAccess processAccess)
        {
            _processAccess= processAccess;
        }

        [HttpGet("myData")]
        public async Task<IActionResult> OnGetUserList()
        {
            try
            {
                string procedureName = "SP_UTILITY_LOGIN_MGT";
                string Calltype = "SHOWUSER";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CallType", Calltype)
                }; 
                var userList = await _processAccess.GetAllAsync<Userinf>(procedureName, parameters);
                // Serialize the structured data to JSON and return as response
                var json = JsonConvert.SerializeObject(new { data = userList });
                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error", Message = "An error occurred while fetching data.", Exception = ex.Message });
            }
        }
        [HttpPost("insertData")]
        public async Task<IActionResult> InsertUserData([FromBody] List<Userinf> userList)
        {
            try
            {
                // Here, 'updatedData' contains the data sent from the client in JSON format.
                // You can iterate through the 'updatedData' list and update your database accordingly.
                //Update userinf set usrsname=@Desc3,usrname=@Desc4,usrdesig=@Desc5,usractive=@Desc6,usrpass=@Desc7,mailid=@Desc8,userrole=@Desc9 where comcod=@Desc1 and usrid=@Desc2
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
                         new SqlParameter("@Desc5", user.usrpass),
                         new SqlParameter("@Desc6", user.mailid),
                         new SqlParameter("@Desc7", user.userrole.ToString()),
                         new SqlParameter("@Desc8", user.usrid),
                         new SqlParameter("@Desc9", user.empid)
                    };
                    bool result = await _processAccess.ExecuteTransactionalOperationAsync(procedureName, parameters);
                    if (!result)
                    {
                        return BadRequest(new { Status = "Error", Message = "An error occurred while inserting data."});
                    }
                }
                return Ok(new { Status = "Success", Message = "Data Inserted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error", Message = "An error occurred while inserting data.", Exception = ex.Message });
            }
        }

        [HttpPost("updateData")]
        public async Task<IActionResult> UpdateUserData([FromBody] List<Userinf> updatedData)
        {
            try
            {
                // Here, 'updatedData' contains the data sent from the client in JSON format.
                // You can iterate through the 'updatedData' list and update your database accordingly.
                //Update userinf set usrsname=@Desc3,usrname=@Desc4,usrdesig=@Desc5,usractive=@Desc6,usrpass=@Desc7,mailid=@Desc8,userrole=@Desc9 where comcod=@Desc1 and usrid=@Desc2
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
                        return BadRequest(new { Status = "Error", Message = "An error occurred while updating data." });
                    }
                }
                return Ok(new { Status = "Success", Message = "Data updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error", Message = "An error occurred while updating data.", Exception = ex.Message });
            }
        }

        [HttpPost("deleteData")]
        public async Task<IActionResult> DeleteUserData([FromBody] List<Userinf> userList)
        {
            try
            {
                string procedureName = "SP_UTILITY_LOGIN_MGT";
                string Calltype = "DELETEUSER";
                foreach (var user in userList)
                {
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@CallType", Calltype),
                        new SqlParameter("@Comp1", user.comcod),
                        new SqlParameter("@Desc8", user.usrid)

                    };
                    bool result = await _processAccess.ExecuteTransactionalOperationAsync(procedureName, parameters);
                    if (!result)
                    {
                        return BadRequest(new { Status = "Error", Message = "An error occurred while deleting data." });
                    }
                }
                return Ok(new { Status = "Success", Message = "Data deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error", Message = "An error occurred while deleting data.", Exception = ex.Message });                
            }
        }
    }
}
