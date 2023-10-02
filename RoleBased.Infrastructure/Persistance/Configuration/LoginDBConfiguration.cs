using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoleBased.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RoleBased.Infrastructure.Persistance.Configuration
{
    public class LoginDBConfiguration : IEntityTypeConfiguration<LoginDB>
    {
        public void Configure(EntityTypeBuilder<LoginDB> builder)
        {

            builder.HasKey(x => x.RegNo);
            //builder.HasData(new
            ////{
            ////    Id = 1,
            ////    CountryName = "Bangladesh",
            ////    Currency = "BDT",
            ////    Created = DateTimeOffset.Now,
            ////    CreatedBy = "1",
            ////    LastModified = DateTimeOffset.Now,
            ////    Status = EntityStatus.Created
            ////});
            //{
            ////    RegNo = 1,
            ////    Password = "",
            ////    Role=""
            //});
        }
    }
}
