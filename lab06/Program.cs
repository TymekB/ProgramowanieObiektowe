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

            List<string> result = users
                .Select(user => user.Name)
                .ToList();
            // List<string> result = (from user in users select user.Name).ToList();

            foreach (string name in result)
                Console.WriteLine(name);
            
            Console.WriteLine();
        }

        static void zad3(List<User> users)
        {
            Console.WriteLine("ZAD 3 - Posortowani uzytkownicy po nazwach");

            List<User> result = users
                .OrderBy(user => user.Name)
                .ToList();
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
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
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

            Console.WriteLine(result + "\n");
        }

        // TODO: correct, use array join
        static void zad7(List<User> users)
        {
            Console.WriteLine("ZAD 7 - Suma, ilosc i srednia wszystkich ocen studentow");

            IEnumerable<int[]> userMarks = users
                .Where(user => user.Marks != null)
                .Select(user => user.Marks);
            
            // IEnumerable<int[]> userMarks = (from user in users where user.Marks != null select user.Marks);

            IEnumerable<int> marksSum = userMarks.Select(marks => marks.Sum());
            IEnumerable<double> marksAverage = userMarks.Select(marks => marks.Average());
            IEnumerable<int> marksCount = userMarks.Select(marks => marks.Length);

            Console.WriteLine("Suma");

            foreach (var sum in marksSum)
            {
                Console.WriteLine(sum);
            }
            
            Console.WriteLine("Srednia");

            foreach (var average in marksAverage)
            {
                Console.WriteLine(average);
            }

            Console.WriteLine("Ilosc");

            foreach (var count in marksCount)
            {
                Console.WriteLine(count);
            }

            Console.WriteLine("");
        }

        static void zad8(List<User> users)
        {
            Console.WriteLine("ZAD 8 - Najlepsza ocena");
            
            

            IEnumerable<int> result = users
                .Where(user => user.Marks != null)
                .Select(user => user.Marks.Max());

            // IEnumerable<int> result = (from user in users where user.Marks != null select user.Marks.Max());

            foreach (int mark in result)
            {
                Console.WriteLine(mark);
            }

            Console.WriteLine();
        }

        static void zad9(List<User> users)
        {
            Console.WriteLine("ZAD 9 - Najgorsza ocena");

            IEnumerable<int> result = users
                .Where(user => user.Marks != null)
                .Select(user => user.Marks.Min());

            // IEnumerable<int> result = (from user in users where user.Marks != null select user.Marks.Max());

            foreach (int mark in result)
            {
                Console.WriteLine(mark);
            }
        }

        static void zad10(List<User> users)
        {
            Console.WriteLine("Zad 10 - Najlepszy student");

            // User user = users.Where(user => user.Marks != null)
            //     .OrderByDescending(user => user.Marks.Average())
            //     .First();

            var user = (from u in users where u.Marks != null orderby u.Marks.Average() descending select u).First();

            Console.WriteLine(user.Name);
        }
        static void zad11(List<User> users)
        {
            Console.WriteLine("ZAD 11 - Lista studentow, ktorzy posiadają najmniej ocen");
            
            // users = (from user in users where user.Marks != null select user).ToList();

            users = users.Where(user => user.Marks != null).ToList();
            
            var min = users
                .Select(user => user.Marks.Length)
                .Min();
            
            // int min = (from user in users select user.Marks.Length).Min(); 

            var result = users.Where(user => user.Marks.Length == min);

            foreach (var user in result)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine();
        }

        static void zad12(List<User> users)
        {
            Console.WriteLine("ZAD 12 - Lista studentow, ktorzy posiadają najwiecej ocen");

            users = users.Where(user => user.Marks != null).ToList();
            
            // users = (from user in users where user.Marks != null select user).ToList();

            var max = users
                .Select(user => user.Marks.Length)
                .Max();
            
            // var max = (from user in users select user.Marks.Length).Max(); 

            var result = users.Where(user => user.Marks.Length == max);
  
            foreach (var user in result)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine();
        }

        static void zad13(List<User> users)
        {
            Console.WriteLine("ZAD 13 - Lista obiektow zawierajaca tylko nazwe i srednia ocene");
            
            var result = users
                .Where(user => user.Marks != null)
                .Select(user => new { user.Name, AverageMark = user.Marks.Average() });

            // var result = (from user in users where user.Marks != null select new {user.Name, AverageMark = user.Marks.Average()}).ToList();

            foreach (var user in result)
            {
                Console.WriteLine(user.Name + " " + user.AverageMark);
            }
        }

        static void zad14(List<User> users)
        {
            Console.WriteLine("ZAD 14 - Studenci posortowani od najlepszego");

            // var result = users.Where(user => user.Marks != null)
            //     .OrderByDescending(user => user.Marks.Average());

            var result = (from user in users
                where user.Marks != null
                orderby user.Marks.Average() descending
                select user);

            foreach (var user in result)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine();
        }

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
            zad7(users);
            zad8(users);
            zad9(users);
            zad10(users);
            zad11(users);
            zad12(users);
            zad13(users);
            zad14(users);
        }
    }
}