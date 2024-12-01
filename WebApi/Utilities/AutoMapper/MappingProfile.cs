using AutoMapper;
using Entities.DTOs.Book;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<CreateBookRequestDto, Book>();
		CreateMap<UpdateBookRequestDto, Book>();
	}
}
