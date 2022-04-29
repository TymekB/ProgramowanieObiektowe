using System;

namespace lab06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User { Name = "A", Role = "STUDENT", Marks = new int[]{ 5,1,4 }},
                new User { Name = "B", Role = "STUDENT", Marks = new int[]{ 0,1,4 }},
                new User { Name = "C", Role = "ADMIN"},
                new User { Name = "A", Role = "TEACHER"}
            };
        }
    }
}