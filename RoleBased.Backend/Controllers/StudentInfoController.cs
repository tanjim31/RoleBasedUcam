using Microsoft.AspNetCore.Mvc;
using RoleBased.Core.CQRS.RoleBased.Command;
using RoleBased.Core.CQRS.RoleBased.Query;
using RoleBased.Services.Model;

namespace RoleBased.Backend.Controllers
{
    public class StudentInfoController : APIControllerBase
    {
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpGet("id:string")]

        public async Task<ActionResult<VMStudentInfo>> GetById(string id)
        {
            return await HandleQueryAsync(new GetAllStudentInfoByIdQuery(id));
        }

        [HttpGet]
        public async Task<ActionResult<VMStudentInfo>> GetAllEmployee()
        {
            return await HandleQueryAsync(new GetAllStudentInfoQuery());
        }

        [HttpPost]
        public async Task<ActionResult<VMStudentInfo>> CreateEmployee(VMStudentInfo command)
        {
            return await HandleCommandAsync(new CreateStudentInfoCommand(command));
        }

        [HttpPut("id:string")]
        public async Task<ActionResult<VMStudentInfo>> UpdateEmployee(string id, VMStudentInfo studentInfo)
        {
            return await HandleCommandAsync(new UpdateStudentInfoCommand(id, studentInfo));
        }
        [HttpDelete("id:string")]
        public async Task<ActionResult<VMStudentInfo>> DeleteEmployee(string id)
        {
            return await HandleCommandAsync(new DeleteStudentInfoCommand(id));
        }
    }
}
