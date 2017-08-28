using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IListFullImplementation
{
    class Book : IComparable<Book>, IList<Book>
    {
        // properties
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public List<Book> BookList { get; } = new List<Book>();
        public int Count => BookList.Count;
        public bool IsReadOnly => false;
        public Book this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = value;
            }
        }

        // default constructor
        public Book() { }

        // constructor
        public Book(string bookNo, string name, string writer, string pub, DateTime published)
        {
            ISBN = bookNo;
            Title = name;
            Author = writer;
            Publisher = pub;
            PublicationDate = published;
        }

        // book data
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"ISBN: {ISBN}");
            buffer.AppendLine($"Title: {Title}");
            buffer.AppendLine($"Author: {Author}");
            buffer.AppendLine($"Publisher: {Publisher}");
            buffer.AppendLine($"Publication date: {PublicationDate.ToShortDateString()}");
            return buffer.ToString();
        }

        // IList add to collection
        public void Add(Book item)
        {
            if (!BookList.Contains(item))
            {
                BookList.Add(item);
            }
        }

        public void Contains(string v)
        {
            for (int i = 0; i < BookList.Count; i++)
            {
                if (BookList[i].ISBN == v)
                {
                    WriteLine("Found book");
                }
                else
                {
                    throw new Exception(message: "ISBN not found");
                }
            }
        }

        // IList clear collection
        public void Clear() => BookList.Clear();

        // IList check if collection already has item
        public bool Contains(Book item)
        {
            bool found = false;
            foreach (Book book in BookList)
            {
                if (book.Equals(item))
                {
                    found = true;
                }
            }
            return found;
        }

        // IList copy collection to array
        public void CopyTo(Book[] array, int arrayIndex)
        {
            // array can't be null
            if (array == null)
            {
                throw new ArgumentNullException(message: "Array can't be null", paramName: nameof(array));
            }

            // array start index can't be negative
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(message: "Start index can't be negative", paramName: nameof(array));
            }

            // array can't have fewer elements than collection
            if (BookList.Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentException(message: "Destination has fewer elements than source", paramName: nameof(array));
            }

            // all good
            for (int i = 0; i < BookList.Count; i++)
            {
                array[i + arrayIndex] = BookList[i];
            }
        }

        // IList to enable looping through list with enumerator
        public IEnumerator<Book> GetEnumerator() => BookList.GetEnumerator();

        // IList return index of item
        public int IndexOf(Book item)
        {
            int index = -1;
            for (int i = 0; i < BookList.Count; i++)
            {
                if (BookList[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        // IList insert an item at specified index
        public void Insert(int index, Book item)
        {
            // item can't be a plain Book object
            if (item.ISBN == null)
            {
                throw new ArgumentNullException("Book can't be null");
            }

            // index can't be less than 0
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index can't be negative");
            }

            // index can't exceed current index max
            if (index > BookList.Count)
            {
                throw new ArgumentOutOfRangeException("Index can't be higher than array index maximum");
            }

            // all is good
            BookList.Insert(index, item);
        }

        // IList remove an item
        public bool Remove(Book item)
        {
            bool found = false;
            for (int i = 0; i < BookList.Count; i++)
            {
                Book current = (Book)BookList[i];
                if (current.Equals(item))
                {
                    found = true;
                    BookList.RemoveAt(i);
                    break;
                }
            }
            return found;
        }

        // IList remove an item a specified index
        public void RemoveAt(int index) => BookList.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => BookList.GetEnumerator();

        // IComparable<Book> compare book ISBN
        public int CompareTo(Book other) => ISBN.CompareTo(other.ISBN);
    }
}
