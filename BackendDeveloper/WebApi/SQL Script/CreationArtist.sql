-- Create database Music
CREATE DATABASE MusicApi
GO

USE MusicApi
GO

-- Create Table Artist
CREATE TABLE Artist (
 Name NVARCHAR(50) NOT NULL,
 [UniqueIdentifier] CHAR(36) NOT NULL PRIMARY KEY,
 Country CHAR(2) NOT NULL
)
GO

-- Create Table for Artist Aliases
CREATE TABLE ArtistAlias (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	ArtistUniqueIdentifier CHAR(36) NOT NULL,
	Alias NVARCHAR(MAX),
	FOREIGN KEY (ArtistUniqueIdentifier) REFERENCES Artist(UniqueIdentifier)
)
GO

-- Populate data in the table Artist
INSERT INTO [dbo].[Artist] (Name, [UniqueIdentifier],Country) VALUES
('Metallica', '65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab', 'US'),
('Lady Gaga', '650e7db6-b795-4eb5-a702-5ea2fc46c848', 'US'),
('Mumford & Sons', 'c44e9c22-ef82-4a77-9bcd-af6c958446d6','GB' ),
('Mott the Hoople', '435f1441-0f43-479d-92db-a506449a686b','GB'),
('Megadeth', 'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e','US'),
('John Coltrane', 'b625448e-bf4a-41c3-a421-72ad46cdb831','US'),
('Mogwai', 'd700b3f5-45af-4d02-95ed-57d301bda93e','GB'),
('John Mayer', '144ef525-85e9-40c3-8335-02c32d0861f3','US'),
('Johnny Cash', '18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f','US'),
('Jack Johnson', '6456a893-c1e9-4e3d-86f7-0008b0a3ac8a','US'),
('John Frusciante', 'f1571db1-c672-4a54-a2cf-aaa329f26f0b','US'),
('Elton John', 'b83bc61f-8451-4a5d-8b8e-7e9ed295e822','GB'),
('Rancid', '24f8d8a5-269b-475c-a1cb-792990b0b2ee','US'),
('Transplants', '29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699','US'),
('Operation Ivy', '931e1d1f-6b2f-4ff8-9f70-aa537210cd46', 'US');

INSERT INTO [dbo].[ArtistAlias] (ArtistUniqueIdentifier,Alias) VALUES
('65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab', 'Metalica'),
('65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab', N'메탈리카'),
('650e7db6-b795-4eb5-a702-5ea2fc46c848', 'Lady Ga Ga'),
('650e7db6-b795-4eb5-a702-5ea2fc46c848', 'Stefani Joanne Angelina Germanotta'),
('435f1441-0f43-479d-92db-a506449a686b', 'Mott The Hoppie'),
('435f1441-0f43-479d-92db-a506449a686b', 'Mott The Hopple'),
('a9044915-8be3-4c7e-b11f-9e2d2ea0a91e', 'Megadeath'),
('b625448e-bf4a-41c3-a421-72ad46cdb831', 'John Coltraine'),
('b625448e-bf4a-41c3-a421-72ad46cdb831', 'John William Coltrane'),
('d700b3f5-45af-4d02-95ed-57d301bda93e', 'Mogwa'),
('18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f', 'Johhny Cash'),
('18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f', 'Jonny Cash'),
('6456a893-c1e9-4e3d-86f7-0008b0a3ac8a', 'Jack Hody Johnson'),
('f1571db1-c672-4a54-a2cf-aaa329f26f0b', 'John Anthony Frusciante'),
('b83bc61f-8451-4a5d-8b8e-7e9ed295e822', 'E. John'),
('b83bc61f-8451-4a5d-8b8e-7e9ed295e822', 'Elthon John'),
('b83bc61f-8451-4a5d-8b8e-7e9ed295e822', 'Elton Jphn'),
( 'b83bc61f-8451-4a5d-8b8e-7e9ed295e822', 'John Elton'),
( 'b83bc61f-8451-4a5d-8b8e-7e9ed295e822', 'Reginald Kenneth Dwight'),
( '24f8d8a5-269b-475c-a1cb-792990b0b2ee', N'ランシド'),
( '29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699', 'The Transplants'),
( '931e1d1f-6b2f-4ff8-9f70-aa537210cd46',  'Op Ivy');

-- Verify if data has been entered correctly
SELECT * FROM Artist;
SELECT * FROM ArtistAlias;