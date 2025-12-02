-- ========================================
-- SEED MOBILE NETWORKS
-- ========================================
-- Run this after creating the Networks table
-- Add popular mobile networks for various countries

USE [YourDatabaseName]; -- Change to your database name
GO

-- First, get country IDs (you'll need to replace these with actual GUIDs from your database)
-- To get the GUIDs, run: SELECT Id, Name, Code FROM Countries WHERE IsDeleted = 0 ORDER BY DisplayOrder

DECLARE @KuwaitId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'KW');
DECLARE @SaudiId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'SA');
DECLARE @UAEId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'AE');
DECLARE @QatarId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'QA');
DECLARE @BahrainId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'BH');
DECLARE @OmanId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'OM');
DECLARE @EgyptId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'EG');
DECLARE @IndiaId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'IN');
DECLARE @USAId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'US');
DECLARE @UKId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'GB');

-- Kuwait Networks
IF @KuwaitId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'Zain Kuwait', 'https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Zain_logo.svg/200px-Zain_logo.svg.png', @KuwaitId, 1, 1, GETDATE(), 0),
        (NEWID(), 'Ooredoo Kuwait', 'https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Ooredoo_logo.svg/200px-Ooredoo_logo.svg.png', @KuwaitId, 1, 2, GETDATE(), 0),
        (NEWID(), 'Viva Kuwait', 'https://www.stc.com.kw/wps/wcm/connect/english/stc/resources/8/d/8db2a9c3-4b1e-4c5d-8e5f-6e2c8c8c8c8c/stc-viva.png', @KuwaitId, 1, 3, GETDATE(), 0);
    PRINT 'Added Kuwait networks';
END

-- Saudi Arabia Networks
IF @SaudiId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'STC Saudi Arabia', 'https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/STC_Logo_2021.svg/200px-STC_Logo_2021.svg.png', @SaudiId, 1, 1, GETDATE(), 0),
        (NEWID(), 'Mobily', 'https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Mobily_Logo.svg/200px-Mobily_Logo.svg.png', @SaudiId, 1, 2, GETDATE(), 0),
        (NEWID(), 'Zain Saudi Arabia', 'https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Zain_logo.svg/200px-Zain_logo.svg.png', @SaudiId, 1, 3, GETDATE(), 0),
        (NEWID(), 'Virgin Mobile Saudi Arabia', NULL, @SaudiId, 1, 4, GETDATE(), 0);
    PRINT 'Added Saudi Arabia networks';
END

-- UAE Networks
IF @UAEId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'Etisalat UAE', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Etisalat_logo.svg/200px-Etisalat_logo.svg.png', @UAEId, 1, 1, GETDATE(), 0),
        (NEWID(), 'du (Emirates Integrated Telecommunications)', 'https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Du_logo.svg/200px-Du_logo.svg.png', @UAEId, 1, 2, GETDATE(), 0),
        (NEWID(), 'Virgin Mobile UAE', NULL, @UAEId, 1, 3, GETDATE(), 0);
    PRINT 'Added UAE networks';
END

-- Qatar Networks
IF @QatarId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'Ooredoo Qatar', 'https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Ooredoo_logo.svg/200px-Ooredoo_logo.svg.png', @QatarId, 1, 1, GETDATE(), 0),
        (NEWID(), 'Vodafone Qatar', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Vodafone_icon.svg/200px-Vodafone_icon.svg.png', @QatarId, 1, 2, GETDATE(), 0);
    PRINT 'Added Qatar networks';
END

-- Bahrain Networks
IF @BahrainId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'Batelco', NULL, @BahrainId, 1, 1, GETDATE(), 0),
        (NEWID(), 'Zain Bahrain', 'https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Zain_logo.svg/200px-Zain_logo.svg.png', @BahrainId, 1, 2, GETDATE(), 0),
        (NEWID(), 'Viva Bahrain', NULL, @BahrainId, 1, 3, GETDATE(), 0);
    PRINT 'Added Bahrain networks';
END

-- Oman Networks
IF @OmanId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'Omantel', NULL, @OmanId, 1, 1, GETDATE(), 0),
        (NEWID(), 'Ooredoo Oman', 'https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Ooredoo_logo.svg/200px-Ooredoo_logo.svg.png', @OmanId, 1, 2, GETDATE(), 0);
    PRINT 'Added Oman networks';
END

-- Egypt Networks
IF @EgyptId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'Vodafone Egypt', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Vodafone_icon.svg/200px-Vodafone_icon.svg.png', @EgyptId, 1, 1, GETDATE(), 0),
        (NEWID(), 'Orange Egypt', 'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Orange_logo.svg/200px-Orange_logo.svg.png', @EgyptId, 1, 2, GETDATE(), 0),
        (NEWID(), 'Etisalat Egypt', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Etisalat_logo.svg/200px-Etisalat_logo.svg.png', @EgyptId, 1, 3, GETDATE(), 0),
        (NEWID(), 'WE (Telecom Egypt)', NULL, @EgyptId, 1, 4, GETDATE(), 0);
    PRINT 'Added Egypt networks';
END

-- India Networks
IF @IndiaId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'Jio (Reliance Jio)', NULL, @IndiaId, 1, 1, GETDATE(), 0),
        (NEWID(), 'Airtel (Bharti Airtel)', NULL, @IndiaId, 1, 2, GETDATE(), 0),
        (NEWID(), 'Vi (Vodafone Idea)', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Vodafone_icon.svg/200px-Vodafone_icon.svg.png', @IndiaId, 1, 3, GETDATE(), 0),
        (NEWID(), 'BSNL', NULL, @IndiaId, 1, 4, GETDATE(), 0);
    PRINT 'Added India networks';
END

-- USA Networks
IF @USAId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'Verizon', NULL, @USAId, 1, 1, GETDATE(), 0),
        (NEWID(), 'AT&T', NULL, @USAId, 1, 2, GETDATE(), 0),
        (NEWID(), 'T-Mobile US', NULL, @USAId, 1, 3, GETDATE(), 0),
        (NEWID(), 'Sprint', NULL, @USAId, 1, 4, GETDATE(), 0);
    PRINT 'Added USA networks';
END

-- UK Networks
IF @UKId IS NOT NULL
BEGIN
    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
    VALUES 
        (NEWID(), 'EE (Everything Everywhere)', NULL, @UKId, 1, 1, GETDATE(), 0),
        (NEWID(), 'O2 UK', NULL, @UKId, 1, 2, GETDATE(), 0),
        (NEWID(), 'Vodafone UK', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Vodafone_icon.svg/200px-Vodafone_icon.svg.png', @UKId, 1, 3, GETDATE(), 0),
        (NEWID(), 'Three UK', NULL, @UKId, 1, 4, GETDATE(), 0);
    PRINT 'Added UK networks';
END

-- Verify insertion
SELECT 
    c.Name AS Country,
    COUNT(n.Id) AS NetworkCount
FROM Countries c
LEFT JOIN Networks n ON n.CountryId = c.Id AND n.IsDeleted = 0
WHERE c.IsDeleted = 0
GROUP BY c.Name, c.DisplayOrder
ORDER BY c.DisplayOrder;

PRINT '';
PRINT 'Total networks added:';
SELECT COUNT(*) AS TotalNetworks FROM Networks WHERE IsDeleted = 0;

PRINT '';
PRINT '========================================';
PRINT 'NETWORKS SEEDED SUCCESSFULLY!';
PRINT 'Navigate to /AdminPanel/Networks to manage them.';
PRINT '========================================';
GO
