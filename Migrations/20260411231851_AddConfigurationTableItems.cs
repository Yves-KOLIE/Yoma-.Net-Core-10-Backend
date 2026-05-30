using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class AddConfigurationTableItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "EcoBank" },
                    { 2, "Bicigui" },
                    { 3, "Vista" },
                    { 4, "Société Générale" },
                    { 5, "Coris Bank" }
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "BirthPlaces",
                columns: new[] { "ID", "PLACE" },
                values: new object[,]
                {
                    { 1, "Conakry" },
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "GasStations",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Autre" },
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "SchoolEducations",
                columns: new[] { "ID", "DESCRIPTION", "ABBREVIATION"},
                values: new object[,]
                {
                    { 1, "Maternelle", "EM"},
                    { 2, "Primaire", "EP" },
                    { 3, "Collège", "C" },
                    { 4, "Lycée", "LP" },
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "HighSchoolOptions",
                columns: new[] { "ID", "DESCRIPTION", "ABBREVIATION" },
                values: new object[,]
                {
                    { 1, "Sciences Mathématiques", "SM" },
                    { 2, "Sciences Expérimentales", "SE" },
                    { 3, "Sciences Sociales", "SS" },
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "ID", "DESCRIPTION", "SCHOOL_EDUCATION_ID", "HIGH_SCHOOL_OPTION_ID" },
                values: new object[,]
                {
                    { 1, "Petite section", 1, null },
                    { 2, "Moyenne section", 1, null },
                    { 3, "Grande section", 1, null },

                    { 4, "1ère année", 2, null },
                    { 5, "2ème année", 2, null },
                    { 6, "3ème année", 2, null },
                    { 7, "4ème", 2, null },
                    { 8, "5ème", 2, null },
                    { 9, "6ème", 2, null },

                    { 10, "7ème année", 3, null },
                    { 11, "8ème année", 3, null },
                    { 12, "9ème année", 3, null },
                    { 13, "10ème année", 3, null },

                    { 14, "11ème année", 4, 1 },
                    { 15, "11ème année", 4, 2 },
                    { 16, "11ème année", 4, 3 },

                    { 17, "12ème année", 4, 1 },
                    { 18, "12ème année", 4, 2 },
                    { 19, "12ème année", 4, 3 },

                    { 20, "Terminale", 4, 1 },
                    { 21, "Terminale", 4, 2 },
                    { 22, "Terminale", 4, 3 },
                },
            schema: null);


            migrationBuilder.InsertData(
                table: "TypeSalaryAdvances",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Cours"},
                    { 2, "Revision" },
                },
            schema: null);


            migrationBuilder.InsertData(
                table: "ParentTypes",
                columns: new[] { "ID", "DESCRIPTION", "SEXE" },
                values: new object[,]
                {
                    { 1, "Père", "M"},
                    { 2, "Mère", "F" },
                    { 3, "Frère", "M" },
                    { 4, "Sœur", "F" },
                    { 5, "Oncle", "M" },
                    { 6, "Tante", "F" },
                    { 7, "Neveu", "M" },
                    { 8, "Nièce", "F" },
                    { 9, "Cousin", "M" },
                    { 10, "Cousine", "F" },
                    { 11, "Grand-père", "M" },
                    { 12, "Grande-mère", "F" },
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "Months",
                columns: new[] { "ID", "DESCRIPTION", "ABBREVIATION" },
                values: new object[,]
                {
                    { 1, "Janvier", "Janv."},
                    { 2, "Février", "Févr." },
                    { 3, "Mars", "Mars" },
                    { 4, "Avril", "Avril" },
                    { 5, "Mai", "Mai" },
                    { 6, "Juin", "Juin" },
                    { 7, "Juillet", "Juill." },
                    { 8, "Août", "Aôut" },
                    { 9, "Septembre", "Sept." },
                    { 10, "Octobre", "Oct." },
                    { 11, "Novembre", "Nov." },
                    { 12, "Décembre", "Déc." },
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "Subdivisions",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "A"},
                    { 2, "B" },
                    { 3, "C" },
                    { 4, "D" },
                    { 5, "E" },
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Cash"},
                    { 2, "Orange Money" },
                    { 3, "Virement bancaire" }
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "TransportLoadTypes",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Reparation"},
                    { 2, "Maintenance" },
                    { 3, "Achat de carburant" },
                    { 4, "Autre" }
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "UserPositions",
                columns: new[] { "ID", "DESCRIPTION", "IS_ACTIVE" },
                values: new object[,]
                {
                    {1, "Fondateur", true },
                    {2, "Directeur des études", true },
                    {3, "Censeur", true },
                    {4, "Proviseur", true },
                    {5, "Comptable", true },
                    {6, "Enseignant", true },
                    {7, "Surveillant", true },
                    {8, "Chauffeur", true },
                    {9, "Gardien", true },
                    {10, "Professeur", true },
                    {11, "Developpeur", false },
                },
            schema: null);

            migrationBuilder.InsertData(
                table: "ProfessionalQualifications",
                columns: new[] { "ID", "DESCRIPTION", "ABBREVIATION" },
                values: new object[,]
                {
                    { 1, "Docteur", "Dr"},
                    { 2, "Professeur", "Pr" },
                    { 3, "Monsieur", "Mr" },
                    { 4, "Madame", "Mme" },
                    { 5, "Madémoiselle", "Mlle" },
                },
            schema: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
