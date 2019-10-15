CREATE DATABASE Airport

CREATE TABLE Planes
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(30) NOT NULL,
    Seats INT NOT NULL,
    Range INT NOT NULL
)

CREATE TABLE Flights
(
    Id INT PRIMARY KEY IDENTITY,
    DepartureTime DATETIME,
    ArrivalTime DATETIME,
    Origin NVARCHAR(50) NOT NULL,
    Destination NVARCHAR(50),
    PlaneId INT FOREIGN KEY REFERENCES Planes (Id) NOT NULL
)

CREATE TABLE Passengers
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Age INT NOT NULL,
    Address NVARCHAR(30) NOT NULL,
    PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
    Id INT PRIMARY KEY IDENTITY,
    Type NVARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
    Id INT PRIMARY KEY IDENTITY,
    LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes (Id) NOT NULL,
    PassengerId INT FOREIGN KEY REFERENCES Passengers (Id) NOT NULL
)

CREATE TABLE Tickets
(
    Id INT PRIMARY KEY IDENTITY,
    PassengerId INT FOREIGN KEY REFERENCES Passengers (Id) NOT NULL,
    FlightId INT FOREIGN KEY REFERENCES Flights (Id) NOT NULL,
    LuggageId INT FOREIGN KEY REFERENCES Luggages (Id) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
)

--02.Insert--

INSERT
  INTO Planes(Name, Seats, Range)
VALUES ('Airbus 336', 112, 5132),
       ('Airbus 330', 432, 5325),
       ('Boeing 369', 231, 2355),
       ('Stelt 297', 254, 2143),
       ('Boeing 338', 165, 5111),
       ('Airbus 558', 387, 1342),
       ('Boeing 128', 345, 5541)

INSERT
  INTO LuggageTypes(Type)
VALUES ('Crossbody Bag'),
       ('School Backpack'),
       ('Shoulder Bag')


--03.Update--

SELECT *
  FROM Flights
 WHERE Destination = 'Carlsbad'

UPDATE Tickets
   SET Price = Price * 1.13
 WHERE FlightId = (SELECT
                      TOP (1)
                       Id
                     FROM Flights
                    WHERE Destination = 'Carlsbad')


--04.Delete--
DELETE
  FROM Tickets
 WHERE FlightId = (SELECT
                      TOP (1)
                       Id
                     FROM Flights
                    WHERE Destination = 'Ayn Halagim')

DELETE
  FROM Flights
 WHERE Destination = 'Ayn Halagim'


--SECTION 3 - Querying--

--05.The 'Tr' Planes--

SELECT *
  FROM Planes
 WHERE Name LIKE '%tr%'
 ORDER BY Id,
          Name,
          Seats,
          Range

--06.Flight Profits--

SELECT FlightId, SUM(Price) AS Price
  FROM Tickets AS t
           JOIN Flights AS f ON t.FlightId = f.Id
 GROUP BY FlightId
 ORDER BY Price DESC,
          FlightId


--07.Passenger Trips--

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name], Origin, Destination
  FROM Passengers AS p
           JOIN Tickets AS t ON t.PassengerId = p.Id
           JOIN Flights AS f ON f.Id = t.FlightId
 ORDER BY [Full Name],
          Origin,
          Destination


--08.Non Adventures people--

SELECT FirstName, LastName, Age
  FROM Passengers AS p
           LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
 WHERE t.Id IS NULL
 ORDER BY Age DESC,
          FirstName,
          LastName

--09.Full Info--

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name],
       pl.Name AS [Plane Name],
       CONCAT(Origin, ' - ', Destination) AS Trip,
       lt.Type AS [Luggage Type]
  FROM Passengers AS p
           JOIN Tickets AS t ON t.PassengerId = p.Id
           JOIN Flights AS f ON f.Id = t.FlightId
           JOIN Planes AS pl ON pl.Id = f.PlaneId
           JOIN Luggages AS l ON l.Id = t.LuggageId
           JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
 ORDER BY [Full Name],
          pl.Name,
          f.Origin,
          f.Destination,
          lt.Type


--10.PSP--

SELECT p.Name, p.Seats, COUNT(t.Id) AS [Passengers Count]
  FROM Planes AS p
           LEFT JOIN Flights AS f ON p.Id = f.PlaneId
           LEFT JOIN Tickets AS t ON f.Id = t.FlightId
 GROUP BY p.Name,
          p.Seats
 ORDER BY [Passengers Count] DESC,
          p.Name,
          p.Seats


--Section 4 - Programmability --

--11.Vacation--

CREATE FUNCTION udf_CalculateTickets(@origin varchar(50), @destination varchar(50), @peopleCount int)
RETURNS VARCHAR(100)
AS
BEGIN

IF (@peopleCount <= 0)
BEGIN
	RETURN 'Invalid people count!'
END

DECLARE @tripId INT = (SELECT f.Id FROM Flights AS f
											  JOIN Tickets AS t ON t.FlightId = f.Id
											  WHERE Origin = @origin AND Destination = @destination)
IF (@tripId IS NULL)
BEGIN
	RETURN 'Invalid flight!'
END

DECLARE @ticketPrice DECIMAL(15,2) = (SELECT t.Price FROM Flights AS f
											  JOIN Tickets AS t ON t.FlightId = f.Id
											  WHERE Origin = @origin AND Destination = @destination)

DECLARE @totalPrice DECIMAL(15, 2) = @ticketPrice * @peoplecount;

RETURN 'Total price ' + CAST(@totalPrice as VARCHAR(30));
END