using AutoMapper;
using CEMEX.API.Models.Catalogos;
using CEMEX.API.Models.Seguridad;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
using System.Collections.Generic;

namespace CEMEX.API.Mappings
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        public DomainToViewModelMappingProfile()
        {

            //Mapping Catalogos
            CreateMap<Estado, EstadoViewModel>().ForMember(e => e.Municipios, map => map.MapFrom(ma => ma.Municipios));
            CreateMap<Municipio, MunicipioViewModel>();
            CreateMap<Region, RegionViewModel>();


            CreateMap<Jerarquia, JerarquiaViewModel>();

            CreateMap<Permiso, PermisoViewModel>();

            CreateMap<Modulo, ModuloViewModel>();//.ForMember(m => m.DetalleModuloPermisos, map =>map.MapFrom(ma => ma.ModuloDetallePermisos));

            CreateMap<DetalleModuloPermiso, DetalleModuloPermisoViewModel>();

            CreateMap<Rol, RolViewModel>();

            CreateMap<Usuario, UsuarioViewModel>().ForMember(u => u.Contrasena, opt => opt.Ignore());

            
        }
    }
}