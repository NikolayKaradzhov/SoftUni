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


--06. Employees Hired After--


--07. Employees With Project--


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


