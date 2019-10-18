--Section 1. DDL --

CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(30) NOT NULL,
    Password NVARCHAR(30) NOT NULL,
    Email NVARCHAR(30) NOT NULL
)

CREATE TABLE Repositories
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
    RepositoryId INT FOREIGN KEY REFERENCES Repositories (Id),
    ContributorId INT FOREIGN KEY REFERENCES Users (Id),
    CONSTRAINT PK_RepositoriesContributors PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    IssueStatus CHAR(6) NOT NULL,
    RepositoryId INT FOREIGN KEY REFERENCES Repositories (Id) NOT NULL,
    AssigneeId INT FOREIGN KEY REFERENCES Users (Id) NOT NULL
)

CREATE TABLE Commits
(
    Id INT PRIMARY KEY IDENTITY,
    Message NVARCHAR(255) NOT NULL,
    IssueId INT FOREIGN KEY REFERENCES Issues (Id),
    RepositoryId INT FOREIGN KEY REFERENCES Repositories (Id) NOT NULL,
    ContributorId INT FOREIGN KEY REFERENCES Users (Id) NOT NULL
)

CREATE TABLE Files
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Size DECIMAL(15, 2) NOT NULL,
    ParentId INT FOREIGN KEY REFERENCES Files (Id),
    CommitId INT FOREIGN KEY REFERENCES Commits (Id) NOT NULL
)


--Section 2 - DML --

--02.Insert--

INSERT
  INTO Files(Name, Size, ParentId, CommitId)
VALUES ('Trade.idk', 2598.0, 1, 1),
       ('menu.net', 9238.31, 2, 2),
       ('Administrate.soshy', 1246.93, 3, 3),
       ('Controller.php', 7353.15, 4, 4),
       ('Find.java', 9957.86, 5, 5),
       ('Controller.json', 14034.87, 3, 6),
       ('Operate.xix', 7662.92, 7, 7)


INSERT
  INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)
VALUES ('Critical Problem with HomeController.cs file', 'open', 1, 4),
       ('Typo fix in Judge.html', 'open', 4, 3),
       ('Implement documentation for UsersService.cs', 'closed', 8, 2),
       ('Unreachable code in Index.cs', 'open', 9, 8)


--03.Update--

UPDATE Issues
   SET IssueStatus = 'closed'
 WHERE AssigneeId = 6


--04.Delete--

DELETE
  FROM RepositoriesContributors
 WHERE RepositoryId IN (SELECT Id
                          FROM Repositories
                         WHERE Name LIKE 'Softuni-Teamwork')

DELETE
  FROM Issues
 WHERE RepositoryId IN (SELECT Id
                          FROM Repositories
                         WHERE Name LIKE 'Softuni-Teamwork')


--Section 3 - Querying --

--05.Commits--

SELECT Id, Message, RepositoryId, ContributorId
  FROM Commits
 ORDER BY Id,
          Message,
          RepositoryId,
          ContributorId


--06.Heavy HTML--

SELECT Id, Name, Size
  FROM Files
 WHERE Size > 1000 AND
       Name LIKE '%html%'
 ORDER BY Size DESC,
          Id,
          Name


--07.Issues and Users--

SELECT i.Id, CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
  FROM Issues AS i
           JOIN Users AS u ON i.AssigneeId = u.Id
 ORDER BY i.Id DESC,
          i.AssigneeId


--08.Non directory files--

SELECT ff.Id, ff.Name, CONCAT(ff.Size, 'KB') AS Size
  FROM Files AS f
           RIGHT JOIN Files AS ff ON ff.Id = f.ParentId
 WHERE f.ParentId IS NULL
 ORDER BY ff.Id,
          ff.Name,
          Size DESC


--09.Most contributed repositories--

SELECT
   TOP (5) r.Id,
           r.Name,
           COUNT(c.Id) AS Commits
  FROM Repositories AS r
           JOIN RepositoriesContributors AS rc ON r.Id = rc.RepositoryId
           JOIN Commits AS c ON r.Id = c.RepositoryId
 GROUP BY r.Id,
          r.Name
 ORDER BY Commits DESC,
          r.Id,
          r.Name