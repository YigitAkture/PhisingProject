﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhishingTestPlatform.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
