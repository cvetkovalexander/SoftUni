-- Section 1.DDL
-- Task 01

CREATE DATABASE [EuroLeagues]

GO

USE [EuroLeagues]

CREATE TABLE Leagues (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Teams (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
	City NVARCHAR(50) NOT NULL,
	LeagueId INT FOREIGN KEY REFERENCES Leagues(Id) NOT NULL
)

CREATE TABLE Players (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Position NVARCHAR(20) NOT NULL
)

CREATE TABLE Matches (
	Id INT PRIMARY KEY IDENTITY,
	HomeTeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
	AwayTeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
	MatchDate DATETIME2 NOT NULL,
	HomeTeamGoals INT DEFAULT 0 NOT NULL,
	AwayTeamGoals INT DEFAULT 0 NOT NULL,
	LeagueId INT FOREIGN KEY REFERENCES Leagues(Id) NOT NULL
)

CREATE TABLE PlayersTeams (
	PlayerId INT FOREIGN KEY REFERENCES Players(Id) NOT NULL,
	TeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
	PRIMARY KEY(PlayerId, TeamId)
)

CREATE TABLE PlayerStats (
	PlayerId INT PRIMARY KEY FOREIGN KEY REFERENCES Players(Id) NOT NULL,
	Goals INT DEFAULT 0 NOT NULL,
	Assists INT DEFAULT 0 NOT NULL
)

CREATE TABLE TeamStats (
	TeamId INT PRIMARY KEY FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
	Wins INT DEFAULT 0 NOT NULL,
	Draws INT DEFAULT 0 NOT NULL,
	Losses INT DEFAULT 0 NOT NULL
)

-- Only the statements above are needed for judge

ALTER TABLE PlayerStats
DROP CONSTRAINT FK__PlayerSta__Playe__48CFD27E

ALTER TABLE PlayerStats
ADD CONSTRAINT PK_PlayerStats PRIMARY KEY (PlayerId)

ALTER TABLE PlayerStats
ADD CONSTRAINT FK_PlayerStats_Players
FOREIGN KEY (PlayerId) REFERENCES Players(Id)

-- Section 2.DML
-- Task 02

INSERT INTO Leagues ([Name])
VALUES
('Eredivisie')

INSERT INTO Teams([Name], City, LeagueId)
VALUES
('PSV', 'Eindhoven', 6),
('Ajax', 'Amsterdam', 6)

INSERT INTO Players([Name], Position)
VALUES
('Luuk de Jong', 'Forward'),
('Josip Sutalo', 'Defender')

INSERT INTO Matches(HomeTeamId, AwayTeamId, MatchDate, HomeTeamGoals, AwayTeamGoals, LeagueId)
VALUES
(98, 97, '2024-11-02 20:45:00', 3, 2, 6)

INSERT INTO PlayersTeams (PlayerId, TeamId)
VALUES
(2305, 97),
(2306, 98)

INSERT INTO PlayerStats (PlayerId, Goals, Assists)
VALUES
(2305, 2, 0),
(2306, 2, 0)

INSERT INTO TeamStats (TeamId, Wins, Draws, Losses)
VALUES
(97, 15, 1, 3),
(98, 14, 3, 2)

-- Task 03

UPDATE ps
SET Goals += 1
FROM PlayerStats AS ps
JOIN Players AS p ON ps.PlayerId = p.Id
JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
JOIN Teams AS t ON pt.TeamId = t.Id
JOIN Leagues AS l ON t.LeagueId = l.Id
WHERE p.Position = 'Forward'
	  AND l.[Name] = 'La Liga'


-- Task 04
SELECT
	p.Id
FROM Players AS p
JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
JOIN Teams AS t ON pt.TeamId = t.Id
JOIN Leagues AS l ON t.LeagueId = l.Id
WHERE l.[Name] = 'Eredivisie'

DELETE
FROM PlayerStats
WHERE PlayerId IN (
	SELECT
	p.Id
	FROM Players AS p
	JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	JOIN Teams AS t ON pt.TeamId = t.Id
	JOIN Leagues AS l ON t.LeagueId = l.Id
	WHERE l.[Name] = 'Eredivisie'
)

DELETE
FROM PlayersTeams
WHERE PlayerId IN (
	SELECT
		p.Id
	FROM Players AS p
	JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	JOIN Teams AS t ON pt.TeamId = t.Id
	JOIN Leagues AS l ON t.LeagueId = l.Id
	WHERE l.[Name] = 'Eredivisie'
)

DELETE
FROM Players
WHERE Id IN (
	SELECT
		p.Id
	FROM Players AS p
	JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	JOIN Teams AS t ON pt.TeamId = t.Id
	JOIN Leagues AS l ON t.LeagueId = l.Id
	WHERE l.[Name] = 'Eredivisie'
)

-- Section 3.Querying
-- Task 05

SELECT
	FORMAT(MatchDate, 'yyyy-MM-dd') AS [MatchDate],
	HomeTeamGoals,
	AwayTeamGoals,
	(HomeTeamGoals + AwayTeamGoals) AS [TotalGoals]
FROM Matches
WHERE (HomeTeamGoals + AwayTeamGoals) >= 5
ORDER BY TotalGoals DESC,
		 MatchDate

-- Task 06

SELECT
	p.[Name],
	t.City
FROM Players AS p
JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
JOIN Teams AS t ON pt.TeamId = t.Id
WHERE CHARINDEX('Aaron', p.[Name]) <> 0
ORDER BY p.[Name]

-- Task 07
SELECT
	p.Id,
	p.[Name],
	p.Position
FROM Players AS p
JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
JOIN Teams AS t ON pt.TeamId = t.Id
WHERE t.City = 'London'
ORDER BY p.[Name]

-- Task 08

SELECT TOP (10)
	t.[Name] AS HomeTeamName,
	t2.[Name] AS AwayTeamName,
	l.[Name] AS LeagueName,
	FORMAT(MatchDate, 'yyyy-MM-dd') AS MatchDate
FROM Matches AS m 
JOIN Teams AS t ON m.HomeTeamId = t.Id
JOIN Teams AS t2 ON m.AwayTeamId = t2.Id
JOIN Leagues AS l ON m.LeagueId = l.Id
WHERE (MatchDate >= '2024-09-01' AND MatchDate <= '2024-09-15')
	  AND
	  l.Id % 2 = 0
ORDER BY m.MatchDate, HomeTeamName


-- Task 09

SELECT
	t.Id,
	t.[Name],
	SUM(m.AwayTeamGoals) AS TotalAwayGoals
FROM Matches AS m
JOIN Teams AS t ON m.AwayTeamId = t.Id
GROUP BY t.Id, t.[Name]
HAVING SUM(m.AwayTeamGoals) >= 6
ORDER BY TotalAwayGoals DESC,
		 t.[Name]

-- Task 10
SELECT
	l.[Name] AS LeagueName,
	--AVG(CAST(HomeTeamGoals AS FLOAT)) + AVG(CAST(AwayTeamGoals AS FLOAT))
	ROUND(AVG(HomeTeamGoals + CAST(AwayTeamGoals AS FLOAT)), 2) AS AvgScoringRate
FROM Matches AS m
JOIN Leagues AS l ON m.LeagueId = l.Id
GROUP BY l.[Name]
ORDER BY AvgScoringRate DESC

-- Section 4.Programmability
-- Task 11
CREATE
OR
ALTER FUNCTION [dbo].[udf_LeagueTopScorer]
	(@league NVARCHAR(50))
RETURNS TABLE
	AS
		RETURN (
			SELECT
				PlayerName,
				Goals AS TotalGoals
			FROM (
			SELECT
				p.[Name] AS [PlayerName],
				ps.[Goals] AS Goals,
				DENSE_RANK() OVER (PARTITION BY l.[Name] ORDER BY ps.Goals DESC) AS [Rank]
			FROM Players AS p
			JOIN PlayerStats AS ps ON p.Id = ps.PlayerId
			JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
			JOIN Teams AS t ON pt.TeamId = t.Id
			JOIN Leagues AS l ON t.LeagueId = l.Id
			WHERE l.[Name] = @league
		) AS TopScorersByLeague
		WHERE [Rank] = 1
	)


SELECT * FROM [dbo].[udf_LeagueTopScorer]('Eredivisie')

-- Task 12
CREATE OR ALTER PROCEDURE dbo.usp_UpdatePlayerStats
    @PlayerId INT,
    @GoalsDelta INT = NULL,
    @AssistsDelta INT = NULL
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.PlayerStats WHERE PlayerId = @PlayerId)
    BEGIN
        INSERT INTO dbo.PlayerStats (PlayerId, Goals, Assists)
        VALUES (@PlayerId, 0, 0);
    END

	UPDATE PlayerStats
	SET Goals += ISNULL(@GoalsDelta, 0),
	Assists += ISNULL(@AssistsDelta, 0)
	WHERE PlayerId = @PlayerId
END

EXEC usp_UpdatePlayerStats 5, NULL, 1

SELECT *
FROM PlayerStats
WHERE PlayerId = 5