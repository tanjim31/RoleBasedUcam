using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleBased.Model;
using RoleBased.Shared.Enums;
using System.Text.RegularExpressions;

namespace RoleBased.Infrastructure.Persistance.Configuration
{
    public class StudentInfoConfiguration : IEntityTypeConfiguration<StudentInfo>
    {
        public void Configure(EntityTypeBuilder<StudentInfo> builder)
        {

            builder.HasKey(x => x.RegNo);
            builder.HasData(new
            //{
            //    Id = 1,
            //    CountryName = "Bangladesh",
            //    Currency = "BDT",
            //    Created = DateTimeOffset.Now,
            //    CreatedBy = "1",
            //    LastModified = DateTimeOffset.Now,
            //    Status = EntityStatus.Created
            //});
            {
                RegNo="1",
                Name="Rahat Ahmed Tanjim",
                DOB= DateTimeOffset.Now,
                PhoneNumber="0198xxxxxx",
                Email="rahat@gmail.com",
                Created = DateTimeOffset.Now,
                CreatedBy = "1",
                LastModified = DateTimeOffset.Now,
                Status = EntityStatus.Created
            });
        }
    }
}
