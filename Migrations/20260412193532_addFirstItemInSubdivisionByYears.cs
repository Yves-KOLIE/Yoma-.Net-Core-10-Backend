using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addFirstItemInSubdivisionByYears : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubdivisionByYears",
                columns: new[] { 
                    "CREATION_DATE", 
                    "MODIFICATION_DATE",
                    "SCHOOL_YEAR_ID",
                    "SUBDIVISION_ID",
                    "EDUCATION_LEVEL_ID" 
                },
                values: new object[,]
                {
                    // Petite Section
                    { DateTime.UtcNow, null, 1, 1, 1 },
                    { DateTime.UtcNow, null, 1, 2, 1 },
                    { DateTime.UtcNow, null, 1, 3, 1 },
                    { DateTime.UtcNow, null, 1, 4, 1 },
                    { DateTime.UtcNow, null, 1, 5, 1 },

                    // Moyenne Section
                    { DateTime.UtcNow, null, 1, 1, 2 },
                    { DateTime.UtcNow, null, 1, 2, 2 },
                    { DateTime.UtcNow, null, 1, 3, 2 },
                    { DateTime.UtcNow, null, 1, 4, 2 },
                    { DateTime.UtcNow, null, 1, 5, 2 },

                    // Grande Section
                    { DateTime.UtcNow, null, 1, 1, 3 },
                    { DateTime.UtcNow, null, 1, 2, 3 },
                    { DateTime.UtcNow, null, 1, 3, 3 },
                    { DateTime.UtcNow, null, 1, 4, 3 },
                    { DateTime.UtcNow, null, 1, 5, 3 },

                    // 1ère année
                    { DateTime.UtcNow, null, 1, 1, 4 },
                    { DateTime.UtcNow, null, 1, 2, 4 },
                    { DateTime.UtcNow, null, 1, 3, 4 },
                    { DateTime.UtcNow, null, 1, 4, 4 },
                    { DateTime.UtcNow, null, 1, 5, 4 },

                    // 2ème année
                    { DateTime.UtcNow, null, 1, 1, 5 },
                    { DateTime.UtcNow, null, 1, 2, 5 },
                    { DateTime.UtcNow, null, 1, 3, 5 },
                    { DateTime.UtcNow, null, 1, 4, 5 },
                    { DateTime.UtcNow, null, 1, 5, 5 },

                    // 3ème année
                    { DateTime.UtcNow, null, 1, 1, 6 },
                    { DateTime.UtcNow, null, 1, 2, 6 },
                    { DateTime.UtcNow, null, 1, 3, 6 },
                    { DateTime.UtcNow, null, 1, 4, 6 },
                    { DateTime.UtcNow, null, 1, 5, 6 },

                    // 4ème année
                    { DateTime.UtcNow, null, 1, 1, 7 },
                    { DateTime.UtcNow, null, 1, 2, 7 },
                    { DateTime.UtcNow, null, 1, 3, 7 },
                    { DateTime.UtcNow, null, 1, 4, 7 },
                    { DateTime.UtcNow, null, 1, 5, 7 },

                    // 5ème année
                    { DateTime.UtcNow, null, 1, 1, 8 },
                    { DateTime.UtcNow, null, 1, 2, 8 },
                    { DateTime.UtcNow, null, 1, 3, 8 },
                    { DateTime.UtcNow, null, 1, 4, 8 },
                    { DateTime.UtcNow, null, 1, 5, 8 },

                    // 6ème année
                    { DateTime.UtcNow, null, 1, 1, 9 },
                    { DateTime.UtcNow, null, 1, 2, 9 },
                    { DateTime.UtcNow, null, 1, 3, 9 },
                    { DateTime.UtcNow, null, 1, 4, 9 },
                    { DateTime.UtcNow, null, 1, 5, 9 },

                    // 7ème année
                    { DateTime.UtcNow, null, 1, 1, 10 },
                    { DateTime.UtcNow, null, 1, 2, 10 },
                    { DateTime.UtcNow, null, 1, 3, 10 },
                    { DateTime.UtcNow, null, 1, 4, 10 },
                    { DateTime.UtcNow, null, 1, 5, 10 },

                    // 8ème année
                    { DateTime.UtcNow, null, 1, 1, 11 },
                    { DateTime.UtcNow, null, 1, 2, 11 },
                    { DateTime.UtcNow, null, 1, 3, 11 },
                    { DateTime.UtcNow, null, 1, 4, 11 },
                    { DateTime.UtcNow, null, 1, 5, 11 },

                    // 9ème année
                    { DateTime.UtcNow, null, 1, 1, 12 },
                    { DateTime.UtcNow, null, 1, 2, 12 },
                    { DateTime.UtcNow, null, 1, 3, 12 },
                    { DateTime.UtcNow, null, 1, 4, 12 },
                    { DateTime.UtcNow, null, 1, 5, 12 },

                    // 10ème année
                    { DateTime.UtcNow, null, 1, 1, 13 },
                    { DateTime.UtcNow, null, 1, 2, 13 },
                    { DateTime.UtcNow, null, 1, 3, 13 },
                    { DateTime.UtcNow, null, 1, 4, 13 },
                    { DateTime.UtcNow, null, 1, 5, 13 },

                    // 11ème année SM
                    { DateTime.UtcNow, null, 1, 1, 14 },
                    { DateTime.UtcNow, null, 1, 2, 14 },
                    { DateTime.UtcNow, null, 1, 3, 14 },
                    { DateTime.UtcNow, null, 1, 4, 14 },
                    { DateTime.UtcNow, null, 1, 5, 14 },

                    // 11ème année SE
                    { DateTime.UtcNow, null, 1, 1, 15 },
                    { DateTime.UtcNow, null, 1, 2, 15 },
                    { DateTime.UtcNow, null, 1, 3, 15 },
                    { DateTime.UtcNow, null, 1, 4, 15 },
                    { DateTime.UtcNow, null, 1, 5, 15 },

                    // 11ème année SS
                    { DateTime.UtcNow, null, 1, 1, 16 },
                    { DateTime.UtcNow, null, 1, 2, 16 },
                    { DateTime.UtcNow, null, 1, 3, 16 },
                    { DateTime.UtcNow, null, 1, 4, 16 },
                    { DateTime.UtcNow, null, 1, 5, 16 },

                    // 12ème année SM
                    { DateTime.UtcNow, null, 1, 1, 17 },
                    { DateTime.UtcNow, null, 1, 2, 17 },
                    { DateTime.UtcNow, null, 1, 3, 17 },
                    { DateTime.UtcNow, null, 1, 4, 17 },
                    { DateTime.UtcNow, null, 1, 5, 17 },

                    // 12ème année SE
                    { DateTime.UtcNow, null, 1, 1, 18 },
                    { DateTime.UtcNow, null, 1, 2, 18 },
                    { DateTime.UtcNow, null, 1, 3, 18 },
                    { DateTime.UtcNow, null, 1, 4, 18 },
                    { DateTime.UtcNow, null, 1, 5, 18 },

                    // 12ème année SS
                    { DateTime.UtcNow, null, 1, 1, 19 },
                    { DateTime.UtcNow, null, 1, 2, 19 },
                    { DateTime.UtcNow, null, 1, 3, 19 },
                    { DateTime.UtcNow, null, 1, 4, 19 },
                    { DateTime.UtcNow, null, 1, 5, 19 },

                    // Terminale SM
                    { DateTime.UtcNow, null, 1, 1, 20 },
                    { DateTime.UtcNow, null, 1, 2, 20 },
                    { DateTime.UtcNow, null, 1, 3, 20 },
                    { DateTime.UtcNow, null, 1, 4, 20 },
                    { DateTime.UtcNow, null, 1, 5, 20 },

                    // Terminale SE
                    { DateTime.UtcNow, null, 1, 1, 21 },
                    { DateTime.UtcNow, null, 1, 2, 21 },
                    { DateTime.UtcNow, null, 1, 3, 21 },
                    { DateTime.UtcNow, null, 1, 4, 21 },
                    { DateTime.UtcNow, null, 1, 5, 21 },

                    // Terminale SS
                    { DateTime.UtcNow, null, 1, 1, 22 },
                    { DateTime.UtcNow, null, 1, 2, 22 },
                    { DateTime.UtcNow, null, 1, 3, 22 },
                    { DateTime.UtcNow, null, 1, 4, 22 },
                    { DateTime.UtcNow, null, 1, 5, 22 },
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "SubdivisionByYears",
            keyColumn: "SCHOOL_YEAR_ID",
            keyValue: 1);
        }
    }
}
