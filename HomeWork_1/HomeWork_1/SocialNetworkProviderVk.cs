using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork_1
{

    class SocialNetworkProviderVk : ISocialNetworkProvider<FriendVk>
    {
        public delegate void CrashSystemHandlerVk(object sender, CrashSystemEventArgs e);

        public event CrashSystemHandlerVk NotifyVk;

        static HashSet<User> ExistingUserVk = new HashSet<User>
        {
            new User {Name="Вадим", Age = new DateTime(92,1,22), Email = "vadim@mail.com",Surname = "Иванов1",Password = "532"},
            new User {Name="Евгений", Age = new DateTime(96,5,17), Email = "evgeniy@mail.com",Surname = "Иванов2",Password = "032" },
            new User {Name="Дмитрий", Age = new DateTime(97,2,15), Email = "dima@mail.com",Surname = "Иванов3",Password = "236" },
            new User {Name="Павел", Age = new DateTime(89,9,13), Email = "pavel@mail.com",Surname = "Иванов4",Password = "132" },
            new User {Name="Иннокентий", Age = new DateTime(91,5,12), Email = "innikentiy@mail.com",Surname = "Иванов5",Password = "932" }
        };

        static HashSet<User> LoginedUserVks = new HashSet<User>();

        static HashSet<FriendVk> FriendVks= new HashSet<FriendVk>();
        public HashSet<User> Login(User user)
        {
           
            foreach (var item in ExistingUserVk)
            {
                
                if (user.Email == item.Email && user.Password == item.Password)
                {
                    if(LoginedUserVks.Count!=0)
                    {
                        foreach (var item1 in LoginedUserVks)
                        {
                            int count = 0;

                            count++;

                            if (user.Email == item1.Email && user.Password == item1.Password)
                            {

                                Console.WriteLine("Вы уже залогинены.");
                                break;

                            }
                            else if(count==LoginedUserVks.Count)
                            {
                                LoginedUserVks.Add(user);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{user.Name} {user.Surname} залогинен в VK");
                                Console.ResetColor();
                                break;
                            }
                           
                        }
                        return LoginedUserVks;
                    }

                    else if (LoginedUserVks.Count == 0)
                    {
                        LoginedUserVks.Add(user);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{user.Name} {user.Surname} залогинен в VK");
                        Console.ResetColor();
                        
                        break;
                    }
                    return LoginedUserVks;

                }
               
            }

            foreach (var item in ExistingUserVk)
            {
                if (!LoginedUserVks.Contains(user))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{user.Name} {user.Surname} не зарегестрирован в сети Вконтакте. Пожалуйста зарегестрируйтесь.");
                    Console.ResetColor();

                    break;
                }
            }
            return LoginedUserVks;

        }

        public void Logout(User user)
        {
            foreach (var item in LoginedUserVks)
            {
                if ((user.Email == item.Email && user.Password == item.Password))
                {
                    LoginedUserVks.Remove(user);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{user.Name} {user.Surname} вышел с системы");
                    Console.ResetColor();

                    break;
                }
            }
    
        }
        public HashSet<FriendVk> AddFriend(User user,IFriend friend)
        {

                if (LoginedUserVks.Contains(user))
                {
                    if(friend is FriendVk)
                    {
                        FriendVks.Add((FriendVk)friend);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{friend.Name} {friend.Surname} добавлен к вам в друзья в VK");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Не могу добавить пользователя {friend.GetType()} в Вконтакте");
                        Console.ResetColor();
                    }
                }


               return FriendVks;
            
        }
        public void CrashSystem()
        {
            LoginedUserVks.Clear();

            NotifyVk?.Invoke(this, new CrashSystemEventArgs($"Текущее время {DateTime.Now}",DateTime.Now));

        }



    }
}
