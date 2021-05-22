--Equipo #9
-- 1887950 Inés Anahí Santiago Camacho
-- 1887849 Víctor Rafael Medina Gómez

--QUERY #2
--Descripcion:
--Ingreso de Registros a la BD para pruebas con PostMan

--Fecha de creacion 2021/23/04

--Actualizacion 2021/21/05
--Pruebas para ingreso de Recetas, Ingredientes, Comida y Warnings


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

select Id from [ContactInfo] order by Id desc 

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
           (2
           ,4)
GO

use Satio
GO

INSERT INTO [dbo].[Food]
           ([Name])
     VALUES
           ('Pepino')
GO
INSERT INTO [dbo].[Food]
           ([Name])
     VALUES
           ('Fresa')
GO


INSERT INTO [dbo].[Food]
           ([Name])
     VALUES
           ('Nopales')
GO
INSERT INTO [dbo].[Food]
           ([Name])
     VALUES
           ('Spaguetti')
GO

INSERT INTO [dbo].[Food]
           ([Name])
     VALUES
           ('Arroz')
GO
INSERT INTO [dbo].[Food]
           ([Name])
     VALUES
           ('Tomate')
GO


INSERT INTO [dbo].[Food]
           ([Name])
     VALUES
           ('Pan Molido')
GO
INSERT INTO [dbo].[Food]
           ([Name])
     VALUES
           ('Granola')
GO

select * from Food

select * from [Ingredient]

select * from Recipe

select * from Warning



INSERT INTO [dbo].[Ingredient]
           ([Quantity]
           ,[IdFood])
     VALUES
           (5
           ,10)
GO


INSERT INTO [dbo].[RecipeIngredient]
           ([IdIngredient]
           ,[IdRecipe])
     VALUES
           (1
           ,1)
GO

INSERT INTO [dbo].[Warning]
           ([Description]
           ,[ThreatLevel])
     VALUES
           ('Contiene Nuez'
           ,5)
GO

INSERT INTO [dbo].[RecipeWarning]
           ([IdWarning]
           ,[IdRecipe])
     VALUES
           (1
           ,1)
GO






