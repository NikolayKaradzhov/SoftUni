--01.Records’ Count--

SELECT
    COUNT(DepositAmount) AS DepositsCount
FROM
    WizzardDeposits


--02. Longest Magic Wand.02--

SELECT
    MAX(MagicWandSize) AS [Longest Magic Wand]
FROM
    WizzardDeposits


--03. Longest Magic Wand per Deposit Groups.03--

SELECT
    DepositGroup, MAX(MagicWandSize)
FROM
    WizzardDeposits
GROUP BY
    DepositGroup


--04. Smallest Deposit Group per Magic Wand Size.04--

SELECT TOP 2
    DepositGroup
FROM
    WizzardDeposits
GROUP BY
    DepositGroup
ORDER BY
    AVG(MagicWandSize)


--05. Deposits Sum.05--

SELECT
    DepositGroup, SUM(DepositAmount) AS [Total Sum]
FROM
    WizzardDeposits
GROUP BY
    DepositGroup


--06. Deposits Sum for Ollivander Family.06--

SELECT
    DepositGroup, SUM(DepositAmount) AS [Total Sum]
FROM
    WizzardDeposits
WHERE
    MagicWandCreator = 'Ollivander family'
GROUP BY
    DepositGroup


--07. Deposits Filter.07--

SELECT
    DepositGroup, SUM(DepositAmount) AS [Total Sum]
FROM
    WizzardDeposits
WHERE
    MagicWandCreator = 'Ollivander family'
GROUP BY
    DepositGroup
HAVING
    SUM(DepositAmount) < 150000
ORDER BY
    [Total Sum] DESC


--08. Deposit Charge.08--

SELECT
    DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [Min Deposit]
FROM
    WizzardDeposits
GROUP BY
    DepositGroup, MagicWandCreator
ORDER BY
    MagicWandCreator, DepositGroup ASC


--09. Age Groups.09--
SELECT [Ages].AgeGroup, COUNT(Ages.AgeGroup)
    FROM
        (
            SELECT
                CASE
                    WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
                    WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
                    WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
                    WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
                    WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
                    WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
                ELSE '[61+]'
            END AS [AgeGroup]
    FROM  WizzardDeposits) AS Ages
GROUP BY
    Ages.AgeGroup


--10.First Letter.10--

SELECT
    LEFT(FirstName, 1) AS [FirstLetter]
FROM
    WizzardDeposits
WHERE
    DepositGroup = 'Troll Chest'
GROUP BY
    LEFT(FirstName, 1)
ORDER BY
    FirstLetter ASC


--11.Average Interest.11--

SELECT
    DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM
    WizzardDeposits
WHERE
    DepositStartDate > CONVERT(DATETIME, '01/01/1985')
GROUP BY
    DepositGroup, IsDepositExpired
ORDER BY
    DepositGroup DESC, IsDepositExpired ASC


--12.Rich Wizard, Poor Wizard.12--

SELECT SUM(Difference) AS [SumDifference] FROM (
    SELECT
    FirstName AS [Host Wizard],
    DepositAmount AS [Host Wizard Deposit],
    LEAD(FirstName) over (ORDER BY Id) [Guest Wizard],
    LEAD(DepositAmount) over (ORDER BY Id) [Guest Wizard Deposit],
    DepositAmount - LEAD(DepositAmount) over (ORDER BY Id) AS [Difference]
FROM
    WizzardDeposits ) AS DiffTable


--13.Departments Total Salaries.13--

USE SoftUni

SELECT
    DepartmentID, SUM(Salary) AS [TotalSalary]
FROM
    Employees
GROUP BY
    DepartmentID
ORDER BY
    DepartmentID ASC


--14.Employees Minimum Salaries.14--

SELECT
    DepartmentID, MIN(Salary) AS [MinimumSalary]
FROM
    Employees
WHERE
    DepartmentID IN (2,5,7)
    AND
        HireDate > CONVERT(DATETIME, '01/01/2000')
GROUP BY
    DepartmentID


--15. Employees Average Salaries.15--

SELECT * INTO NewEmployeesTable
FROM
    Employees
WHERE
    Salary > 30000

DELETE FROM
    NewEmployeesTable
WHERE
    ManagerID = 42

UPDATE
    NewEmployeesTable
SET
    Salary += 5000
WHERE
    DepartmentID = 1

SELECT
    DepartmentID, AVG(Salary) AS [AverageSalary]
FROM
    NewEmployeesTable
GROUP BY
    DepartmentID


--16. Employees Maximum Salaries.16--

SELECT
    DepartmentID, MAX(Salary) AS [MaxSalary]
FROM
    Employees
GROUP BY
    DepartmentID
HAVING
    MAX(Salary) NOT BETWEEN 30000 AND 70000


--17. Employees Count Salaries.17--

SELECT
    COUNT(Salary) AS [Count]
FROM
    Employees
WHERE
    ManagerID IS NULL