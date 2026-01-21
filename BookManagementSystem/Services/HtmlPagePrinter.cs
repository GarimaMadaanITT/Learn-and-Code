using System;
using BookManagementSystem.Interfaces;

namespace BookManagementSystem.Services
{
    public class HtmlPagePrinter : IPagePrinter
    {
        public void PrintPage(string pageContent)
        {
            Console.WriteLine($"<div class='single-page'>{pageContent}</div>");
        }
    }
}
