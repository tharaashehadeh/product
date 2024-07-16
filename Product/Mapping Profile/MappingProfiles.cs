using AutoMapper;
using Product.Core.Entities;
using Product.Core.Entities.DTO;
namespace Product.Mapping_Profile
{
    public class MappingProfiles :Profile
    {
       public MappingProfiles()
        {
            CreateMap<Products, ProductDTO>();
              //  .ForMember(To=>To.Category_Name,from=>from.MapFrom(x=>x.Category!=null?x.Category.Name:null));
        }
    }
}
