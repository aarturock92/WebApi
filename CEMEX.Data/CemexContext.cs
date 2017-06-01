﻿using CEMEX.Data.Configurations.Catalogos;
using CEMEX.Data.Configurations.Seguridad;
using CEMEX.Entidades.Catalogos;
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
        #endregion

        #region Seguridad
        public IDbSet<DetalleModuloPermiso> DetalleModuloPermisoSet { get; set; }
        public IDbSet<DetalleRolPermiso> DetalleRolPermisoSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }
        public IDbSet<Jerarquia> JerarquiaSet { get; set; }
        public IDbSet<Modulo> ModuloSet { get; set; }
        public IDbSet<Permiso> PermisoSet { get; set; }
        public IDbSet<Rol> RolSet { get; set; }
        public IDbSet<Usuario> UsuarioSet { get; set; }
        public IDbSet<UsuarioRol> UsuarioRolSet { get; set; }        
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
                        

            modelBuilder.Configurations.Add(new DetalleModuloPermisoConfiguration());
            modelBuilder.Configurations.Add(new DetalleRolPermisoConfiguration());
            modelBuilder.Configurations.Add(new JerarquiaConfiguration());
            modelBuilder.Configurations.Add(new ModuloConfiguration());
            modelBuilder.Configurations.Add(new PermisoConfiguration());
            modelBuilder.Configurations.Add(new RolConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioRolConfiguration());

            modelBuilder.Entity<Estado>().ToTable("Estados","Catalogo");
            modelBuilder.Entity<Municipio>().ToTable("Municipios","Catalogo");
            modelBuilder.Entity<Movil>().ToTable("Moviles", "Catalogo");
            modelBuilder.Entity<Region>().ToTable("Regiones","Catalogo");
            modelBuilder.Entity<PlazaImmex>().ToTable("PlazasImmex", "Catalogo");
            modelBuilder.Entity<PlazaOxxo>().ToTable("PlazasOxxo","Catalogo");
            modelBuilder.Entity<Distrito>().ToTable("Distritos","Catalogo");
            modelBuilder.Entity<Tienda>().ToTable("Tiendas","Catalogo");

            modelBuilder.Entity<Usuario>().ToTable("Usuarios", "Seguridad");
            modelBuilder.Entity<PerfilUsuario>().ToTable("PerfilesUsuario", "Seguridad");
            modelBuilder.Entity<Jerarquia>().ToTable("Jerarquias","Seguridad");

        }

    }
}
