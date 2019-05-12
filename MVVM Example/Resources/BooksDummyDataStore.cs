using MVVM_Example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example.Resources
{
    public class BooksDummyDataStore
    {
        public static BooksDummyDataStore Current { get; } = new BooksDummyDataStore();

        public List<Book> BooksFromDb { get; set; }

        public BooksDummyDataStore()
        {
            BooksFromDb = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Władca Pierścieni - Drużyna Pierścienia",
                    Description = "Kultowa powieść Tolkien, pierwsza odsłona trylogii",
                    Author = new Author()
                    {
                        Id = 1,
                        DateOfBirth = DateTime.Today,
                        Name = "J.R.R",
                        Surname = "Tolkien"                            
                    }
                },
                new Book()
                {
                    Id = 2,
                    Title = "Władca Pierścieni - Dwie wieże",
                    Description = "Kultowa powieść Tolkien, druga odsłona trylogii",
                    Author = new Author()
                    {
                        Id = 1,
                        DateOfBirth = DateTime.Today,
                        Name = "J.R.R",
                        Surname = "Tolkien"
                    }
                },
                new Book()
                {
                    Id = 3,
                    Title = "Harry Potter i Kamień Filozoficzny",
                    Description = "Powieść o przygodach chłopca, który umiał w czary",
                    Author = new Author()
                    {
                        Id = 2,
                        DateOfBirth = DateTime.Today.AddDays(-10),
                        Name = "J.K",
                        Surname = "Rowling"
                    }
                }
            };
        }
    }
}
