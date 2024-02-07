using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, string category, int year, double price)
    {
        Title = title;
        Author = author;
        Category = category;
        Year = year;
        Price = price;
    }
}

class Author
{
    public string Name { get; set; }
    public string Biography { get; set; }

    public Author(string name, string biography)
    {
        Name = name;
        Biography = biography;
    }
}

sealed class Category
{
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public Category(string categoryName, string description)
    {
        CategoryName = categoryName;
        Description = description;
    }
}

static class LibraryManager
{
    private static List<Book> books = new List<Book>();

    public static void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book added successfully!");
    }

    public static void RemoveBook(string title)
    {
        Book bookToRemove = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Book removed successfully!");
        }
        else
        {
            Console.WriteLine("Book not found!");
        }
    }

    public static void ListAllBooks()
    {
        Console.WriteLine("List of Books:");
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Category: {book.Category}, Year: {book.Year}, Price: {book.Price:C}");
        }
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. List All Books");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine();
                    Console.Write("Enter Year: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Price: ");
                    double price = Convert.ToDouble(Console.ReadLine());

                    Book newBook = new Book(title, author, category, year, price);
                    LibraryManager.AddBook(newBook);
                    break;

                case 2:
                    Console.Write("Enter Title of the book to remove: ");
                    string titleToRemove = Console.ReadLine();
                    LibraryManager.RemoveBook(titleToRemove);
                    break;

                case 3:
                    LibraryManager.ListAllBooks();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
