-- Part 1

GO

USE [SoftUni]

GO

-- Problem 01
CREATE OR ALTER PROC [usp_GetEmployeesSalaryAbove35000]
AS
BEGIN
	SELECT
		[FirstName] AS [First Name],
		[LastName] AS [Last Name]
	FROM [Employees]
	WHERE [Salary] > 35000
END

EXEC [usp_GetEmployeesSalaryAbove35000]

-- Problem 02
CREATE OR ALTER PROC [usp_GetEmployeesSalaryAboveNumber]
	(@n DECIMAL(18, 4))
AS
BEGIN
	SELECT
		[FirstName] AS [First Name],
		[LastName] AS [Last Name]
	FROM [Employees]
	WHERE [Salary] >= @n
END

EXEC [usp_GetEmployeesSalaryAboveNumber] 48100

-- Problem 03
CREATE OR ALTER PROC [usp_GetTownsStartingWIth]
	(@n VARCHAR(20))
AS
BEGIN
	SELECT
		[Name] AS [Town]
	FROM [Towns]
	WHERE CHARINDEX(@n, [Name]) = 1
END

EXEC [usp_GetTownsStartingWIth] 'b'

-- Problem 04
CREATE OR ALTER PROC [usp_GetEmployeesFromTown]
	(@n VARCHAR(50))
AS
BEGIN
	SELECT
		[FirstName] AS [First Name],
		[LastName] AS [Last Name]
	FROM [Employees] AS [e]
	JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
	JOIN [Towns] AS [t] ON [a].[TownID] = [t].[TownID]
	WHERE [t].[Name] = @n
END

EXEC [usp_GetEmployeesFromTown] 'Sofia'

-- Problem 05
CREATE OR ALTER FUNCTION [ufn_GetSalaryLevel]
	(@salary DECIMAL(18, 4))
RETURNS VARCHAR(20)
AS
BEGIN
	DECLARE @result VARCHAR(20)
	IF (@salary > 50000)
		BEGIN
			SET @result = 'High'
		END
	ELSE IF (@salary >= 30000)
		BEGIN
			SET @result =  'Average'
		END
	ELSE
		BEGIN
			SET @result = 'Low'
		END
	RETURN @result
END

SELECT dbo.ufn_GetSalaryLevel(30000)

-- Problem 06
CREATE OR ALTER PROC [usp_EmployeesBySalaryLevel]
	(@level VARCHAR(10))
AS
BEGIN
	SELECT
		[FirstName] AS [First Name],
		[LastName] AS [Last Name]
	FROM [Employees]
	WHERE dbo.ufn_GetSalaryLevel([Salary]) = @level
END

EXEC [usp_EmployeesBySalaryLevel] 'high'

-- Problem 07

CREATE OR ALTER FUNCTION [ufn_IsWordComprised]
	(@set VARCHAR(30), @word VARCHAR(50))
RETURNS BIT
AS
	BEGIN
		DECLARE @index TINYINT = 1

		WHILE @index <= LEN(@word)
			BEGIN
				DECLARE @char CHAR(1) = SUBSTRING(@word, @index, 1)
				DECLARE @charPos INT = CHARINDEX(@char, @set)

				IF @charPos = 0
					BEGIN
						RETURN 0
					END

				SET @index += 1
			END
		RETURN 1
	END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')

-- Problem 08
CREATE OR ALTER PROC [usp_DeleteEmployeesFromDepartment]
	(@id INT)
AS
	BEGIN
		
		DELETE
		FROM [EmployeesProjects]
		WHERE [EmployeeID] IN (
							SELECT [EmployeeID]
							FROM [Employees]
							WHERE [DepartmentID] = @id
						)

		UPDATE [Employees]
		SET [ManagerID] = NULL
		WHERE [ManagerID] IN (
							SELECT [EmployeeID]
							FROM [Employees]
							WHERE [DepartmentID] = @id
						)

		ALTER TABLE [Departments]
		ALTER COLUMN [ManagerID] INT

		UPDATE [Departments]
		SET [ManagerID] = NULL
		WHERE [ManagerID] IN (
							SELECT [EmployeeID]
							FROM [Employees]
							WHERE [DepartmentID] = @id
						)

		DELETE
		FROM [Employees]
		WHERE [DepartmentID] = @id

		DELETE
		FROM [Departments]
		WHERE [DepartmentID] = @id

		SELECT
			COUNT(*)
		FROM [Employees]
		WHERE [DepartmentID] = @id

	END

EXEC [dbo].[usp_DeleteEmployeesFromDepartment] 1

-- Part 2

GO

USE [Bank]

GO

-- Problem 9
CREATE
OR
ALTER PROC [dbo].[usp_GetHoldersFullName]
AS
	BEGIN
	
		SELECT
			CONCAT_WS(' ', [FirstName], [LastName]) AS [Full Name]
		FROM [AccountHolders]

	END

EXEC [dbo].[usp_GetHoldersFullName]

-- Problem 10
CREATE
OR
ALTER PROC [dbo].[usp_GetHoldersWithBalanceHigherThan]
	(@n MONEY)
AS
	BEGIN
		
		SELECT
			[FirstName] AS [First Name],
			[LastName] AS [Last Name]
		FROM [AccountHolders]
		WHERE [Id] IN (
			SELECT
			[AccountHolderId]
			FROM [Accounts]
			GROUP BY [AccountHolderId]
			HAVING SUM([Balance]) > @n
		)
		ORDER BY [FirstName],
				 [LastName]

	END

-- Problem 11
CREATE
OR
ALTER FUNCTION [dbo].[ufn_CalculateFutureValue]
	(@sum DECIMAL(18, 4), @rate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
	BEGIN
		
		DECLARE @result DECIMAL(18, 4) = POWER(@rate + 1, @years) * @sum

		RETURN ROUND(@result, 4)	
			
	END

SELECT [dbo].[ufn_CalculateFutureValue](1000, 0.1, 5)

-- Problem 12
CREATE
OR
ALTER PROC [dbo].[usp_CalculateFutureValueForAccount]
	(@accountID INT, @rate FLOAT)
AS
	BEGIN
		SELECT TOP (1)
			[ah].[Id] AS [Account Id],
			[ah].[FirstName] AS [First Name],
			[ah].[LastName] AS [Last Name],
			[a].[Balance] AS [Current Balance],
			[dbo].[ufn_CalculateFutureValue]([a].[Balance], @rate, 5) AS [Balance in 5 years]
		FROM [AccountHolders] AS [ah]
		JOIN [Accounts] AS [a] ON [ah].[Id] = [a].[AccountHolderId]
		WHERE [ah].[Id] = @accountID
	END

EXEC [dbo].[usp_CalculateFutureValueForAccount] 1, 0.1

-- Part 3

GO

USE [Diablo]

GO

-- Problem 13
CREATE
OR
ALTER FUNCTION [dbo].[ufn_CashInUsersGames]
	(@game NVARCHAR(50))
RETURNS TABLE
AS	
		RETURN (
			SELECT
				SUM([Cash]) AS [SumCash]
			FROM (
				SELECT
					[Cash],
					ROW_NUMBER() OVER(ORDER BY [Cash] DESC) AS [Row]
				FROM [UsersGames] AS [us]
				JOIN [Games] AS [g] ON [us].[GameId] = [g].[Id]
				WHERE [g].[Name] = @game
			) AS [rankedCashTable]
			WHERE [Row] % 2 <> 0
		)

SELECT * FROM [dbo].[ufn_CashInUsersGames]('Love in a mist')