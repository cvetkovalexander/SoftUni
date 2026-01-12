-- Problem 01

CREATE DATABASE [Minions]

GO

USE [Minions]

GO


-- Problem 02
CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(80) NOT NULL,
	[Age] TINYINT NOT NULL
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL 
)

-- Problem 03
ALTER TABLE [Minions]
ADD [TownId] INT NOT NULL

ALTER TABLE [Minions]
ADD FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

-- Problem 04
INSERT INTO [Towns]([Id], [Name])
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)


-- Problem 05
-- TRUNCATE - deletes all data from the table, but not the table itself!
TRUNCATE TABLE [Minions]

GO

-- Problem 06
-- DROP - deletes the whole table!
DROP TABLE [Minions]
DROP TABLE [Towns]


-- Problem 07
CREATE TABLE [People] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(4,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1)
	CHECK ([Gender] IN ('m', 'f')),
	[Birthdate] DATE NOT NULL,
	[Biography]	NVARCHAR(MAX)
)

INSERT INTO [People]([Id], [Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES
(1, 'Alex', NULL, 1.80, 62.25, 'm', '2007-01-02', NULL),
(2, 'Ivan', NULL, 1.82, 72.25, 'm', '2007-01-03', NULL),
(3, 'Petar', NULL, 1.83, 82.25, 'm', '2007-01-04', NULL),
(4, 'Gosho', NULL, 1.84, 52.25, 'm', '2007-01-05', NULL),
(5, 'Boris', NULL, 1.81, 92.25, 'm', '2007-01-06', NULL)

--Problem 08
CREATE TABLE [Users] (
	[Id] BIGINT PRIMARY KEY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	[LastLoginTime] DATETIME,
	[IsDeleted] VARCHAR(5)
	CHECK ([IsDeleted] in ('true', 'false'))
)

INSERT INTO [Users]([Id], [Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
(1, 'Alex', '12345', NULL, NULL, 'true'),
(2, 'Ivan', '22345', NULL, NULL, 'false'),
(3, 'Georgi', '32345', NULL, NULL, 'true'),
(4, 'Petar', '42345', NULL, NULL, 'false'),
(5, 'Boris', '52345', NULL, NULL, 'true')

	
-- Problem 09
SELECT name AS ConstraintName
FROM sys.key_constraints
WHERE type = 'PK' AND parent_object_id = OBJECT_ID('Users');

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC0729E9108A

ALTER TABLE [Users]
ADD CONSTRAINT PK_Users_IdUsername PRIMARY KEY ([Id], [Username])

-- Problem 05
ALTER TABLE [Users]
ADD CONSTRAINT CK_Users_Password_Length
CHECK (LEN([Password]) >= 5)

INSERT INTO [Users]([Id], [Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
(7, 'Boris', '1234', NULL, NULL, 'true')

-- Problem 13
CREATE DATABASE [Movies]

USE [Movies]

GO

CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY,
	[DirectorName] VARCHAR(80) NOT NULL,
	[Notes] VARCHAR(200)
)

INSERT INTO [Directors]
VALUES
(1, 'Stratimir', NULL),
(2, 'Boqn', 'A very adequate and passionate director!'),
(3, 'Liuboslav', NUll)

INSERT INTO [Directors]
VALUES
(4, 'Alexander', NULL),
(5, 'Vencislav', 'A director with a huge amount of experience in the his field')



CREATE TABLE [Genres] (
	[Id] INT PRIMARY KEY,
	[GenreName] VARCHAR(80) NOT NULL,
	[Notes] VARCHAR(200)
)

INSERT INTO [Genres]
VALUES
(1, 'Action', 'Fast-paced, full of fights, chases and explosions.'),
(2, 'Comdedy', 'Lighthearted, made to make you laugh.'),
(3, 'Drama', 'Focused on emotional storytelling and characted development.'),
(4, 'Horror', 'Designed to scare or unsettle the audience.'),
(5, 'Science Fiction (Sci-Fi)', NULL)



CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY,
	[CategoryName] VARCHAR(80) NOT NULL,
	[Notes] VARCHAR(200)
)

INSERT INTO [Categories]
VALUES
(1, 'Blockbuster', 'Big-budget, high-profile movies made for mass appeal.'),
(2, 'Independent (Indie)', NULL),
(3, 'Animated', 'Movies created with animation, ranging from 2D to CGI.'),
(4, 'Documentary', 'Non-fiction films that explore real-life topics.'),
(5, 'Short Film', NULL)



CREATE TABLE [Movies] (
	[Id] INT PRIMARY KEY,
	[Title] VARCHAR(80) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] SMALLINT NOT NULL,
	[Length] DECIMAL(5,2) NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] DECIMAL(2,1),
	[Notes] VARCHAR(200)
)

INSERT INTO [Movies]
VALUES
(1, 'Avengers:Endgame', 4, 2019, 3.01, 2, 3, 4.7, NULL),
(2, 'Lady Bird', 3, 2017, 1.34, 1, 2, 3.6, NULL),
(3, 'Coco', 2, 2017, 1.45, 5, 2, 2.2, NULL),
(4, 'The Nightmare', 1, 2015, 1.30, 4, 1, 5.0, NULL),
(5, 'World of Tomorrow', 5, 2015, 0.17, 5, 1, 1.2, NULL)



-- Problem 14
CREATE DATABASE [CarRental]

GO

USE [CarRental]

GO

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY,
	[CategoryName] VARCHAR(60) NOT NULL,
	[DailyRate] DECIMAL(10,2),
	[WeeklyRate] DECIMAL(10,2),
	[MonthlyRate] DECIMAL(10,2),
	[WeekendRate] DECIMAL(10,2)
)

INSERT INTO [Categories] (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
(1, 'Economy',  29.99, 180.00, 700.00, 55.00),
(2, 'SUV',      59.99, 380.00, 1400.00, 110.00),
(3, 'Luxury',  129.99, 800.00, 3000.00, 250.00)

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY,
	[PlateNumber] VARCHAR(30) NOT NULL,
	[Manufacturer] VARCHAR(50) NOT NULL,
	[Model] VARCHAR(50) NOT NULL,
	[CarYear] SMALLINT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Doors] SMALLINT NOT NULL,
	[Picture] VARBINARY(MAX),
	[Condition] VARCHAR(100) NOT NULL,
	[Available] VARCHAR(20) NOT NULL
	CHECK ([Available] IN ('Yes', 'No')),
)

INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
(1, 'CA1234AB', 'Toyota', 'Corolla', 2019, 1, 4, NULL, 'Good condition, recently serviced', 'Yes'),
(2, 'CB5678CD', 'BMW', 'X5', 2021, 2, 5, NULL, 'Excellent condition, low mileage', 'No'),
(3, 'CC9012EF', 'Mercedes', 'E-Class', 2020, 3, 4, NULL, 'Luxury sedan, very good condition', 'Yes');


CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(100)
)

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES
(1, 'John', 'Smith', 'Manager', 'Oversees daily operations'),
(2, 'Emily', 'Johnson', 'Sales Representative', 'Excellent communication with customers'),
(3, 'Michael', 'Brown', 'Mechanic', 'Specialist in car maintenance and repairs');


CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY,
	[DriverLicenceNumber] VARCHAR(30) NOT NULL,
	[FullName] VARCHAR(110) NOT NULL,
	[Address] VARCHAR(110) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[ZIPCode] VARCHAR(10) NOT NULL,
	[Notes] VARCHAR(100)
)

INSERT INTO Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES
(1, 'BG1234567', 'Alice Carter', '12 Vitosha Blvd', 'Sofia', '1000', 'VIP customer, frequent rentals'),
(2, 'BG7654321', 'Daniel Ivanov', '45 Rakovski St', 'Plovdiv', '4000', 'Prefers SUVs'),
(3, 'BG9876543', 'Maria Petrova', '78 Shipka St', 'Varna', '9000', 'New customer, first rental');

CREATE TABLE RentalOrders (
    Id INT PRIMARY KEY,
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
    CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
    CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
    TankLevel INT NOT NULL,
    KilometrageStart INT NOT NULL,
    KilometrageEnd INT NOT NULL,
    TotalKilometrage INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays INT NOT NULL,              -- ✅ fixed here
    RateApplied DECIMAL(10,2) NOT NULL,
    TaxRate DECIMAL(5, 2) NOT NULL,
    OrderStatus VARCHAR(20) NOT NULL,
    Notes VARCHAR(200)
)

INSERT INTO RentalOrders 
(Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 1, 1, 100, 12000, 12250, 250, '2025-09-01', '2025-09-05', 4, 150.00, 18.00, 'Completed', 'Customer returned car on time'),
(2, 2, 2, 2, 75, 5000, 5100, 100, '2025-09-10', '2025-09-12', 2, 200.00, 18.00, 'Completed', 'Minor scratches on rear bumper'),
(3, 3, 3, 3, 90, 8000, 8200, 200, '2025-09-15', '2025-09-18', 3, 180.00, 18.00, 'Pending', 'Car still with customer')


--Problem 15

CREATE DATABASE [Hotel]

GO

USE [Hotel]

GO

CREATE TABLE [Employees] (
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(30) NOT NULL,
	[Notes] VARCHAR(100)
)

INSERT INTO [Employees] (FirstName, LastName, Title, Notes)
VALUES
('John', 'Smith', 'Manager', 'Oversees hotel operations'),
('Emily', 'Johnson', 'Receptionist', 'Handles guest check-ins and bookings'),
('Michael', 'Brown', 'Housekeeping', 'Responsible for room cleaning and maintenance')

CREATE TABLE [Customers] (
	[AccountNumber] INT PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[EmergencyName] VARCHAR(20),
	[EmergencyNumber] VARCHAR(10) NOT NULL,
	[Notes] VARCHAR(100)
)

INSERT INTO [Customers] (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
(111, 'Alice', 'Carter', '0888123456', 'John', '0877654321', 'VIP customer, prefers quiet rooms'),
(213, 'Daniel', 'Ivanov', '0888987654', 'Eva', '0877123456', 'Allergic to peanuts, prefers non-smoking room'),
(63, 'Maria', 'Petrova', '0889112233', 'Leo', '0877998877', 'First-time visitor, requires early check-in')

CREATE TABLE [RoomStatus] (
	[RoomStatus] VARCHAR(80) PRIMARY KEY,
	[Notes] VARCHAR(100)
)

INSERT INTO [RoomStatus] (RoomStatus, Notes)
VALUES
('Available', 'Room is clean and ready for guests'),
('Occupied', 'Room currently has a guest checked in'),
('Cleaning', 'Housekeeping is preparing the room')

CREATE TABLE [RoomType] (
	[RoomType] VARCHAR(80) PRIMARY KEY,
	[Notes] VARCHAR(100)
)

INSERT INTO [RoomType] (RoomType, Notes)
VALUES
('Standard', 'Basic room with essential amenities'),
('Deluxe', 'Larger room with better view and extra comfort'),
('Suite', 'Luxury room with separate living area and premium services')

CREATE TABLE [BedTypes] (
	[BedType] VARCHAR(80) PRIMARY KEY,
	[Notes] VARCHAR(100)
)

INSERT INTO [BedTypes] (BedType, Notes)
VALUES
('Single', 'One single bed, suitable for one guest'),
('Double', 'One double bed, suitable for two guests'),
('Twin', 'Two separate single beds in the same room')

CREATE TABLE [Rooms] (
	[RoomNumber] INT IDENTITY(1,1) PRIMARY KEY,
	[RoomType] VARCHAR(80) FOREIGN KEY REFERENCES [RoomType]([RoomType]),
	[BedType] VARCHAR(80) FOREIGN KEY REFERENCES [BedTypes]([BedType]),
	[Rate] DECIMAL(2,1),
	[RoomStatus] VARCHAR(80) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
	[Notes] VARCHAR(100)
)

SELECT name 
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('Rooms')

ALTER TABLE Rooms
DROP CONSTRAINT FK__Rooms__RoomType__4F7CD00D

ALTER TABLE Rooms
ADD CONSTRAINT FK_Rooms_RoomType
FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType)

ALTER TABLE [Rooms]
ALTER COLUMN [Rate] DECIMAL(6,2)

INSERT INTO [Rooms] (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
('Standard', 'Single', 59.99, 'Available', 'Quiet room near the garden'),
('Deluxe', 'Double', 120.50, 'Occupied', 'Ocean view, booked for 3 nights'),
('Suite', 'Twin', 199.00, 'Cleaning', 'VIP suite, preparing for next guest')

CREATE TABLE [Payments] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id),
	[PaymentDate] DATE NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[FirstDateOccupied] DATE NOT NULL,
	[LastDateOccupied] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[AmountCharged] DECIMAL(10,2) NOT NULL,
	[TaxRate] DECIMAL(5,2) NOT NULL,
	[PaymentTotal] DECIMAL(12,2) NOT NULL,
	[Notes] VARCHAR(100)
)

INSERT INTO [Payments] (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, PaymentTotal, Notes)
VALUES
(1, '2025-09-01', 111, '2025-08-28', '2025-08-31', 3, 180.00, 10.00, 198.00, 'Standard room, paid in cash'),
(2, '2025-09-05', 213, '2025-09-01', '2025-09-04', 3, 360.00, 5.00, 378.00, 'Deluxe room, card payment'),
(3, '2025-09-10', 63, '2025-09-07', '2025-09-10', 3, 600.00, 20.00, 720.00, 'Suite booking, includes breakfast')

CREATE TABLE [Occupancies] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES[Employees]([Id]),
	[DateOccupied] DATE NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES[Customers]([AccountNumber]),
	[RoomNumber] INT FOREIGN KEY REFERENCES[Rooms]([RoomNumber]),
	[RateApplied] DECIMAL(5,2) NOT NULL,
	[PhoneCharge] DECIMAL(6,2),
	[Notes] VARCHAR(100)
)

INSERT INTO [Occupancies] (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
(1, '2025-09-01', 111, 1, 59.99, 5.50, 'Checked in at 2 PM, requested extra towels'),
(2, '2025-09-05', 213, 2, 120.50, 0.00, 'Late check-in, room facing ocean'),
(3, '2025-09-10', 63, 3, 199.00, 12.75, 'VIP guest, used room service')

EXEC sp_rename 'RoomType', 'RoomTypes'
