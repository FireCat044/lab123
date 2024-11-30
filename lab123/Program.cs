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
            context.Users.Add(new User { FirstName = "����", LastName = "��������", Age = 25 });
            context.Users.Add(new User { FirstName = "�����", LastName = "��������", Age = 30 });
            context.Users.Add(new User { FirstName = "�����", LastName = "������", Age = 22 });
            context.SaveChanges();

            // **READ**
            var users = context.Users.ToList();
            Console.WriteLine("����������� � ���� �����:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName}, {user.Age} ����");
            }

            // **UPDATE**
            var userToUpdate = context.Users.FirstOrDefault(u => u.FirstName == "����");
            if (userToUpdate != null)
            {
                userToUpdate.Age = 26; 
                context.SaveChanges();
                Console.WriteLine($"����������� {userToUpdate.FirstName} ��������!");
            }

            // **DELETE**
            var userToDelete = context.Users.FirstOrDefault(u => u.FirstName == "�����");
            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
                Console.WriteLine($"����������� {userToDelete.FirstName} ��������!");
            }
        }
    }
}
