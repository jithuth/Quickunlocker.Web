using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Quickunlocker.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedMiddleEastCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // First, delete any existing countries to avoid duplicates
            migrationBuilder.Sql(@"
                DELETE FROM Countries 
                WHERE Code IN (
                    'KW','SA','AE','QA','BH','OM','JO','LB','SY','PS',
                    'EG','IQ','YE','TR','IR','IN','PK','BD','AF','MY',
                    'ID','SG','PH','US','GB','CA','AU','DE','FR','IT',
                    'ES','NL','SE','CH','MA','DZ','TN','LY','CN','JP','KR'
                )
            ");
            
            // Seed 41 countries with flags - Middle East, Asia, Europe, Americas
            var now = DateTimeOffset.UtcNow;
            
            // GCC Countries (Priority 1-6)
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Kuwait", "KW", "https://flagcdn.com/w40/kw.png", true, 1, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Saudi Arabia", "SA", "https://flagcdn.com/w40/sa.png", true, 2, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "United Arab Emirates", "AE", "https://flagcdn.com/w40/ae.png", true, 3, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Qatar", "QA", "https://flagcdn.com/w40/qa.png", true, 4, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Bahrain", "BH", "https://flagcdn.com/w40/bh.png", true, 5, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Oman", "OM", "https://flagcdn.com/w40/om.png", true, 6, now, null, false, null });
            
            // Levant Countries (7-10)
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Jordan", "JO", "https://flagcdn.com/w40/jo.png", true, 7, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Lebanon", "LB", "https://flagcdn.com/w40/lb.png", true, 8, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Syria", "SY", "https://flagcdn.com/w40/sy.png", true, 9, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Palestine", "PS", "https://flagcdn.com/w40/ps.png", true, 10, now, null, false, null });
            
            // Other Middle East (11-15)
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Egypt", "EG", "https://flagcdn.com/w40/eg.png", true, 11, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Iraq", "IQ", "https://flagcdn.com/w40/iq.png", true, 12, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Yemen", "YE", "https://flagcdn.com/w40/ye.png", true, 13, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Turkey", "TR", "https://flagcdn.com/w40/tr.png", true, 14, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Iran", "IR", "https://flagcdn.com/w40/ir.png", true, 15, now, null, false, null });
            
            // South Asia (16-19)
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "India", "IN", "https://flagcdn.com/w40/in.png", true, 16, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Pakistan", "PK", "https://flagcdn.com/w40/pk.png", true, 17, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Bangladesh", "BD", "https://flagcdn.com/w40/bd.png", true, 18, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Afghanistan", "AF", "https://flagcdn.com/w40/af.png", true, 19, now, null, false, null });
            
            // Southeast Asia (20-23)
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Malaysia", "MY", "https://flagcdn.com/w40/my.png", true, 20, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Indonesia", "ID", "https://flagcdn.com/w40/id.png", true, 21, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Singapore", "SG", "https://flagcdn.com/w40/sg.png", true, 22, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Philippines", "PH", "https://flagcdn.com/w40/ph.png", true, 23, now, null, false, null });
            
            // Western Countries (24-27)
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "United States", "US", "https://flagcdn.com/w40/us.png", true, 24, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "United Kingdom", "GB", "https://flagcdn.com/w40/gb.png", true, 25, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Canada", "CA", "https://flagcdn.com/w40/ca.png", true, 26, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Australia", "AU", "https://flagcdn.com/w40/au.png", true, 27, now, null, false, null });
            
            // Europe (28-34)
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Germany", "DE", "https://flagcdn.com/w40/de.png", true, 28, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "France", "FR", "https://flagcdn.com/w40/fr.png", true, 29, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Italy", "IT", "https://flagcdn.com/w40/it.png", true, 30, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Spain", "ES", "https://flagcdn.com/w40/es.png", true, 31, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Netherlands", "NL", "https://flagcdn.com/w40/nl.png", true, 32, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Sweden", "SE", "https://flagcdn.com/w40/se.png", true, 33, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Switzerland", "CH", "https://flagcdn.com/w40/ch.png", true, 34, now, null, false, null });
            
            // North Africa (35-38)
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Morocco", "MA", "https://flagcdn.com/w40/ma.png", true, 35, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Algeria", "DZ", "https://flagcdn.com/w40/dz.png", true, 36, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Tunisia", "TN", "https://flagcdn.com/w40/tn.png", true, 37, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Libya", "LY", "https://flagcdn.com/w40/ly.png", true, 38, now, null, false, null });
            
            // East Asia (39-41)
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "China", "CN", "https://flagcdn.com/w40/cn.png", true, 39, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "Japan", "JP", "https://flagcdn.com/w40/jp.png", true, 40, now, null, false, null });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Code", "FlagUrl", "IsActive", "DisplayOrder", "CreatedAt", "UpdatedAt", "IsDeleted", "DeletedAt" },
                values: new object[] { Guid.NewGuid(), "South Korea", "KR", "https://flagcdn.com/w40/kr.png", true, 41, now, null, false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove all seeded countries by their codes
            migrationBuilder.Sql(@"
                DELETE FROM Countries 
                WHERE Code IN (
                    'KW','SA','AE','QA','BH','OM','JO','LB','SY','PS',
                    'EG','IQ','YE','TR','IR','IN','PK','BD','AF','MY',
                    'ID','SG','PH','US','GB','CA','AU','DE','FR','IT',
                    'ES','NL','SE','CH','MA','DZ','TN','LY','CN','JP','KR'
                )
            ");
        }
    }
}
