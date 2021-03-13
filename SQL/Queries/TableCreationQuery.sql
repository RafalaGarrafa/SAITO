--Equipo #9
-- 1887950 Inés Anahí Santiago Camacho
-- 1887849 Víctor Rafael Medina Gómez

--QUERY #1
--Descripcion:
--Creacion de BD: Satio
--Creacion de tablas: RegisteredUser, Recipe, Ingredient, Warning, Food, ContactInfo, BlockedWord, RegisteredUserRecipe, RecipeIngredient, RecipeWarning

--Fecha de creacion 2021/03/13

--Actualizacion 2021/03/13

CREATE DATABASE Satio
GO

USE Satio
GO


CREATE TABLE ContactInfo
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	YouTube VARCHAR(255) NOT NULL,
	Instagram VARCHAR(255) NOT NULL,
	Twitter VARCHAR(255) NOT NULL,
	Facebook VARCHAR(255) NOT NULL,
	WebPage VARCHAR(255) NOT NULL
)
GO

CREATE TABLE RegisteredUser
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	[Name] VARCHAR(15) NOT NULL,
	LastName VARCHAR(15) NOT NULL,
	ProfilePicture VARCHAR(255) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	IdContactInfo INT NOT NULL,

	CONSTRAINT FK_RegisteredUser_ContactInfo FOREIGN KEY (Id) REFERENCES ContactInfo(Id),

)
GO

CREATE TABLE Recipe
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	[Name] VARCHAR(15) NOT NULL,
	Steps VARCHAR(15) NOT NULL,
	PrepTime INT NOT NULL,
	Difficulty SMALLINT NOT NULL DEFAULT 3,
	Rating SMALLINT NOT NULL DEFAULT 0,

	IdOwnerUser INT NOT NULL,
	CONSTRAINT FK_Recipe_RegisteredUser FOREIGN KEY (Id) REFERENCES RegisteredUser(Id),

)
GO

CREATE TABLE Food
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	[Name] VARCHAR(30) NOT NULL
)
GO

CREATE TABLE Ingredient
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	Quantity INT NOT NULL,
	IdFood INT NOT NULL,
	CONSTRAINT FK_Ingredient_Food FOREIGN KEY (Id) REFERENCES Food(Id),

)
GO

CREATE TABLE Warning
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	[Description] VARCHAR(100) NOT NULL,
	ThreatLevel INT NOT NULL DEFAULT 3
)
GO

CREATE TABLE BlockedWord
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	Word VARCHAR(50) NOT NULL
)
GO

CREATE TABLE RegisteredUserRecipe
(
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	IdRegisteredUser INT NOT NULL,
	IdRecipe INT NOT NULL,

	CONSTRAINT FK_RegisteredUserRecipe_RegisteredUser FOREIGN KEY (Id) REFERENCES RegisteredUser(Id),
	CONSTRAINT FK_RegisteredUserRecipe_Recipe FOREIGN KEY (Id) REFERENCES Recipe(Id)
)
GO

CREATE TABLE RecipeIngredient
(
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	IdIngredient INT NOT NULL,
	IdRecipe INT NOT NULL,

	CONSTRAINT FK_RecipeIngredient_Ingredient FOREIGN KEY (Id) REFERENCES Ingredient(Id),
	CONSTRAINT FK_RecipeIngredient_Recipe FOREIGN KEY (Id) REFERENCES Recipe(Id)
)
GO

CREATE TABLE RecipeWarning
(
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	IdWarning INT NOT NULL,
	IdRecipe INT NOT NULL,

	CONSTRAINT FK_RecipeWarning_Warning FOREIGN KEY (Id) REFERENCES Warning(Id),
	CONSTRAINT FK_RecipeWarning_Recipe FOREIGN KEY (Id) REFERENCES Recipe(Id)
)
GO





