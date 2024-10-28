using AutoMapper;
using VendaIngressos.Application.DTOs.Produto;
using VendaIngressos.Application.DTOs.ProdutoReadDto;
using VendaIngressos.Domain.Entities;

namespace VendaIngressos.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamento para Produto
            CreateMap<Produto, ProdutoCreateDto>().ReverseMap();
            CreateMap<Produto, ProdutoReadDto>().ReverseMap();
            CreateMap<Produto, ProdutoUpdateDto>().ReverseMap();
            CreateMap<Produto, ProdutoDeleteDto>().ReverseMap();

            // Mapeamento para ProdutoDesconto
            CreateMap<ProdutoDesconto, ProdutoDescontoCreateDto>().ReverseMap();
            CreateMap<ProdutoDesconto, ProdutoDescontoReadDto>().ReverseMap();
            CreateMap<ProdutoDesconto, ProdutoDescontoUpdateDto>().ReverseMap();
            CreateMap<ProdutoDesconto, ProdutoDescontoDeleteDto>().ReverseMap();
        }
    }
}
