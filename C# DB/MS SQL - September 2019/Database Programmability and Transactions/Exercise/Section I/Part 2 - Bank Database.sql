--Part 2. Queries for Bank Database--

--09. Find Full Name--

USE Bank

CREATE PROC usp_GetHoldersFullName AS
BEGIN
    SELECT CONCAT(FirstName, ' ', LastName) AS [FullName]
      FROM AccountHolders
END

GO


--10.People with Balance Higher Than--

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@balance MONEY)
AS
BEGIN
    SELECT ah.FirstName, ah.LastName
      FROM AccountHolders AS ah
               JOIN Accounts AS a ON a.AccountHolderId = ah.Id
     GROUP BY ah.FirstName,
              ah.LastName
    HAVING SUM(a.Balance) > @balance
     ORDER BY ah.FirstName,
              ah.LastName
END

    EXEC usp_GetHoldersWithBalanceHigherThan 10000

GO


--11. Future Value Function--

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(15, 2), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(15, 4)
AS
BEGIN
    RETURN @sum * (POWER(1 + @yearlyInterestRate, @numberOfYears))
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS [Output]


--12. Calculating interest--

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT, @yearlyInterestRate DECIMAL(15, 2)) AS
BEGIN
    DECLARE @years INT = 5

    SELECT a.Id,
           ah.FirstName,
           ah.LastName,
           a.Balance AS [Current Balance],
           dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, @years) AS [Balance in 5 years]
      FROM Accounts AS a
               JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
     WHERE a.Id = @accountId
END

    EXEC usp_CalculateFutureValueForAccount 1, 0.1