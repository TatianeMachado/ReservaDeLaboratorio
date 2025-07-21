using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularLaboratorioProfessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO LaboratorioProfessor (LaboratoriosLaboratorioId, ProfessoresProfessorId) VALUES (1, 1)");
            mb.Sql("INSERT INTO LaboratorioProfessor (LaboratoriosLaboratorioId, ProfessoresProfessorId) VALUES (2, 2)");
            mb.Sql("INSERT INTO LaboratorioProfessor (LaboratoriosLaboratorioId, ProfessoresProfessorId) VALUES (3, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM LaboratorioProfessor WHERE LaboratoriosLaboratorioId IN (1, 2, 3)");
        }
    }
}
