-- ========================================
-- ADD TEST DEVICES FOR PAGINATION TESTING
-- ========================================
-- This script adds 25 test devices to test pagination
-- Run this in SQL Server Management Studio, Azure Data Studio,
-- or Visual Studio SQL Server Object Explorer

USE [YourDatabaseName]; -- Change this to your actual database name
GO

-- Add 25 test devices
DECLARE @Counter INT = 1;
DECLARE @Brands TABLE (BrandName NVARCHAR(100));
DECLARE @Models TABLE (ModelName NVARCHAR(200));

-- Insert sample brands
INSERT INTO @Brands VALUES 
    ('Huawei'), ('ZTE'), ('Nokia'), ('D-Link'), ('TP-Link'),
    ('Netgear'), ('Telstra'), ('Vodafone'), ('Apple'), ('Samsung');

-- Insert sample models  
INSERT INTO @Models VALUES 
    ('E5577'), ('MF920'), ('MF971R'), ('CPE B315'), ('E5186'),
    ('Nighthawk'), ('5G Hub'), ('WiFi Pod'), ('MiFi 2000'), ('Turbo 5G');

-- Generate 25 test devices
WHILE @Counter <= 25
BEGIN
    DECLARE @RandomBrand NVARCHAR(100);
    DECLARE @RandomModel NVARCHAR(200);
    DECLARE @RandomTac BIGINT;
    
    -- Select random brand
    SELECT TOP 1 @RandomBrand = BrandName 
    FROM @Brands 
    ORDER BY NEWID();
    
    -- Select random model
    SELECT TOP 1 @RandomModel = ModelName 
    FROM @Models 
    ORDER BY NEWID();
    
    -- Generate random TAC (8 digits)
    SET @RandomTac = 35000000 + @Counter;
    
    -- Insert device
    INSERT INTO Devices (
        Id,
        Tac,
        Brand,
        Model,
        BrandLogoUrl,
        CreatedAt,
        UpdatedAt,
        IsDeleted,
        DeletedAt
    )
    VALUES (
        NEWID(),
        @RandomTac,
        @RandomBrand + ' Test',
        @RandomModel + ' ' + CAST(@Counter AS NVARCHAR(10)),
        'https://via.placeholder.com/40x40.png?text=' + LEFT(@RandomBrand, 1),
        DATEADD(HOUR, -@Counter, GETDATE()),
        NULL,
        0,
        NULL
    );
    
    SET @Counter = @Counter + 1;
END

-- Verify insertion
SELECT COUNT(*) AS 'Total Active Devices'
FROM Devices
WHERE IsDeleted = 0;

SELECT TOP 10 
    Id,
    Tac,
    Brand,
    Model,
    CreatedAt
FROM Devices
WHERE IsDeleted = 0
ORDER BY CreatedAt DESC;

PRINT 'Successfully added 25 test devices!';
PRINT 'Navigate to /AdminPanel/Devices to see pagination.';
GO
