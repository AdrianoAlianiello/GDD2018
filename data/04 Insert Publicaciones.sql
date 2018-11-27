declare @Codigo numeric(18,0), @Descripcion nvarchar(255), @FechaVenc datetime, 
@EstadoId Int, @EspectaculoHorarioId Int, @EmpresaId Int, @Fecha datetime

declare cursor_Publicaciones cursor for 

Select  distinct 
		[Espectaculo_Cod]
      ,[Espectaculo_Descripcion]
      ,[Espectaculo_Fecha_Venc]
	  ,Espectaculo_Fecha
	  ,ep.Id
	  ,e.Id 
	  from gd_esquema.Maestra m
	  join EstadosPublicaciones ep on ep.Descripcion = 'Publicada'
	  Join Empresas e on e.RazonSocial = m.Espec_Empresa_Razon_Social and e.Cuit = m.Espec_Empresa_Cuit
	  where Cli_Dni is null
	  order by 1

open cursor_Publicaciones
Fetch cursor_Publicaciones Into
@Codigo, @Descripcion, @FechaVenc, 
@Fecha, @EstadoId, @EmpresaId


While @@FETCH_STATUS = 0
Begin
	select @EspectaculoHorarioId = 1 from EspectaculosHorarios where Fecha = @Fecha

	Insert into Publicaciones
	(Codigo, Descripcion, FechaInicio, 
EstadoId, EspectaculoHorarioId, EmpresaId)
	  values(@Codigo, @Descripcion, @FechaVenc, 
@EstadoId, @EspectaculoHorarioId, @EmpresaId)
Fetch next from cursor_Publicaciones Into
@Codigo, @Descripcion, @FechaVenc, 
@Fecha, @EstadoId, @EmpresaId
End 

Close cursor_Publicaciones
Deallocate cursor_Publicaciones

select * from Publicaciones