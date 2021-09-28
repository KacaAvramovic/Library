using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos.Book
{
    public class BookGetDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }
    }
}
