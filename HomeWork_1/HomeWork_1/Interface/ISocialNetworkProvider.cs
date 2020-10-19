using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1
{
    interface ISocialNetworkProvider<T>  
    {
        public HashSet<User> Login(User user);
        public void Logout(User user);
        public HashSet<T> AddFriend(User user, IFriend friend);
        public void CrashSystem();

    }
}
