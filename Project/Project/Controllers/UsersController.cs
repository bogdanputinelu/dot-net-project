using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ProjectContext _projectContext;

        public UsersController(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _projectContext.Users.ToListAsync());
        }

        
    }
}
