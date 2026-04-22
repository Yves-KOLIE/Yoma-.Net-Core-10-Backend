using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BirthPlaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PLACE = table.Column<string>(type: "text", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthPlaces", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GasStations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasStations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HighSchoolOptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    ABBREVIATION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighSchoolOptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    ABBREVIATION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "text", nullable: false),
                    SURNAME = table.Column<string>(type: "text", nullable: false),
                    SEXE = table.Column<string>(type: "text", nullable: false),
                    TELEPHONE_1 = table.Column<string>(type: "text", nullable: false),
                    TELEPHONE_2 = table.Column<string>(type: "text", nullable: true),
                    QUARTER = table.Column<string>(type: "text", nullable: false),
                    EMAIL = table.Column<string>(type: "text", nullable: true),
                    PASSWORD = table.Column<string>(type: "text", nullable: true),
                    PHOTO = table.Column<string>(type: "text", nullable: true),
                    IS_LOCK = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    LOCK_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UNLOCK_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LAST_CONNEXION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LAST_DECONNEXION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParentTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    SEXE = table.Column<char>(type: "character(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalQualifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    ABBREVIATION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalQualifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SchoolBuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    MATRICULATION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolBuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SchoolEducations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    ABBREVIATION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolEducations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subdivisions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivisions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransportLoadTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportLoadTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeSalaryAdvances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSalaryAdvances", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPositions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPositions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "text", nullable: false),
                    SURNAME = table.Column<string>(type: "text", nullable: false),
                    SEXE = table.Column<string>(type: "text", nullable: false),
                    BIRTH_DAY_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QUARTER = table.Column<string>(type: "text", nullable: false),
                    TELEPHONE_1 = table.Column<string>(type: "text", nullable: true),
                    TELEPHONE_2 = table.Column<string>(type: "text", nullable: true),
                    EMAIL = table.Column<string>(type: "text", nullable: true),
                    MATRICULE = table.Column<string>(type: "text", nullable: false),
                    PASSWORD = table.Column<string>(type: "text", nullable: true),
                    PHOTO = table.Column<string>(type: "text", nullable: true),
                    IS_LOCK = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    LOCK_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UNLOCK_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LAST_CONNEXION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LAST_DECONNEXION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    BIRTH_PLACE_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_BirthPlaces_BIRTH_PLACE_ID",
                        column: x => x.BIRTH_PLACE_ID,
                        principalTable: "BirthPlaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "text", nullable: false),
                    SURNAME = table.Column<string>(type: "text", nullable: false),
                    SEXE = table.Column<string>(type: "text", nullable: false),
                    QUARTER = table.Column<string>(type: "text", nullable: false),
                    TELEPHONE_1 = table.Column<string>(type: "text", nullable: false),
                    TELEPHONE_2 = table.Column<string>(type: "text", nullable: true),
                    EMAIL = table.Column<string>(type: "text", nullable: true),
                    MATRICULE = table.Column<string>(type: "text", nullable: false),
                    PASSWORD = table.Column<string>(type: "text", nullable: false),
                    PHOTO = table.Column<string>(type: "text", nullable: true),
                    IS_LOCK = table.Column<bool>(type: "boolean", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IS_PRINCIPAL_TEACHER = table.Column<bool>(type: "boolean", nullable: false),
                    USER_POSITION_IDS = table.Column<int[]>(type: "integer[]", nullable: false),
                    SCHOOL_EDUCATION_IDS = table.Column<int[]>(type: "integer[]", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    LOCK_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UNLOCK_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LAST_CONNEXION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LAST_DECONNEXION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    PROFESSIONAL_QUALIFICATION_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_ProfessionalQualifications_PROFESSIONAL_QUALIFICATION~",
                        column: x => x.PROFESSIONAL_QUALIFICATION_ID,
                        principalTable: "ProfessionalQualifications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    ABREVIATION = table.Column<string>(type: "text", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    SCHOOL_EDUCATION_ID = table.Column<int>(type: "integer", nullable: false),
                    HIGH_SCHOOL_OPTION_ID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EducationLevels_HighSchoolOptions_HIGH_SCHOOL_OPTION_ID",
                        column: x => x.HIGH_SCHOOL_OPTION_ID,
                        principalTable: "HighSchoolOptions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EducationLevels_SchoolEducations_SCHOOL_EDUCATION_ID",
                        column: x => x.SCHOOL_EDUCATION_ID,
                        principalTable: "SchoolEducations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusPayments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    INFOS = table.Column<string>(type: "text", nullable: true),
                    INVOICE_NUMBER = table.Column<string>(type: "text", nullable: false),
                    AMOUNT = table.Column<int>(type: "integer", nullable: false),
                    IS_FESS_1 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_FESS_2 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_FESS_3 = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    PAYMENT_METHOD_ID = table.Column<int>(type: "integer", nullable: false),
                    BANK_ID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusPayments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusPayments_Banks_BANK_ID",
                        column: x => x.BANK_ID,
                        principalTable: "Banks",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BusPayments_PaymentMethods_PAYMENT_METHOD_ID",
                        column: x => x.PAYMENT_METHOD_ID,
                        principalTable: "PaymentMethods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusPayments_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusPayments_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolPayments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    INFOS = table.Column<string>(type: "text", nullable: true),
                    INVOICE_NUMBER = table.Column<string>(type: "text", nullable: false),
                    AMOUNT = table.Column<int>(type: "integer", nullable: false),
                    IS_REGISTRATION = table.Column<bool>(type: "boolean", nullable: false),
                    IS_FESS_1 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_FESS_2 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_FESS_3 = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    PAYMENT_METHOD_ID = table.Column<int>(type: "integer", nullable: false),
                    BANK_ID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolPayments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SchoolPayments_Banks_BANK_ID",
                        column: x => x.BANK_ID,
                        principalTable: "Banks",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SchoolPayments_PaymentMethods_PAYMENT_METHOD_ID",
                        column: x => x.PAYMENT_METHOD_ID,
                        principalTable: "PaymentMethods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolPayments_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolPayments_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentParents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    PARENT_ID = table.Column<int>(type: "integer", nullable: false),
                    PARENT_TYPE_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentParents_ParentTypes_PARENT_TYPE_ID",
                        column: x => x.PARENT_TYPE_ID,
                        principalTable: "ParentTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParents_Parents_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalTable: "Parents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParents_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherPrimes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    AMOUNT = table.Column<int>(type: "integer", nullable: false),
                    IS_PAYED = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    MONTH_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherPrimes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OtherPrimes_Months_MONTH_ID",
                        column: x => x.MONTH_ID,
                        principalTable: "Months",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherPrimes_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherPrimes_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryAdvances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    INFOS = table.Column<string>(type: "text", nullable: true),
                    AMOUNT = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    MONTH_ID = table.Column<int>(type: "integer", nullable: false),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    TYPE_SALARY_ADVANCE_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAdvances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_Months_MONTH_ID",
                        column: x => x.MONTH_ID,
                        principalTable: "Months",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_TypeSalaryAdvances_TYPE_SALARY_ADVANCE_ID",
                        column: x => x.TYPE_SALARY_ADVANCE_ID,
                        principalTable: "TypeSalaryAdvances",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryAdvances_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SumSalaryAdvances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SUM = table.Column<float>(type: "real", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    TYPE_SALARY_ADVANCE_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SumSalaryAdvances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SumSalaryAdvances_TypeSalaryAdvances_TYPE_SALARY_ADVANCE_ID",
                        column: x => x.TYPE_SALARY_ADVANCE_ID,
                        principalTable: "TypeSalaryAdvances",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SumSalaryAdvances_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPrimes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IS_PAYED = table.Column<bool>(type: "boolean", nullable: false),
                    PRINCIPAL_TEACHER_PRIME = table.Column<int>(type: "integer", nullable: false),
                    INCENTIVE_PRIME = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    MONTH_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrimes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPrimes_Months_MONTH_ID",
                        column: x => x.MONTH_ID,
                        principalTable: "Months",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrimes_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrimes_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusFess",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PRICE_FESS_1 = table.Column<int>(type: "integer", nullable: false),
                    PRICE_FESS_2 = table.Column<int>(type: "integer", nullable: false),
                    PRICE_FESS_3 = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    DEADLINE_FESS_1 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DEADLINE_FESS_2 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DEADLINE_FESS_3 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusFess", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusFess_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusFess_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    COEFFICIENT = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cours_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cours_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HightSchoolAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HOURS_SALARY = table.Column<int>(type: "integer", nullable: false),
                    COURS_IDS = table.Column<int[]>(type: "integer[]", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false),
                    SUBDIVISION_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HightSchoolAssignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HightSchoolAssignments_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HightSchoolAssignments_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HightSchoolAssignments_Subdivisions_SUBDIVISION_ID",
                        column: x => x.SUBDIVISION_ID,
                        principalTable: "Subdivisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HightSchoolAssignments_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KindergartenSchoolAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HOURS_SALARY = table.Column<int>(type: "integer", nullable: false),
                    COURS_IDS = table.Column<int[]>(type: "integer[]", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false),
                    SUBDIVISION_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindergartenSchoolAssignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KindergartenSchoolAssignments_EducationLevels_EDUCATION_LEV~",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KindergartenSchoolAssignments_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KindergartenSchoolAssignments_Subdivisions_SUBDIVISION_ID",
                        column: x => x.SUBDIVISION_ID,
                        principalTable: "Subdivisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KindergartenSchoolAssignments_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MiddleSchoolAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HOURS_SALARY = table.Column<int>(type: "integer", nullable: false),
                    COURS_IDS = table.Column<int[]>(type: "integer[]", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false),
                    SUBDIVISION_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddleSchoolAssignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MiddleSchoolAssignments_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiddleSchoolAssignments_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiddleSchoolAssignments_Subdivisions_SUBDIVISION_ID",
                        column: x => x.SUBDIVISION_ID,
                        principalTable: "Subdivisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiddleSchoolAssignments_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteMonths",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IS_COMPOSITION_MONTH = table.Column<bool>(type: "boolean", nullable: false),
                    IS_TRIMESTER_1 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_TRIMESTER_2 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_TRIMESTER_3 = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    MONTH_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteMonths", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoteMonths_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteMonths_Months_MONTH_ID",
                        column: x => x.MONTH_ID,
                        principalTable: "Months",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteMonths_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrimarySchoolAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HOURS_SALARY = table.Column<int>(type: "integer", nullable: false),
                    COURS_IDS = table.Column<int[]>(type: "integer[]", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false),
                    SUBDIVISION_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimarySchoolAssignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrimarySchoolAssignments_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrimarySchoolAssignments_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrimarySchoolAssignments_Subdivisions_SUBDIVISION_ID",
                        column: x => x.SUBDIVISION_ID,
                        principalTable: "Subdivisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrimarySchoolAssignments_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolFess",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    REGISTRATION_FESS = table.Column<int>(type: "integer", nullable: false),
                    PRICE_FESS_1 = table.Column<int>(type: "integer", nullable: false),
                    PRICE_FESS_2 = table.Column<int>(type: "integer", nullable: false),
                    PRICE_FESS_3 = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    DEADLINE_FESS_1 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DEADLINE_FESS_2 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DEADLINE_FESS_3 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolFess", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SchoolFess_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolFess_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentRegistrations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FOLDER_INFORMATION = table.Column<string>(type: "text", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IS_SUPPORTED = table.Column<bool>(type: "boolean", nullable: false),
                    IS_DISCOUNTED = table.Column<bool>(type: "boolean", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    IS_ABANDON = table.Column<bool>(type: "boolean", nullable: false),
                    REGISTRATION_FESS = table.Column<int>(type: "integer", nullable: false),
                    PRICE_FESS_1 = table.Column<int>(type: "integer", nullable: false),
                    PRICE_FESS_2 = table.Column<int>(type: "integer", nullable: false),
                    PRICE_FESS_3 = table.Column<int>(type: "integer", nullable: false),
                    AVERAGE_QUARTER_1 = table.Column<float>(type: "real", nullable: false),
                    AVERAGE_QUARTER_2 = table.Column<float>(type: "real", nullable: false),
                    AVERAGE_QUARTER_3 = table.Column<float>(type: "real", nullable: false),
                    ANNUAL_AVERAGE = table.Column<float>(type: "real", nullable: false),
                    IS_SUBSCRIBE_TO_THE_BUS_FESS_1 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_SUBSCRIBE_TO_THE_BUS_FESS_2 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_SUBSCRIBE_TO_THE_BUS_FESS_3 = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false),
                    SUBDIVISION_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegistrations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentRegistrations_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrations_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrations_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrations_Subdivisions_SUBDIVISION_ID",
                        column: x => x.SUBDIVISION_ID,
                        principalTable: "Subdivisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubdivisionByYears",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    SUBDIVISION_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubdivisionByYears", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubdivisionByYears_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubdivisionByYears_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubdivisionByYears_Subdivisions_SUBDIVISION_ID",
                        column: x => x.SUBDIVISION_ID,
                        principalTable: "Subdivisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    INFOS = table.Column<string>(type: "text", nullable: true),
                    IS_PAYED = table.Column<bool>(type: "boolean", nullable: false),
                    HOURS_SALARY = table.Column<int>(type: "integer", nullable: false),
                    COURS_TITLE = table.Column<string>(type: "text", nullable: false),
                    NUMBER_HOURS_WORKED = table.Column<int>(type: "integer", nullable: false),
                    TOTAL_HOURS = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    USER_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    MONTH_ID = table.Column<int>(type: "integer", nullable: false),
                    EDUCATION_LEVEL_ID = table.Column<int>(type: "integer", nullable: false),
                    SUBDIVISION_ID = table.Column<int>(type: "integer", nullable: false),
                    COURS_ID = table.Column<int>(type: "integer", nullable: true),
                    TYPE_ADVANCE_SALARY_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SalaryStatus_Cours_COURS_ID",
                        column: x => x.COURS_ID,
                        principalTable: "Cours",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SalaryStatus_EducationLevels_EDUCATION_LEVEL_ID",
                        column: x => x.EDUCATION_LEVEL_ID,
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryStatus_Months_MONTH_ID",
                        column: x => x.MONTH_ID,
                        principalTable: "Months",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryStatus_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryStatus_Subdivisions_SUBDIVISION_ID",
                        column: x => x.SUBDIVISION_ID,
                        principalTable: "Subdivisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryStatus_TypeSalaryAdvances_TYPE_ADVANCE_SALARY_ID",
                        column: x => x.TYPE_ADVANCE_SALARY_ID,
                        principalTable: "TypeSalaryAdvances",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryStatus_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteHightSchools",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOTE = table.Column<float>(type: "real", nullable: false),
                    INFOS = table.Column<string>(type: "text", nullable: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    NOTE_MONTH_ID = table.Column<int>(type: "integer", nullable: false),
                    COURS_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteHightSchools", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoteHightSchools_Cours_COURS_ID",
                        column: x => x.COURS_ID,
                        principalTable: "Cours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteHightSchools_NoteMonths_NOTE_MONTH_ID",
                        column: x => x.NOTE_MONTH_ID,
                        principalTable: "NoteMonths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteHightSchools_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteMiddleSchools",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOTE = table.Column<float>(type: "real", nullable: false),
                    INFOS = table.Column<string>(type: "text", nullable: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    NOTE_MONTH_ID = table.Column<int>(type: "integer", nullable: false),
                    COURS_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteMiddleSchools", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoteMiddleSchools_Cours_COURS_ID",
                        column: x => x.COURS_ID,
                        principalTable: "Cours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteMiddleSchools_NoteMonths_NOTE_MONTH_ID",
                        column: x => x.NOTE_MONTH_ID,
                        principalTable: "NoteMonths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteMiddleSchools_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotePrimarys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOTE = table.Column<float>(type: "real", nullable: false),
                    INFOS = table.Column<string>(type: "text", nullable: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    NOTE_MONTH_ID = table.Column<int>(type: "integer", nullable: false),
                    COURS_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotePrimarys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NotePrimarys_Cours_COURS_ID",
                        column: x => x.COURS_ID,
                        principalTable: "Cours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotePrimarys_NoteMonths_NOTE_MONTH_ID",
                        column: x => x.NOTE_MONTH_ID,
                        principalTable: "NoteMonths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotePrimarys_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusFess_EDUCATION_LEVEL_ID",
                table: "BusFess",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BusFess_SCHOOL_YEAR_ID",
                table: "BusFess",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BusPayments_BANK_ID",
                table: "BusPayments",
                column: "BANK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BusPayments_PAYMENT_METHOD_ID",
                table: "BusPayments",
                column: "PAYMENT_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BusPayments_SCHOOL_YEAR_ID",
                table: "BusPayments",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BusPayments_STUDENT_ID",
                table: "BusPayments",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EDUCATION_LEVEL_ID",
                table: "Cours",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_SCHOOL_YEAR_ID",
                table: "Cours",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevels_HIGH_SCHOOL_OPTION_ID",
                table: "EducationLevels",
                column: "HIGH_SCHOOL_OPTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevels_SCHOOL_EDUCATION_ID",
                table: "EducationLevels",
                column: "SCHOOL_EDUCATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HightSchoolAssignments_EDUCATION_LEVEL_ID",
                table: "HightSchoolAssignments",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HightSchoolAssignments_SCHOOL_YEAR_ID",
                table: "HightSchoolAssignments",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HightSchoolAssignments_SUBDIVISION_ID",
                table: "HightSchoolAssignments",
                column: "SUBDIVISION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HightSchoolAssignments_USER_ID",
                table: "HightSchoolAssignments",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KindergartenSchoolAssignments_EDUCATION_LEVEL_ID",
                table: "KindergartenSchoolAssignments",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KindergartenSchoolAssignments_SCHOOL_YEAR_ID",
                table: "KindergartenSchoolAssignments",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KindergartenSchoolAssignments_SUBDIVISION_ID",
                table: "KindergartenSchoolAssignments",
                column: "SUBDIVISION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KindergartenSchoolAssignments_USER_ID",
                table: "KindergartenSchoolAssignments",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleSchoolAssignments_EDUCATION_LEVEL_ID",
                table: "MiddleSchoolAssignments",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleSchoolAssignments_SCHOOL_YEAR_ID",
                table: "MiddleSchoolAssignments",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleSchoolAssignments_SUBDIVISION_ID",
                table: "MiddleSchoolAssignments",
                column: "SUBDIVISION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleSchoolAssignments_USER_ID",
                table: "MiddleSchoolAssignments",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteHightSchools_COURS_ID",
                table: "NoteHightSchools",
                column: "COURS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteHightSchools_NOTE_MONTH_ID",
                table: "NoteHightSchools",
                column: "NOTE_MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteHightSchools_STUDENT_ID",
                table: "NoteHightSchools",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteMiddleSchools_COURS_ID",
                table: "NoteMiddleSchools",
                column: "COURS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteMiddleSchools_NOTE_MONTH_ID",
                table: "NoteMiddleSchools",
                column: "NOTE_MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteMiddleSchools_STUDENT_ID",
                table: "NoteMiddleSchools",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteMonths_EDUCATION_LEVEL_ID",
                table: "NoteMonths",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteMonths_MONTH_ID",
                table: "NoteMonths",
                column: "MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteMonths_SCHOOL_YEAR_ID",
                table: "NoteMonths",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NotePrimarys_COURS_ID",
                table: "NotePrimarys",
                column: "COURS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NotePrimarys_NOTE_MONTH_ID",
                table: "NotePrimarys",
                column: "NOTE_MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NotePrimarys_STUDENT_ID",
                table: "NotePrimarys",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPrimes_MONTH_ID",
                table: "OtherPrimes",
                column: "MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPrimes_SCHOOL_YEAR_ID",
                table: "OtherPrimes",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPrimes_USER_ID",
                table: "OtherPrimes",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PrimarySchoolAssignments_EDUCATION_LEVEL_ID",
                table: "PrimarySchoolAssignments",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PrimarySchoolAssignments_SCHOOL_YEAR_ID",
                table: "PrimarySchoolAssignments",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PrimarySchoolAssignments_SUBDIVISION_ID",
                table: "PrimarySchoolAssignments",
                column: "SUBDIVISION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PrimarySchoolAssignments_USER_ID",
                table: "PrimarySchoolAssignments",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_MONTH_ID",
                table: "SalaryAdvances",
                column: "MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_SCHOOL_YEAR_ID",
                table: "SalaryAdvances",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_TYPE_SALARY_ADVANCE_ID",
                table: "SalaryAdvances",
                column: "TYPE_SALARY_ADVANCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAdvances_USER_ID",
                table: "SalaryAdvances",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStatus_COURS_ID",
                table: "SalaryStatus",
                column: "COURS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStatus_EDUCATION_LEVEL_ID",
                table: "SalaryStatus",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStatus_MONTH_ID",
                table: "SalaryStatus",
                column: "MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStatus_SCHOOL_YEAR_ID",
                table: "SalaryStatus",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStatus_SUBDIVISION_ID",
                table: "SalaryStatus",
                column: "SUBDIVISION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStatus_TYPE_ADVANCE_SALARY_ID",
                table: "SalaryStatus",
                column: "TYPE_ADVANCE_SALARY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStatus_USER_ID",
                table: "SalaryStatus",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFess_EDUCATION_LEVEL_ID",
                table: "SchoolFess",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFess_SCHOOL_YEAR_ID",
                table: "SchoolFess",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPayments_BANK_ID",
                table: "SchoolPayments",
                column: "BANK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPayments_PAYMENT_METHOD_ID",
                table: "SchoolPayments",
                column: "PAYMENT_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPayments_SCHOOL_YEAR_ID",
                table: "SchoolPayments",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPayments_STUDENT_ID",
                table: "SchoolPayments",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_PARENT_ID",
                table: "StudentParents",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_PARENT_TYPE_ID",
                table: "StudentParents",
                column: "PARENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_STUDENT_ID",
                table: "StudentParents",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_EDUCATION_LEVEL_ID",
                table: "StudentRegistrations",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_SCHOOL_YEAR_ID",
                table: "StudentRegistrations",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_STUDENT_ID",
                table: "StudentRegistrations",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_SUBDIVISION_ID",
                table: "StudentRegistrations",
                column: "SUBDIVISION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BIRTH_PLACE_ID",
                table: "Students",
                column: "BIRTH_PLACE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubdivisionByYears_EDUCATION_LEVEL_ID",
                table: "SubdivisionByYears",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubdivisionByYears_SCHOOL_YEAR_ID",
                table: "SubdivisionByYears",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubdivisionByYears_SUBDIVISION_ID",
                table: "SubdivisionByYears",
                column: "SUBDIVISION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SumSalaryAdvances_TYPE_SALARY_ADVANCE_ID",
                table: "SumSalaryAdvances",
                column: "TYPE_SALARY_ADVANCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SumSalaryAdvances_USER_ID",
                table: "SumSalaryAdvances",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimes_MONTH_ID",
                table: "UserPrimes",
                column: "MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimes_SCHOOL_YEAR_ID",
                table: "UserPrimes",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimes_USER_ID",
                table: "UserPrimes",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PROFESSIONAL_QUALIFICATION_ID",
                table: "Users",
                column: "PROFESSIONAL_QUALIFICATION_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusFess");

            migrationBuilder.DropTable(
                name: "BusPayments");

            migrationBuilder.DropTable(
                name: "GasStations");

            migrationBuilder.DropTable(
                name: "HightSchoolAssignments");

            migrationBuilder.DropTable(
                name: "KindergartenSchoolAssignments");

            migrationBuilder.DropTable(
                name: "MiddleSchoolAssignments");

            migrationBuilder.DropTable(
                name: "NoteHightSchools");

            migrationBuilder.DropTable(
                name: "NoteMiddleSchools");

            migrationBuilder.DropTable(
                name: "NotePrimarys");

            migrationBuilder.DropTable(
                name: "OtherPrimes");

            migrationBuilder.DropTable(
                name: "PrimarySchoolAssignments");

            migrationBuilder.DropTable(
                name: "SalaryAdvances");

            migrationBuilder.DropTable(
                name: "SalaryStatus");

            migrationBuilder.DropTable(
                name: "SchoolBuses");

            migrationBuilder.DropTable(
                name: "SchoolFess");

            migrationBuilder.DropTable(
                name: "SchoolPayments");

            migrationBuilder.DropTable(
                name: "StudentParents");

            migrationBuilder.DropTable(
                name: "StudentRegistrations");

            migrationBuilder.DropTable(
                name: "SubdivisionByYears");

            migrationBuilder.DropTable(
                name: "SumSalaryAdvances");

            migrationBuilder.DropTable(
                name: "TransportLoadTypes");

            migrationBuilder.DropTable(
                name: "UserPositions");

            migrationBuilder.DropTable(
                name: "UserPrimes");

            migrationBuilder.DropTable(
                name: "NoteMonths");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ParentTypes");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subdivisions");

            migrationBuilder.DropTable(
                name: "TypeSalaryAdvances");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "SchoolYears");

            migrationBuilder.DropTable(
                name: "BirthPlaces");

            migrationBuilder.DropTable(
                name: "ProfessionalQualifications");

            migrationBuilder.DropTable(
                name: "HighSchoolOptions");

            migrationBuilder.DropTable(
                name: "SchoolEducations");
        }
    }
}
