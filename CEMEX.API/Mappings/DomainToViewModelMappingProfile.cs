﻿using AutoMapper;
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
            CreateMap<Movil, MovilViewModel>();
            CreateMap<PerfilUsuario, PerfilUsuarioViewModel>();
            CreateMap<Estado, EstadoViewModel>().ForMember(e => e.Municipios, map => map.MapFrom(ma => ma.Municipios));
            CreateMap<Municipio, MunicipioViewModel>();
            CreateMap<Region, RegionViewModel>();
            CreateMap<PlazaImmex, PlazaImmexViewModel>();
            CreateMap<PlazaOxxo, PlazaOxxoViewModel>();
            CreateMap<Distrito, DistritoViewModel>();
            CreateMap<Tienda, TiendaViewModel>();


            CreateMap<Jerarquia, JerarquiaViewModel>();
            CreateMap<Permiso, PermisoViewModel>();
            CreateMap<Usuario, UsuarioViewModel>().ForMember(u => u.Contrasena, opt => opt.Ignore());            
        }
    }
}