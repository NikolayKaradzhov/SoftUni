--01.Create Database.01--
CREATE DATABASE Minions

--02.Create Tables.02--
CREATE TABLE Minions (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50),
Age INT )

CREATE TABLE Towns (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) )

--03.Alter Tables.03--
ALTER TABLE Minions 
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--04.Insert Records in Both Tables.04--
INSERT INTO Towns(Id, Name)
VALUES (1, 'Sofia'), (2, 'Plovdiv'), (3, 'Varna')

INSERT INTO Minions(Id, Name, Age, TownId)
VALUES (1, 'Kevin', 22, 1), (2, 'Bob', 15, 3), (3, 'Steward', NULL, 2)

--05.Truncate Table Minions.05--
TRUNCATE TABLE Minions

--06.Drop all tables.06--
DROP TABLE Minions
DROP TABLE Towns

--07.Create table People.07--
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(13, 2),
[Weight] DECIMAL(13, 2),
Gender CHAR(1) NOT NULL CHECK(Gender='m' OR Gender='f'),
Birthdate DATE NOT NULL,
Biography NVARCHAR(max))

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
('Gosho', NULL, 1.94, 93.2, 'm', '1992-12-22', NULL),
('Ivan', NULL, 1.54, 43.5, 'm', '1993-11-12', NULL),
('Stela', NULL, 1.94, 53.2, 'm', '1994-10-30', NULL),
('Aleks', NULL, 1.94, 57.1, 'm', '1995-09-04', NULL),
('Maria', NULL, 1.94, 63.2, 'm', '1990-04-07', NULL)

--08.Create Table Users.08--
CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME,
IsDeleted BIT)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('AssSmasher', 'asdf43', NULL, DEFAULT, 0),
('jamaicata', 'qwe432', NULL, DEFAULT, 1),
('csMaster', '12344', NULL, DEFAULT, 1),
('Noob123', '3333s', NULL, DEFAULT, 0),
('Gamer', 'P@rol@', NULL, DEFAULT, 0)

--09.Change Primary Key.09--
ALTER TABLE Users
DROP COLUMN Id

--10.Add Check Constraint.10--
ALTER TABLE Users
ADD CONSTRAINT password_lenght_check
CHECK(DATALENGTH(Password)>=5)

--11.Set Default Value of a Field.11--
UPDATE Users
SET LastLoginTime = GETDATE()

--12.Set Unique Field.12--
ALTER TABLE Users
ADD CONSTRAINT Username_Lenght_Check
CHECK(DATALENGTH(Username)>=3)

--13.Create Database Movies.13--
CREATE DATABASE Movies

--Create the tables--
CREATE TABLE Directors (
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(255) NOT NULL,
Notes NVARCHAR(255))

CREATE TABLE Genres (
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(30),
Notes NVARCHAR(255))

CREATE TABLE Categories (
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30),
Notes NVARCHAR(255))

CREATE TABLE Movies (
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(255) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear DATETIME NOT NULL,
[Length] INT NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Rating FLOAT CHECK(Rating >= 1 AND Rating <= 5),
Notes NVARCHAR(255))

--Insert Data into tables--
INSERT INTO Directors ()
VALUES ()