using AutoMapper;
using BrewFree.Data.Models;
using BrewFree.ReadModels;

namespace BrewFree
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Brewer, BrewerReadModel>();
            });
        }
    }
}
