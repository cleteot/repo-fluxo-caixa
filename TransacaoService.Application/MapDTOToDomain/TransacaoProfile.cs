using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoService.Application.DTOs;
using TransacaoService.Domain.Models;

namespace TransacaoService.Application.MapDTOToDomain
{
    public class TransacaoProfile : Profile
    {
        public TransacaoProfile()
        {
            CreateMap<TransacaoDto, Transacao>();
            CreateMap<Transacao, TransacaoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoTransacao, opt => opt.MapFrom(src => (int)src.TipoTransacao));
        }
    }
}
