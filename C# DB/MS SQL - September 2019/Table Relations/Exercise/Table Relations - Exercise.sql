--01. OneToOne Relationship.01--

CREATE DATABASE OneToOne

USE OneToOne

CREATE TABLE Passports
(
    PassportID INT PRIMARY KEY NOT NULL,
    PassportNumber NVARCHAR(20) NOT NULL
)

CREATE TABLE Persons
(
    PersonID INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(30) NOT NULL,
    Salary DECIMAL(15, 2) NOT NULL,
    PassportID INT FOREIGN KEY REFERENCES Passports (PassportID)
)

INSERT
  INTO Passports (PassportID, PassportNumber)
VALUES (101, 'N34FG21B'),
       (102, 'K65LO4R7'),
       (103, 'ZE657QP2')


INSERT
  INTO Persons (FirstName, Salary, PassportID)
VALUES ('Roberto', 43300.00, 102),
       ('Tom', 56100.00, 103),
       ('Yana', 60200.00, 101)


SELECT *
  FROM Persons AS pe
           JOIN Passports pa ON pe.PassportID = pa.PassportID


--02.One-To-Many Relationship.02--

CREATE DATABASE CarFactory

USE CarFactory

CREATE TABLE Manufacturers
(
    ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(30) NOT NULL,
    EstablishedOn DATE NOT NULL
)

INSERT
  INTO Manufacturers([Name], EstablishedOn)
VALUES ('BMW', '07/03/1916'),
       ('Tesla', '01/01/2003'),
       ('Lada', '01/05/1966')

CREATE TABLE Models
(
    ModelID INT PRIMARY KEY NOT NULL,
    Name NVARCHAR(30) NOT NULL,
    ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers (ManufacturerID)
)

INSERT
  INTO Models(ModelID, Name, ManufacturerID)
VALUES (101, 'X1', 1),
       (102, 'i6', 1),
       (103, 'Model S', 2),
       (104, 'Model X', 2),
       (105, 'Model 3', 2),
       (106, 'Nova', 3)


SELECT *
  FROM Manufacturers AS ma
           JOIN Models AS mo ON mo.ManufacturerID = ma.ManufacturerID


--03.Many-To-Many Relationship.03--

