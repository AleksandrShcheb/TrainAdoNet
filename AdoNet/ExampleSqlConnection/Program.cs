using System;
using System.Collections.Generic;

namespace ExampleSqlConnection
{
    class Program
    {

        static void Main(string[] args)
        {
            var repository = new InfoPersonRepository(
                   @"Data Source=PROFILE\SQLEXPRESS;Initial Catalog=UsersDb;Integrated Security=true;");

            Console.Write("Введите имя пользователя:");
            string name = Console.ReadLine();

            Console.Write("Введите возраст пользователя:");
            int age = int.Parse(Console.ReadLine());

            repository.AddUser(name, age);
            Console.WriteLine();
            repository.GetUsers();

            Console.ReadKey();
        }
    }
}


