using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Quickunlocker.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedMobileNetworks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var now = DateTimeOffset.UtcNow;

            // Seed networks using SQL to avoid hardcoding GUIDs
            // This approach gets country IDs dynamically
            
            migrationBuilder.Sql(@"
                -- Kuwait Networks
                DECLARE @KuwaitId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'KW');
                IF @KuwaitId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'Zain Kuwait', 'https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Zain_logo.svg/200px-Zain_logo.svg.png', @KuwaitId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'Ooredoo Kuwait', 'https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Ooredoo_logo.svg/200px-Ooredoo_logo.svg.png', @KuwaitId, 1, 2, GETDATE(), 0),
                        (NEWID(), 'Viva Kuwait', NULL, @KuwaitId, 1, 3, GETDATE(), 0);
                END

                -- Saudi Arabia Networks
                DECLARE @SaudiId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'SA');
                IF @SaudiId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'STC Saudi Arabia', 'https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/STC_Logo_2021.svg/200px-STC_Logo_2021.svg.png', @SaudiId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'Mobily', 'https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Mobily_Logo.svg/200px-Mobily_Logo.svg.png', @SaudiId, 1, 2, GETDATE(), 0),
                        (NEWID(), 'Zain Saudi Arabia', 'https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Zain_logo.svg/200px-Zain_logo.svg.png', @SaudiId, 1, 3, GETDATE(), 0),
                        (NEWID(), 'Virgin Mobile Saudi Arabia', NULL, @SaudiId, 1, 4, GETDATE(), 0);
                END

                -- UAE Networks
                DECLARE @UAEId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'AE');
                IF @UAEId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'Etisalat UAE', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Etisalat_logo.svg/200px-Etisalat_logo.svg.png', @UAEId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'du (Emirates Integrated Telecommunications)', 'https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Du_logo.svg/200px-Du_logo.svg.png', @UAEId, 1, 2, GETDATE(), 0),
                        (NEWID(), 'Virgin Mobile UAE', NULL, @UAEId, 1, 3, GETDATE(), 0);
                END

                -- Qatar Networks
                DECLARE @QatarId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'QA');
                IF @QatarId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'Ooredoo Qatar', 'https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Ooredoo_logo.svg/200px-Ooredoo_logo.svg.png', @QatarId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'Vodafone Qatar', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Vodafone_icon.svg/200px-Vodafone_icon.svg.png', @QatarId, 1, 2, GETDATE(), 0);
                END

                -- Bahrain Networks
                DECLARE @BahrainId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'BH');
                IF @BahrainId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'Batelco', NULL, @BahrainId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'Zain Bahrain', 'https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Zain_logo.svg/200px-Zain_logo.svg.png', @BahrainId, 1, 2, GETDATE(), 0),
                        (NEWID(), 'Viva Bahrain', NULL, @BahrainId, 1, 3, GETDATE(), 0);
                END

                -- Oman Networks
                DECLARE @OmanId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'OM');
                IF @OmanId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'Omantel', NULL, @OmanId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'Ooredoo Oman', 'https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Ooredoo_logo.svg/200px-Ooredoo_logo.svg.png', @OmanId, 1, 2, GETDATE(), 0);
                END

                -- Egypt Networks
                DECLARE @EgyptId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'EG');
                IF @EgyptId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'Vodafone Egypt', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Vodafone_icon.svg/200px-Vodafone_icon.svg.png', @EgyptId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'Orange Egypt', 'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Orange_logo.svg/200px-Orange_logo.svg.png', @EgyptId, 1, 2, GETDATE(), 0),
                        (NEWID(), 'Etisalat Egypt', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Etisalat_logo.svg/200px-Etisalat_logo.svg.png', @EgyptId, 1, 3, GETDATE(), 0),
                        (NEWID(), 'WE (Telecom Egypt)', NULL, @EgyptId, 1, 4, GETDATE(), 0);
                END

                -- India Networks
                DECLARE @IndiaId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'IN');
                IF @IndiaId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'Jio (Reliance Jio)', NULL, @IndiaId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'Airtel (Bharti Airtel)', NULL, @IndiaId, 1, 2, GETDATE(), 0),
                        (NEWID(), 'Vi (Vodafone Idea)', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Vodafone_icon.svg/200px-Vodafone_icon.svg.png', @IndiaId, 1, 3, GETDATE(), 0),
                        (NEWID(), 'BSNL', NULL, @IndiaId, 1, 4, GETDATE(), 0);
                END

                -- USA Networks
                DECLARE @USAId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'US');
                IF @USAId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'Verizon', NULL, @USAId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'AT&T', NULL, @USAId, 1, 2, GETDATE(), 0),
                        (NEWID(), 'T-Mobile US', NULL, @USAId, 1, 3, GETDATE(), 0),
                        (NEWID(), 'Sprint', NULL, @USAId, 1, 4, GETDATE(), 0);
                END

                -- UK Networks
                DECLARE @UKId UNIQUEIDENTIFIER = (SELECT Id FROM Countries WHERE Code = 'GB');
                IF @UKId IS NOT NULL
                BEGIN
                    INSERT INTO Networks (Id, Name, LogoUrl, CountryId, IsActive, DisplayOrder, CreatedAt, IsDeleted)
                    VALUES 
                        (NEWID(), 'EE (Everything Everywhere)', NULL, @UKId, 1, 1, GETDATE(), 0),
                        (NEWID(), 'O2 UK', NULL, @UKId, 1, 2, GETDATE(), 0),
                        (NEWID(), 'Vodafone UK', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Vodafone_icon.svg/200px-Vodafone_icon.svg.png', @UKId, 1, 3, GETDATE(), 0),
                        (NEWID(), 'Three UK', NULL, @UKId, 1, 4, GETDATE(), 0);
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove all seeded networks
            migrationBuilder.Sql(@"
                DELETE FROM Networks 
                WHERE Name IN (
                    'Zain Kuwait', 'Ooredoo Kuwait', 'Viva Kuwait',
                    'STC Saudi Arabia', 'Mobily', 'Zain Saudi Arabia', 'Virgin Mobile Saudi Arabia',
                    'Etisalat UAE', 'du (Emirates Integrated Telecommunications)', 'Virgin Mobile UAE',
                    'Ooredoo Qatar', 'Vodafone Qatar',
                    'Batelco', 'Zain Bahrain', 'Viva Bahrain',
                    'Omantel', 'Ooredoo Oman',
                    'Vodafone Egypt', 'Orange Egypt', 'Etisalat Egypt', 'WE (Telecom Egypt)',
                    'Jio (Reliance Jio)', 'Airtel (Bharti Airtel)', 'Vi (Vodafone Idea)', 'BSNL',
                    'Verizon', 'AT&T', 'T-Mobile US', 'Sprint',
                    'EE (Everything Everywhere)', 'O2 UK', 'Vodafone UK', 'Three UK'
                )
            ");
        }
    }
}
