-- Part 1

GO

USE [SoftUni]

GO

-- Problem 01

SELECT TOP 5
	e.[EmployeeID] AS 'EmployeeId',
	e.[JobTitle],
	a.[AddressID] AS 'AddressId',
	a.[AddressText]
FROM [Employees] AS e JOIN [Addresses] AS a ON e.AddressID = a.AddressID
ORDER BY a.[AddressID]

-- Problem 02

SELECT TOP 50
	e.[FirstName],
	e.[LastName],
	t.[Name] AS 'Town',
	a.[AddressText]
FROM [Employees] AS e 
JOIN [Addresses] AS a ON e.[AddressID] = a.AddressID
JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
ORDER BY e.[FirstName],
		 e.[LastName]

-- Problem 03
SELECT
	[e].[EmployeeID],
	[e].[FirstName],
	[e].[LastName],
	[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e] JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [d].[Name] = 'Sales'
ORDER BY [e].[EmployeeID]

-- Problem 04
SELECT TOP 5
	[e].[EmployeeID],
	[e].[FirstName],
	[e].[Salary],
	[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e] JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [e].[Salary] > 15000
ORDER BY [d].[DepartmentID]

-- Problem 05

SELECT TOP 3
	[e].[EmployeeID],
	[e].[FirstName]
FROM [Employees] AS [e]
LEFT JOIN [EmployeesProjects] AS [ep] ON [e].[EmployeeID] = [ep].[EmployeeID]
WHERE [ep].[ProjectID] IS NULL
ORDER BY e.[EmployeeID]

-- Problem 06
SELECT 
	[e].[FirstName],
	[e].[LastName],
	[e].[HireDate],
	[d].[Name] AS [DeptName]
FROM [Employees] AS [e]
JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [e].[HireDate] > '1.1.1999'
	  AND [d].[Name] IN ('Sales', 'Finance')
ORDER BY [e].[HireDate]

-- Problem 07
SELECT TOP (5)
	[e].[EmployeeID],
	[e].[FirstName],
	[p].[Name] AS [ProjectName]
FROM [EmployeesProjects] AS [ep]
JOIN [Employees] AS [e] ON [ep].[EmployeeID] = [e].[EmployeeID]
JOIN [Projects] AS [p] ON [ep].[ProjectID] = [p].[ProjectID]
WHERE [p].[StartDate] > '08.13.2002' 
	  AND [p].[EndDate] IS NULL
ORDER BY [e].[EmployeeID]

-- Problem 08
SELECT 
	[e].[EmployeeID],
	[e].[FirstName],
	CASE
		WHEN YEAR([p].[StartDate]) >= 2005 THEN NULL
		ELSE [p].[Name]
	END AS [ProjectName]
FROM [EmployeesProjects] AS [ep]
JOIN [Employees] AS [e] ON [ep].[EmployeeID] = [e].[EmployeeID]
JOIN [Projects] AS [p] ON [ep].[ProjectID] = [p].[ProjectID]
WHERE [e].[EmployeeID] = 24

-- Problem 09
SELECT
	[e].[EmployeeID],
	[e].[FirstName],
	[e].[ManagerID],
	[es].[FirstName]
FROM [Employees] AS [e]
JOIN [Employees] AS [es] ON [e].[ManagerID] = [es].[EmployeeID]
WHERE [es].[EmployeeID] IN (3, 7)
ORDER BY [e].[EmployeeID]

-- Problem 10
SELECT TOP (50)
	[e].[EmployeeID],
	CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [EmployeeName],
	CONCAT([em].[FirstName], ' ', [em].[LastName]) AS [ManagerName],
	[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
JOIN [Employees] AS [em] ON [e].[ManagerID] = [em].[EmployeeID]
JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
ORDER BY [e].[EmployeeID]

-- Problem 11
WITH [AvgSalaryByDepartment] (AvgSalary)
AS (
	SELECT
		AVG([Salary])
	FROM [Employees]
	GROUP BY [DepartmentID]
)

SELECT
	MIN([AvgSalary]) AS [MinAverageSalary]
FROM [AvgSalaryByDepartment]

-- Part 2
GO

USE [Geography]

GO

-- Problem 12
SELECT
	[mc].[CountryCode],
	[m].[MountainRange],
	[p].[PeakName],
	[p].[Elevation]
FROM [MountainsCountries] AS [mc]
JOIN [Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
JOIN [Peaks] AS [p] ON [m].[Id] = [p].[MountainId]
WHERE [mc].[CountryCode] = 'BG'
	  AND [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC

-- Problem 13
SELECT
	[mc].[CountryCode],
	COUNT(m.[MountainRange]) AS [MountainRanges]
FROM [MountainsCountries] AS [mc]
JOIN [Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
WHERE [mc].[CountryCode] IN ('US', 'RU', 'BG')
GROUP BY [mc].[CountryCode]

-- Problem 14
/*SELECT
	[c].[CountryName],
	CASE
		WHEN [r].[RiverName] IS NULL THEN 'NULL'
		ELSE [r].[RiverName]
	END AS [RiverName]							WRONG!!!!!
FROM [CountriesRivers] AS [cr]
LEFT JOIN [Countries] AS [c] ON [cr].[CountryCode] = [c].[CountryCode]
LEFT JOIN [Rivers] AS [r] ON [cr].[RiverId] = [r].[Id]
WHERE [c].[ContinentCode] = 'AF'
ORDER BY [c].[CountryName] */

SELECT TOP (5)
	[c].[CountryName],
	[r].[RiverName]
FROM [Countries] AS [c]
LEFT JOIN [CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
LEFT JOIN [Rivers] AS [r] ON [r].[Id] = [cr].[RiverId]
WHERE [c].[ContinentCode] = 'AF'
ORDER BY [c].[CountryName]

-- Problem 15

SELECT
	[ContinentCode],
	[CurrencyCode],
	[CurrencyUsage]
FROM (
	SELECT *,
		DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC)
		AS [CurrencyRank]
	FROM (
		SELECT
			[ContinentCode],
			[CurrencyCode],
			COUNT([CountryCode]) AS [CurrencyUsage]
			FROM [Countries]
			WHERE [CurrencyCode] IS NOT NULL
			GROUP BY [ContinentCode], [CurrencyCode]
			HAVING COUNT([CountryCode]) > 1
	) AS [CurrencyUsageTempTable]
) AS [CurrencyRankTable]
WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]



-- Problem 16
SELECT 
	COUNT([c].[CountryCode]) AS [Count]
FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc] ON [c].[CountryCode] = [mc].[CountryCode]
WHERE [MountainId] IS NULL

-- Problem 17
SELECT
	[c].[CountryName],
	MAX([p].[Elevation]) AS [HighestPeakElevation]
FROM [Peaks] AS [p]
JOIN [Mountains] AS [m] ON [p].[MountainId] = [m].[Id]
JOIN [MountainsCountries] AS [mc] ON [m].[Id] = [mc].[MountainId]
JOIN [Countries] AS [c] ON [mc].[CountryCode] = [c].[CountryCode]
GROUP BY [c].[CountryName]
ORDER BY [HighestPeakElevation] DESC

SELECT
	[c].[CountryName],
	MAX([r].[Length]) AS [LongestRiverLength]
FROM [Rivers] AS [r]
JOIN [CountriesRivers] AS [cr] ON [r].[Id] = [cr].[RiverId]
JOIN [Countries] AS [c] ON [cr].[CountryCode] = [c].[CountryCode]
GROUP BY [c].[CountryName]
ORDER BY [LongestRiverLength] DESC

SELECT TOP (5)
	[c].[CountryName],
	[hpe].[HighestPeakElevation],
	[lrl].[LongestRiverLength]
FROM [Countries] AS [c]
LEFT JOIN (
	SELECT
		[c].[CountryName],
		MAX([p].[Elevation]) AS [HighestPeakElevation]
	FROM [Peaks] AS [p]
	JOIN [Mountains] AS [m] ON [p].[MountainId] = [m].[Id]
	JOIN [MountainsCountries] AS [mc] ON [m].[Id] = [mc].[MountainId]
	JOIN [Countries] AS [c] ON [mc].[CountryCode] = [c].[CountryCode]
	GROUP BY [c].[CountryName]
) AS [hpe] ON [c].[CountryName] = [hpe].[CountryName]
LEFT JOIN (
	SELECT
		[c].[CountryName],
		MAX([r].[Length]) AS [LongestRiverLength]
	FROM [Rivers] AS [r]
	JOIN [CountriesRivers] AS [cr] ON [r].[Id] = [cr].[RiverId]
	JOIN [Countries] AS [c] ON [cr].[CountryCode] = [c].[CountryCode]
	GROUP BY [c].[CountryName]
) AS [lrl] ON [c].[CountryName] = [lrl].[CountryName]
ORDER BY [hpe].[HighestPeakElevation] DESC,
		 [lrl].[LongestRiverLength] DESC,
		 [c].[CountryName]

-- Problem 18
SELECT
	[c].[CountryName],
	MAX([p].[Elevation])
FROM [Peaks] AS [p]
JOIN [Mountains] AS [m] ON [p].[MountainId] = [m].[Id]
JOIN [MountainsCountries] AS [mc] ON [m].[Id] = [mc].[MountainId]
JOIN [Countries] AS [c] ON [mc].[CountryCode] = [c].[CountryCode]
GROUP BY [c].[CountryName]

SELECT TOP (5)
	[c].[CountryName],
	CASE
		WHEN [p].[PeakName] IS NULL THEN '(no highest peak)'
		ELSE [p].[PeakName]
	END AS [Highest Peak Name],
	CASE
		WHEN [hpe].[HighestPeakElevation] IS NULL THEN 0
		ELSE [hpe].[HighestPeakElevation]
	END AS [Highest Peak Elevation],
	CASE
		WHEN [m].[MountainRange] IS NULL THEN '(no mountain)'
		ELSE [m].[MountainRange]
	END AS [Mountain]
FROM [Countries] AS [c]
LEFT JOIN (
	SELECT
		[c].[CountryCode],
		MAX([p].[Elevation]) AS [HighestPeakElevation]
	FROM [Peaks] AS [p]
	JOIN [Mountains] AS [m] ON [p].[MountainId] = [m].[Id]
	JOIN [MountainsCountries] AS [mc] ON [m].[Id] = [mc].[MountainId]
	JOIN [Countries] AS [c] ON [mc].[CountryCode] = [c].[CountryCode]
	GROUP BY [c].[CountryCode]
) AS [hpe] ON [c].[CountryCode] = [hpe].[CountryCode]
LEFT JOIN [MountainsCountries] AS [mc] ON [c].[CountryCode] = [mc].[CountryCode]
LEFT JOIN [Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
LEFT JOIN [Peaks] AS [p] ON [hpe].[HighestPeakElevation] = [p].[Elevation]
						 AND [p].[MountainId] = [m].[Id]
ORDER BY [c].[CountryName], ISNULL([p].[PeakName], '(no highest peak)')