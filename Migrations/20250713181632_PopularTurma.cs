using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Turmas (TurmaId, Nome, QuantidadeAlunos, ProfessorId) VALUES (1, '1A Informática', 18, 1)");
            mb.Sql("INSERT INTO Turmas (TurmaId, Nome, QuantidadeAlunos, ProfessorId) VALUES (2, '2B Redes', 15, 2)");
            mb.Sql("INSERT INTO Turmas (TurmaId, Nome, QuantidadeAlunos, ProfessorId) VALUES (3, '3C Programação', 20, 3)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Turmas WHERE TurmaId IN (1, 2, 3)");
        }
    }
}
