using System;
using BookManagementSystem.Models;
using BookManagementSystem.Services;

class Program
{
    static void Main()
    {
        var location = new BookLocation("Reading Room", "Shelf 5");
        var book = new Book("A Great Book", "John Doe", location);

        var printer = new HtmlPagePrinter();
        var repository = new FileBookRepository();

        printer.PrintPage(book.GetCurrentPage());
        repository.Save(book);

        Console.WriteLine($"Book Location: {book.Location}");
    }
}
