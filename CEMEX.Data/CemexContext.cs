﻿using CEMEX.Data.Configurations.App;
using CEMEX.Data.Configurations.Catalogos;
using CEMEX.Data.Configurations.Operacion;
using CEMEX.Data.Configurations.Seguridad;
using CEMEX.Entidades.App;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Operacion;
using CEMEX.Entidades.Seguridad;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CEMEX.Data
{
    public class CemexContext:DbContext
    {
        /// <summary>
        /// Declará el nombre de la cadena de Conexión a la BD.
        /// </summary>
        public CemexContext()
            :base("Cemex")
        {
            Database.SetInitializer<CemexContext>(null);
        }

        #region Catalogos
        public IDbSet<Estado> EstadoSet { get; set; }
        public IDbSet<Municipio> MunicipioSet { get; set; }
        public IDbSet<Region> RegionSet { get; set; }
        public IDbSet<PlazaImmex> PlazaImmexSet { get; set; }
        public IDbSet<PlazaOxxo> PlazaOxxoSet { get; set; }
        public IDbSet<Distrito> DistritoSet { get; set; }
        public IDbSet<Tienda> TiendaSet { get; set; }
        public IDbSet<Movil> MovilSet { get; set; }
        public IDbSet<TipoEncuesta> TipoEncuestaSet { get; set; }
        #endregion

        #region Seguridad
        public IDbSet<DetallePerfilUsuarioMenu> DetallePerfilUsuarioMenu { get; set; }
        public IDbSet<DetalleMenuPermiso> DetalleModuloPermisoSet { get; set; }
        public IDbSet<DetalleUsuarioAsignacion> DetalleUsuarioAsignacionSet { get; set; }
        public IDbSet<PerfilUsuario> PerfilUsuarioSet { get; set; }
        public IDbSet<Jerarquia> JerarquiaSet { get; set; }
        public IDbSet<Permiso> PermisoSet { get; set; }
        public IDbSet<Usuario> UsuarioSet { get; set; }
        #endregion

        #region App
        public IDbSet<Menu> MenuSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }
        #endregion

        #region Operacion
        public IDbSet<Encuesta> EncuestaSet { get; set; }
        public IDbSet<Seccion> SeccionSet { get; set; }
        public IDbSet<Pregunta> PreguntaSet { get; set; }
        public IDbSet<Respuesta> RespuestaSet { get; set; }
        public IDbSet<DetalleRespuesta> DetalleRespuestaSet { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        /// <summary>
        /// Se establece la configuración de cada Entidad.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new EstadoConfiguration());
            modelBuilder.Configurations.Add(new MunicipioConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new PlazaImmexConfiguration());
            modelBuilder.Configurations.Add(new PlazaOxxoConfiguration());
            modelBuilder.Configurations.Add(new DistritoConfiguration());
            modelBuilder.Configurations.Add(new TiendaConfiguration());
            modelBuilder.Configurations.Add(new MovilConfiguration());
            modelBuilder.Configurations.Add(new VehiculoConfiguration());
            modelBuilder.Configurations.Add(new TipoEncuestaConfiguration());

            modelBuilder.Configurations.Add(new DetalleMenuPermisoConfiguration());
            modelBuilder.Configurations.Add(new DetallePerfilUsuarioMenuConfiguration());
            modelBuilder.Configurations.Add(new DetalleUsuarioAsignacionConfiguration());
            modelBuilder.Configurations.Add(new JerarquiaConfiguration());
            modelBuilder.Configurations.Add(new PermisoConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PerfilUsuarioConfiguration());

            modelBuilder.Configurations.Add(new MenuConfiguration());

            modelBuilder.Configurations.Add(new EncuestaConfiguration());
            modelBuilder.Configurations.Add(new SeccionConfiguration());
            modelBuilder.Configurations.Add(new PreguntaConfiguration());
            modelBuilder.Configurations.Add(new RespuestaConfiguration());
            modelBuilder.Configurations.Add(new DetalleRespuestaConfiguration());

            
            modelBuilder.Entity<Estado>().ToTable("Estados","Catalogo");
            modelBuilder.Entity<Municipio>().ToTable("Municipios","Catalogo");
            modelBuilder.Entity<Region>().ToTable("Regiones","Catalogo");
            modelBuilder.Entity<PlazaImmex>().ToTable("PlazasImmex", "Catalogo");
            modelBuilder.Entity<PlazaOxxo>().ToTable("PlazasOxxo","Catalogo");
            modelBuilder.Entity<Distrito>().ToTable("Distritos","Catalogo");
            modelBuilder.Entity<Tienda>().ToTable("Tiendas","Catalogo");
            modelBuilder.Entity<Movil>().ToTable("Moviles", "Catalogo");
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculos", "Catalogo");
            modelBuilder.Entity<TipoEncuesta>().ToTable("TiposEncuesta", "Catalogo");

            modelBuilder.Entity<Usuario>().ToTable("Usuarios", "Seguridad");
            modelBuilder.Entity<PerfilUsuario>().ToTable("PerfilesUsuario", "Seguridad");
            modelBuilder.Entity<Jerarquia>().ToTable("Jerarquias","Seguridad");
            modelBuilder.Entity<Permiso>().ToTable("Permisos", "Seguridad");
            modelBuilder.Entity<DetalleMenuPermiso>().ToTable("DetalleMenuPermiso", "Seguridad");
            modelBuilder.Entity<DetallePerfilUsuarioMenu>().ToTable("DetallePerfilUsuarioMenu", "Seguridad");
            modelBuilder.Entity<DetalleUsuarioAsignacion>().ToTable("DetalleUsuarioAsignacion", "Seguridad");

            modelBuilder.Entity<Menu>().ToTable("Menu", "Aplicacion");
            modelBuilder.Entity<Error>().ToTable("Error", "Aplicacion");

            modelBuilder.Entity<Encuesta>().ToTable("Encuestas", "Operacion");
            modelBuilder.Entity<Seccion>().ToTable("Secciones", "Operacion");
            modelBuilder.Entity<Pregunta>().ToTable("Preguntas", "Operacion");
            modelBuilder.Entity<Respuesta>().ToTable("Respuestas", "Operacion");
            modelBuilder.Entity<DetalleRespuesta>().ToTable("DetallesRespuesta", "Operacion");
        }

    }
}
