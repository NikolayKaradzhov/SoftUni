using System;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var input = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.AgeRestriction
                })
                .Where(b => b.AgeRestriction == input)
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Select(b => new
                {
                    b.Copies,
                    b.Title,
                    b.EditionType,
                    b.BookId
                })
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId);

            StringBuilder sb = new StringBuilder();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
