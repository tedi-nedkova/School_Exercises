CREATE DATABASE LibraryDB_20

CREATE TABLE Libraries (
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[Name] NVARCHAR(255) NOT NULL
)

CREATE TABLE Books (
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[Title] NVARCHAR(200) NOT NULL,
[LibraryId] INT FOREIGN KEY REFERENCES Libraries(Id) ON DELETE SET DEFAULT
)

CREATE TABLE Readers (
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[Name] NVARCHAR(200) NOT NULL
)

CREATE TABLE Loans (
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[LoanDate] DATE NOT NULL,
[ReaderId] INT FOREIGN KEY REFERENCES Readers(Id) ON DELETE CASCADE,
[BookId] INT FOREIGN KEY REFERENCES Books(Id) ON DELETE SET NULL
)

INSERT INTO Readers (Name) VALUES
(N'Петър Петров'),
(N'Мария Иванова'),
(N'Георги Димитров'),
(N'Елена Стоянова')

INSERT INTO Libraries (Name) VALUES
(N'Централна библиотека'),
(N'Градска библиотека'),
(N'Университетска библиотека')

INSERT INTO Books (Title, LibraryId) VALUES
(N'1984', 1),
(N'Престъпление и наказание', 2),
(N'Хари Потър', 3),
(N'Граф Монте Кристо', 1)

INSERT INTO Loans (ReaderId, BookId, LoanDate) VALUES
(1, 1, '2023-05-10'),
(2, 2, '2023-06-15'),
(3, 3, '2023-07-20'),
(4, 4, '2023-08-25')

--1--
DELETE 
FROM Readers 
WHERE Id = 1;

--2--
DELETE 
FROM Books 
WHERE Title = N'Престъпление и наказание';

--3--
INSERT INTO Books (Title, LibraryId)
VALUES
(N'Война и мир', (SELECT TOP 1 Id FROM Libraries WHERE [Name] = N'Университетска библиотека'))

--4--
DELETE 
FROM Libraries 
WHERE Id = 3;