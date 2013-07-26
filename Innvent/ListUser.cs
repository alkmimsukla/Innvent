using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innvent
{
    class ListUser
    {
        private List<TUser> user = new List<TUser>();

        public List<TUser> User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
