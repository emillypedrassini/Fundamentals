using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { Isbn = 123, Title = "C# Advanced" };

            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(book);
            books.Add(new Book());

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1A", new Book());

            Console.WriteLine();

            Console.WriteLine("Generics + Constraints");

            var number = new Nullable<int>(5);
            Console.WriteLine($"Has value? {number.HasValue}");
            Console.WriteLine($"Value: {number.GetValueOrDefault()}");
            Console.WriteLine();

            number = new Nullable<int>();
            Console.WriteLine($"Has value? {number.HasValue}");
            Console.WriteLine($"Value: {number.GetValueOrDefault()}");

            Console.ReadLine();

        }
    }
}
