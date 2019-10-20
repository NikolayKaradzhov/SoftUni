--Section I - DDL --

--01.--

CREATE DATABASE Service

CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY ,
    Username NVARCHAR(30) UNIQUE NOT NULL ,
    Password NVARCHAR(50) NOT NULL ,
    Name NVARCHAR(50),
    Birthdate DATETIME,
    Age INT CHECK (Age BETWEEN 14 AND 110),
    Email NVARCHAR(50) NOT NULL

)

CREATE TABLE Departments
(
    Id INT PRIMARY KEY IDENTITY ,
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY ,
    FirstName NVARCHAR(25) ,
    LastName NVARCHAR(25),
    Birthdate DATETIME ,
    Age INT CHECK (Age BETWEEN 18 AND 110),
    DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY ,
    Name NVARCHAR(50) NOT NULL ,
    DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Status
(
    Id INT PRIMARY KEY IDENTITY ,
    Label NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
    Id INT PRIMARY KEY IDENTITY ,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL ,
    StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL ,
    OpenDate DATETIME NOT NULL ,
    CloseDate DATETIME,
    Description NVARCHAR(200) NOT NULL ,
    UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL ,
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)


--Section 2 - DML --

--02.Insert--

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O''Malley', 1958-9-21, 1),
('Niki', 'Stanaghan', 1969-11-26, 4),
('Ayrton', 'Senna', 1960-03-21, 9),
('Ronnie', 'Peterson', 1944-02-14, 9),
('Giovanna', 'Amati', 1959-07-20, 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId)
VALUES
(1, 1, 2017-04-13, NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, 2015-09-05, 2015-12-06, 'Charity trail running', 3, 5),
(14, 2, 2015-09-07, NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, 2017-07-03, 2017-07-06, 'Cut off streetlight on Str.11', 1, 1)


--03.Update--

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL


--04.Delete--

DELETE FROM Reports
WHERE StatusId = 4


--Section III - Querying --

--05.Unassigned Reports--

SELECT Description, FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY CONVERT(DATETIME, OpenDate, 103) ASC, Description ASC

--06.Reports & Categories--

SELECT r.Description, c.Name
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE r.CategoryId IS NOT NULL
ORDER BY r.Description, c.Name


--07.Most Reported Category--

SELECT TOP (5) c.Name, COUNT(r.CategoryId) AS ReportsNumber
FROM Categories AS c
JOIN Reports as r ON c.Id = r.CategoryId
GROUP BY c.Name, r.CategoryId
ORDER BY ReportsNumber DESC, c.Name ASC


--08.BirthDay Report--

SELECT u.Username, c.Name
FROM Reports AS r
JOIN Users AS u ON r.UserId = u.Id
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DAY(r.OpenDate) = DAY(u.Birthdate) AND MONTH(r.OpenDate) = MONTH(u.Birthdate)
ORDER BY u.Username, c.Name


--09.Users per Employee--

SELECT DISTINCT CONCAT(FirstName, ' ', LastName) AS FullName, COUNT(r.EmployeeId) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
GROUP BY CONCAT(FirstName, ' ', LastName)
ORDER BY UsersCount DESC , FullName


--10.FullInfo--

SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
       ISNULL(d.Name, 'None') AS Department,
       ISNULL(c.Name, 'None') AS Category,
       ISNULL(r.Description, 'None') AS Description,
       ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None') AS OpenDate,
       ISNULL(s.Label, 'None') AS Status,
       ISNULL(u.Name, 'None') AS [User]
FROM Reports AS r
FULL JOIN Employees AS e ON r.EmployeeId = e.Id
FULL JOIN Departments AS d ON e.DepartmentId = d.Id
JOIN Categories AS c ON c.Id = r.CategoryId
JOIN Status AS s ON r.StatusId = s.Id
JOIN Users AS u ON r.UserId = u.Id
ORDER BY e.FirstName DESC,
         e.LastName DESC,
         d.Name ,
         c.Name,
         r.Description,
         CONVERT(DATETIME, OpenDate, 104) ASC,
         s.Label,
         u.Name


--11.Hours to complete--

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
    DECLARE @result INT = (SELECT DATEDIFF(hour , OpenDate, CloseDate) FROM Reports
                            WHERE OpenDate = @StartDate AND CloseDate = @EndDate)

    IF(@StartDate IS NULL)
    BEGIN
        RETURN 0
    END

    IF(@EndDate IS NULL)
    BEGIN
        RETURN 0
    END

        RETURN @result
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports


--12.Assign Employee--

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
    DECLARE @neededDepartment INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)

    DECLARE @reportsDepartment INT = (SELECT DepartmentId FROM Reports AS r
                                        JOIN Categories AS c ON r.CategoryId = c.Id
                                            WHERE r.Id = @ReportId)

    IF(@neededDepartment != @reportsDepartment)
    BEGIN
        RAISERROR ('Employee doesn''t belong to the appropriate department!', 16, 1)
        RETURN
    END

    UPDATE Reports
    SET EmployeeId = @EmployeeId
    WHERE Reports.Id = @ReportId
END

EXEC usp_AssignEmployeeToReport 17, 2