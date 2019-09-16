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
INSERT INTO
    Towns(Name)
VALUES
       ('Sofia'),
       ('Plovdiv'),
       ('Varna')

INSERT INTO
    Minions(Name, Age, TownId)
VALUES
       ('Kevin', 22, 1),
       ('Bob', 15, 3),
       ('Steward', NULL, 2)

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
Id INT PRIMARY KEY IDENTITY (1,1),
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
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating FLOAT CHECK(Rating >= 1 AND Rating <= 5),
Notes NVARCHAR(255))

--Insert Data into tables--
INSERT INTO Directors (DirectorName, Notes)
VALUES 
('Stephen Speilberg', NULL),
('Martin Scorseze', 'Very good director'),
('Peter Jackson', NULL),
('Quentin Tarantino', NULL),
('Ridley Scott', NULL)

INSERT INTO Genres(GenreName, Notes)
VALUES
('Comedy', NULL),
('Drama', NULL),
('Action', NULL),
('Fantasy', NULL),
('Musical', NULL)

INSERT INTO Categories(CategoryName, Notes)
VALUES
('Documentary', NULL),
('Erotic', NULL),
('Horror', NULL),
('Fantasy', NULL),
('Western', NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES
('Fantastic Four', 1, GETDATE(), 90, 2, 3, 3.2, NULL),
('Avengers', 2, GETDATE(), 91, 2, 3, 4.5, NULL),
('Lethal Weapon', 4, GETDATE(), 92, 2, 3, 2.3, NULL),
('The Office', 5, GETDATE(), 93, 2, 3, 3.2, NULL),
('Training day', 3, GETDATE(), 95, 2, 3, 3.5, NULL)


--14.Car Rental Database.14--

CREATE DATABASE CarRental

--Create Tables--

CREATE TABLE Categories (
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryName NVARCHAR(255) NOT NULL,
DailyRate FLOAT,
WeeklyRate FLOAT,
MonthlyRate FLOAT,
WeekendRate FLOAT)

CREATE TABLE Cars (
Id INT PRIMARY KEY IDENTITY(1,1),
PlateNumber NVARCHAR(30) NOT NULL,
Manifacturer NVARCHAR(30) NOT NULL,
Model NVARCHAR(30) NOT NULL,
CarYear DATETIME NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT CHECK(Doors between 1 and 5),
Picture IMAGE,
Condition NVARCHAR(30),
Available BIT)

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30),
Title NVARCHAR(255),
Notes NVARCHAR(255))

CREATE TABLE Customers (
Id INT PRIMARY KEY IDENTITY(1,1),
DriverLicenceNumber NVARCHAR(32) NOT NULL,
FullName NVARCHAR(255) NOT NULL,
[Address] NVARCHAR(255) NOT NULL,
City NVARCHAR(30) NOT NULL,
ZipCode INT NOT NULL,
Notes NVARCHAR(255))

CREATE TABLE RentalOrders (
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel TINYINT NOT NULL, 
KilometrageStart BIGINT NOT NULL,
KilometrageEnd BIGINT NOT NULL,
TotalKilometrage AS KilometrageEnd - KilometrageStart,
StartDate DATETIME NOT NULL,
EndDate DATETIME NOT NULL,
TotalDays AS DATEDIFF (d, StartDate, EndDate),
RateApplied BIT,
TaxRate MONEY,
OrderStatus NVARCHAR(30),
Notes NVARCHAR(255))

--Insert Data Into Tables--
INSERT INTO Categories(CategoryName)
VALUES
('SportCar'),
('CityCar'),
('HighwayCruiser')

INSERT INTO Cars(PlateNumber, Manifacturer, Model, CarYear)
VALUES
('CB5351KX', 'Seat', 'Ibiza', 1999),
('CB1111KX', 'VW', 'Golf', 2009),
('CB222KX', 'BMW', 'E90', 2007)

INSERT INTO Employees(FirstName)
VALUES
('Gosho'),
('Ivan'),
('Petkan')

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZipCode)
VALUES
('1111111111', 'Georgi Ivanov', 'Druzhba 1', 'Sofia', 1000),
('2222222222', 'Ivaylo Georgiew', 'Druzhba 2', 'Pernik', 2222),
('3333333333', 'Martin Kostov', 'Mladost 1', 'Sofia', 3333)

INSERT INTO RentalOrders(TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate)
VALUES
(123, 123333, 123455, GETDATE(), GETDATE()),
(12, 111111, 333333, GETDATE(), GETDATE()),
(23, 222222, 555555, GETDATE(), GETDATE())