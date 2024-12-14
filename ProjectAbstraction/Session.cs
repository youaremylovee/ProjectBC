using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAbstraction
{
    public class Session
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public bool IsActive => UserId >= 0;
        public static Session Instance { get; private set; } = new Session();
        public static void SetSession(int userId, string role)
        {
            Instance.UserId = userId;
            Instance.Role = role;
        }
        public static void ClearSession()
        {
            Instance.UserId = -1;
            Instance.Role = null;
        }
    }
}
