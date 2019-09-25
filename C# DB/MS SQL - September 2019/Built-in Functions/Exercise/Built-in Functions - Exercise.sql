--01. Find Names of All Employees by First Name.01--

SELECT
    FirstName, LastName
FROM
    Employees
WHERE
    FirstName LIKE 'SA%'


--02.Find Names of All Employees by Last Name.02--

SELECT
    FirstName, LastName
FROM
    Employees
WHERE
    LastName LIKE '%ei%'


--03. Find First Names of All Employees.03--

SELECT
    FirstName
FROM
    Employees
WHERE
    DepartmentID IN (3, 10)
AND
    DATEPART(YEAR , HireDate) BETWEEN 1995 AND 2005



--04.Find All Employees Except Engineers.04--

SELECT
    FirstName, LastName
FROM
    Employees
WHERE
    JobTitle NOT LIKE '%engineer%'


--05. Find Towns with Name Length.05--

SELECT
    [Name]
FROM
    Towns
WHERE
    LEN(Name) BETWEEN 5 AND 6
ORDER BY [Name] ASC


--06. Find Towns Starting With.06--

SELECT
    TownID, [Name]
FROM
    Towns
WHERE
    [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%' --[MKBE]%--
ORDER BY
    [Name] ASC



--07. Find Towns Not Starting With.07--

SELECT
    TownID, [Name]
FROM
    Towns
WHERE
    [Name] NOT LIKE 'R%' AND [Name] NOT LIKE 'B%' AND [Name] NOT LIKE 'D%'
ORDER BY
    [Name] ASC


--08. Create View Employees Hired After.08--

CREATE VIEW
    V_EmployeesHiredAfter2000
AS
SELECT
    FirstName, LastName
FROM
    Employees
WHERE
    DATEPART(YEAR, HireDate) > 2000


--09. Length of Last Name.09--

SELECT
    FirstName, LastName
FROM
    Employees
WHERE
    LEN(LastName) = 5


--10. Rank Employees by Salary.10--

SELECT
    EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM
    Employees
WHERE
    Salary BETWEEN 10000 AND 50000
ORDER BY
    Salary DESC


--11. Find All Employees with Rank 2--




--12. Countries Holding 'A'--

SELECT
    CountryName, IsoCode
FROM
    Countries
WHERE
    CountryName LIKE '%a%a%a%'
ORDER BY
    IsoCode ASC


--13. Mix of Peak and River Names--

SELECT
    PeakName, RiverName, LOWER(LEFT(PeakName, LEN(PeakName) - 1) + RiverName) AS Mix
FROM
    Peaks, Rivers
WHERE
    RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY
    Mix


--14. Games From 2011 and 2012 Year.14--

SELECT TOP 50
    Name, FORMAT(Start, 'yyyy-MM-dd') AS Start
FROM
    Games
WHERE
     DATEPART(YEAR, Start) BETWEEN 2011 AND 2012
ORDER BY
    Start ASC


--15. User Email Providers.15--

SELECT
    Username, RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
FROM
    Users
ORDER BY
    [Email Provider] ASC, Username


--16.Get Users with IPAddress Like Pattern.16-

SELECT
    Username, IpAddress
FROM
    Users
WHERE
    IpAddress LIKE '___.1%.%.___'
ORDER BY
    Username ASC