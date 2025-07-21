using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularLaboratorios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Laboratorios (LaboratorioId, Nome, Capacidade, TurmaId) VALUES (1, 'Lab Química', 20, NULL)");
            mb.Sql("INSERT INTO Laboratorios (LaboratorioId, Nome, Capacidade, TurmaId) VALUES (2, 'Lab Física', 25, NULL)");
            mb.Sql("INSERT INTO Laboratorios (LaboratorioId, Nome, Capacidade, TurmaId) VALUES (3, 'Lab Biologia', 22, NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Laboratorios WHERE LaboratorioId IN (1, 2, 3)");

        }
    }
}
