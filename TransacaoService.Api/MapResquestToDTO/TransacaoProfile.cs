using AutoMapper;
using Microsoft.Data.SqlClient;
using TransacaoService.Api.Models.Request;
using TransacaoService.Application.DTOs;
using TransacaoService.Domain.Models;

namespace TransacaoService.Api.MapResquestToDomain
{
    public class TransacaoProfile: Profile
    {
        public TransacaoProfile()
        {
            CreateMap<RespTransacao, TransacaoDto>()
                .ForMember(
                    dest => dest.TipoTransacao,
                    opt => opt.MapFrom(scr => (scr.Valor < 0.0m) ? Tipo.Debito : Tipo.Credito)
                    );
        }
    }
}
