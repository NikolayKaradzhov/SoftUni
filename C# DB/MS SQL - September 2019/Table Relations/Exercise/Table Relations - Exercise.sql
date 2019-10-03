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

CREATE DATABASE ManyToMany

USE ManyToMany

CREATE TABLE Students
(
    StudentID INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(30) NOT NULL
)

INSERT
  INTO Students(Name)
VALUES ('Mila'),
       ('Toni'),
       ('Ron')

CREATE TABLE Exams
(
    ExamID INT PRIMARY KEY NOT NULL,
    Name NVARCHAR(30) NOT NULL
)

INSERT
  INTO Exams(ExamID, Name)
VALUES (101, 'SpringMVC'),
       (102, 'Neo4j'),
       (103, 'Oracle 11g')

CREATE TABLE StudentsExams
(
    StudentID INT FOREIGN KEY REFERENCES Students (StudentID),
    ExamID INT FOREIGN KEY REFERENCES Exams (ExamID),
    CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID)
)

INSERT
  INTO StudentsExams(StudentID, ExamID)
VALUES (1, 101),
       (1, 102),
       (2, 101),
       (3, 103),
       (2, 102),
       (2, 103)


SELECT *
  FROM StudentsExams AS se
           JOIN Students s ON se.StudentId = s.StudentID
           JOIN Exams e ON se.ExamId = e.ExamID


--04.Self-Referencing.04--

CREATE DATABASE SelfReferencing

USE SelfReferencing

CREATE TABLE Teachers
(
    TeacherID INT PRIMARY KEY IDENTITY (101,1) NOT NULL,
    Name NVARCHAR(30) NOT NULL,
    ManagerID INT FOREIGN KEY REFERENCES Teachers (TeacherID)
)

INSERT
  INTO Teachers(Name, ManagerID)
VALUES ('John', NULL),
       ('Maya', 106),
       ('Silvia', 106),
       ('Ted', 105),
       ('Mark', 101),
       ('Greta', 101)


--05.Online Store Database.05--

CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Cities
(
    CityID INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY IDENTITY NOT NULL ,
    Name NVARCHAR(50) NOT NULL,
    Birthday DATE NOT NULL,
    CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY IDENTITY NOT NULL ,
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE ItemTypes
(
    ItemTypeID INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
    ItemID INT PRIMARY KEY IDENTITY NOT NULL ,
    Name NVARCHAR(50) NOT NULL ,
    ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems
(
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL ,
    ItemID INT FOREIGN KEY REFERENCES Items(ItemID) NOT NULL ,
    CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID)
)