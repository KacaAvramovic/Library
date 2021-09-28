using AutoMapper;
using Domain.Enum;
using Domain.Models;
using LibraryApi.Dtos.Author;
using LibraryApi.Dtos.Book;
using LibraryApi.Dtos.Genre;

namespace LibraryApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<Book, BookGetDto>();
            CreateMap<BookGetDto, Book>();

            CreateMap<Book, BookUpdateDto>();
            CreateMap<BookUpdateDto, Book>()
                  .ForMember(b => b.AuthorId, a => a.MapFrom(dto => dto.Author))
                  .ForMember(b => b.Author, opt => opt.Ignore());

            CreateMap<Book, BookCreateDto>();
            CreateMap<BookCreateDto, Book>()
                 .ForMember(b => b.AuthorId, a => a.MapFrom(dto => dto.Author))
                 .ForMember(b => b.Author, opt => opt.Ignore()); 

            CreateMap<Author, AuthorDto>()
                .ForMember(a => a.Name, name => name.MapFrom(dto => $"{dto.FirstName} {dto.LastName}"));
            CreateMap<AuthorDto, Author>()
                .ForMember(a => a.FirstName, name => name.MapFrom(a => ExtractFirstName(a.Name)))
                .ForMember(a => a.LastName, name => name.MapFrom(a => ExtractLastName(a.Name)));

            CreateMap<BookGenre, GenreDto>()
                .ForMember(dto => dto.Id, id => id.MapFrom(a => a))
                .ForMember(dto => dto.Name, name => name.MapFrom(a => a.ToString())); 
            CreateMap<GenreDto, BookGenre>();
        }

        private string ExtractFirstName(string name)
        {
            var separatorIndex = name.LastIndexOf(' ');
            return name.Substring(0, separatorIndex);
        }

        private string ExtractLastName(string name)
        {
            var separatorIndex = name.LastIndexOf(' ');
            return name.Substring(separatorIndex, name.Length - 1 - separatorIndex);
        }
    }
}
