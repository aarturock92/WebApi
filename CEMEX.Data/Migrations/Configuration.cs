namespace CEMEX.Data.Migrations
{
    using Entidades.Seguridad;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CEMEX.Data.CemexContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CEMEX.Data.CemexContext context)
        {
            //Agrega las jerarquias por default
            context.JerarquiaSet.AddOrUpdate(GetJerarquias());
            //Agrega los perfiles por default
            context.PerfilUsuarioSet.AddOrUpdate(GetPerfilesUsuario());
            //Agrega el usuario Admin por Default
            context.UsuarioSet.AddOrUpdate(GetUsuarios());
            //Agrega los Permisos por Default
            context.PermisoSet.AddOrUpdate(GetPermisos());
        }

        private Jerarquia[] GetJerarquias()
        {
            return new Jerarquia[]
            {
                new Jerarquia() { NivelJerarquia =  1, Nombre ="Administración", Descripcion ="Administración", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico= 0},
                new Jerarquia() { NivelJerarquia =  2, Nombre ="Supervisión", Descripcion ="Supervisión", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico= 0 },
                new Jerarquia() { NivelJerarquia =  3, Nombre ="Operativo", Descripcion ="Supervisión", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico= 0 }
            };
        } 

        private Usuario[] GetUsuarios()
        {
            return new Usuario[]
            {
                new Usuario()
                {
                    PerfilUsuarioId = 1,
                    NumeroEmpleado = "12345",
                    Nombre = "Arturo",
                    PrimerApellido = "López",
                    SegundoApellido ="Vásquez",
                    Sexo = 1,
                    Telefono ="8118853757",
                    Email ="aarturock92@gmail.com",
                    Curp ="LOVA920508HPLPSR02",
                    RFC = "LOVA920508",
                    FechaNacimiento ="08/05/1992",
                    NombreUsuario ="admin",
                    HashedContraseña = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    Calle ="10 Poniente",
                    NumeroExterior ="1425",
                    Colonia ="Constituyentes",
                    CodigoPostal ="75710",
                    IdPais =1,
                    IdEstado =1,
                    IdMunicipio =1,
                    Imagen =string.Empty,
                    IdEstatus = 1,
                    FechaAlta = DateTime.Now,
                    FechaModifico = DateTime.Now,
                    IdUsuarioAlta = 0,
                    IdUsuarioModifico = 0
                }
            };
        }

        private PerfilUsuario[] GetPerfilesUsuario()
        {
            return new PerfilUsuario[]
            {
                new PerfilUsuario()
                {
                    Nombre ="Administrador App",
                    Descripcion = "Administrador App",
                    JerarquiaId = 1,
                    AsignacionMultiple = false,
                    Estatus = 1,
                    FechaAlta = DateTime.Now,
                    FechaModifico = DateTime.Now,
                    IdUsuarioAlta = 0,
                    IdUsuarioModifico = 0
                }
            };
        }

        private Permiso[] GetPermisos()
        {
            return new Permiso[]
            {
                new Permiso() { Nombre ="Crear" , Descripcion = "Permiso para la creación de un recurso", Icono ="", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Permiso() { Nombre ="Editar" , Descripcion = "Permiso para la edición de un recurso", Icono ="", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Permiso() { Nombre ="Cambiar Estatus" , Descripcion = "Permiso para poder cambiar es Estatus de un recurso", Icono ="", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Permiso() { Nombre ="Eliminar" , Descripcion = "Permiso para poder eliminar un recurso", Icono ="", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 }
            };
        }
    }
}
