using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularTurmas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Turmas (TurmaId, Nome, QuantidadeAlunos) VALUES (1, '1º Ano A', 25)");
            mb.Sql("INSERT INTO Turmas (TurmaId, Nome, QuantidadeAlunos) VALUES (2, '2º Ano B', 28)");
            mb.Sql("INSERT INTO Turmas (TurmaId, Nome, QuantidadeAlunos) VALUES (3, '3º Ano C', 30)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Turmas WHERE TurmaId IN (1, 2, 3)");

        }
    }
}
