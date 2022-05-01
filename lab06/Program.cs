using System;
using System.Collections.Generic;
using System.Linq;

namespace lab06
{
    class Program
    {
        static void zad1(List<User> users)
        {
            Console.WriteLine("ZAD 1 - Ilosc rekordow w tablicy");

            int result = users.Count();
            // int result = (from user in users select user).Count();
            
            Console.WriteLine(result + "\n");
        }

        static void zad2(List<User> users)
        {
            Console.WriteLine("ZAD 2 - Lista nazw uzytkownikow");
            
            List<string> result = users.Select(user => user.Name).ToList();
            // List<string> result = (from user in users select user.Name).ToList();
            
            foreach (string name in result)
                Console.WriteLine(name);
            
            Console.WriteLine(result + "\n");

        }

        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User { Name = "A", Role = "STUDENT", Marks = new int[]{ 5,1,4 }},
                new User { Name = "B", Role = "STUDENT", Marks = new int[]{ 0,1,4 }},
                new User { Name = "C", Role = "ADMIN"},
                new User { Name = "A", Role = "TEACHER"}
            };
            zad1(users);
            zad2(users);
        }
    }
}