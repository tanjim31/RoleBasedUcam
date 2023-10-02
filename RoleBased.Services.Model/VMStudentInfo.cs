using RoleBased.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Services.Model
{
    public class VMStudentInfo: IVM
    {
        public string RegNo { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DOB { get; set; } = DateTimeOffset.UtcNow;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
