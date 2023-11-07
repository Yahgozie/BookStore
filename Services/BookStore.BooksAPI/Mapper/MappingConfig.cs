using AutoMapper;
using BookStore.BooksAPI.Models;
using BookStore.BooksAPI.Models.Dto;

namespace BookStore.BooksAPI.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Book, BookDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
