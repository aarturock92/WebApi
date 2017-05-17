namespace CEMEX.Entidades
{
    public enum EstatusRegistro
    {
        Activo = 1,
        Inactivo= 2,
        Eliminado = 3
    }

    public enum ETypeEstatusRegistro
    {
        Activo= 1,
        Inactivo= 2,
        Eliminado = 3,
        Todos = 0
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
