-- Part 1

GO

USE [Gringotts]

GO

-- Problem 01
SELECT
	COUNT([Id]) AS [Count]
FROM [WizzardDeposits]

-- Problem 02
SELECT
	MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits]


-- Problem 03
SELECT
	[DepositGroup],
	MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]

-- Problem 04
SELECT TOP (2)
	[DepositGroup]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize])

-- Problem 05
SELECT 
	[DepositGroup],
	SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]

-- Problem 06
SELECT 
	[DepositGroup],
	SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

-- Problem 07
SELECT 
	[DepositGroup],
	SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

-- Problem 08
SELECT
	[DepositGroup],
	[MagicWandCreator],
	MIN([DepositCharge]) AS [MinDepositCharge]
FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator],
		 [DepositGroup]

-- Problem 09
SELECT
	[AgeGroup],
	COUNT(*) AS [WizardCount]
FROM (
	SELECT
	CASE
		WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN [Age] > 60 THEN '[61+]'
		ELSE NULL
	END AS [AgeGroup]
	FROM [WizzardDeposits]
) AS [AgeGroups]
GROUP BY [AgeGroup]

-- Problem 10
SELECT DISTINCT
	LEFT([FirstName], 1) AS [FirstLetter]
FROM [WizzardDeposits]
WHERE [DepositGroup] = 'Troll Chest'
ORDER BY [FirstLetter]

SELECT
	LEFT([FirstName], 1) AS [FirstLetter]
FROM [WizzardDeposits]
WHERE [DepositGroup] = 'Troll Chest'
GROUP BY LEFT([FirstName], 1)
ORDER BY [FirstLetter]

-- Problem 11
SELECT
	[DepositGroup],
	[IsDepositExpired],
	AVG([DepositInterest]) AS [AverageInterest]
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '01-01-1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC,
		 [IsDepositExpired]

-- Problem 12

-- Solution 1
SELECT
	SUM([Host Wizard Deposit] - [Guest Wizard Deposit])
FROM (
	SELECT
		[a].[FirstName] AS [Host Wizard],
		[a].[DepositAmount] AS [Host Wizard Deposit],
		[b].[FirstName] AS [Guest Wizard],
		[b].[DepositAmount] AS [Guest Wizard Deposit]
	FROM [WizzardDeposits] AS [a]
	JOIN [WizzardDeposits] AS [b] ON [b].[Id] = [a].[Id] + 1
) AS [WizardDepositsTempTable]

-- Solution 2
SELECT
	SUM([Host Wizard Amount] - [Guest Wizard Amount])
FROM (
	SELECT
		[FirstName]  AS [Host Wizard],
		[DepositAmount] AS [Host Wizard Amount],
		LEAD([FirstName]) OVER (ORDER BY [Id]) AS [Guest Wizard],
		LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Guest Wizard Amount]
	FROM [WizzardDeposits]
) AS [WizzardsTempTable]

-- Part 2

GO

USE [SoftUni]

GO

-- Problem 13
SELECT
	[DepartmentID],
	SUM([Salary]) AS [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

-- Problem 14
SELECT
	[DepartmentID],
	MIN([Salary]) AS [MinimumSalary]
FROM [Employees]
WHERE [DepartmentID] IN (2, 5, 7)
	  AND [HireDate] > '01-01-2000'
GROUP BY [DepartmentID]

-- Problem 15
SELECT *
INTO [#EmployeesHigherSalaryThan30000]
FROM [Employees]
WHERE [Salary] > 30000

DELETE
FROM [#EmployeesHigherSalaryThan30000]
WHERE [ManagerID] = 42

UPDATE [#EmployeesHigherSalaryThan30000]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT
	[DepartmentID],
	AVG([Salary]) AS [AverageSalary]
FROM [#EmployeesHigherSalaryThan30000]
GROUP BY [DepartmentID]

-- Problem 16
SELECT
	[DepartmentID],
	MAX([Salary]) AS [MaxSalary]
FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

-- Problem 17
SELECT
	COUNT(*) AS [Count]
FROM [Employees]
WHERE [ManagerID] IS NULL

-- Problem 18
SELECT DISTINCT
	[DepartmentID],
	[Salary] AS [ThirdHighestSalary]
FROM (
	SELECT
		[DepartmentID],
		[Salary],
		DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Rank]
	FROM [Employees]
) AS [RankedSalariesByDepartment]
WHERE [Rank] = 3

-- Problem 19
SELECT TOP (10)
	[e].[FirstName],
	[e].[LastName],
	[e].[DepartmentID]
FROM [Employees] AS [e]
WHERE [e].[Salary] > (
	SELECT
		AVG([Salary]) AS [AverageSalary]
	FROM [Employees]
	WHERE [DepartmentID] = [e].[DepartmentID]
	GROUP BY [DepartmentID]
)
ORDER BY [e].[DepartmentID]