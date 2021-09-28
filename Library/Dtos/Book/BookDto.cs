using Domain.Enum;
using LibraryApi.Dtos.Author;
using LibraryApi.Dtos.Genre;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos.Book
{
    public class BookDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public GenreDto Genre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public AuthorDto Author { get; set; }

        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }
    }
}
