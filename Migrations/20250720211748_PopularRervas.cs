using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularRervas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Reservas (ReservaId, Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId, LaboratorioId1, ProfessorId1, TurmaId1) VALUES (1, '2025-07-22 08:00:00', '08:00:00', 90, 1, 1, 1, NULL, NULL, NULL)");
            mb.Sql("INSERT INTO Reservas (ReservaId, Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId, LaboratorioId1, ProfessorId1, TurmaId1) VALUES (2, '2025-07-22 10:00:00', '10:00:00', 60, 2, 2, 2, NULL, NULL, NULL)");
            mb.Sql("INSERT INTO Reservas (ReservaId, Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId, LaboratorioId1, ProfessorId1, TurmaId1) VALUES (3, '2025-07-23 09:30:00', '09:30:00', 75, 3, 3, 3, NULL, NULL, NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Reservas WHERE ReservaId IN (1, 2, 3)");


        }
    }
}
