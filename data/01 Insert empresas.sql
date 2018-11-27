declare @Razon_Social nvarchar(255), @Empresa_Cuit nvarchar(255), @Empresa_Mail nvarchar(255),
@Dom_Calle nvarchar(255), @Nro_Calle numeric(18,0), @Piso numeric(18,0), @Depto nvarchar(255), 
@Cod_Postal nvarchar(255), @Fecha_Creacion datetime

declare cursor_Empresas cursor for 

Select  distinct [Espec_Empresa_Razon_Social]
      ,[Espec_Empresa_Cuit]
      ,[Espec_Empresa_Mail]
      ,[Espec_Empresa_Dom_Calle]
      ,[Espec_Empresa_Nro_Calle]
      ,[Espec_Empresa_Piso]
      ,[Espec_Empresa_Depto]
      ,[Espec_Empresa_Cod_Postal]
      ,[Espec_Empresa_Fecha_Creacion]
	  from gd_esquema.Maestra

	  where Cli_Dni is null
	  order by 1

open cursor_Empresas
Fetch cursor_Empresas Into
@Razon_Social , @Empresa_Cuit , @Empresa_Mail ,
@Dom_Calle , @Nro_Calle , @Piso , @Depto , 
@Cod_Postal , @Fecha_Creacion

While @@FETCH_STATUS = 0
Begin
	Insert into Empresas
	(RazonSocial
      ,Cuit
      ,Mail
      ,DomicilioCalle
      ,DomicilioNro
      ,DomicilioPiso
      ,DomicilioDepto
      ,DomicilioCodPostal
      ,FechaCreacion
	  ,Telefono)
	  values(@Razon_Social , @Empresa_Cuit , @Empresa_Mail ,
@Dom_Calle , @Nro_Calle , @Piso , @Depto , 
@Cod_Postal , @Fecha_Creacion,null)
Fetch next from cursor_Empresas Into
@Razon_Social , @Empresa_Cuit , @Empresa_Mail ,
@Dom_Calle , @Nro_Calle , @Piso , @Depto , 
@Cod_Postal , @Fecha_Creacion
End 

Close cursor_Empresas
Deallocate cursor_Empresas

select * from Empresas