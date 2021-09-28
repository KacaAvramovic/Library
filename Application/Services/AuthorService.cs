using Application.Interfaces;
using Domain.Models;
using Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository repository)
        {
            _authorRepository = repository;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }

        public async Task<Author> AddAsync(Author author)
        {
            if (_authorRepository.Search(a => a.FirstName == author.FirstName && a.LastName == author.LastName).ToList().Any())
                return null;

            await _authorRepository.CreateAsync(author);
            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            if ( _authorRepository.Search(a => a.Id == author.Id).ToList().Any())
                return null;

            await _authorRepository.UpdateAsync(author);
            return author;
        }

        public async Task<bool> RemoveAsync(Author author)
        {
            if ( _authorRepository.Search(a => a.Id == author.Id).ToList().Any())
                return false;

            await _authorRepository.RemoveAsync(author);
            return true;
        }

    }
}
