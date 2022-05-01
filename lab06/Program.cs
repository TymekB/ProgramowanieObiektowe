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
            
            Console.WriteLine();
        }

        static void zad3(List<User> users)
        {
            Console.WriteLine("ZAD 3 - Posortowani uzytkownicy po nazwach");

            List<User> result = users.OrderBy(user => user.Name).ToList();
            
            // List<User> result = (from user in users orderby user.Name select user).ToList();

            foreach (User user in result)
                Console.WriteLine(user.Name);

            Console.WriteLine();
        }

        static void zad4(List<User> users)
        {
            Console.WriteLine("ZAD 4 - Lista dostepnych rol uzytkownikow");

            List<string> result = users
                .Select(user => user.Role)
                .Distinct()
                .ToList();

            // List<string> result = (from user in users select user.Role).Distinct().ToList();

            foreach (string role in result)
                Console.WriteLine(role);

            Console.WriteLine();
        }
        
        static void zad5(List<User> users)
        {
            Console.WriteLine("ZAD 5 - Pogrupowani uzytkownicy po rolach");
            
            IEnumerable<IGrouping<string, User>> result = users.GroupBy(user => user.Role);
            
            // IEnumerable<IGrouping<string, User>> result = (from user in users group user by user.Role).ToList();
            
            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
                foreach (var blogpost in item)
                {
                    Console.WriteLine(blogpost.Name);
                }
            }
            
            Console.WriteLine();
        }

        static void zad6(List<User> users)
        {
            Console.WriteLine("ZAD 6 - Ilosc rekordow, dla ktorych podano oceny (nie null i wiecej niz 0)");

            int result = users
                .Where(user => user.Marks != null)
                .Count(user => user.Marks.Any());

            // int result = (from user in users where user.Marks != null && user.Marks.Any() select user).Count();

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User { Name = "A", Role = "STUDENT", Marks = new int[]{ 5,1,4 }},
                new User { Name = "B", Role = "STUDENT", Marks = new int[]{ 0,1,4 }},
                new User { Name = "C", Role = "ADMIN"},
                new User { Name = "D", Role = "TEACHER"}
            };
            zad1(users);
            zad2(users);
            zad3(users);
            zad4(users);
            zad5(users);
            zad6(users);
        }
    }
}