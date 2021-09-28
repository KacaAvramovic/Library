﻿using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos.Book
{
    public class BookUpdateDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int Genre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int Author { get; set; }
    }
}
