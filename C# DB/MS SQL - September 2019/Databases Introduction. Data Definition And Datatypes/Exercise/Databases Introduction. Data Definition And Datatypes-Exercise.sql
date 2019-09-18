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
	Towns(Id, Name)
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO
	Minions(Id, Name, Age, TownId)
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

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
INSERT INTO
    Directors (DirectorName, Notes)
VALUES 
    ('Stephen Speilberg', NULL),
    ('Martin Scorseze', 'Very good director'),
    ('Peter Jackson', NULL),
    ('Quentin Tarantino', NULL),
    ('Ridley Scott', NULL)

INSERT INTO
    Genres(GenreName, Notes)
VALUES
    ('Comedy', NULL),
    ('Drama', NULL),
    ('Action', NULL),
    ('Fantasy', NULL),
    ('Musical', NULL)

INSERT INTO
    Categories(CategoryName, Notes)
VALUES
    ('Documentary', NULL),
    ('Erotic', NULL),
    ('Horror', NULL),
    ('Fantasy', NULL),
    ('Western', NULL)

INSERT INTO
    Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
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
INSERT INTO
    Categories(CategoryName)
VALUES
    ('SportCar'),
    ('CityCar'),
    ('HighwayCruiser')

INSERT INTO
    Cars(PlateNumber, Manifacturer, Model, CarYear)
VALUES
    ('CB5351KX', 'Seat', 'Ibiza', 1999),
    ('CB1111KX', 'VW', 'Golf', 2009),
    ('CB222KX', 'BMW', 'E90', 2007)

INSERT INTO
    Employees(FirstName)
VALUES
    ('Gosho'),
    ('Ivan'),
    ('Petkan')

INSERT INTO
    Customers(DriverLicenceNumber, FullName, Address, City, ZipCode)
VALUES
    ('1111111111', 'Georgi Ivanov', 'Druzhba 1', 'Sofia', 1000),
    ('2222222222', 'Ivaylo Georgiew', 'Druzhba 2', 'Pernik', 2222),
    ('3333333333', 'Martin Kostov', 'Mladost 1', 'Sofia', 3333)

INSERT INTO
    RentalOrders(TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate)
VALUES
    (123, 123333, 123455, GETDATE(), GETDATE()),
    (12, 111111, 333333, GETDATE(), GETDATE()),
    (23, 222222, 555555, GETDATE(), GETDATE())


--15.Hotel Database--
CREATE DATABASE Hotel

--15.Create Hotel Tables--
CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY (1,1),
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Title NVARCHAR(20),
Notes NVARCHAR(200)
)

INSERT INTO
    Employees(FirstName, LastName, Notes)
VALUES
    ('Gosho', 'Petkov', NULL),
    ('Ivan', 'Ivanov', NULL),
    ('Georgi', 'Vasilev', NULL)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY (1,1),
AccountNumber INT NOT NULL,
FirstName NVARCHAR(30) NOT NULL ,
LastName NVARCHAR(30) NOT NULL ,
PhoneNumber INT,
EmergencyName NVARCHAR(30) NOT NULL ,
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(30)
)

INSERT INTO
    Customers(AccountNumber, FirstName, LastName, EmergencyName, EmergencyNumber)
VALUES
    (123312321, 'Vasko', 'Ivanov', '911Emergency', 911),
    (4234324, 'Gosko', 'Petkov', '112Emergency', 112),
    (64564646, 'Ivancho', 'Georgiev', '611Call', 611)


CREATE TABLE RoomStatus (
Id INT PRIMARY KEY IDENTITY (1,1),
RoomStatus NVARCHAR(10) NOT NULL ,
Notes NVARCHAR(200)
)

INSERT INTO
    RoomStatus(RoomStatus)
VALUES
    ('Free'),
    ('Occupied'),
    ('Half');

CREATE TABLE RoomTypes(
Id INT PRIMARY KEY IDENTITY (1,1),
RoomType NVARCHAR(30) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO
    RoomTypes(RoomType)
VALUES
    ('Single'),
    ('Double'),
    ('Triple');

CREATE TABLE BedTypes (
Id INT PRIMARY KEY IDENTITY (1,1),
BedType NVARCHAR(30) NOT NULL,
Notes NVARCHAR(200)
)

INSERT INTO
    BedTypes(BedType)
VALUES
    ('Single'),
    ('Double'),
    ('Tripple');

CREATE TABLE Rooms (
Id INT PRIMARY KEY IDENTITY (1,1),
RoomNumber INT NOT NULL,
RoomType INT FOREIGN KEY REFERENCES RoomTypes(Id),
BedType INT FOREIGN KEY REFERENCES BedTypes(Id),
Rate INT CHECK (Rate >= 1 AND Rate <= 5),
RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(Id),
Notes NVARCHAR(200)
)

INSERT INTO
    Rooms(RoomNumber, RoomType, BedType, RoomStatus)
VALUES
    (123, 1, 1, 1),
    (456, 2, 2, 2),
    (789, 3, 3, 3)

CREATE TABLE Payments (
    Id INT PRIMARY KEY IDENTITY (1,1),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    PaymentDate DATE,
    AccountNumber INT,
    FirstDateOccupied DATE,
    LastDateOccupied DATE,
    TotalDays INT,
    AmountCharged MONEY,
    TaxRate MONEY,
    TaxAmount MONEY,
    PaymentTotal MONEY,
    Notes NVARCHAR(200)
)

INSERT INTO
    Payments(EmployeeId)
VALUES
    (2),
    (3),
    (1);


CREATE TABLE Occupancies (
    Id INT PRIMARY KEY IDENTITY (1,1),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    DateOccupied DATE,
    AccountNumber INT,
    RoomNumber INT FOREIGN KEY REFERENCES Rooms(Id) ,
    RateApplied BIT,
    PhoneCharge BIT,
    Notes NVARCHAR(200)
)

INSERT INTO
    Occupancies(EmployeeId)
VALUES
    (2),
    (1),
    (3);


--19.Basic Select All Fields--

SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;


--20.Basic Select All Fields and Order Them--

SELECT * FROM Towns ORDER BY Name
SELECT * FROM Departments ORDER BY Name
SELECT * FROM Employees ORDER BY Salary DESC

--21.Basic Select Some Fields--

SELECT
    Name
FROM
    Towns
ORDER BY
    Name;

SELECT
    Name
FROM
    Departments
ORDER BY
    Name;

--22.Increase Empleyee Salary--

UPDATE
    Employees
SET
    Salary = Salary + Salary * 0.10;
SELECT
    Salary
FROM
    Employees;
SELECT
    FirstName, LastName, JobTitle, Salary
FROM
    Employees
ORDER BY
    Salary DESC;

--23.Decrease Tax Rate--

UPDATE
    Payments
SET
    TaxRate -= TaxRate * 0.03;
SELECT
    TaxRate
FROM
    Payments;

--24.Delete All Records--

TRUNCATE TABLE Occupancies