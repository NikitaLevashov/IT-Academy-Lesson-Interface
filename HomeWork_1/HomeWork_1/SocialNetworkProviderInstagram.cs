using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1
{
    class SocialNetworkProviderInstagram : ISocialNetworkProvider<FriendInstagram>
    {
        public delegate void CrashSystemHandlerInstagram(object sender, CrashSystemEventArgs e);

        public event CrashSystemHandlerInstagram NotifyInstagram;

        static HashSet<User> ExistingUserInstagram = new HashSet<User>
        {
            new User {Name="Дмитрий", Age = new DateTime(91,2,21), Email = "dmitriy1@mail.com",Surname = "Иванов11",Password = "432"},
            new User {Name="Валерий", Age = new DateTime(95,6,19), Email = "valeriy1@mail.com",Surname = "Иванов12",Password = "532" },
            new User {Name="Артем", Age = new DateTime(88,9,10), Email = "artem@mail.com",Surname = "Иванов13",Password = "136" },
            new User {Name="Кирилл", Age = new DateTime(87,8,13), Email = "kirill@mail.com",Surname = "Иванов14",Password = "932" },
            new User {Name="Николай", Age = new DateTime(91,5,9), Email = "nikolay@mail.com",Surname = "Иванов15",Password = "032" }

        };
        static HashSet<User> LoginedUserInstagram = new HashSet<User>();

        static HashSet<FriendInstagram> FriendInstagrams = new HashSet<FriendInstagram>();

        public HashSet<User> Login(User user)
        {

            foreach (var item in ExistingUserInstagram)
            {

                if (user.Email == item.Email && user.Password == item.Password)
                {
                    if (LoginedUserInstagram.Count != 0)
                    {
                        foreach (var item1 in LoginedUserInstagram)
                        {
                            int count = 0;

                            count++;

                            if (user.Email == item1.Email && user.Password == item1.Password)
                            {

                                Console.WriteLine("Вы уже залогинены.");
                                break;

                            }
                            else if (count == LoginedUserInstagram.Count)
                            {
                                LoginedUserInstagram.Add(user);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{user.Name} {user.Surname} залогинен в Instagram");
                                Console.ResetColor();
                                break;
                            }

                        }
                        return LoginedUserInstagram;
                    }

                    else if (LoginedUserInstagram.Count == 0)
                    {
                        LoginedUserInstagram.Add(user);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{user.Name} {user.Surname} залогинен в Instagram");
                        Console.ResetColor();

                        break;
                    }
                    return LoginedUserInstagram;

                }

            }

            foreach (var item in ExistingUserInstagram)
            {
                if (!LoginedUserInstagram.Contains(user))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{user.Name} {user.Surname} не зарегестрирован в сети Вконтакте. Пожалуйста зарегестрируйтесь.");
                    Console.ResetColor();
                    break;
                }
            }
            return LoginedUserInstagram;

        }

        public void Logout(User user)
        {
            foreach (var item in LoginedUserInstagram)
            {
                if ((user.Email == item.Email && user.Password == item.Password))
                {
                    LoginedUserInstagram.Remove(user);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{user.Name} {user.Surname} вышел с системы");
                    Console.ResetColor();

                    break;
                }
            }

        }
        public HashSet<FriendInstagram> AddFriend(User user, IFriend friend)
        {

            if (LoginedUserInstagram.Contains(user))
            {
                if (friend is FriendInstagram)
                {
                    FriendInstagrams.Add((FriendInstagram)friend);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{friend.Name} {friend.Surname} добавлен к вам в друзья в Instagram");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Не могу добавить пользователя {friend.GetType()} в Instagram");
                    Console.ResetColor();

                }
            }


            return FriendInstagrams;

        }
        public void CrashSystem()
        {
            LoginedUserInstagram.Clear();

            NotifyInstagram?.Invoke(this, new CrashSystemEventArgs($"Текущее время {DateTime.Now}", DateTime.Now));

        }
    }
}
