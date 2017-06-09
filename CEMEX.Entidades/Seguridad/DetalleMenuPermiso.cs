namespace CEMEX.Entidades.Seguridad
{
    public class DetalleMenuPermiso 
    {
        public int ID { get; set; }

        public int IdModulo { get; set; }

        public int IdPermiso { get; set; }

        public int IdEstatus { get; set; }

        public virtual Permiso Permiso { get; set; }
    }
}
