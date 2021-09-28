using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAllAsync();
        public Task<Author> GetByIdAsync(int id);
        public IEnumerable<Author> Search(Func<Author, bool> searchFunction);
        public Task<int> CreateAsync(Author author);
        public Task<Author> UpdateAsync(Author author);
        public Task<bool> RemoveAsync(Author author);
    }
}
