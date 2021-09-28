using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllAsync();

        public Task<Book> GetByIdAsync(int id);

        public Task<Book> AddAsync(Book book);

        public Task<Book> UpdateAsync(Book book);

        public Task<bool> RemoveAsync(int bookId);
    }
}
