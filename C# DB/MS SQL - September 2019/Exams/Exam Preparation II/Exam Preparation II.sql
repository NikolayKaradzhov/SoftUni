CREATE DATABASE School

CREATE TABLE Students
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(30) NOT NULL,
    MiddleName NVARCHAR(25),
    LastName NVARCHAR(30) NOT NULL,
    Age INT CHECK (Age BETWEEN 5 AND 100),
    Address NVARCHAR(50),
    Phone CHAR(10)
)

CREATE TABLE Subjects
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(20) NOT NULL,
    Lessons INT CHECK (Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects
(
    Id INT PRIMARY KEY IDENTITY,
    StudentId INT FOREIGN KEY REFERENCES Students (Id) NOT NULL,
    SubjectId INT FOREIGN KEY REFERENCES Subjects (Id) NOT NULL,
    Grade DECIMAL(15, 2) CHECK (Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams
(
    Id INT PRIMARY KEY IDENTITY,
    Date DATETIME,
    SubjectId INT FOREIGN KEY REFERENCES Subjects (Id) NOT NULL
)

CREATE TABLE StudentsExams
(
    StudentId INT FOREIGN KEY REFERENCES Students (Id) NOT NULL,
    ExamId INT FOREIGN KEY REFERENCES Exams (Id) NOT NULL,
    Grade DECIMAL(15, 2) CHECK (Grade BETWEEN 2 AND 6) NOT NULL,
    CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(20) NOT NULL,
    LastName NVARCHAR(20) NOT NULL,
    Address NVARCHAR(20) NOT NULL,
    Phone CHAR(10),
    SubjectId INT FOREIGN KEY REFERENCES Subjects (Id) NOT NULL
)

CREATE TABLE StudentsTeachers
(
    StudentId INT FOREIGN KEY REFERENCES Students (Id) NOT NULL,
    TeacherId INT FOREIGN KEY REFERENCES Teachers (Id) NOT NULL,
    CONSTRAINT PK_StudentsTeachers PRIMARY KEY (StudentId, TeacherId)
)

--Section 2 --
--02.Insert--

INSERT
  INTO Teachers (FirstName, LastName, Address, Phone, SubjectId)
VALUES ('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
       ('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
       ('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
       ('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT
  INTO Subjects (Name, Lessons)
VALUES ('Geometry', 12),
       ('Health', 10),
       ('Drama', 7),
       ('Sports', 9)


--03.Update--

UPDATE StudentsSubjects
   SET Grade = 6.00
 WHERE SubjectId IN (1, 2) AND
       Grade >= 5.50


--04.Delete--
DELETE
  FROM StudentsTeachers
 WHERE TeacherId IN (SELECT Id
                       FROM Teachers
                      WHERE Phone LIKE '%72%')

DELETE
  FROM Teachers
 WHERE Phone LIKE '%72%'


--Section 3 - Querying--

--05.Teen Students--

SELECT FirstName, LastName, Age
  FROM Students
 WHERE Age >= 12
 ORDER BY FirstName,
          LastName


--06.Students Teachers--

SELECT s.FirstName, s.LastName, COUNT(t.id)
  FROM Students AS s
           JOIN StudentsTeachers AS st ON s.Id = st.StudentId
           JOIN Teachers AS t ON st.TeacherId = t.Id
 GROUP BY s.FirstName,
          s.LastName


--07.Students to Go--

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
  FROM Students AS s
           LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
 WHERE Grade IS NULL
 ORDER BY [Full Name]


--08.Top Students--

SELECT
   TOP (10)
FirstName
     ,
LastName
     ,
CONVERT(DECIMAL(3, 2), AVG(Grade)) AS Grade
  FROM Students AS s
           JOIN StudentsExams AS se ON s.Id = se.StudentId
 GROUP BY FirstName,
          LastName
 ORDER BY Grade DESC,
          s.FirstName,
          s.LastName


--09.Not so in the studying--

SELECT CONCAT(FirstName, ' ' + MiddleName, ' ', LastName) AS [FullName]
  FROM Students AS s
           LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
 WHERE ss.SubjectId IS NULL
 ORDER BY FullName


--10.Average Grade Per Subject--

SELECT Name, AVG(Grade) AS [AverageGrade]
  FROM Subjects AS s
           JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
 GROUP BY s.Name,
          s.Id
 ORDER BY s.Id


--11.Exam Grades--

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT , @grade DECIMAL(15,2))
RETURNS VARCHAR(100)
AS
BEGIN
            DECLARE @studentExist INT = (SELECT TOP(1) Id FROM Students WHERE Id = @studentId)

            IF (@studentExist IS NULL)
                BEGIN
                    RETURN 'The student with provided id does not exist in the school!'
                END

            IF (@grade > 6 )
                BEGIN
                    RETURN 'Grade cannot be above 6.00!'
                END

            DECLARE @countGrades INT = (SELECT COUNT(Grade) FROM StudentsExams
                                            WHERE StudentId = @studentId
                                                AND Grade BETWEEN @grade AND @grade + 0.5)

            DECLARE @studentName NVARCHAR(30) = (SELECT TOP(1) FirstName FROM Students AS s WHERE Id = @studentId)

            RETURN 'You have to update ' +  CAST(@countGrades AS VARCHAR(30)) + ' grades for the student ' + @studentName

END

EXEC udf_ExamGradesToUpdate 12, 6.20