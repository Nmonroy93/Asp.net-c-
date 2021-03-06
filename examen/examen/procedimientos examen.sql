USE [Examen]
GO
/****** Object:  StoredProcedure [dbo].[Sp_actualizar_Area]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Sp_actualizar_Area]
@id int,@Nombre varchar(100),@Descripcion varchar(2000)
as
update Area
set Nombre=@Nombre,Descripcion=@Descripcion
where IdArea =@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_actualizar_foto]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_actualizar_foto]

@foto varbinary(max)
,@id int

as


update [Empleado] set [Foto]=@foto where IdEmpleado=@id
	  
	  
  
GO
/****** Object:  StoredProcedure [dbo].[Sp_agregar_Area]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[Sp_agregar_Area]
@nombre varchar(100),@descripcion varchar(2000)
as

insert into [dbo].[Area] values(@nombre,@descripcion)
GO
/****** Object:  StoredProcedure [dbo].[Sp_agregar_Habilidad]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[Sp_agregar_Habilidad]
@empleado int,@habilidad varchar(100)
as

insert into Empleado_Habilidad(IdEmpleado,NombreHabilidad)
values(@empleado,@habilidad)
GO
/****** Object:  StoredProcedure [dbo].[Sp_descargar_imagen_por_id]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_descargar_imagen_por_id]
@id int
as

SELECT 
      replace([NombreCompleto],' ','_') as nombre
      ,[Foto] 
	    FROM [Examen].[dbo].[Empleado] where IdEmpleado=@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_descargar_imagen_por_id2]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_descargar_imagen_por_id2]
@id int
as

SELECT 
   
      [Foto] 
	  
  FROM [Examen].[dbo].[Empleado] where IdEmpleado=@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_eliminar_Area]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_eliminar_Area]
@id int
as
delete from Area where IdArea =@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_eliminar_empleado]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_eliminar_empleado] 
@id int
as

delete from [Empleado] where IdEmpleado=@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_guardar_empleado_editado]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_guardar_empleado_editado]
@nombre varchar(100)
,@cedula varchar(50)
,@correo varchar(100)
,@f1 datetime
,@f2 datetime
,@id_area int
,@id_jefe int

,@id int

as


	  update [Empleado] 
set [NombreCompleto]=@nombre      ,[Cedula]=@cedula      ,[Correo]=@correo      ,[FechaNacimiento]=@f1
      ,[FechaIngreso]=@f2      ,[IdJefe]=@id_jefe      ,[IdArea]=@id_area   where IdEmpleado=@id
	  

  
GO
/****** Object:  StoredProcedure [dbo].[Sp_guardar_empleado_nuevo]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_guardar_empleado_nuevo]
@nombre varchar(100)
,@cedula varchar(50)
,@correo varchar(100)
,@f1 datetime
,@f2 datetime
,@id_area int
,@id_jefe int
,@foto varbinary(max)
--,@contentType varchar(200)
as

insert into [Empleado] 
([NombreCompleto]
      ,[Cedula]
      ,[Correo]
      ,[FechaNacimiento]
      ,[FechaIngreso]
      ,[IdJefe]
      ,[IdArea]
      ,[Foto])--,contentType)
	  values(@nombre,@cedula,@correo,@f1,@f2,@id_jefe,@id_area,@foto)--,@contentType)
  
GO
/****** Object:  StoredProcedure [dbo].[sp_traer_area_dropdowlist]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_traer_area_dropdowlist]
as

SELECT IdArea , Nombre as nombre FROM [Area]
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_area_por_id]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_area_por_id]  --Sp_traer_area_por_id 4
@id int
as

select 
      ltrim(rtrim(Nombre)) as area

  FROM Area where IdArea=@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_area_por_id2]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_area_por_id2]  --Sp_traer_area_por_id 4
@id int
as

select IdArea as id,
      Nombre as nombre

  FROM Area where IdArea=@id
GO
/****** Object:  StoredProcedure [dbo].[sp_traer_areas]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[sp_traer_areas]
as
SELECT [IdArea] 
      ,[Nombre]
      ,[Descripcion]
  FROM [Examen].[dbo].[Area] order by IdArea
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_empleados]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_empleados]
as

declare @empleados2 table(IdJefe int ,jefe varchar(100))
insert into @empleados2
select IdEmpleado,NombreCompleto  FROM [Empleado]

--select * from  @empleados2
SELECT [IdEmpleado]
      ,[NombreCompleto] 
      ,[Cedula]
      ,[Correo]
      , CONVERT (varchar(10),FechaNacimiento, 126)  as f1
      , CONVERT (varchar(10),FechaIngreso, 126)  as f2
      ,e.IdJefe
      ,e.IdArea
	  ,e2.jefe
	  ,a.nombre as area
      ,[Foto]
  FROM [dbo].[Empleado]  e 
  inner join Area a on a.IdArea=e.IdArea
  inner join @empleados2 e2 on e2.IdJefe=e.IdJefe
   order by  e.[IdEmpleado]
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_empleados_para_treeview]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Sp_traer_empleados_para_treeview]
as

SELECT IdEmpleado, NombreCompleto FROM Empleado
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_empleados_para_treeview_2]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Sp_traer_empleados_para_treeview_2]
@id int
as

SELECT IdEmpleado, NombreCompleto FROM Empleado WHERE IdJefe = @id
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_empleados_por_area]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_empleados_por_area]
@id int
as
declare @empleados2 table(IdJefe int ,jefe varchar(100))
insert into @empleados2
select IdEmpleado,NombreCompleto  FROM [Empleado]

--select * from  @empleados2
SELECT [IdEmpleado]
      ,[NombreCompleto] 
      ,[Cedula]
      ,[Correo]
      , CONVERT (varchar(10),FechaNacimiento, 126)  as f1
      , CONVERT (varchar(10),FechaIngreso, 126)  as f2
      ,e.IdJefe
      ,e.IdArea
	  ,e2.jefe
	  ,a.nombre as area
      ,[Foto]
  FROM [dbo].[Empleado]  e 
  inner join Area a on a.IdArea=e.IdArea
  inner join @empleados2 e2 on e2.IdJefe=e.IdJefe
  where e.IdArea=@id order by  [IdEmpleado] 
  
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_empleados_por_id]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_empleados_por_id] --[Sp_traer_empleados_por_id] 23
@id int
as

SELECT [IdEmpleado]as id
      ,[NombreCompleto]  as nombre
      ,[Cedula] as cedula
      ,[Correo] as correo 
      , CONVERT (varchar(10),FechaNacimiento, 126)  as f1
      , CONVERT (varchar(10),FechaIngreso, 126)  as f2
      ,IdJefe 
      ,IdArea 
      ,[Foto]
  FROM [dbo].[Empleado]  e
  where IdEmpleado=@id
   order by  e.[IdEmpleado]
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_habilidad_por_id]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_habilidad_por_id]
@id int
as

SELECT 
      [NombreHabilidad]
  FROM [Examen].[dbo].[Empleado_Habilidad] where IdEmpleado=@id
GO
/****** Object:  StoredProcedure [dbo].[sp_traer_jefe_dropdowlist]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_traer_jefe_dropdowlist]
as

SELECT IdEmpleado as IdJefe, NombreCompleto as nombre FROM Empleado
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_jefe_por_id]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_jefe_por_id]  --Sp_traer_jefe_por_id 23
@id int
as

select 
      ltrim(rtrim([NombreCompleto])) as jefe

  FROM [Examen].[dbo].[Empleado] where IdEmpleado=@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_jefe_por_id2]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_jefe_por_id2]  --Sp_traer_jefe_por_id 23
@id int
as

select 
IdEmpleado,
      [NombreCompleto]

  FROM [Examen].[dbo].[Empleado] where IdEmpleado=@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_jefe_por_id3]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_jefe_por_id3]  --Sp_traer_jefe_por_id 23
@id int
as

select 
IdEmpleado as id,
      [NombreCompleto] as jefe

  FROM [Examen].[dbo].[Empleado] where IdEmpleado=@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_lista_de_areas]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_traer_lista_de_areas]
as

declare  @lista table(IdArea int,Nombre varchar(100))
insert into @lista values(0,'Todas')

insert into @lista
SELECT [IdArea] 
      ,[Nombre]
      FROM [Examen].[dbo].[Area] order by IdArea


	  select  [IdArea] 
      ,[Nombre] from @lista order by IdArea
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_lista_de_areas2]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_traer_lista_de_areas2]
as

declare  @lista table(IdArea int,Nombre varchar(100))
insert into @lista values(0,'Seleccionar')

insert into @lista
SELECT [IdArea] 
      ,[Nombre]
      FROM [Examen].[dbo].[Area] order by IdArea


	  select  [IdArea] 
      ,[Nombre] from @lista order by IdArea
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_lista_de_areas3]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_traer_lista_de_areas3]
as


SELECT [IdArea] as id 
      ,[Nombre] as nombre
      FROM [Examen].[dbo].[Area] order by IdArea

GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_lista_de_empleados_para_habilidad]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[Sp_traer_lista_de_empleados_para_habilidad]
as

declare  @lista table(id int,empleado varchar(100))

insert into @lista values(0,'Seleccionar Empleado')

insert into @lista
SELECT [IdEmpleado] as id       ,[NombreCompleto] as empleado        FROM [Examen].[dbo].[Empleado]

select  id,empleado  from @lista order by id
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_lista_de_jefes]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_lista_de_jefes]  
as

select IdEmpleado as id,
      [NombreCompleto] as jefe

  FROM [Examen].[dbo].[Empleado]
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_lista_de_jefes2]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_traer_lista_de_jefes2]  
as
declare  @lista table(IdEmpleado int,NombreCompleto varchar(100))
insert into @lista values(0,'Seleccionar')

insert into @lista
select IdEmpleado as id,
      [NombreCompleto] as jefe

  FROM [Examen].[dbo].[Empleado]


  select IdEmpleado as id,
      [NombreCompleto] as jefe

  FROM @lista
GO
/****** Object:  StoredProcedure [dbo].[Sp_traer_nombre_de_empleado_por_id]    Script Date: 26/7/2020 01:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Sp_traer_nombre_de_empleado_por_id]
@id int
as

SELECT 
      [NombreCompleto] as nombre

  FROM [Examen].[dbo].[Empleado] where IdEmpleado=@id
GO
