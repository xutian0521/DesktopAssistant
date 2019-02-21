using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.model
{
    public enum LoginSta
    {
        UserNameUndefinition,
        PassWordError,
    }
    public class LoginMsg
    {
        public LoginSta loginSta { get; set; }
        public string prompt { get; set; }
    }
}
