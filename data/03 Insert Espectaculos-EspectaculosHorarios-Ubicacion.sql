declare @Espectaculo_Descripcion nvarchar(255), @Empresa_Cuit nvarchar(255), @Espectaculo_Fecha datetime, @idInsertada int
declare @Fila varchar(3), @Asiento numeric(18,0), @Precio numeric(18,0), @Numerada bit, @TipoId int
declare cursor_Espectaculos cursor for 
select distinct [Ubicacion_Fila]
      ,[Ubicacion_Asiento]
      ,[Ubicacion_Sin_numerar]
      ,[Ubicacion_Precio]
      ,ut.Id
	  ,[Espectaculo_Descripcion]
      ,[Espec_Empresa_Cuit]
      ,[Espectaculo_Fecha]
	  from gd_esquema.Maestra m
	  join UbicacionesTipos ut on m.Ubicacion_Tipo_Codigo = ut.Codigo
	  where Cli_Dni is null
	  order by 1

open cursor_Espectaculos
Fetch cursor_Espectaculos Into
@Fila, @Asiento, @Precio, @Numerada, @TipoId,
@Espectaculo_Descripcion, @Empresa_Cuit, @Espectaculo_Fecha

While @@FETCH_STATUS = 0
Begin
	  Insert into Espectaculos
	  (Descripcion)
	  values(@Espectaculo_Descripcion)

	  set @idInsertada=@@IDENTITY

	  Insert into EspectaculosHorarios
	  (Fecha, EspectaculoId)
	  values(@Espectaculo_Fecha,@idInsertada)

	  Insert into Ubicaciones
	  (Fila, Asiento, Precio, Numerada, TipoId, CantPuntos)
	  values(@Fila, @Asiento, @Precio, @Numerada, @TipoId, null)
	  
	  Insert into UbicacionesEspectaculos
	  (EspectaculoId, UbicacionId)
	  values
	  (@idInsertada,  @@IDENTITY)


Fetch next from cursor_Espectaculos Into
@Fila, @Asiento, @Precio, @Numerada, @TipoId,
@Espectaculo_Descripcion, @Empresa_Cuit, @Espectaculo_Fecha
End 

Close cursor_Espectaculos
Deallocate cursor_Espectaculos

select * from Espectaculos
select * from EspectaculosHorarios
select * from Ubicaciones m
join UbicacionesTipos ut on m.TipoId = ut.Id




