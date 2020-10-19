using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1
{
    class SocialNetworkProviderFacebook : ISocialNetworkProvider<FriendFacebook>
    {
        public delegate void CrashSystemHandlerFacebook(object sender, CrashSystemEventArgs e);

        public event CrashSystemHandlerFacebook NotifyFacebook;

        static HashSet<User> ExistingUserFacebook = new HashSet<User>
        {
            new User {Name="Юрий", Age = new DateTime(92,1,22), Email = "yuriy@mail.com",Surname = "Иванов6",Password = "252"},
            new User {Name="Никита", Age = new DateTime(96,5,17), Email = "nikita@mail.com",Surname = "Иванов7",Password = "632" },
            new User {Name="Вадим", Age = new DateTime(97,2,15), Email = "vadim1@mail.com",Surname = "Иванов8",Password = "282" },
            new User {Name="Александр", Age = new DateTime(89,9,13), Email = "aleksandr@mail.com",Surname = "Иванов9",Password = "230" },
            new User {Name="Владимир", Age = new DateTime(91,5,12), Email = "vladimir@mail.com",Surname = "Иванов10",Password = "432" }

        };
        static HashSet<User> LoginedUserFacebook = new HashSet<User>();

        static HashSet<FriendFacebook> FriendFacebooks = new HashSet<FriendFacebook>();
        public HashSet<User> Login(User user)
        {

            foreach (var item in ExistingUserFacebook)
            {

                if (user.Email == item.Email && user.Password == item.Password)
                {
                    if (LoginedUserFacebook.Count != 0)
                    {
                        foreach (var item1 in LoginedUserFacebook)
                        {
                            int count = 0;

                            count++;

                            if (user.Email == item1.Email && user.Password == item1.Password)
                            {

                                Console.WriteLine("Вы уже залогинены.");
                                break;

                            }
                            else if (count == LoginedUserFacebook.Count)
                            {
                                LoginedUserFacebook.Add(user);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{user.Name} {user.Surname} залогинен в Facebook");
                                Console.ResetColor();
                                break;
                            }

                        }
                        return LoginedUserFacebook;
                    }

                    else if (LoginedUserFacebook.Count == 0)
                    {
                        LoginedUserFacebook.Add(user);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{user.Name} {user.Surname} залогинен в Facebook");
                        Console.ResetColor();

                        break;
                    }
                    return LoginedUserFacebook;

                }

            }

            foreach (var item in ExistingUserFacebook)
            {
                if (!LoginedUserFacebook.Contains(user))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{user.Name} {user.Surname} не зарегестрирован в сети Facebook. Пожалуйста зарегестрируйтесь.");
                    Console.ResetColor();

                    break;
                }
            }
            return LoginedUserFacebook;

        }

        public void Logout(User user)
        {
            foreach (var item in LoginedUserFacebook)
            {
                if ((user.Email == item.Email && user.Password == item.Password))
                {
                    Console.WriteLine($"{user.Name} {user.Surname} вышел с системы");

                    LoginedUserFacebook.Remove(user);

                    break;
                }
            }

        }
        public HashSet<FriendFacebook> AddFriend(User user, IFriend friend)
        {

            if (LoginedUserFacebook.Contains(user))
            {
                if (friend is FriendFacebook)
                {
                    FriendFacebooks.Add((FriendFacebook)friend);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{friend.Name} {friend.Surname} добавлен к вам в друзья в Facebook");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Не могу добавить пользователя {friend.GetType()} в Facebook");
                    Console.ResetColor();
                }
            }
            
            return FriendFacebooks;

        }
        public void CrashSystem()
        {
            LoginedUserFacebook.Clear();

            NotifyFacebook?.Invoke(this, new CrashSystemEventArgs($"Текущее время {DateTime.Now}", DateTime.Now));

        }

    }
}
