using Domain.Enum;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using System;
using System.Linq;

namespace LibraryApi
{
    public class InMemoryDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                InitializeBooks(context);
                InitializeAuthors(context);
            }
        }

        private static void InitializeBooks(LibraryContext context)
        {
            if (context.Books.Any())
            {
                return;
            }

            context.Books.AddRange(
                new Book
                {
                    Id = 1,
                    Title = "Igra staklenih perli",
                    Description = "Igra staklenih perli opis knjige",
                    Genre = BookGenre.Novel,
                    AuthorId = 1,
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Book
                {
                    Id = 2,
                    Title = "Če Gevara",
                    Description = "Če Gevara biografija",
                    Genre = BookGenre.Biography,
                    AuthorId = 2,
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Book
                {
                    Id = 3,
                    Title = "Kada je Niče plakao",
                    Description = "Kada je Niče plakao opis",
                    Genre = BookGenre.Novel,
                    AuthorId = 3,
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Book
                {
                    Id = 4,
                    Title = "Problem Spinoza",
                    Description = "Problem Spinoza opis",
                    Genre = BookGenre.Novel,
                    AuthorId = 3,
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Book
                {
                    Id = 5,
                    Title = "Prokleta avlija",
                    Description = "Prokleta avlija opis",
                    Genre = BookGenre.Drama,
                    AuthorId = 4,
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Book
                {
                    Id = 6,
                    Title = "Travnička hronika",
                    Description = "Travnička hronika",
                    Genre = BookGenre.Drama,
                    AuthorId = 4,
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Book
                {
                    Id = 7,
                    Title = "Tesla, portret među maskama",
                    Description = "Tesla - biografija",
                    Genre = BookGenre.Biography,
                    AuthorId = 5,
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Book
                {
                    Id = 8,
                    Title = "Sicilijanac",
                    Description = "Sicilijanac - opis",
                    Genre = BookGenre.Novel,
                    AuthorId = 6,
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                });

            context.SaveChanges();
        }

        private static void InitializeAuthors(LibraryContext context)
        {
            if (context.Authors.Any())
            {
                return;
            }

            context.Authors.AddRange(
                new Author
                {
                    Id = 1,
                    FirstName = "Herman",
                    LastName = "Hese",
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Borislav",
                    LastName = "Lalić",
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Irvin",
                    LastName = "Jalom",
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Author
                {
                    Id = 4,
                    FirstName = "Ivo",
                    LastName = "Andrić",
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Author
                {
                    Id = 5,
                    FirstName = "Vladimir",
                    LastName = "Pištalo",
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                },
                new Author
                {
                    Id = 6,
                    FirstName = "Mario",
                    LastName = "Puzo",
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow
                });

            context.SaveChanges();
        }

    }
}
