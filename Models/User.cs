﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTraders.Models
{
    public class User
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string mobileno { get; set; }
        public string email { get; set; }
    }
}