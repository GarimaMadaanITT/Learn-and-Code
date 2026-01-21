using System;
using BookManagementSystem.Interfaces;

namespace BookManagementSystem.Services
{
    public class PlainTextPagePrinter : IPagePrinter
    {
        public void PrintPage(string pageContent)
        {
            Console.WriteLine(pageContent);
        }
    }
}
