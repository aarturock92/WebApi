namespace CEMEX.Entidades
{
    /// <summary>
    /// Especifica los tipos de Estatus en los Registros.
    /// </summary>
    public enum ETypeEstatusRegistro
    {
        Activo= 1,
        Inactivo= 2,
        Eliminado = 3,
        Todos = 0
    }

    /// <summary>
    /// Especifica los niveles de Jerarquia que se utilizan en la aplicación
    /// </summary>
    public enum ETypeNivelJerarquia
    {
        Administracion = 1,
        Supervision = 2,
        Operativo = 3
    }

    public static class ResponseMessages
    {
        public static class MessageResponseServices
        {
            public const string NotFound = "No se encontraron resultados";
        }
        
        public static class MessageResponseEstados
        {
            public const string NoEncontrado = "No se encontro el Estado con el ID {0}";
        }
        
        public static class MessageResponseMunicipios
        {
            public const string NoEncontrado = "No se encontro el Municipio con el ID {0}";
        }        
    }

}
