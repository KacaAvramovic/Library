using Application.Interfaces;
using Domain.Models;
using Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository repository)
        {
            _bookRepository = repository;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            if (_bookRepository.Search(b => b.Title == book.Title).ToList().Any())
            {
                return null;
            }

            return await _bookRepository.CreateAsync(book);
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            await _bookRepository.UpdateAsync(book);
            return book;
        }

        public async Task<bool> RemoveAsync(int bookId)
        {
            var book =  _bookRepository.Search(b => b.Id == bookId).FirstOrDefault();

            if (book == null)
            {
                return false;
            }

            await _bookRepository.RemoveAsync(book);
            return true;
        }
    }
}
