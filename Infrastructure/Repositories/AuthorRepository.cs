using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(b => b.Id == id);
        }

        public IEnumerable<Author> Search(Func<Author, bool> searchFunction)
        {
            return _context.Authors.Where(b => searchFunction(b));
        }

        public async Task<int> CreateAsync(Author author)
        {
            var newAuthor = await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            return newAuthor.Entity.Id;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            var updatedBook = _context.Authors.Update(author);
            await _context.SaveChangesAsync();

            return updatedBook.Entity;
        }

        public async Task<bool> RemoveAsync(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
