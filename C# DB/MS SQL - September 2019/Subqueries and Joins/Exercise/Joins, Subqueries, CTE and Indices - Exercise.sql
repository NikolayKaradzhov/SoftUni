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
EmployeeID
     ,
FirstName
     ,
Salary
     ,
     D.Name
  FROM Employees AS E
           JOIN Departments AS D ON E.DepartmentID = D.DepartmentID
 WHERE Salary > 15000
 ORDER BY D.DepartmentID


--05. Employees Without Projects--

SELECT
   TOP 3
     E.EmployeeID
     ,
     E.FirstName
  FROM Employees AS E
           FULL JOIN EmployeesProjects AS EP ON E.EmployeeID = EP.EmployeeID
 WHERE EP.ProjectID IS NULL
 ORDER BY E.EmployeeID

--06. Employees Hired After--

SELECT FirstName, LastName, HireDate, D.Name
  FROM Employees
           JOIN Departments D ON Employees.DepartmentID = D.DepartmentID
 WHERE D.Name IN ('Sales', 'Finance') AND
       HireDate > '1.1.1999'
 ORDER BY HireDate


--07. Employees With Project--

SELECT
   TOP 5
        E.EmployeeID,
        E.FirstName,
        P.Name
  FROM Employees AS E
           JOIN EmployeesProjects AS EP ON E.EmployeeID = EP.EmployeeID
           JOIN Projects AS P ON EP.ProjectID = P.ProjectID
 WHERE P.StartDate > '2002.08.13' AND
       P.EndDate IS NULL
 ORDER BY E.EmployeeID


--08. Employee 24--

SELECT E.EmployeeID,
       E.FirstName,
       --IIF(YEAR(p.StartDate) >= 2005, NULL, P.Name) AS [ProjectName]--
       CASE
           WHEN YEAR(p.StartDate) >= 2005 THEN NULL
           ELSE P.Name
       END AS [ProjectName]
  FROM Employees AS E
           JOIN EmployeesProjects AS EP ON E.EmployeeID = EP.EmployeeID
           JOIN Projects AS P ON EP.ProjectID = P.ProjectID
 WHERE E.EmployeeID = 24


--09. Employee Manager--

SELECT E.EmployeeID, E.FirstName, E.ManagerID, MG.FirstName AS ManagerName
  FROM Employees AS E
           JOIN Employees AS MG ON MG.EmployeeID = E.ManagerID
 WHERE E.ManagerID IN (3, 7)
 ORDER BY E.EmployeeID ASC


--10. Employees Summary--

SELECT
   TOP 50
        E.EmployeeID,
        CONCAT(E.FirstName, ' ', E.LastName) AS [EmployeeName],
        CONCAT(MG.FirstName, ' ', MG.LastName) AS [ManagerName],
        D.Name AS [DepartmentName]
  FROM Employees AS E
           JOIN Employees AS MG ON MG.EmployeeID = E.ManagerID
           JOIN Departments AS D ON D.DepartmentID = E.DepartmentID
 ORDER BY E.EmployeeID


--11. Min Average Salary--

SELECT
   TOP (1)
   AVG(e.Salary) AS [MinAverageSalary]
  FROM Departments AS D
           JOIN Employees AS E ON E.DepartmentID = D.DepartmentID
 GROUP BY D.Name
 ORDER BY [MinAverageSalary] ASC


SELECT MIN(A.AverageSalary) AS MinAverageSalary
  FROM (SELECT E.DepartmentID, AVG(E.Salary) AS AverageSalary
          FROM Employees AS E
         GROUP BY E.DepartmentID) AS A

--12. Highest Peaks in Bulgaria--

SELECT MC.CountryCode, M.MountainRange, P.PeakName, P.Elevation
  FROM Mountains AS M
           JOIN Peaks AS P ON M.Id = P.MountainId
           JOIN MountainsCountries AS MC ON MC.MountainId = M.Id
 WHERE P.Elevation > 2835 AND
       CountryCode = 'BG'
 ORDER BY P.Elevation DESC


--13. Count Mountain Ranges--

SELECT CountryCode, COUNT(MountainRange) AS [MountainRages]
  FROM Mountains AS M
           JOIN MountainsCountries AS MC ON MC.MountainId = M.Id
 WHERE MC.CountryCode IN ('BG', 'RU', 'US')
 GROUP BY CountryCode


--14. Countries With or Without Rivers--

SELECT
   TOP 5
        CountryName,
        R.RiverName
  FROM Countries AS C
           LEFT JOIN CountriesRivers AS CR ON CR.CountryCode = C.CountryCode
           LEFT JOIN Rivers AS R ON CR.RiverId = R.Id
 WHERE C.ContinentCode = 'AF'
 ORDER BY C.CountryName


--15*. Continents and Currencies--
SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
  FROM (SELECT c.ContinentCode,
               c.CurrencyCode,
               COUNT(c.CurrencyCode) AS [CurrencyUsage],
               DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
          FROM Countries AS c
                   JOIN Currencies AS cc ON cc.CurrencyCode = c.CurrencyCode
         GROUP BY c.ContinentCode,
                  c.CurrencyCode
        HAVING COUNT(c.CurrencyCode) != 1) AS k
 WHERE k.[Rank] = 1
 ORDER BY k.ContinentCode;


--16. Countries Without any Mountains--

SELECT COUNT(C.CountryName) AS Count
  FROM Countries AS C
           LEFT JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
 WHERE MC.MountainId IS NULL


--17. Highest Peak and Longest River by Country--

SELECT
   TOP 5
        C.CountryName,
        MAX(p.Elevation) AS [HighestPeakElevation],
        MAX(R.Length) AS [LongestRiverLength]
  FROM Countries AS C
           JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
           JOIN Mountains M ON MC.MountainId = M.Id
           JOIN Peaks P ON M.Id = P.MountainId
           JOIN CountriesRivers CR ON C.CountryCode = CR.CountryCode
           JOIN Rivers R ON CR.RiverId = R.Id
 GROUP BY C.CountryName
 ORDER BY [HighestPeakElevation] DESC,
          [LongestRiverLength] DESC,
          C.CountryName


--18. Highest Peak Name and Elevation by Country--


