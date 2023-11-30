using AutoMapper;
using SaldoService.Api.Models.Response;
using SaldoService.Application.DTOs;

namespace SaldoService.Api.MapResquestToDTO
{
    public class SaldoDiaProfile: Profile
    {
        public SaldoDiaProfile()
        {
            CreateMap<SaldoDiarioDto, SaldoDiaResp>();
        }
    }
}
