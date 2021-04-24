--Equipo #9
-- 1887950 Inés Anahí Santiago Camacho
-- 1887849 Víctor Rafael Medina Gómez

--QUERY #2
--Descripcion:
--Ingreso de Registros a la BD para pruebas con PostMan

--Fecha de creacion 2021/23/04

--Actualizacion 2021/23/04


USE [Satio]
GO


INSERT INTO [dbo].[ContactInfo]
           ([YouTube]
           ,[Instagram]
           ,[Twitter]
           ,[Facebook]
           ,[WebPage])
     VALUES
           (''
           ,''
           ,''
           ,''
           ,'')
GO

select * from ContactInfo


INSERT INTO [dbo].[RegisteredUser]
           ([Name]
           ,[LastName]
           ,[ProfilePicture]
           ,[Email]
           ,[IdContactInfo])
     VALUES
           ('Solaire'
           ,'de Astora'
           ,'Imagen'
           ,'praisethesun@lordran.gwyn'
           ,1)
GO

select * from [RegisteredUser]
select * from [Recipe]
select * from [RegisteredUserRecipe]


INSERT INTO [dbo].[Recipe]
           ([Name]
           ,[Steps]
           ,[PrepTime]
           ,[Difficulty]
           ,[Rating]
           ,[IdOwnerUser])
     VALUES
           ('Sopa de Estus'
           ,'Estus en sopa'
           ,1
           ,4
           ,5
           ,1)
GO



INSERT INTO [dbo].[RegisteredUserRecipe]
           ([IdRegisteredUser]
           ,[IdRecipe])
     VALUES
           (1
           ,1)
GO


