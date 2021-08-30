using System;
using System.Collections.Generic;
using Books.Interfaces;

namespace Books
{
    public class BookRepository : iRepositorio<Book>
    {
        private List<Book> listBook = new List<Book>();

        public void Update(int id, Book obj)
        {
            listBook[id] = obj;
        }

        public void Delete(int id)
        {
            listBook[id].DeleteBook();
        }

        public void Insert(Book obj)
        {
            listBook.Add(obj);
        }

        public List<Book> List()
        {
            return listBook;
        }

        public int NextId()
        {
            return listBook.Count;
        }

        public Book ReturnById(int id)
        {
            return listBook[id];
        }
    }
}