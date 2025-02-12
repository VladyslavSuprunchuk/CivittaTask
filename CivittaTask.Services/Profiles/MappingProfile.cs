using AutoMapper;

using CivittaTask.DatabaseProvider.Entities;
using CivittaTask.Shared.DTOs;

namespace CivittaTask.Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CountryDTO, Country>()
                .ForMember(dest => dest.Regions, opt => opt.MapFrom(src => MapRegions(src.Regions)))
                .ForMember(dest => dest.HolidayTypes, opt => opt.MapFrom(src => MapHolidayTypes(src.HolidayTypes)))
                .ForMember(dest => dest.FromDate, opt => opt.MapFrom(src => src.FromDate))
                .ForMember(dest => dest.ToDate, opt => opt.MapFrom(src => src.ToDate));
            CreateMap<CountryDateDTO, CountryDate>();
            CreateMap<Country, CountryDTO>()
                .ForMember(dest => dest.Regions, opt => opt.MapFrom(src => MapRegionsToString(src.Regions)))
                .ForMember(dest => dest.HolidayTypes, opt => opt.MapFrom(src => MapHolidayTypesToString(src.HolidayTypes)))
                .ForMember(dest => dest.FromDate, opt => opt.MapFrom(src => src.FromDate))
                .ForMember(dest => dest.ToDate, opt => opt.MapFrom(src => src.ToDate));
            CreateMap<CountryDate, CountryDateDTO>();

            CreateMap<HolidayDateDTO, HolidayDate>();
            CreateMap<HolidayNameDTO, HolidayName>();
            CreateMap<HolidayDTO, Holiday>();
            CreateMap<HolidayDate, HolidayDateDTO>();
            CreateMap<HolidayName, HolidayNameDTO>();
            CreateMap<Holiday, HolidayDTO>();

            CreateMap<DayDTO, Day>()
            .AfterMap((src, dest, context) =>
            {
                dest.CountryCode = (string)context.Items["CountryCode"];
                dest.Date = (DateTime)context.Items["Date"];
            });
            CreateMap<Day, DayDTO>();
        }

        private List<Region> MapRegions(List<string> regions)
        {
            if (regions == null)
                return null;

            var result = new List<Region>();
            foreach (var regionName in regions)
            {
                result.Add(new Region { Name = regionName });
            }
            return result;
        }

        private List<HolidayType> MapHolidayTypes(List<string> holidayTypes)
        {
            if (holidayTypes == null)
                return null;

            var result = new List<HolidayType>();
            foreach (var holidayTypeName in holidayTypes)
            {
                result.Add(new HolidayType { Name = holidayTypeName });
            }
            return result;
        }

        private List<string> MapRegionsToString(List<Region> regions)
        {
            if (regions == null)
                return null;

            return regions.Select(r => r.Name).ToList();
        }

        private List<string> MapHolidayTypesToString(List<HolidayType> holidayTypes)
        {
            if (holidayTypes == null)
                return null;

            return holidayTypes.Select(ht => ht.Name).ToList();
        }
    }
}
