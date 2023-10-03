using AutoMapper;
using RoleBased.Model;
using RoleBased.Services.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.Mapping
{
    public class MappingExtension : Profile
    {
        public MappingExtension()
        {
            CreateMap<VMStudentInfo, StudentInfo>().ReverseMap();
            CreateMap<VMLoginDB, LoginDB>().ReverseMap();
        }
    }
}
