﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evacuation.Web.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}