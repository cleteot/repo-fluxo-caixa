using AutoMapper;
using SaldoService.Application.DTOs;
using SaldoService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoService.Application.MapDTOToDomain
{
    public class SaldoDiaProfile : Profile
    {
        public SaldoDiaProfile()
        {
            CreateMap<SaldoDiarioDto, SaldoDia>();
            CreateMap<SaldoDia, SaldoDiarioDto>();
        }
    }
}
