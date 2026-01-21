using System.IO;
using System.Text.Json;
using BookManagementSystem.Interfaces;
using BookManagementSystem.Models;

namespace BookManagementSystem.Services
{
    public class FileBookRepository : IBookRepository
    {
        public void Save(Book book)
        {
            var directoryPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Documents"
            );

            Directory.CreateDirectory(directoryPath);

            var filePath = Path.Combine(
                directoryPath,
                $"{book.Title}-{book.Author}.json"
            );

            var json = JsonSerializer.Serialize(book, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }
    }
}
