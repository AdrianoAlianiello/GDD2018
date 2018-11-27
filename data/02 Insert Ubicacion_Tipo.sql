
declare @Codigo numeric(18,0), @Descripcion nvarchar(255)

declare cursor_Ubicacion_Tipo cursor for 

Select  distinct [Ubicacion_Tipo_Codigo], [Ubicacion_Tipo_Descripcion]
	  from gd_esquema.Maestra

	  where Cli_Dni is null
	  order by 1

open cursor_Ubicacion_Tipo
Fetch cursor_Ubicacion_Tipo Into
@Codigo, @Descripcion

While @@FETCH_STATUS = 0
Begin
	Insert into UbicacionesTipos
	(Codigo, Descripcion)
	  values(@Codigo, @Descripcion)
Fetch next from cursor_Ubicacion_Tipo Into
@Codigo, @Descripcion
End 

Close cursor_Ubicacion_Tipo
Deallocate cursor_Ubicacion_Tipo

select * from UbicacionesTipos