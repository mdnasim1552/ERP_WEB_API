using ERP_WEB_API.Data;
using ERP_WEB_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompinfsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompinfsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            //var compinfs= _context.Compinfs.ToList();
            var compinfs = _unitOfWork.Comp.GetAll();
            return Ok(compinfs);
        }
    }
}
