using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PersonalManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentCode = table.Column<string>(type: "text", nullable: true),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
                    ParentDepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentDepartmentId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentDepartmentId",
                        column: x => x.ParentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentDepartmentId1",
                        column: x => x.ParentDepartmentId1,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobCode = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "text", nullable: false),
                    DepartementId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Departments_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Matricule = table.Column<string>(type: "text", nullable: false),
                    Identity_Avatar_Name = table.Column<string>(type: "text", nullable: true),
                    Identity_Avatar_Extensions = table.Column<string>(type: "text", nullable: true),
                    Identity_Avatar_ContentType = table.Column<string>(type: "text", nullable: true),
                    Identity_Avatar_Size = table.Column<int>(type: "integer", nullable: true),
                    Identity_Avatar_Url = table.Column<string>(type: "text", nullable: true),
                    Identity_LastName = table.Column<string>(type: "text", nullable: true),
                    Identity_FirstName = table.Column<string>(type: "text", nullable: true),
                    Identity_BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Identity_Gender = table.Column<int>(type: "integer", nullable: true),
                    Identity_BirthPlace = table.Column<string>(type: "text", nullable: true),
                    Identity_CIN = table.Column<string>(type: "text", nullable: true),
                    Identity_Nationality = table.Column<string>(type: "text", nullable: true),
                    CivilStatus_MaritalStatus = table.Column<int>(type: "integer", nullable: true),
                    CivilStatus_Spouse_Avatar_Name = table.Column<string>(type: "text", nullable: true),
                    CivilStatus_Spouse_Avatar_Extensions = table.Column<string>(type: "text", nullable: true),
                    CivilStatus_Spouse_Avatar_ContentType = table.Column<string>(type: "text", nullable: true),
                    CivilStatus_Spouse_Avatar_Size = table.Column<int>(type: "integer", nullable: true),
                    CivilStatus_Spouse_Avatar_Url = table.Column<string>(type: "text", nullable: true),
                    CivilStatus_Spouse_LastName = table.Column<string>(type: "text", nullable: true),
                    CivilStatus_Spouse_FirstName = table.Column<string>(type: "text", nullable: true),
                    CivilStatus_Spouse_BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CivilStatus_Spouse_Gender = table.Column<int>(type: "integer", nullable: true),
                    CivilStatus_Spouse_BirthPlace = table.Column<string>(type: "text", nullable: true),
                    CivilStatus_Spouse_CIN = table.Column<string>(type: "text", nullable: true),
                    CivilStatus_Spouse_Nationality = table.Column<string>(type: "text", nullable: true),
                    Adress_City = table.Column<string>(type: "text", nullable: true),
                    Adress_Area = table.Column<string>(type: "text", nullable: true),
                    Adress_Street = table.Column<string>(type: "text", nullable: true),
                    Adress_PostalCode = table.Column<string>(type: "text", nullable: true),
                    Adress_District = table.Column<string>(type: "text", nullable: true),
                    Adress_Region = table.Column<string>(type: "text", nullable: true),
                    Adress_Country = table.Column<string>(type: "text", nullable: true),
                    Contact_PhoneNumber = table.Column<string[]>(type: "text[]", nullable: true),
                    Contact_Email = table.Column<string[]>(type: "text[]", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    Civility = table.Column<int>(type: "integer", nullable: true),
                    JobId = table.Column<Guid>(type: "uuid", nullable: true),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rib = table.Column<string>(type: "text", nullable: false),
                    Iban = table.Column<string>(type: "text", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    Bic = table.Column<string>(type: "text", nullable: true),
                    AccountLabel = table.Column<string>(type: "text", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Banks_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identity_Avatar_Name = table.Column<string>(type: "text", nullable: true),
                    Identity_Avatar_Extensions = table.Column<string>(type: "text", nullable: true),
                    Identity_Avatar_ContentType = table.Column<string>(type: "text", nullable: true),
                    Identity_Avatar_Size = table.Column<int>(type: "integer", nullable: true),
                    Identity_Avatar_Url = table.Column<string>(type: "text", nullable: true),
                    Identity_LastName = table.Column<string>(type: "text", nullable: true),
                    Identity_FirstName = table.Column<string>(type: "text", nullable: true),
                    Identity_BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Identity_Gender = table.Column<int>(type: "integer", nullable: true),
                    Identity_BirthPlace = table.Column<string>(type: "text", nullable: true),
                    Identity_CIN = table.Column<string>(type: "text", nullable: true),
                    Identity_Nationality = table.Column<string>(type: "text", nullable: true),
                    IsDependent = table.Column<bool>(type: "boolean", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Children_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContratReference = table.Column<string>(type: "text", nullable: true),
                    TypeContrat = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    SalaryMensual = table.Column<float>(type: "real", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Graduation = table.Column<string>(type: "text", nullable: false),
                    FieldOfStudy = table.Column<string>(type: "text", nullable: false),
                    GraduationYear = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Establishment = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdChild = table.Column<Guid>(type: "uuid", nullable: true),
                    ChildId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Children_ChildId1",
                        column: x => x.ChildId1,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Children_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banks_EmployeeId",
                table: "Banks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_EmployeeId1",
                table: "Banks",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Children_EmployeeId",
                table: "Children",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId1",
                table: "Contracts",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentId1",
                table: "Departments",
                column: "ParentDepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ChildId1",
                table: "Educations",
                column: "ChildId1");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EmployeeId",
                table: "Educations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EmployeeId1",
                table: "Educations",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobId",
                table: "Employees",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_DepartementId",
                table: "Jobs",
                column: "DepartementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
