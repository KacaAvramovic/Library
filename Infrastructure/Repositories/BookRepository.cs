using Domain.Consts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Contexts;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _inMemoryCacheOptions;

        public BookRepository(LibraryContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;

            _inMemoryCacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(3));

        }

        public async Task<List<Book>> GetAllAsync()
        {
            if (!_cache.TryGetValue(CacheKeys.GetAllBooks, out List<Book> books))
            {
                books = await _context.Books
                    .Include(b => b.Author).ToListAsync();

                _cache.Set(CacheKeys.GetAllBooks, books, _inMemoryCacheOptions);
            }
            
            return books;
        }

        public async Task<Book> GetByIdAsync(int id)
        {            
            if (!_cache.TryGetValue(CacheKeys.GetBookById(id), out Book book))
            {
                book = await _context.Books
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(b => b.Id == id);

                _cache.Set(CacheKeys.GetBookById(id), book, _inMemoryCacheOptions);
            }

            return book;
        }

        public IEnumerable<Book> Search(Func<Book, bool> searchFunction)
        {
            return _context.Books.Where(searchFunction);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            book.ModifiedUtc = DateTime.UtcNow;
            book.CreatedUtc = DateTime.UtcNow;

            var newBook = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return newBook.Entity;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            book.ModifiedUtc = DateTime.UtcNow;
            var updatedBook = _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return updatedBook.Entity;
        }

        public async  Task<bool> RemoveAsync(Book book)
        {
             _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
