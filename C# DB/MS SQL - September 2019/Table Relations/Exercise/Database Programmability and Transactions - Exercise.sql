--SECTION 1--

--Part 1. Queries for SoftUni Database--

--01.Employees with Salary Above 35000--

USE SoftUni

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 AS
BEGIN
    SELECT FirstName, LastName
      FROM Employees AS e
     WHERE Salary > 35000
END

GO
--02.Employees with Salary Above Number--

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Salary DECIMAL(18, 4)) AS
BEGIN
    SELECT FirstName, LastName
      FROM Employees AS e
     WHERE e.Salary >= @Salary
END

    EXEC usp_GetEmployeesSalaryAboveNumber 40000.22

GO
--03.Town Names Starting With--

CREATE PROCEDURE usp_GetTownsStartingWith(@StartLetter VARCHAR(10)) AS
BEGIN
    SELECT t.Name AS Town
      FROM Towns AS t
     WHERE t.Name LIKE @StartLetter + '%'
END

    EXEC usp_GetTownsStartingWith b

GO
--04.Employees from Town--

CREATE PROCEDURE usp_GetEmployeesFromTown(@TownName NVARCHAR(20)) AS
BEGIN
    SELECT e.FirstName, e.LastName
      FROM Employees AS e
               JOIN Addresses AS a ON a.AddressID = e.AddressID
               JOIN Towns AS t ON t.TownID = a.TownID
     WHERE @TownName = t.Name
END

    EXEC usp_GetEmployeesFromTown Sofia


--05.Salary Level Function--

CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
    DECLARE @result NVARCHAR(20)

        IF (@salary < 30000)
            SET @result = 'Low'
        ELSE IF (@salary BETWEEN  30000 AND 50000)
            SET @result = 'Average'
        ELSE IF (@salary > 50000)
            SET @result = 'High'
    RETURN @result
END



--06.Employees by Salary Level--

CREATE PROCEDURE usp_EmployeesBySalaryLevel (@Level NVARCHAR(20)) AS
BEGIN
    SELECT FirstName, LastName
    FROM Employees AS e
    WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level
END

GO

--07.Define Function--

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT                         --OFIAS--
AS
    BEGIN
        DECLARE @result BIT
        DECLARE @count INT = 1

        WHILE @count <= LEN(@word)
        BEGIN
            DECLARE @currentSymbol NVARCHAR(1) = SUBSTRING(@word, @count, 1)
                                                          --Sofia--
            IF CHARINDEX(@currentSymbol, @setOfLetters) > 0
                BEGIN   --S>o>f>i>a--      --OFIAS--
                    SET @result = 1
                    SET @count += 1
                END
            ELSE
                BEGIN
                    SET @result = 0
                END
        END
        RETURN @result
    END


GO


--08.Delete Employees and Departments--

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) AS
BEGIN
    
END