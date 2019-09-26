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