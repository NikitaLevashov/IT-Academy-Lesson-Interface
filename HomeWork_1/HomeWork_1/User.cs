using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1
{
    class User 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{ Name} {Surname}. Логин: {Email}. Пароль: {Password}.";

        }

       
    }
}
