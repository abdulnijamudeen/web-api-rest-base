﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Form.Response
{
    public class LoginRes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}