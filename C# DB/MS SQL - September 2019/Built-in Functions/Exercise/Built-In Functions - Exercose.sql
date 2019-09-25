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
    [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%'
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

