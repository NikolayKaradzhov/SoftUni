--01.Employee Address--
USE SoftUni

SELECT
   TOP 5
EmployeeID
     ,
JobTitle
     ,
     A.AddressID
     ,
AddressText
  FROM Employees E
           JOIN Addresses A ON E.AddressID = A.AddressID
 ORDER BY AddressID


--02.Addresses with Towns--

SELECT
   TOP 50
FirstName
     ,
LastName
     ,
     T.Name
     ,
     A.AddressText
  FROM Employees AS E
           JOIN Addresses AS A ON E.AddressID = A.AddressID
           JOIN Towns T ON A.TownID = T.TownID
 ORDER BY FirstName,
          LastName


--03. Sales Employees--

SELECT EmployeeID, FirstName, LastName, D.Name
  FROM Employees AS E
           JOIN Departments AS D ON E.DepartmentID = D.DepartmentID
 WHERE D.Name = 'Sales'
 ORDER BY EmployeeID ASC



--04. Employee Departments--

SELECT
    TOP 5
        EmployeeID, FirstName, Salary, D.Name
FROM Employees AS E
JOIN Departments AS D ON E.DepartmentID = D.DepartmentID
WHERE Salary > 15000
ORDER BY D.DepartmentID



--05. Employees Without Projects--

SELECT
    TOP 3
        E.EmployeeID, E.FirstName
FROM Employees AS E
FULL JOIN EmployeesProjects AS EP ON E.EmployeeID = EP.EmployeeID
WHERE EP.ProjectID IS NULL
ORDER BY E.EmployeeID

--06. Employees Hired After--

SELECT FirstName, LastName, HireDate, D.Name
FROM Employees
JOIN Departments D ON Employees.DepartmentID = D.DepartmentID
WHERE D.Name IN ('Sales', 'Finance') AND HireDate > '1.1.1999'
ORDER BY HireDate



--07. Employees With Project--

SELECT
    TOP 5
        E.EmployeeID, E.FirstName, P.Name
FROM Employees AS E
JOIN EmployeesProjects AS EP ON E.EmployeeID = EP.EmployeeID
JOIN Projects AS P ON EP.ProjectID = P.ProjectID
WHERE P.StartDate > '2002.08.13' AND P.EndDate IS NULL
ORDER BY E.EmployeeID


--08. Employee 24--


--09. Employee Manager--


--10. Employees Summary--


--11. Min Average Salary--


--12. Highest Peaks in Bulgaria--


--13. Count Mountain Ranges--


--14. Countries With or Without Rivers--


--15. Continents and Currencies--


--16. Countries Without any Mountains--


--17. Highest Peak and Longest River by Country--


--18. Highest Peak Name and Elevation by Country--


