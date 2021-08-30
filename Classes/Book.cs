using System;

namespace Books
{
    public class Book : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Author { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Book(int id, string author, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Genre = genre;
            this.Description = description;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string bookInfoMsg = "";
            bookInfoMsg += "Genre: " + this.Genre + Environment.NewLine;
            bookInfoMsg += "Title: " + this.Title + Environment.NewLine;
            bookInfoMsg += "Author: " + this.Author + Environment.NewLine;
            bookInfoMsg += "Year: " + this.Year + Environment.NewLine;
            bookInfoMsg += "Description: " + this.Description + Environment.NewLine;
            bookInfoMsg += "Deleted: " + this.Deleted;

            return bookInfoMsg;
        }

        public string GetTitle()
        {
            return this.Title;
        }
        public int GetId()
        {
            return this.Id;
        }
        public bool GetDeleted() 
        {
            return this.Deleted;
        }
        public void DeleteBook()
        {
            this.Deleted = true;
        }
    }
}