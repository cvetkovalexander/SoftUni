USE [SoftUni]

-- Problem 02
SELECT * FROM [Departments]

-- Problem 03
SELECT [Name] FROM [Departments]

-- Problem 04
SELECT [FirstName], [LastName], [Salary] FROM [Employees]

-- Problem 05
SELECT [FirstName], [MiddleName], [LastName] FROM [Employees]

-- Problem 06
SELECT 
	[FirstName] + '.' + [LastName] + '@softuni.bg' AS 'Full Email Address'
FROM [Employees]

-- Problem 07
SELECT DISTINCT [Salary] FROM [Employees]

-- Problem 08
SELECT *
FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'

-- Problem 09
SELECT
	[FirstName],
	[LastName],
	[JobTitle]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000

-- Problem 10
SELECT
	CONCAT_WS(' ', [FirstName], [MiddleName], [LastName])
	AS 'Full Name'
FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600)

-- Problem 11
SELECT
	[FirstName],
	[LastName]
FROM [Employees]
WHERE [ManagerId] IS NULL

-- Problem 12
SELECT
	[FirstName],
	[LastName],
	[Salary]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC

-- Problem 13
SELECT TOP 5
	[FirstName],
	[LastName]
FROM [Employees]
ORDER BY [Salary] DESC

-- Problem 14
SELECT
	[FirstName],
	[LastName]
FROM [Employees]
WHERE [DepartmentID] != 4

-- Problem 15
SELECT *
FROM [Employees]
ORDER BY [Salary] DESC,
[FirstName],
[LastName] DESC,
[MiddleName]

-- Problem 16
CREATE VIEW [V_EmployeesSalaries] AS 
SELECT
	[FirstName],
	[LastName],
	[Salary]
FROM [Employees]

SELECT * FROM V_EmployeesSalaries

-- Problem 17
CREATE VIEW [V_EmployeeNameJobTitle] AS
SELECT
	CONCAT([FirstName], ' ', ISNULL([MiddleName], ''), ' ', [LastName])
	AS 'Full Name',
	[JobTitle] AS 'Job Title'
FROM [Employees]

SELECT * FROM [V_EmployeeNameJobTitle]

-- Problem 18
SELECT DISTINCT [JobTitle] FROM [Employees]

-- Problem 19
SELECT TOP 10 *
FROM [Projects]
ORDER BY [StartDate], [Name]

-- Problem 20
SELECT TOP 7
	[FirstName],
	[LastName],
	[HireDate]
FROM [Employees]
ORDER BY [HireDate] DESC

-- Problem 21
UPDATE [Employees]
SET [Salary] *= 1.12
WHERE [DepartmentID] IN (
		SELECT [DepartmentId]
		FROM [Departments]
		WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
	)

SELECT [Salary] FROM [Employees]

GO

UPDATE [Employees]
SET [Salary] /= 1.12
WHERE [DepartmentID] IN (1, 2, 4, 11)

USE [Geography]

--Problem 22
SELECT
	[PeakName]
FROM [Peaks]
ORDER BY [PeakName]

-- Problem 23

SELECT *
FROM [Continents]

SELECT TOP 30
	[CountryName],
	[Population]
FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC

-- Problem 24
SELECT 
	[CountryName],
	[CountryCode],
	CASE
		WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS 'Currency'
FROM [Countries]
ORDER BY [CountryName]

-- Probem 25
USE [Diablo]

SELECT [Name]
FROM [Characters]
ORDER BY [Name]