﻿using RoleBased.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Services.Model
{
    public class VMLoginDB : IVM
    {
        public string RegNo { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

