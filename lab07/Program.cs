using System;
using System.Data.Linq;
using System.Linq;

namespace lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uwaga: zmień `DESKTOP-123ABC\SQLEXPRESS` na nazwę swojego serwera.

            string connectionString =
                @"Data Source=DESKTOP-F6VNSC1;Initial Catalog=projectdb;Integrated Security=True";

            using (DataContext dataContext = new DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();

                IQueryable<UserEntity> query = from user in users
                    where user.RemovedAt.HasValue == false // user.RemovedAt == null
                    select user;

                foreach (UserEntity user in query)
                    Console.WriteLine("{0} {1}", user.Id, user.Name);
            }
        }
    }
}