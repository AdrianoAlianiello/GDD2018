declare 
@Nombre nvarchar(255), @Apellido nvarchar(255),
@NroDocumento numeric(18,0), @Mail nvarchar(255), @DomicilioCalle nvarchar(255), 
@DomicilioNro numeric(18,0), @DomicilioPiso numeric(18,0), @DomicilioDepto nvarchar(255), 
@DomicilioCodPostal nvarchar(255), @FechaNacimiento datetime

declare cursor_Cliente cursor for 

Select  distinct 
      [Cli_Nombre]
      ,[Cli_Apeliido]
      ,[Cli_Dni] 
      ,[Cli_Mail]
      ,[Cli_Dom_Calle]
      ,[Cli_Nro_Calle]
      ,[Cli_Piso]
      ,[Cli_Depto]
      ,[Cli_Cod_Postal]
      ,[Cli_Fecha_Nac]
	  from gd_esquema.Maestra

	  where Cli_Dni is not null
	  order by 1

open cursor_Cliente
Fetch cursor_Cliente Into
@Nombre, @Apellido, @NroDocumento, @Mail, @DomicilioCalle, 
@DomicilioNro, @DomicilioPiso,@DomicilioDepto, @DomicilioCodPostal, @FechaNacimiento

While @@FETCH_STATUS = 0
Begin
	Insert into Clientes
	(Nombre, Apellido, NroDocumento, Mail, DomicilioCalle,  DomicilioNro, DomicilioPiso, 
	DomicilioDepto, DomicilioCodPostal, FechaNacimiento, TipoDocumento, FechaCreacion, Activo)
	  values(
@Nombre, @Apellido, @NroDocumento, @Mail, @DomicilioCalle, @DomicilioNro, @DomicilioPiso,
@DomicilioDepto, @DomicilioCodPostal, @FechaNacimiento, 'DNI', getdate(), 1)
Fetch next from cursor_Cliente Into
@Nombre, @Apellido, @NroDocumento, @Mail, @DomicilioCalle, 
@DomicilioNro, @DomicilioPiso,@DomicilioDepto, @DomicilioCodPostal, @FechaNacimiento
End 

Close cursor_Cliente
Deallocate cursor_Cliente

select * from Clientes