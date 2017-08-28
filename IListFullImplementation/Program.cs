using System;
using static System.Console;
using static System.Array;
using System.Linq;
using System.Collections;

namespace IListFullImplementation
{
    class Program
    {
        // collection
        public static Book books = new Book();

        // main
        static void Main(string[] args)
        {
            // Add books to collection
            books.Add(new Book("1234-34343-5-343", "The Odyssey", "Homer", "Addison", DateTime.Parse("1888.12.12")));
            books.Add(new Book("7532-45231-6-234", "The Iliad", "Homer", "Addison", DateTime.Parse("1890.12.12")));
            books.Add(new Book("6235-98457-5-143", "The Roof", "Homer", "Addison", DateTime.Parse("1900.12.12")));

            // Insert a book at an index
            try
            {
                books.Insert(1, new Book("2365-32456-9-193", "The Cake", "Homer", "Addison", DateTime.Parse("1900.12.12")));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            // Create an array
            Array booksArrayCopy = Array.CreateInstance(typeof(Book), books.Count);

            // Convert books collection to array
            Book[] booksArray = books.ToArray();

            // Sort the array
            Sort(booksArray);

            // Copy booksArray to booksArrayCopy
            try
            {
                Copy(booksArray, booksArrayCopy, booksArray.Length);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            // view the array data
            ViewBooks(booksArrayCopy);

            // check if collection contains a book with specified isbn
            try
            {
                books.Contains("2365-32456-9-193");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            // remove a book at a specific index
            books.RemoveAt(1);

            // view the array data
            WriteLine(@"After removing a book");
            ViewBooks();

            // hold
            ReadLine();
        }

        // view books
        public static void ViewBooks(Array array)
        {
            IEnumerator enumerator = array.GetEnumerator();

            while (enumerator.MoveNext())
            {
                WriteLine(enumerator.Current);
                WriteLine();
            }
        }

        // overloaded view books
        public static void ViewBooks()
        {
            foreach (Book item in books)
            {
                WriteLine(item);
                WriteLine();
            }
        }
    }
}
