using MVVM_Example.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }

        public List<Opinion> Opinions { get; set; }

        public Book()
        {
            Opinions = new List<Opinion>();
        }
        ~Book()
        {
            Console.Beep();
        }

        public static List<Book> DownloadBooks()
        {
            return new List<Book>(BooksDummyDataStore.Current.BooksFromDb);
        }

    }
}
