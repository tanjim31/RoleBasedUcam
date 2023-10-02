using RoleBased.Model;
using RoleBased.Services.Model;
using RoleBased.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Repository.Interface
{
    public interface IStudentRepository : IRepository<StudentInfo, VMStudentInfo, string>
    {

    }
}
