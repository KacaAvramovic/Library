using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>> GetAllAsync();

        public Task<Author> GetByIdAsync(int id);

        public Task<Author> AddAsync(Author author);

        public Task<Author> UpdateAsync(Author author);

        public Task<bool> RemoveAsync(Author author);
    }
}
