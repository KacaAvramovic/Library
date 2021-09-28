using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using LibraryApi.Dtos.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, ILogger<BooksController> logger, IMapper mapper)
        {
            _bookService = bookService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));           
        }

        [HttpGet]
        [Route("{bookId}")]
        public async Task<IActionResult> GetAsync(int bookId)
        {
            var book = await _bookService.GetByIdAsync(bookId);

            if (book == null)
            {
                _logger.LogInformation($"Book with id {bookId} not found.");
                return NotFound($"Book with id {bookId} not found.");
            }

            return Ok(_mapper.Map<BookDto>(book));                    
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Book model invalid: ({bookDto.Title}, {bookDto.Author}).");
                return BadRequest("You were trying to create invalid book.");
            }

            var book = _mapper.Map<Book>(bookDto);
            var bookResult = await _bookService.AddAsync(book);

            if (bookResult == null)
            {
                _logger.LogWarning($"There was an error while adding the book ({bookDto.Title}, {bookDto.Author}).");
                return BadRequest("There was an error while adding the book. Are you trying to add existing book?");
            }

            return Ok(_mapper.Map<BookDto>(bookResult));
        }

        [HttpPut]
        [Route("{bookId}")]
        public async Task<IActionResult> Update(BookUpdateDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Book model invalid: ({bookDto.Title}, {bookDto.Author}, {bookDto.Genre}).");
                return BadRequest("You were trying to update book with invalid data.");
            }

            var book = _mapper.Map<Book>(bookDto);

            var bookResult = await _bookService.UpdateAsync(book);

            return Ok(_mapper.Map<BookDto>(bookResult));
        }

        [HttpDelete]
        [Route("{bookId}")]
        public async Task<IActionResult> Delete(int bookId)
        {
            if (await _bookService.RemoveAsync(bookId))
            {
                return Ok();
            };

            return NotFound("The book was not found");
        }
    }
}
