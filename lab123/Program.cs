using lab123.Models;
using lab123;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            // **CREATE**
            context.Users.Add(new User { FirstName = "Іван", LastName = "Іваненко", Age = 25 });
            context.Users.Add(new User { FirstName = "Петро", LastName = "Петренко", Age = 30 });
            context.Users.Add(new User { FirstName = "Олена", LastName = "Оленко", Age = 22 });
            context.SaveChanges();

            // **READ**
            var users = context.Users.ToList();
            Console.WriteLine("Користувачі з бази даних:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName}, {user.Age} років");
            }

            // **UPDATE**
            var userToUpdate = context.Users.FirstOrDefault(u => u.FirstName == "Іван");
            if (userToUpdate != null)
            {
                userToUpdate.Age = 26; 
                context.SaveChanges();
                Console.WriteLine($"Користувача {userToUpdate.FirstName} оновлено!");
            }

            // **DELETE**
            var userToDelete = context.Users.FirstOrDefault(u => u.FirstName == "Олена");
            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
                Console.WriteLine($"Користувача {userToDelete.FirstName} видалено!");
            }
        }
    }
}
