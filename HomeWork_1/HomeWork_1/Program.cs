using System;
using System.Collections.Generic;

namespace HomeWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SocialNetworkProviderVk vk = new SocialNetworkProviderVk();
            vk.NotifyVk += Vk_Notify;

            SocialNetworkProviderFacebook fc = new SocialNetworkProviderFacebook();
            fc.NotifyFacebook += Vk_Notify;

            SocialNetworkProviderInstagram inst = new SocialNetworkProviderInstagram();
            inst.NotifyInstagram += Vk_Notify;
                       
            User user = new User { Name = "Вадим", Age = new DateTime(92, 1, 22), Email = "vadim@mail.com", Surname = "Иванов1", Password = "532" };
            User user1 = new User { Name = "Юрий", Age = new DateTime(92, 1, 22), Email = "yuriy@mail.com", Surname = "Иванов6", Password = "252" };
            User user2 = new User { Name = "Павел", Age = new DateTime(89, 9, 13), Email = "pavel@mail.com", Surname = "Иванов4", Password = "132" };
            User user3 = new User { Name = "Павел", Age = new DateTime(89, 9, 13), Email = "pavel@mail.com", Surname = "Иванов4", Password = "132" };
            User user4 = new User{ Name = "Вадим", Age = new DateTime(92, 1, 22), Email = "vadim@mail.com", Surname = "Иванов1", Password = "532" };
            User user5 = new User { Name = "Николай", Age = new DateTime(91, 5, 9), Email = "nikolay@mail.com", Surname = "Иванов15", Password = "032" };
            User user6 = new User { Name = "Александр", Age = new DateTime(89, 9, 13), Email = "aleksandr@mail.com", Surname = "Иванов9", Password = "230" };
            User user7 = new User { Name = "Владимир", Age = new DateTime(91, 5, 12), Email = "vladimir@mail.com", Surname = "Иванов10", Password = "432" };

            IFriend friend = new FriendInstagram()
            {
                Name = "Женя", PhoneNumber = "+3753343434", Surname = "иванов"
            };

            IFriend friend1 = new FriendVk()
            {
                Name = "Митя",
                PhoneNumber = "+37532323434",
                Surname = "Шапетько"
            };

            IFriend friend2 = new FriendVk()
            {
                Name = "Дима",
                PhoneNumber = "+37532323434",
                Surname = "Иванов"
            };


            IFriend friend3 = new FriendFacebook()
            {
                Name = "Инна",
                PhoneNumber = "+3753343434",
                Surname = "Иванов"
            };

            IFriend friend4 = new FriendFacebook()
            {
                Name = "Деннис",
                PhoneNumber = "+37532323434",
                Surname = "Шапетько"
            };

            IFriend friend5 = new FriendFacebook()
            {
                Name = "Дима",
                PhoneNumber = "+37532323434",
                Surname = "Сидоров"
            };

                     
            vk.Login(user5);
            vk.Login(user);
            vk.Login(user1);
            vk.Login(user2);
            vk.Login(user3);
            vk.Login(user4);

            fc.Login(user5);
            fc.Login(user6);
            fc.Login(user7);
            fc.Logout(user7);
            fc.Login(user);

            vk.Logout(user1);
            vk.AddFriend(user, friend);
            vk.AddFriend(user, friend1);

            fc.AddFriend(user, friend2);
            fc.AddFriend(user, friend5);

            vk.AddFriend(user, friend4);

            HashSet<FriendVk> user_vk = vk.AddFriend(user, friend2);

            Dictionary <User, HashSet<FriendVk> >dictionary = new Dictionary <User, HashSet<FriendVk>>();
            Dictionary<User, HashSet<FriendFacebook>> dictionary1 = new Dictionary<User, HashSet<FriendFacebook>>();
            Dictionary<User, HashSet<FriendInstagram>> dictionary2 = new Dictionary<User, HashSet<FriendInstagram>>();

            dictionary.Add(user, user_vk);

            vk.CrashSystem();

            Console.ReadLine();

        }

        private static void Vk_Notify(object sender, CrashSystemEventArgs e)
        {
            Console.WriteLine($"Система упала.Из-за этого вы были вылогинены из системы ");
            Console.WriteLine(e.Message);
        }
    }
}
