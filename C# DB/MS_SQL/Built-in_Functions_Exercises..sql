-- Part 1
GO

USE [SoftUni]

GO

-- Problem 01
SELECT
	[FirstName],
	[LastName]
FROM [Employees]
--WHERE [FirstName] LIKE 'Sa%'
WHERE LEFT([FirstName], 2) = 'Sa'

-- Problem 02
SELECT
	[FirstName],
	[LastName]
FROM [Employees]
--WHERE [LastName] LIKE '%ei%'
WHERE CHARINDEX('ei', [LastName]) > 0

-- Problem 03
SELECT
	[FirstName]
FROM [Employees]
WHERE [DepartmentID] IN (3, 10)
AND YEAR([HireDate]) BETWEEN 1995 AND 2005

-- Problem 04
SELECT 
	[FirstName],
	[LastName]
FROM [Employees]
--WHERE CHARINDEX('engineer', [JobTitle]) = 0
WHERE [JobTitle] NOT LIKE '%engineer%'

-- Problem 05
SELECT 
	[Name]
FROM [Towns]
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

-- Problem 06
SELECT
	[TownID],
	[Name]
FROM [Towns]
--WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

-- Problem 07
SELECT
	[TownID],
	[Name]
FROM [Towns]
--WHERE [Name] NOT LIKE '[RBD]%'
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

-- Problem 08
CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT
	[FirstName],
	[LastName]
FROM [Employees]
WHERE YEAR([HireDate]) > 2000

SELECT * FROM [V_EmployeesHiredAfter2000]

-- Problem 09
SELECT 
	[FirstName],
	[LastName]
FROM [Employees]
WHERE LEN([LastName]) = 5

-- Problem 10
SELECT
	[EmployeeID],
	[FirstName],
	[LastName],
	[Salary],
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

-- Problem 11
SELECT * FROM (
	SELECT
	[EmployeeID],
	[FirstName],
	[LastName],
	[Salary],
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
) AS [Ranked]
WHERE [Rank] = 2
ORDER BY [Salary] DESC

-- Part 2
GO

USE [Geography]

GO

-- Problem 12
SELECT
	[CountryName] AS 'Country Name',
	[IsoCode] AS 'ISO Code'
FROM [Countries]
WHERE LEN(LOWER([CountryName])) - LEN(REPLACE([CountryName], 'a', '')) >= 3
ORDER BY [IsoCode]

-- Problem 13
/*SELECT 
	p.PeakName,
	r.RiverName,
	CONCAT(LOWER(LEFT(p.PeakName, LEN(p.PeakName) - 1)), LOWER(r.RiverName))AS 'Mix'
FROM [Peaks] AS p JOIN [Rivers] AS r ON RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY [Mix] */

SELECT 
	p.PeakName,
	r.RiverName
FROM [Peaks] AS [p],
	 [Rivers] AS [r]
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)

-- Part 3
GO

USE [Diablo]

GO

-- Problem 14
SELECT TOP 50
	[Name],
	--CONVERT(DATE, [Start]) AS 'Start' | WRONG
	--CAST([Start] AS DATE) AS 'Start'	| WRONG
	FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM [Games]
--WHERE YEAR([Start]) BETWEEN 2011 AND 2012 | SLOW
WHERE [Start] >= '2011-01-01'
AND [Start] <= '2013-01-01'
ORDER BY [Start],
		 [Name]

-- Problem 15
SELECT 
	[Username],
	--SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])) AS 'Email Provider' | Specific case - if there is only one '@' in the email address!
	RIGHT([Email], CHARINDEX('@', REVERSE(Email)) - 1) AS [Email Provider] -- Correct for every case
FROM [Users]
ORDER BY [Email Provider],
		 [Username]

-- Problem 16
SELECT
	[Username],
	[IpAddress] AS 'IP Address'
FROM [Users]
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

-- Problem 17
SELECT
	[Name] AS 'Game',
	CASE
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		ELSE 'Evening'
	END AS 'Part of the Day',
	CASE
		WHEN [Duration] BETWEEN 0 AND 3 THEN 'Extra Short'
		WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS 'Duration'
FROM [Games]
ORDER BY [Name],
		 [Duration],
		 [Part of the Day]

-- Part 4

-- Problem 18
CREATE DATABASE [ExercisesAndTests]

GO

USE [ExercisesAndTests]

GO

CREATE TABLE [Orders] (
	[Id] INT PRIMARY KEY IDENTITY,
	[ProductName] VARCHAR(80) NOT NULL,
	[OrderDate] DATETIME NOT NULL
)

INSERT INTO Orders
VALUES
('Butter',   '2016-09-19 00:00:00.000'),
('Milk',     '2016-09-30 00:00:00.000'),
('Cheese',   '2016-09-04 00:00:00.000'),
('Bread',    '2015-12-20 00:00:00.000'),
('Tomatoes', '2015-01-01 00:00:00.000')

SELECT
	[ProductName],
	[OrderDate],
	DATEADD(DAY, 3, [OrderDate]) AS 'Pay Due',
	DATEADD(MONTH, 1, [OrderDate]) AS 'Deliver Due'
FROM [Orders]

-- Problem 19
CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(80) NOT NULL,
	[Birthdate] DATETIME NOT NULL
)

INSERT INTO [People]
VALUES
('Victor',  '2000-12-07 00:00:00.000'),
('Steven',  '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John',    '2010-01-06 00:00:00.000')

WITH Person AS (
	SELECT
		[Name],
		YEAR(GETDATE()) - YEAR([Birthdate]) AS Age
	FROM [People]
)
SELECT 
	[Name],
	[Age],
	[Age] * 12 AS 'Age in Months',
	[Age] * 365 AS 'Age in Days',
	[Age] * 365 * 24 * 60 AS 'Age in Minutes'
FROM [Person]