using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addDefaultItemsInNoteMonths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NoteMonths",
                columns: new[] { 
                    "IS_COMPOSITION_MONTH", 
                    "IS_TRIMESTER_1",
                    "IS_TRIMESTER_2",
                    "IS_TRIMESTER_3",
                    "CREATION_DATE", 
                    "MODIFICATION_DATE",
                    "SCHOOL_YEAR_ID",
                    "MONTH_ID",
                    "EDUCATION_LEVEL_ID"
                },
                values: new object[,]
                {
                    // 1ère année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 4 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 4 },

                    // 2ème année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 5 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 5 },

                    // 3ème année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 6 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 6 },

                    // 4ème année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 7 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 7 },

                    // 5ème année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 8 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 8 },

                    // 6ème année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 9 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 9 },

                    // 7ème année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 10 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 10 },

                    // 8ème année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 11 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 11 },

                    // 9ème année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 12 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 12 },

                    // 10ème année
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 13 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 13 },

                    // 11ème année SM
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 14 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 14 },

                    // 11ème année SE
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 15 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 15 },

                    // 11ème année SS
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 16 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 16 },

                    // 12ème année SM
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 17 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 17 },

                    // 12ème année SE
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 18 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 18 },

                    // 12ème année SS
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 19 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 19 },

                    // Terminale année SM
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 20 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 20 },

                    // Terminale année SE
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 21 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 21 },

                    // Terminale année SE
                    { false, false, false, false, DateTime.UtcNow, null, 1, 1, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 2, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 3, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 4, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 5, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 6, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 7, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 8, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 9, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 10, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 11, 22 },
                    { false, false, false, false, DateTime.UtcNow, null, 1, 12, 22 },
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}