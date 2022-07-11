using System;
using System.Collections.Generic;

namespace BookStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();
            application.StartWork();
        }
    }

    class Application
    {
        private readonly Storage _storage;

        public Application()
        {
            _storage = new Storage();
        }

        public void StartWork()
        {
            string command = "";

            _storage.AddInfo();

            while (command != "exit")
            {
                Console.Write("\n Добро пожаловать в программу: Хранилище книг!\n В данной программе eсть хранилище книг. Каждая книга имеет название, автора, год выпуска, оглавление и количество\n " +
                "страниц. В хранилище можно добавить книгу, убрать книгу, показать все книги и показать книги по указанному параметру\n (по названию, по автору, по году выпуска).\n\n");

                _storage.ShowInfo();

                Console.Write("\n Команды:\n add - добавить книгу,\n del - убрать книгу,\n all - посмотреть все книги в хранилище,\n name - показать книги по названию,\n author - показать книги по" +
                " автору,\n year - показать книги по году выпуска,\n exit - выход из приложения.\n\n");

                Console.Write("\n Введите команду: ");
                command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                        AddBook();
                        break;
                    case "del":
                        DeleteBook();
                        break;
                    case "all":
                        _storage.ShowAllBooks();
                        break;
                    case "name":
                        ShowNameBooks();
                        break;
                    case "author":
                        ShowAuthorBooks();
                        break;
                    case "year":
                        ShowYearBooks();
                        break;
                    case "exit":
                        break;
                }

                Console.Write("\n Нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
            }

            Console.Write("\n Программа База данных игроков завершается.\n");
        }

        private void AddBook()
        {
            Console.Write("\n Добавьте информацию о книге, которую вы хотите положить в хранилище!\n Введите название книги: ");
            string name = Console.ReadLine();

            Console.Write("\n Введите автора книги: ");
            string author = Console.ReadLine();

            Console.Write("\n Введите оглавление книги: ");
            string contents = Console.ReadLine();

            Console.Write("\n Введите год выпуска книги: ");
            if (int.TryParse(Console.ReadLine(), out int yearIssue) == false)
            {
                Console.Write("\n Ошибка ввода. Введено не число.\n");
            }
            
            Console.Write("\n Введите количество страниц в книге: ");
            if (int.TryParse(Console.ReadLine(), out int numberPages) == false)
            {
                Console.Write("\n Ошибка ввода. Введено не число.\n");
            }

            _storage.AddBook(name, author, contents, yearIssue, numberPages);
        }

        private void DeleteBook()
        {
            Console.Write("\n Введите название книги, которую вы хотите удалить: ");
            string name = Console.ReadLine();

            Console.Write("\n Введите автора книги, которую вы хотите удалить: ");
            string author = Console.ReadLine();

            _storage.DeleteBook(author, name);
        }

        private void ShowNameBooks()
        {
            Console.Write("\n Введите название книги, которую вы хотите посмотреть: ");
            string name = Console.ReadLine();

            _storage.ShowNameBooks(name);
        }

        private void ShowAuthorBooks()
        {
            Console.Write("\n Введите автора книги, которую вы хотите посмотреть: ");
            string author = Console.ReadLine();

            _storage.ShowAuthorBooks(author);
        }

        private void ShowYearBooks()
        {
            Console.Write("\n Введите год выпуска книги, которую вы хотите посмотреть: ");
            if (int.TryParse(Console.ReadLine(), out var yearIssue) == false)
            {
                Console.Write("\n Ошибка ввода. Введено не число.\n");
            }
            else
            {
                _storage.ShowYearBooks(yearIssue);
            }
        }
    }

    class Storage
    {
        private readonly List<Book> _books;

        public int NumberBooks { get; private set; }

        public Storage()
        {
            _books = new List<Book>();
        }

        public void AddInfo()
        {
            Book book1 = new Book("Sapiens. Краткая история человечества", "Юваль Ной Харари", "5 глав", 2011, 400);
            Book book2 = new Book("Бог как элюзия", "Ричард Докинз", "10 глав", 2016, 300);
            Book book3 = new Book("Эгоистичный ген", "Ричард Докинз", "7 глав", 1989, 200);
            Book book4 = new Book("Происхождение видов", "Чарльз Дарвин", "5 глав", 1859, 500);
            Book book5 = new Book("Вы, конечно, шутите, мистер Фейнман", "Ричард Фейнман", "9 глав", 1985, 300);
            Book book6 = new Book("1984", "Джордж Оруэлл", "15 частей", 1949, 200);
            Book book7 = new Book("Пикник на обочине", "Братья Стругацкие", "13 частей", 1971, 350);
            Book book8 = new Book("Мастер и Маргарита", "Михаил Афанасьевич", "20 частей", 1967, 250);
            Book book9 = new Book("Трудно быть богом", "Братья Стругацкие", "23 главы", 1964, 300);
            Book book10 = new Book("Гормоны счастья. Как приручить мозг вырабатывать серотонин, дофамин, эндорфин и окситоцин", "Лоретта Бройнинг, Зверь", "14 глав", 2016, 500);
            Book book11 = new Book("Ведьмак", "Анджей Сапковский", "15 глав", 1993, 400);
            Book book12 = new Book("Преуступление и наказание", "Федор михайлович достоевский", "15 глав", 1866, 2);

            _books.Add(book1);
            _books.Add(book2);
            _books.Add(book3);
            _books.Add(book4);
            _books.Add(book5);
            _books.Add(book6);
            _books.Add(book7);
            _books.Add(book8);
            _books.Add(book9);
            _books.Add(book10);
            _books.Add(book11);
            _books.Add(book12);

            NumberBooks = _books.Count;
        }

        public void ShowInfo()
        {
            Console.WriteLine(" Общее количество книг, имеющихся в хранилище NumberCards = " + NumberBooks + ".");
        }

        public void AddBook(string name, string author, string contents, int yearIssue, int numberPages)
        {
            Book book = new Book(name, author, contents, yearIssue, numberPages);
            _books.Add(book);
            Console.WriteLine("\n Книга добавлена в хранилище.");
        }

        public void DeleteBook(string author, string name)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (name == _books[i].Name && author == _books[i].Author)
                {
                    _books.RemoveAt(i);
                    Console.WriteLine("\n Книга удалена из хранилища.");
                }
            }
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("\n Весь список книг:");
            for (int i = 0; i < _books.Count; i++)
            {
                ShowBooks(i);
            }
        }

        public void ShowNameBooks(string name)
        {
            Console.WriteLine("\n Список книг по названию:");
            for (int i = 0; i < _books.Count; i++)
            {
                if (name == _books[i].Name)
                {
                    ShowBooks(i);
                }
            }
        }

        public void ShowAuthorBooks(string author)
        {
            Console.WriteLine("\n Список книг по автору:");
            for (int i = 0; i < _books.Count; i++)
            {
                if (author == _books[i].Author)
                {
                    ShowBooks(i);
                }
            }
        }

        public void ShowYearBooks(int yearIssue)
        {
            Console.WriteLine("\n Список книг по году выпуска:");
            for (int i = 0; i < _books.Count; i++)
            {
                if (yearIssue == _books[i].YearIssue)
                {
                    ShowBooks(i);
                }
            }
        }

        private void ShowBooks(int i)
        {
            Console.Write(" Номер - " + i);
            _books[i].ShowDescription();
        }
    }

    class Book
    {
        private readonly string _contents;
        private readonly int _numberPages;

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int YearIssue { get; private set; }

        public Book(string name, string author, string contents, int yearIssue, int numberPages)
        {
            _contents = contents;
            _numberPages = numberPages;
            Name = name;
            Author = author;
            YearIssue = yearIssue;
        }

        public void ShowDescription()
        {
            Console.WriteLine(", название - " + Name + ", автор - " + Author + ", оглавление - " + _contents + ",\n год выпуска - " + YearIssue + ", количество страниц - " + _numberPages + ".\n");
        }
    }
}