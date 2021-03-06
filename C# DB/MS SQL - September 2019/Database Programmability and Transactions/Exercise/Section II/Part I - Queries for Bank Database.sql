--Section II. Triggers and Transactions--

--Part 1. Queries for Bank Database--

--14.Create Table Logs--

USE Bank

GO

CREATE TABLE Logs
(
    LogId     INT PRIMARY KEY IDENTITY,
    AccountId INT FOREIGN KEY REFERENCES Accounts (Id) NOT NULL,
    OldSum    DECIMAL(18, 2)                               NOT NULL,
    NewSum    DECIMAL(18, 2)                               NOT NULL
)

CREATE TRIGGER tr_sumChange
    ON Accounts
    FOR UPDATE
    AS
BEGIN
    DECLARE @newSum DECIMAL(18, 2) = (SELECT i.Balance FROM inserted AS i)
    DECLARE @oldSum DECIMAL(18, 2) = (SELECT d.Balance FROM deleted AS d)
    DECLARE @accountId INT = (SELECT i.Id FROM inserted AS i)

    INSERT INTO Logs (AccountId, OldSum, NewSum)
    VALUES (@accountId, @oldSum, @newSum)
END

GO

--15.Create Table Emails--

CREATE TABLE NotificationEmails
(
    Id        INT PRIMARY KEY IDENTITY,
    Recipient INT FOREIGN KEY REFERENCES Accounts (Id),
    Subject   NVARCHAR(100),
    Body      NVARCHAR(100)
)

CREATE TRIGGER tr_sendNotificationEmailOnChange
    ON Logs
    FOR INSERT
    AS
    BEGIN
        DECLARE @recipient INT = (SELECT l.AccountId FROM Logs AS l)
        DECLARE @oldSum DECIMAL(15, 2) = (SELECT i.[OldSum] FROM inserted AS i)
	    DECLARE @newSum DECIMAL(15, 2) = (SELECT i.[NewSum] FROM inserted AS i)

        INSERT INTO NotificationEmails(Recipient, Subject, Body)
        VALUES
        (
            @recipient,
            'Balance change for account: ' + CAST(@recipient AS VARCHAR(100)),
            'On ' + CAST(GETDATE() AS VARCHAR(100)) + 'your balance was changed from ' +
            CAST(@oldSum AS VARCHAR(30)) + 'to ' + CAST(@newSum AS VARCHAR(30)) + '.'
        )
    END


--16.Deposit Money--

CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN
    DECLARE @targetAccountId INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)

    IF (@MoneyAmount < 0 OR @MoneyAmount IS NULL)
    BEGIN
        ROLLBACK
        RAISERROR ('Invalid amount of money', 50001, 1)
        RETURN
    END

    IF(@targetAccountId IS NULL)
    BEGIN
        ROLLBACK
        RAISERROR ('Invalid account Id', 50001, 2)
        RETURN
    END

    UPDATE Accounts
    SET Accounts.Balance += @MoneyAmount
    WHERE Accounts.Id = @AccountId
END



--17.Withdraw Money--

CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN
   DECLARE @targetAccountId INT = (SELECT a.Id FROM Accounts AS a WHERE a.Id = @AccountId)

    IF (@MoneyAmount < 0 OR @MoneyAmount IS NULL)
    BEGIN
        ROLLBACK
        RAISERROR ('Invalid amount of money', 50002, 1)
    END

    IF (@targetAccountId IS NULL)
    BEGIN
        ROLLBACK
        RAISERROR ('AccountId cannot be null', 50002, 2)
    END

    UPDATE Accounts
    SET Balance -= @MoneyAmount
    WHERE Accounts.Id = @targetAccountId
END



--18.Money Transfer--

CREATE PROC usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS
BEGIN

    DECLARE @targetSender INT = (SELECT Id FROM Accounts WHERE Id = @SenderId)
    DECLARE @targetReceiver INT = (SELECT Id FROM Accounts WHERE Id = @ReceiverId)

    IF (@targetSender IS NULL OR @targetReceiver IS NULL)
    BEGIN
        ROLLBACK
        RAISERROR ('Invalid Id Parameter', 16, 1)
    END

    IF (@Amount < 0 OR @Amount IS NULL)
    BEGIN
        ROLLBACK
        RAISERROR ('Amount cannot be less than zero or null', 16, 2)
    END

    EXEC dbo.usp_WithdrawMoney @targetSender, @Amount
	EXEC dbo.usp_DepositMoney @targetReceiver, @Amount
END