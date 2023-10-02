using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id:int}")]

        public async Task<ActionResult<VMStudentInfo>> GetById(int id)
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<VMStudentInfo>> UpdateEmployee(int id, VMStudentInfo studentInfo)
        {
            return await HandleCommandAsync(new UpdateStudentInfoCommand(id, studentInfo));
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VMStudentInfo>> DeleteEmployee(int id)
        {
            return await HandleCommandAsync(new DeleteStudentInfoCommand(id));
        }
    }
}
