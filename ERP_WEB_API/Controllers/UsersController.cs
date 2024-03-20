using ERP_WEB_API.DataAccess;
using ERP_WEB_API.Models;
using ERP_WEB_API.Repositories;
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
        private readonly IUserRepository _userRepository;
        public UsersController(IProcessAccess processAccess,IUserRepository userRepository)
        {
            _processAccess= processAccess;
            _userRepository= userRepository;
        }

        [HttpGet("myData")]
        public async Task<IActionResult> GetUserList()
        {
            try
            {
                var userList = await _userRepository.GetUserList();
                var json = JsonConvert.SerializeObject(new { data = userList });
                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error", Message = "An error occurred while fetching data.", Exception = ex.Message });
            }
        }
        [HttpPost("insertData")]
        public async Task<IActionResult> InsertUserData([FromBody] List<Userinfs> userList)
        {
            try
            {
                bool result = await _userRepository.InsertUserData(userList);
                if (!result)
                {
                    return BadRequest(new { Status = "Error", Message = "An error occurred while inserting data." });
                }
                return Ok(new { Status = "Success", Message = "Data Inserted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error", Message = "An error occurred while inserting data.", Exception = ex.Message });
            }
        }

        [HttpPost("updateData")]
        public async Task<IActionResult> UpdateUserData([FromBody] List<Userinfs> updatedData)
        {
            try
            {
                bool result = await _userRepository.UpdateUserData(updatedData);
                if (!result)
                {
                    return BadRequest(new { Status = "Error", Message = "An error occurred while updating data." });
                }
                return Ok(new { Status = "Success", Message = "Data updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error", Message = "An error occurred while updating data.", Exception = ex.Message });
            }
        }

        [HttpPost("deleteData")]
        public async Task<IActionResult> DeleteUserData(string comcod, string usrid)
        {
            try
            {
                bool result = await _userRepository.DeleteUserData(comcod,usrid);
                if (!result)
                {
                    return BadRequest(new { Status = "Error", Message = "An error occurred while deleting data." });
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
