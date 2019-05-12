using MVVM_Example.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Example.ViewModel
{
    public class BookshelfVM : PropertyBase
    {
        private List<Book> AllBooks;

        protected ObservableCollection<Book> _Books;
        public virtual ObservableCollection<Book> Books
        {
            get
            {
                if (_Books == null)
                    _Books = new ObservableCollection<Book>();
                return _Books;
            }
            set
            {
                _Books = value;
                OnPropertyChanged(nameof(DownloadBooksText));
                OnPropertyChanged(nameof(Books));
            }
        }

        protected string _SearchField;
        public virtual string SearchField
        {
            get
            {
                return _SearchField;
            }
            set
            {
                _SearchField = value;
                OnPropertyChanged(nameof(SearchField));
            }
        }

        //TODO:DOKONCZYC PODMIENIANIE AUTOMATYCZNE TEKSTU
        public String DownloadBooksText
        {
            get
            {
                return (AllBooks.Any() ? "Refresh books" : "Download books");
            }
        }


        protected ICommand _LoadBooksFromDummyDb;
        public ICommand LoadBooksFromDummyDb
        {
            get
            {
                if (_LoadBooksFromDummyDb == null)
                {
                    _LoadBooksFromDummyDb = new BaseCommand<object>(GetBooksExecute, GetBooksCanExecute);
                }
                return _LoadBooksFromDummyDb;
            }
        }

        private void GetBooksExecute(object obj)
        {
            if (!AllBooks.Any())
            {
                Books = new ObservableCollection<Book>(Book.DownloadBooks());
                AllBooks = new List<Book>(Books);
            }
            else
            {
                Books = new ObservableCollection<Book>(AllBooks);
            }
        }
        private bool GetBooksCanExecute(object obj)
        {
            return true;
        }

        protected ICommand _RemoveOneBookFromList;
        public ICommand RemoveOneBookFromList
        {
            get
            {
                if (_RemoveOneBookFromList == null)
                {
                    _RemoveOneBookFromList = new BaseCommand<object>(RemoveOneBookFromListExecute, RemoveOneBookFromListCanExecute);
                }
                return _RemoveOneBookFromList;
            }
        }

        private bool RemoveOneBookFromListCanExecute(object obj)
        {
            return Books.Any();
        }

        private void RemoveOneBookFromListExecute(object obj)
        {
            Books.RemoveAt(Books.Count - 1);
        }

        protected ICommand _SearchBook;
        public ICommand SearchBook
        {
            get
            {
                if (_SearchBook == null)
                {
                    _SearchBook = new BaseCommand<object>(SearchBookExecute);
                }
                return _SearchBook;
            }
        }
        //TODO: Dokonczyc sprawdzanie uzupełnionego tekstu w textboxie
        //public bool SearchButtonEnabled
        //{
        //    get
        //    {
        //        return !string.IsNullOrEmpty(SearchField);
        //    }
        //}

        private void SearchBookExecute(object obj)
        {
            if (!string.IsNullOrEmpty(SearchField))
                Books = new ObservableCollection<Book>(AllBooks.FindAll(x => x.Title.ToLower().Contains(SearchField.ToLower()) || x.Author.FullName.ToLower().Contains(SearchField.ToLower()) || x.Description.ToLower().Contains(SearchField.ToLower())));
        }

        public BookshelfVM()
        {
            _Books = new ObservableCollection<Book>();
            AllBooks = new List<Book>();
        }

    }
}
