using AutoMapper;
using PYP_Task_One.Aplication.DTOs;
using PYP_Task_One.Domain.Entites;

namespace PYP_Task_One.Aplication.AutoMapper;

internal class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SpreadsheetDto, Spreadsheet>().ReverseMap();
    }
}
