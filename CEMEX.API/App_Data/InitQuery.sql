
 INSERT INTO [Cemex].[Catalogo].[Estados] (Nombre, Abreviatura, Estatus, FechaAlta, FechaModifico, IdUsuarioAlta, IdUsuarioModifico) SELECT nombreEstado, abreviatura, 1, GETDATE(), GETDATE(), 0,0  FROM [IMMEXDB].[dbo].[CAT_ESTADOS]

 INSERT INTO [Cemex].[Catalogo].[Municipios] (Nombre, Estatus, EstadoId, FechaAlta, FechaModifico, IdUsuarioAlta, IdUsuarioModifico)
 SELECT nombreMunicipio, 1, idEstado, GETDATE(),GETDATE(), 0,0 FROM [IMMEXDB].[dbo].[CAT_MUNICIPIOS]

 INSERT INTO [Cemex].[Catalogo].[Regiones] (IdNegocio, ClaveRegion, NombreRegion, Estatus, FechaAlta, FechaModifico, IdUsuarioAlta, IdUsuarioModifico)
 SELECT idNegocio, claveRegion, nombreRegion, 1, GETDATE(), GETDATE(), 0,0 FROM [IMMEXDB].[dbo].[ADM_REGIONES]

 INSERT INTO [Cemex].[Catalogo].[PlazasImmex] (RegionId, CRPlazaImmex, NombrePlazaImmex, Estatus,FechaAlta, FechaModifico, IdUsuarioAlta, IdUsuarioModifico)
 SELECT  idRegion, crPlazaImmex, nombrePlazaImmex, 1, GETDATE(),GETDATE(), 0,0 FROM [IMMEXDB].[dbo].[ADM_PLAZAS_IMMEX]

 INSERT INTO [Cemex].[Catalogo].[PlazasOxxo] (PlazaImmexId, CRPlazaOxxo, NombrePlazaOxxo, Estatus, FechaAlta, FechaModifico, IdUsuarioAlta, IdUsuarioModifico)
 SELECT idPlazaImmex, crPlazaOxxo, nombrePlazaOxxo, 1, GETDATE(),GETDATE(), 0,0 FROM [IMMEXDB].[dbo].[ADM_PLAZAS_OXXO]


 INSERT INTO [Cemex].[Catalogo].[Distritos] (PlazaOxxoId, ClaveDistrito, NombreDistrito, Estatus, FechaAlta, FechaModifico, IdUsuarioAlta, IdUsuarioModifico)
 SELECT idPlazaOxxo, claveDistrito, nombreDistrito, 1, GETDATE(), GETDATE(), 0,0 FROM [IMMEXDB].[dbo].[ADM_DISTRITOS]
 SELECT * FROM [Cemex].[Catalogo].[Distritos]

 

 USE Cemex
 GO


 SELECT * FROM [Catalogo].[PlazasOxxo]

 



 SELECT * FROM [Cemex].[Catalogo].[PlazasImmex]
 SELECT * FROM [IMMEXDB].[dbo].[ADM_PLAZAS_IMMEX]

 SELECT *  FROM [IMMEXDB].[dbo].[CAT_MUNICIPIOS]
 SELECT * FROM [Cemex].[Catalogo].[Municipios]