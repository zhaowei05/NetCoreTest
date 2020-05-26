using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class LoginUserModel
    {
        public string userid { get; set; }
        public string username { get; set; }
        public string realname { get; set; }
        public string roles { get; set; }
        public string permissions { get; set; }
        public string normalPermissions { get; set; }
        public string userpwd { get; set; }
    }
}
