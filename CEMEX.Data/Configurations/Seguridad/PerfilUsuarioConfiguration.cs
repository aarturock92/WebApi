﻿using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class PerfilUsuarioConfiguration:EntityBaseConfiguration<PerfilUsuario>
    {
        public PerfilUsuarioConfiguration()
        {
            HasKey(p => p.ID);

            Property(p => p.Nombre).HasMaxLength(100).IsRequired();

            Property(p => p.Descripcion).HasMaxLength(200).IsRequired();

            Property(p => p.JerarquiaId).IsRequired();

            Property(p => p.AsignacionMultiple).IsRequired();

            Property(p => p.Estatus).IsRequired();

            Property(j => j.IdUsuarioAlta).IsRequired();

            Property(j => j.IdUsuarioModifico).IsOptional();

            Property(j => j.FechaAlta).IsRequired();

            Property(j => j.FechaModifico).IsOptional();

            HasMany(e => e.Usuarios).WithRequired().HasForeignKey(s => s.PerfilUsuarioId);

            HasMany(e => e.DetallesPefilUsuarioMenu).WithRequired().HasForeignKey(d => d.PefilUsuarioId);
        }
    }
}
