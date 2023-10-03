using Microsoft.AspNetCore.Mvc;
using RoleBased.Core.CQRS.RoleBased.Command;
using RoleBased.Core.CQRS.RoleBased.Query;
using RoleBased.Services.Model;

namespace RoleBased.Backend.Controllers
{
    public class LoginDBController : APIControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpGet("id:string")]

        public async Task<ActionResult<VMLoginDB>> GetById(string id)
        {
            return await HandleQueryAsync(new GetAllLoginDBByIdQuery(id));
        }

        [HttpGet]
        public async Task<ActionResult<VMLoginDB>> GetAllEmployee()
        {
            return await HandleQueryAsync(new GetAllLoginDBQuery());
        }

        [HttpPost]
        public async Task<ActionResult<VMLoginDB>> CreateEmployee(VMLoginDB command)
        {
            return await HandleCommandAsync(new CreateLoginDBCommand(command));
        }

        [HttpPut("id:string")]
        public async Task<ActionResult<VMLoginDB>> UpdateEmployee(string id, VMLoginDB login)
        {
            return await HandleCommandAsync(new UpdateLoginDBCommand(id, login));
        }
        [HttpDelete("id:string")]
        public async Task<ActionResult<VMLoginDB>> DeleteEmployee(string id)
        {
            return await HandleCommandAsync(new DeleteLoginDBCommand(id));
        }
    }
}
