---- Create the database
--CREATE DATABASE parkman;

-- Use the database
USE parkman;

-- Create ParkingLot table
CREATE TABLE ParkingLot (
    LotID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Location VARCHAR(255) NOT NULL,
    Capacity INT NOT NULL
);

-- Create Vehicle table
CREATE TABLE Vehicle (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    LicensePlate VARCHAR(20) NOT NULL UNIQUE,
    OwnerName VARCHAR(100) NOT NULL,
    VehicleType VARCHAR(50) NOT NULL
);

-- Create Reservation table
CREATE TABLE Reservation (
    ReservationID INT IDENTITY(1,1) PRIMARY KEY,
    VehicleID INT NOT NULL,
    LotID INT NOT NULL,
    ReservationDate DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID) ON DELETE CASCADE,
    FOREIGN KEY (LotID) REFERENCES ParkingLot(LotID) ON DELETE CASCADE
);

-- Populate ParkingLot table
INSERT INTO ParkingLot (Name, Location, Capacity)
VALUES
    ('Downtown Lot', '123 Main St, City Center', 50),
    ('Airport Lot', '456 Airport Rd, Near Airport', 100),
    ('Mall Lot', '789 Mall Blvd, Shopping District', 200);

-- Populate Vehicle table
INSERT INTO Vehicle (LicensePlate, OwnerName, VehicleType)
VALUES
    ('ABC123', 'John Doe', 'Sedan'),
    ('XYZ789', 'Jane Smith', 'SUV'),
    ('LMN456', 'Emily Johnson', 'Truck');

-- Populate Reservation table
INSERT INTO Reservation (VehicleID, LotID, ReservationDate, StartTime, EndTime)
VALUES
    (1, 1, '2025-01-22', '08:00:00', '10:00:00'),
    (2, 2, '2025-01-22', '09:00:00', '11:00:00'),
    (3, 3, '2025-01-22', '10:00:00', '12:00:00');

-- Query to verify relationships
-- Fetch all reservations with details about vehicles and parking lots
SELECT 
    Reservation.ReservationID,
    Vehicle.LicensePlate,
    Vehicle.OwnerName,
    ParkingLot.Name AS ParkingLotName,
    Reservation.ReservationDate,
    Reservation.StartTime,
    Reservation.EndTime
FROM 
    Reservation
JOIN 
    Vehicle ON Reservation.VehicleID = Vehicle.VehicleID
JOIN 
    ParkingLot ON Reservation.LotID = ParkingLot.LotID;
