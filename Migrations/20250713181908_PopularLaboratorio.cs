using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularLaboratorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Laboratorios (LaboratorioId, Nome, Capacidade) VALUES (1, 'Lab01', 20)");
            mb.Sql("INSERT INTO Laboratorios (LaboratorioId, Nome, Capacidade) VALUES (2, 'Lab02', 20)");
            mb.Sql("INSERT INTO Laboratorios (LaboratorioId, Nome, Capacidade) VALUES (3, 'Lab03', 20)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Laboratorios WHERE LaboratorioId IN (1, 2, 3)");
        }
    }
}
