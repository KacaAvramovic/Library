using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllAsync();
        public Task<Book> GetByIdAsync(int id);
        public IEnumerable<Book> Search(Func<Book, bool> searchFunction);
        public Task<Book> CreateAsync(Book book);
        public Task<Book> UpdateAsync(Book book);
        public Task<bool> RemoveAsync(Book book);
    }
}
