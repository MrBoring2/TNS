using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Services
{
    public class UserService
    {
        private static UserService instance;
        private UserService() { }
        public static UserService Instance => instance ?? (instance = new UserService());
        public string UserName { get; set; }
    }
}
