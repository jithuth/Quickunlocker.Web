-- ========================================
-- SEED DEFAULT COUNTRIES WITH FLAGS
-- ========================================
-- Run this after creating the Countries table
-- Uses flagcdn.com for flag icons

USE [YourDatabaseName]; -- Change to your database name
GO

-- Insert popular countries with flags
INSERT INTO Countries (Id, Name, Code, FlagUrl, IsActive, DisplayOrder, CreatedAt, IsDeleted)
VALUES
    (NEWID(), 'Kuwait', 'KW', 'https://flagcdn.com/w40/kw.png', 1, 1, GETDATE(), 0),
    (NEWID(), 'Saudi Arabia', 'SA', 'https://flagcdn.com/w40/sa.png', 1, 2, GETDATE(), 0),
    (NEWID(), 'United Arab Emirates', 'AE', 'https://flagcdn.com/w40/ae.png', 1, 3, GETDATE(), 0),
    (NEWID(), 'Qatar', 'QA', 'https://flagcdn.com/w40/qa.png', 1, 4, GETDATE(), 0),
    (NEWID(), 'Bahrain', 'BH', 'https://flagcdn.com/w40/bh.png', 1, 5, GETDATE(), 0),
    (NEWID(), 'Oman', 'OM', 'https://flagcdn.com/w40/om.png', 1, 6, GETDATE(), 0),
    (NEWID(), 'Egypt', 'EG', 'https://flagcdn.com/w40/eg.png', 1, 7, GETDATE(), 0),
    (NEWID(), 'Jordan', 'JO', 'https://flagcdn.com/w40/jo.png', 1, 8, GETDATE(), 0),
    (NEWID(), 'Lebanon', 'LB', 'https://flagcdn.com/w40/lb.png', 1, 9, GETDATE(), 0),
    (NEWID(), 'Iraq', 'IQ', 'https://flagcdn.com/w40/iq.png', 1, 10, GETDATE(), 0),
    (NEWID(), 'India', 'IN', 'https://flagcdn.com/w40/in.png', 1, 11, GETDATE(), 0),
    (NEWID(), 'Pakistan', 'PK', 'https://flagcdn.com/w40/pk.png', 1, 12, GETDATE(), 0),
    (NEWID(), 'Bangladesh', 'BD', 'https://flagcdn.com/w40/bd.png', 1, 13, GETDATE(), 0),
    (NEWID(), 'United States', 'US', 'https://flagcdn.com/w40/us.png', 1, 14, GETDATE(), 0),
    (NEWID(), 'United Kingdom', 'GB', 'https://flagcdn.com/w40/gb.png', 1, 15, GETDATE(), 0),
    (NEWID(), 'Canada', 'CA', 'https://flagcdn.com/w40/ca.png', 1, 16, GETDATE(), 0),
    (NEWID(), 'Australia', 'AU', 'https://flagcdn.com/w40/au.png', 1, 17, GETDATE(), 0),
    (NEWID(), 'Germany', 'DE', 'https://flagcdn.com/w40/de.png', 1, 18, GETDATE(), 0),
    (NEWID(), 'France', 'FR', 'https://flagcdn.com/w40/fr.png', 1, 19, GETDATE(), 0),
    (NEWID(), 'Italy', 'IT', 'https://flagcdn.com/w40/it.png', 1, 20, GETDATE(), 0),
    (NEWID(), 'Spain', 'ES', 'https://flagcdn.com/w40/es.png', 1, 21, GETDATE(), 0),
    (NEWID(), 'Netherlands', 'NL', 'https://flagcdn.com/w40/nl.png', 1, 22, GETDATE(), 0),
    (NEWID(), 'Turkey', 'TR', 'https://flagcdn.com/w40/tr.png', 1, 23, GETDATE(), 0),
    (NEWID(), 'Malaysia', 'MY', 'https://flagcdn.com/w40/my.png', 1, 24, GETDATE(), 0),
    (NEWID(), 'Singapore', 'SG', 'https://flagcdn.com/w40/sg.png', 1, 25, GETDATE(), 0);

-- Verify insertion
SELECT COUNT(*) AS 'Total Countries' FROM Countries WHERE IsDeleted = 0;

SELECT TOP 10
    Name,
    Code,
    CASE WHEN IsActive = 1 THEN 'Enabled' ELSE 'Disabled' END AS Status,
    DisplayOrder
FROM Countries
WHERE IsDeleted = 0
ORDER BY DisplayOrder;

PRINT 'Successfully added 25 countries!';
PRINT 'Navigate to /AdminPanel/Countries to manage them.';
GO
