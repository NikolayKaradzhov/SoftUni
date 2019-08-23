-- 02.Create Tables --

CREATE TABLE Clients (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL
)


CREATE TABLE AccountTypes (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)


CREATE TABLE Accounts (
Id INT PRIMARY KEY IDENTITY,
AccountTypeId INT FOREIGN KEY REFERENCES AccountTypes(Id),
Balance DECIMAL(15, 2) NOT NULL DEFAULT(0),
ClientId INT FOREIGN KEY REFERENCES Clients(Id)
)

--03.Insert Sample Data into Database--

INSERT INTO Clients(FirstName, LastName)
VALUES
('Gosho', 'Ivanov'),
('Pesho', 'Petrov'),
('Ivan', 'Iliev'),
('Merry', 'Ivanova')


INSERT INTO AccountTypes(Name)
VALUES
('Cheking'),
('Savings')


INSERT INTO Accounts(ClientId, AccountTypeId, Balance)
VALUES
(1, 1, 175),
(2, 1, 275.56),
(3, 1, 138.01),
(4, 1, 40.30),
(4, 2, 375.50)

--04.Create a Function--

CREATE FUNCTION f_CalculateTotalBalance(@ClientId INT)
RETURNS DECIMAL(15,2)
BEGIN
	DECLARE @result AS DECIMAL(15,2) = (
		SELECT SUM(Balance)
		FROM Accounts 
		WHERE ClientId = @ClientId
		)
RETURN @result
END


--Show result for ClientId = 4
SELECT dbo.f_CalculateTotalBalance(4) AS Balance