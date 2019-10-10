--Section 1 - Functions and Procedures--

--Part 3 - Diablo Database--

--13. *Scalar Function: Cash in User Games Odd Rows--
USE Diablo

CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(MAX))
    RETURNS TABLE
        AS RETURN
                            SELECT SUM(Cash) AS SumCash
                              FROM (SELECT DENSE_RANK() OVER (ORDER BY Cash DESC ) AS RowNumber, ug.Cash
                                      FROM Games AS g
                                               JOIN UsersGames AS ug ON ug.GameId = g.Id
                                     WHERE Name = @gameName) AS Cash
                             WHERE RowNumber % 2 != 0

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')