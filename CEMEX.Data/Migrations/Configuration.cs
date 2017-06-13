namespace CEMEX.Data.Migrations
{
    using Entidades.App;
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
            //Agrega el menu Por Default
            context.MenuSet.AddOrUpdate(GetMenus());

            context.DetallePerfilUsuarioMenu.AddOrUpdate(DetallePerfilUsuarioMenus());
        }

        private Jerarquia[] GetJerarquias()
        {
            return new Jerarquia[]
            {
                new Jerarquia() { NivelJerarquia =  1, Nombre ="Administraci�n", Descripcion ="Administraci�n", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico= 0},
                new Jerarquia() { NivelJerarquia =  2, Nombre ="Supervisi�n", Descripcion ="Supervisi�n", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico= 0 },
                new Jerarquia() { NivelJerarquia =  3, Nombre ="Operativo", Descripcion ="Supervisi�n", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico= 0 }
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
                    PrimerApellido = "L�pez",
                    SegundoApellido ="V�squez",
                    Sexo = 1,
                    Telefono ="8118853757",
                    Email ="aarturock92@gmail.com",
                    Curp ="LOVA920508HPLPSR02",
                    RFC = "LOVA920508",
                    FechaNacimiento ="08/05/1992",
                    NombreUsuario ="admin",
                    HashedContrase�a = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
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
                    ID = 1,
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
                new Permiso() { Nombre ="Crear" , Descripcion = "Permiso para la creaci�n de un recurso", Icono ="", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Permiso() { Nombre ="Editar" , Descripcion = "Permiso para la edici�n de un recurso", Icono ="", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Permiso() { Nombre ="Cambiar Estatus" , Descripcion = "Permiso para poder cambiar es Estatus de un recurso", Icono ="", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Permiso() { Nombre ="Eliminar" , Descripcion = "Permiso para poder eliminar un recurso", Icono ="", Estatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 }
            };
        }

        private Menu[] GetMenus()
        {
            return new Menu[]
            {
                new Menu() { IdMenuPadre = 0, Nombre = "Inicio", Descripcion = "Inicio", Url ="", Orden = 1, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 0, Nombre = "Configuraci�n", Descripcion = "Configuraci�n", Url ="javascript:void(0)", Orden = 2, CssClass ="menu-configuracion", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 1, Nombre = "Administraci�n de Perfiles", Descripcion = "Administraci�n de Perfiles", Url ="AdmonPerfiles.aspx", Orden = 1, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 1, Nombre = "Administraci�n de Usuarios", Descripcion = "Administraci�n de Usuarios", Url ="admonUsuarios.aspx", Orden = 2, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 1, Nombre = "Administraci�n de M�viles", Descripcion = "Administraci�n de M�viles", Url ="admonMoviles.aspx", Orden = 3, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 1, Nombre = "Cat�logos", Descripcion = "Cat�logos", Url ="AdmonCatalogos.aspx", Orden = 4, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 1, Nombre = "Carga Masiva", Descripcion = "Carga Masiva", Url ="CargaMasiva.aspx", Orden = 5, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 0, Nombre = "Encuestas", Descripcion = "Encuestas", Url ="javascript:void(0)", Orden = 3, CssClass ="menu-encuestas", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 7, Nombre = "Administraci�n de Encuestas", Descripcion = "Administraci�n de Encuestas", Url ="AdmonEncuestas.aspx", Orden = 1, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 7, Nombre = "Administraci�n de Secciones", Descripcion = "Administraci�n de Secciones", Url ="AdmonSecciones.aspx", Orden = 2, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 0, Nombre = "Rutas", Descripcion = "Rutas", Url ="javascript:void(0)", Orden = 4, CssClass ="menu-logistica", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 10, Nombre = "Administraci�n de Rutas", Descripcion = "Administraci�n de Rutas", Url ="AdmonRutas.aspx", Orden =1, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new Menu() { IdMenuPadre = 0, Nombre = "Salir", Descripcion = "Salir", Url ="GenericMethods.aspx", Orden = 5, CssClass ="", IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 }
            };
        }

        private DetallePerfilUsuarioMenu[] DetallePerfilUsuarioMenus()
        {
            return new DetallePerfilUsuarioMenu[] {
                new DetallePerfilUsuarioMenu() {MenuId = 2, PefilUsuarioId = 1, IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new DetallePerfilUsuarioMenu() {MenuId = 3, PefilUsuarioId = 1, IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new DetallePerfilUsuarioMenu() {MenuId = 4, PefilUsuarioId = 1, IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new DetallePerfilUsuarioMenu() {MenuId = 5, PefilUsuarioId = 1, IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new DetallePerfilUsuarioMenu() {MenuId = 6, PefilUsuarioId = 1, IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new DetallePerfilUsuarioMenu() {MenuId = 7, PefilUsuarioId = 1, IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new DetallePerfilUsuarioMenu() {MenuId = 8, PefilUsuarioId = 1, IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 },
                new DetallePerfilUsuarioMenu() {MenuId = 9, PefilUsuarioId = 1, IdEstatus = 1, FechaAlta = DateTime.Now, FechaModifico = DateTime.Now, IdUsuarioAlta = 0, IdUsuarioModifico = 0 }
            };
        }
    }
}
